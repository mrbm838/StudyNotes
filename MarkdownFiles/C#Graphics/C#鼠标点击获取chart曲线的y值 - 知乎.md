---
created: 2023-01-07T13:46:14 (UTC +08:00)
tags: [C#]
source: https://zhuanlan.zhihu.com/p/336902215
author: 
---

# C# 鼠标点击获取chart曲线的y值 - 知乎

> ## Excerpt
> C#在绘制chart图标曲线时，需要能够获取点击处曲线的数值。 首先采取了第一个方法，利用ToolTipEventArgs事件去触发碰到曲线的点（不知道我这么理解对不对），再将ToolTipEventArgs的Text属性赋值即可实现，优点是…

---
C#在绘制chart图标曲线时，需要能够获取点击处曲线的数值。

首先采取了第一个方法，利用ToolTipEventArgs事件去触发碰到曲线的点（不知道我这么理解对不对），再将ToolTipEventArgs的Text属性赋值即可实现，优点是非常简单，无需其他步骤，但其因为用到HitTest方法，只能获取序列点上的坐标值，不能获得“空白”位置的值。而且鼠标只要碰到曲线就会更新数值，最终放弃了。写法如下：

```
   private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                this.Cursor = Cursors.Cross;
                int pointIndex = e.HitTestResult.PointIndex;

                DataPoint dp1 = chart1.Series[0].Points[pointIndex];
                DataPoint dp2 = chart1.Series[1].Points[pointIndex];


                string YValue1 = dp1.YValues[0].ToString("0.0");
                string YValue2 = dp2.YValues[0].ToString("0.0");
            }
            else
            {
                this.Cursor = Cursors.Default;
            }       

        }
```

之后就想方法用鼠标点击去触发，利用Chart的MouseClick事件和Chart方法 HitTest，特点是可以获取鼠标值，同样因为用到HitTest方法，只能获取序列上序列点处的坐标值，且需要自我实现值的显示，这个倒是不麻烦，但是要是点不中曲线上的点就不能触发，这就是最大的问题！总之代码也贴一下：

```
 private void chart1_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {           
                HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);

                if (hit.Series != null)
                {
                    int pointIndex = hit.PointIndex;
                    DataPoint dp;
                    //点中就把y值显示出来
                    dp = chart1.Series[0].Points[pointIndex];
                    dataGridView1.Rows[0].Cells["value"].Value = dp.YValues[0].ToString("0.0");
                }
                else 
                {
                    int pointIndex = hit.PointIndex;
                    DataPoint dp;
                    //点不中的话就清零喽
                    dp = chart1.Series[0].Points[pointIndex];
                    dataGridView1.Rows[0].Cells["value"].Value = "0.0";
                }
            }
        } 
```

而我的想法是能不能鼠标随便点到哪里都可以找到这个横坐标对应的y值，这样的话就很方便，不然曲线那么细点不中才是最麻烦的。

然鹅，出现了一个问题：鼠标坐标和曲线坐标完全不是一个东西，不能通过鼠标坐标去直接拿到这个横坐标的曲线！！！

那么就需要有这么一个思路：首先捕获鼠标点击的x坐标值->然后进行坐标变换->计算出对应的曲线x坐标。ok那么代码就实现了，只需要进行一次坐标变换：

```
HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);

var area = chart1.ChartAreas[0];
int xValue = (int)area.AxisX.PixelPositionToValue(e.X);
int yValue = (int)area.AxisY.PixelPositionToValue(e.Y);
```

![](https://pic4.zhimg.com/v2-38eb8510a4a229b980a02a075b778e73_b.jpg)

实现效果
