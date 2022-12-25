# VisionPro

### 一、Attention

##### 1.PMAlign模板工具

使用模板工具时，为了==提高分数==，可将计分时考虑砸斑勾选去掉，或者掩膜掉可能出现较大偏差的区域。

区域缩放：指定 PMAlign 执行样板搜索时在X 、Y方向上使用的缩放值。
				  当在一个零件上匹配到多个模板或识别框位置大小偏差较大时，可尝试减少或关闭区域缩放。

接收阈值：当零件倾斜等原因使得分数较低时，可降低接收阈值。

建模器：训练模式-带图像的形状模型，区域模式-像素配对限定框

##### 2.高级C#脚本：

在Private Member Variables内声明全局图形变量；
在GroupRun方法内编写逻辑语句；
在ModifyLastRunRecord方法内添加输出到图形。

在QuickBuild应用程序中,有三种类型的脚本:

- ToolGroup 脚本: 在 ToolGroup 中添加脚本，可以控制 ToolGroup的运行行为（三处可编写代码）
- Job 脚本: 作业脚本可以对取像过程进行控制，设置取像参数，控制取像行为，例:设置曝光、频闪、自动对焦等（两处可编写代码）
- ToolBlock 脚本: ToolBlöck 脚本使你可以定制或扩展视觉工具的功能，或者对工具的运行结果进行逻辑判断（高级脚本有三处可编写代码，简单脚本有两处）

##### 3.斑点工具

硬阈值(固定)：定义员工像素值为图像分割点，大于此像素值的为物体像素，小于的则为背景像素；对于处在阈值的像素点则很难判断，容易产生空间量化错误。
硬阈值(相对)：以灰度直方图中某个百分比处的像素为图像分割的阈值。
硬阈值(动态)：根据输入图像直方图自动计算员工合适的分割阈值。

1. 提高斑点的识别度可将分段模式设置为硬阈值(固定)，并降低阈值，减少筛选
2. 清除小面积斑点干扰，除了过滤面积，还可增大连通性的最小面积

##### 4.ToolBlock和ToolGroup对比

①都作为工具的容器，都可以进行嵌套，都支持脚本，封装某个功能。

②脚本的输入输出

ToolBlock简单脚本：

 当输入值改变时，需要点击检查界面终端刷新。

```C#
Outputs.Output = Inputs.Input1 + Inputs.Input2;
```

ToolGroup脚本：

在已经生成过的脚本中，改变在初始化方法中定义的变量，需要删除脚本，生成后再添加变量到初始化方法中。

输入输出需要通过脚本实现

定义终端变量，`true`输入，`false`输出：`DefineScriptTerminal`
设置终端的值：`SetScriptTerminalData`
获取终端的值：`GetscriptTerminalData`

```C#
// Define output and input
public override void Initialize(CogToolGroup host)
{
    int Output;
    this.toolGroup.DefineScriptTerminal(Output, "Output", false);
    this.toolGroup.DefineScriptTerminal(10, "Input", true);
    toolGroup.DefineScriptTerminal("System.Double", 0, "InputDouble", true);
}
// Operate output and input
public override bool GroupRun(ref stringmessage, ref CogToolResultConstants result)
{
    int temp = (int32)this.toolGroup.GetScriptTerminalData("Input");
    this.toolGroup.SetScriptTermianlData("Output", temp);
}
```

③数据链接方式

ToolBlock提供直观的链接方式。

ToolGroup先通过脚本定义输入输出后才能链接，需要在脚本初始化时定义要链接的变量类型才能链接上。

④获取工具的方法

 ToolBlock
简单脚本：Tools.工具名称

```C#
CogBlobTool blob = (CogBlobTool)Tools.MyBlobTool;
Output.degree = CogMisc.RadToDeg(Tools.CogAngleLineLineTool1.Angle);
```

高级脚本：mToolBlock.Tools[工具名称/索引编号/GUID]（GUID唯一标识）

```C#
CogBlobTool blob = (CogBlobTool)mToolBlock.Tools["myBlobTool"];
				 (CogBlobTool)mToolBlock.Tools[0];
```

ToolGroup（需要引用对应工具的程序集）

toolGroup.Tools[工具名称/索引编号]

```C#
CogBlobTool blob = (CogBlobTool)toolGroup.Tools["myBlobTool"];
				  (CogBlobTool)toolGroup.Tools[0];
```

⑤ToolBlock添加记录

当ToolBlock有图像输入时，可通过CogRecord加入到记录并本地显示。

![图像本地显示](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_1-4-1.png)

<details>
    <summary>Show Image</summary>
    <pre><code>
    	CogRectangleAffine rec_Left = new CogRectangleAffine();  
        CogRectangleAffine rec_Right = new CogRectangleAffine();
        CogImage8Grey image;
        //---- GroupRun ----
        rec_Left.SideXLength = 50;
        rec_Left.SideYLength = 50;
        rec_Left.LineWidthInScreenPixels = 2;
        rec_Left.Color = CogColorConstants.DarkGreen;
        rec_Left.CenterX = Convert.ToDouble(mToolBlock.Inputs["Item_0_CenterOfMassX"].Value);
        rec_Left.CenterY = (double) mToolBlock.Inputs["Item_0_CenterOfMassY"].Value;
        rec_Right.SideXLength = 50;
        rec_Right.SideYLength = 50;
        rec_Right.LineWidthInScreenPixels = 2;
        rec_Right.Color = CogColorConstants.Red;
        rec_Right.CenterX = (double) mToolBlock.Inputs["Item_1_CenterOfMassX"].Value;
        rec_Right.CenterY = (double) mToolBlock.Inputs["Item_1_CenterOfMassY"].Value;
        //---- ModifyLastRunRecord ----
        image = mToolBlock.Inputs["InputImage"].Value as CogImage8Grey;
        CogRecord record = new CogRecord("ImageName", image.GetType(), CogRecordUsageConstants.Result, false, image, "note");
        lastRecord.SubRecords.Add(record);
        /**************无用！！!***********
        CogImageConvert convert = mToolBlock.Tools["CogImageConvertTool1"] as CogImageConvert;
        CogRecord test = new CogRecord("TestName", typeof(CogImageConvert), CogRecordUsageConstants.Result, false, convert, "note");
        lastRecord.SubRecords.Add(test);
        **********************************/
            CogCircle circle = new CogCircle();
            circle.CenterX = 200;
            circle.CenterY = 200;
            circle.LineWidthInScreenPixels = 2;
            circle.Color = CogColorConstants.Blue;
            circle.Radius = 200;
            mToolBlock.AddGraphicToRunRecord(circle, lastRecord, "note", string.Empty);
        mToolBlock.AddGraphicToRunRecord(rec_Left, record, "note", string.Empty); // record\lastRecord都可
        mToolBlock.AddGraphicToRunRecord(rec_Right, lastRecord, "CogHistogramTool1.InputImage", string.Empty);
    </code></pre>
</details>

⑥自定义工具(*.vtt)

可将ToolBlock和ToolGroup封装成类似工具箱中的某个工具。

⑦弹窗

```c#
System.Windows.Forms.MessageBox.Show("");
```

##### 5.常用命名空间

| 类、工具                   | 命名空间                      |
| -------------------------- | ----------------------------- |
| CogRecord                  | Cognex.VisionPro.Implement    |
| List<T>                    | System.Collections.Generic    |
| CogDistanceSegmentLineTool | Cognex.VisionPro.Dimensioning |
|                            |                               |

##### 6.CogFindCircle

①指定期望的圆心坐标

将RunParams.ExpectedCircularArc.CenterX/Y作为输入。

![1-6-1图像](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_1-6-1.png)

②卡尺设置

- 当要找的圆在带有一定厚度的圆环内，可使用边缘对模式，并根据搜索方向设置极性
- 找的圆不理想时，在结果中勾选显示最佳拟合圆，向上调整对比度阈值和过滤一半像素，增加筛选

③设置

- 增加卡尺数量可增加拟合圆点的数量
- 勾选减少忽略的点数，可忽略分数低的卡尺数量

##### 7.Image Processing图像处理工具箱

①CogIPOneImageTool图像预处理工具

1. 中值NxM运算
   提取图像背景，增加内核高度和宽度使得图像背景色明显
2. 灰度形态调整\灰阶形态调整NxM
   形态学调整，对输入图像进行腐蚀或膨胀
3. 均衡
   提高黑白对比度
4. 翻转和旋转
5. 量化
   提高黑白对比度
6. 像素映射
   更改图像像素的某个范围的灰度值

②AffineTransform仿射工具
	切割、摆正并输出选择区域的图像，可在X、Y方向进行缩放

③PolarUnwarp极性展开工具
将圆环或弧环展开，**为了防止瑕疵点出现在分割处，将起始角度范围设置大于360°**

④CopyRegion仿制区域工具
可将输入图像的一部分复制到新的输出图像，将输入图像的一部分复制到现有目标图像，或使用恒定灰度值填充输入区域的一部分。

⑤SobelEdge边缘提取工具
隔离或增强图像的边缘信息

##### 8.SearchMax彩色模板匹配工具

##### 9.ID验证工具箱

- ID工具：识别一维码、二维码等
- OCR工具：识别单个字符
- OCV工具

##### 12.DataAnalysis数据分析和ResultsAnalysis结果分析工具

- DataAnalysis通过指定阈值来接受、警告和拒绝输入结果
- ResultsAnalysis通过算式运算输入数据

##### 13.Color颜色工具箱

1. ColorExtractor颜色提取工具
   提取启用的颜色模板的颜色，Add添加，Substract减去，输出一个灰度图像和彩色图像
2. ColorSegment图像分割工具
   用一定的颜色阈值将彩色图像进行分割，输出二值化图像，可与ColorExtract换用
3. ColorMatch颜色匹配工具
   将彩色图像某一区域与启用的每个颜色模板对比得到一个分数，得分越高，颜色越接近
   - 要求传入彩色图像，故当传入Fixture坐标固定工具输出的图像时，Fixture工具则传入彩色原图
   - 使用Fixture工具定位后，需要指定识别的区域，故一个ColorMatch工具只能识别指定区域内的分数最高的颜色
   - 当两个颜色比较接近时，降低相似颜色通道的权重来增加两种颜色的分数差距
   - 置信度 = （最高分 - 第二高分）/ （最高分 + 第二高分）
     表示最匹配的两种颜色的差距，置信度越大，颜色差距越明显
4. CompositeColorMatch复合颜色匹配工具
   与ColorMatch工具不同在于匹配不用颜色的平均值，而是颜色的分布情况，适合复合颜色的图像

##### 14.GraphicLabel标签工具

```C#
myLabel1.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;
myLabel1.SetXYText(30, 380, str2);
myLabel1.Font = new Font("宋体", 17);
myLabel1.Color = CogColorConstants.Green;
myLabel1.SelectedSpaceName = "#";
```

##### 15.Caliper卡尺工具

- 空心箭头表示边的方向，实心箭头表示扫描方向
- 对比度阈值：考虑灰度值大于该值的点
- 过滤一半像素：过滤像素后，边缘越明显的分数越高

##### 16.PatInspect缺陷检测工具

使用PatMaxc（基于边缘的模板匹配）技术探测缺陷。将输入图像区域中包含的特性与经过训练的图像中存储的特征进行比较，生成凸显差异的输出图像。

![1-16-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_1-16-1.png)

统计训练当前模式：可训练多个模板

### 二、Methods

##### 1.CogCreateGraphicLabelTool可用高级C#脚本代替(CogToolBlock)

```C#
ArrayList arr = new ArrayList();

CogGraphicLabel label = new CogGraphicLabel();

CogCaliperTool capliper = (CogCaliperTool)mToolBlock.Tools["CogCaliperTool2"];
label.SetXYText(0, -50, "Width:" + capliper.Results[0].Width.ToString("f3"));
label.Font = new Font("宋体", 16);
label.Color = CogColorConstants.Red;

arr.Add(label);

mToolBlock.AddGraphicToRunRecord(label, lastRecord, "CogFixtureTool2.OutputImage", string.Empty);
```

##### 2.CogResultsAnalysisTool可用简单脚本代替(CogToolBlock)

CogResultsAnalysisTool无法创造变量

```C#
Outputs.Output_Total = Inputs.Input_Count_Large + Inputs.Input_Count_Small;
```

##### 3.脚本绘图类

| 图形     | 类名               |
| -------- | ------------------ |
| 圆       | CogCircle          |
| 坐标轴   | CogCoordinateAxes  |
| 椭圆     | CogEllipse         |
| 线段     | CogLineSegment     |
| 点标记   | CogPointMarker     |
| 矩形     | CogRectangle       |
| 仿射矩形 | CogRectangleAffine |
| 多边形   | CogPolygon         |

##### 4.在原始图像上填充灰度值

1. 使用CogCopyRegionTool
2. 区域内填充常数值，区域外不写入像素
3. 使用图像配对

##### 5.Blob工具

①遍历Blob工具的结果，获取Blob斑点的形状，更改斑点的颜色

```C#
foreach (CogBlolbResult item in blob.Results.GetBlobs())
{
	CogPolygon polygon = blob1.Results.GetBlobs()[i].GetBoundary();
	polygon.Color = CogColorConstants.Red;
	gc.Add(polygon);
}
```

②Blob工具的输出图像

![2-6-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_2-6-1.png)

③获取Blob识别的边界最小外接矩形

```C#
CogRectangleAffine rect = blol.GetBoundingBox(CogBlobAxisConstants.Principal);
```

##### 6.将点映射回极性展开前的图像上

```C#
CogPolarUnwrapTool polar = (CogPolarUnwrapTool)mToolBlock.Tools["CogPolarUnwrapTool1"];
CogFindLineTool line = (CogFindLineTool)mToolBlock.Tools["CogFindLineTool1"];
ArrayList myList = new ArrayList();
CogGraphicCollection gc = new CogGraphicCollection();

for (int i = 0; i < line.Results.Count; i++)
{
    if ((line.Results[i].Found == true && line.Results[i-1].Found == false) ||
        (line.Results[i].Found == true && line.Results[i+1].Found == false))
        myList.Add(i);
}

for (int i = 0; i < myList.Count; i++)
{
    double beforeX, beforeY;
    polar.RunParams.GetInputPointFromOutputPoint(
    	polar.InputImage,
        polar.Region,
        line.Results[(int)myList[i]].X,
        line.Results[(int)myList[i]].Y,
        out beforeX,
        out beforeY
    )
    CogPointMarker point = new CogPointMarker();
    point.X = beforeX;
    point.Y = beforeY;
    point.Color = CogColorConstants.Red;
    point.GraphicType = CogPointMarkerGraphicTypeConstants.Crosshair;
    point.LineWidthInScreenPixels = 20;
    gc.Add(point);
}
```

##### 7.拼接图像作为图像源

创建Job脚本

```C#
CogCopyRegionTool cpRegion;
int count = 0;
//-----------------PostAcquistionRefInfo-------------
count++;
if (count == 1)
{
    cpRegion = new CogCopyRegionTool();
    CogImage8Grey desImage = new CogImage8Grey();
    desImage.Allocate(image.Width * 2, image.Height * 2);
    cpRegion.DestinationImage = desImage;

    cpRegion.Region = null;
    cpRegion.RunParams.ImageAlignmentEnabled = true;

    cpRegion.RunParams.DestinationImageAlignmentX = 0;
    cpRegion.RunParams.DestinationImageAlignmentY = 0;
}
else if (count == 2)
{
    cpRegion.RunParams.DestinationImageAlignmentX = image.Width;
    cpRegion.RunParams.DestinationImageAlignmentY = 0;
}
else if (count == 3)
{
    cpRegion.RunParams.DestinationImageAlignmentX = 0;
    cpRegion.RunParams.DestinationImageAlignmentY = image.Height;
}
else if (count == 4)
{
    cpRegion.RunParams.DestinationImageAlignmentX = image.Width;
    cpRegion.RunParams.DestinationImageAlignmentY = image.Height;
}

cpRegion.InputImage = (CogImage8Grey) image;
cpRegion.Run();

if (count == 4)
{
    image = cpRegion.OutputImage;
    cpRegion = null;
    count = 0;
    return true;
}
else
    return false;
```

##### 8.CopyRegion工具

①当区域是圆时，设置圆参数

```C#
CogCircle copyCir = copy.Region as CogCircle;
copyCir.CenterX = blob1.Results.GetBlobs()[i].CenterOfMassX;
copyCir.CenterY = blob1.Results.GetBlobs()[i].CenterOfMassY;
copyCir.Radius = radius;
```

### 三、Solutions

##### 1.标准零件孔位数量统计

直接使用斑点工具会有较大误差，可多次使用斑点工具在会有孔的区域找出斑点。

##### 2.零件瑕疵检测

①对于零件孔缺失或者表面污垢，如果直接使用模板工具进行匹配，根据分数来判断误差较大。
制作模板时，将要对比的区域掩膜掉，再使用直方图工具统计区域内像素灰度值，根据平均值判断是否有瑕疵。

②对于光滑平面上导致灰度值不一样的情况

1. IPOne提取背景
2. IPTwoImageSubtract原图和背景图相减
3. Blob提取瑕疵斑点

③固定数量零件找正常零件、瑕疵零件和缺失

1. PMAlign训练零件模板并用Fixture建立坐标系
2. 彩色图片的话使用SearchMax训练出正常、瑕疵、缺失中容易训练的两种模板
3. ToolBlock和Label输出结果

④圆形零件外圆环出现灰度值不一样的瑕疵

1. PMAlign训练零件模板并用Fixture建立坐标系
2. 基于坐标系FindCircle找圆
3. 将圆心坐标输出到PolarUnwrap将截取出圆环并展开
4. Blob判断灰度值区别瑕疵
5. ToolBlock和Label输出结果

##### 3.零件类型检测

1. 图像内要区分出多种零件，直接制定不同模板进行匹配。
2. 图像内只有一种零件，但不同图片内零件不同
   可以先找出所有零件的共同点，制定模板识别出零件，用于==判断零件的有无==；再对不同零件制定不同模板。也可直接使用模板匹配。

##### 4.多零件标注

①使用CogRecord为CogPMAlignTool1的InputImage创建图层

![3-4-1图像](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-4-1.png)

```C#
// Variables
List<CogGraphicLabel> listLabel = new List<CogGraphicLabel>();
CogPMAlignTool pm;
// GroupRun
listLabel.Clear();
pm = (CogPMAlignTool) mToolBlock.Tools[1];//["CogPMAlignTool1"];
for(int i = 0; i < pm.Results.Count; i++)
{
    CogGraphicLabel label = new CogGraphicLabel();
    label.SetXYText(pm.Results[i].GetPose().TranslationX,
                    pm.Results[i].GetPose().TranslationY,
                    "分数：" + pm.Results[i].Score.ToString("f3"));
    label.Font = new Font("宋体", 8);
    listLabel.Add(label);
}
// ModifyLastRunRecord
CogImage8Grey image = (CogImage8Grey)pm.InputImage;
CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
lastRecord.SubRecords.Add(record);

foreach(CogGraphicLabel t in listLabel)
{
    mToolBlock.AddGraphicToRunRecord(t, lastRecord, "CogImageFileTool1.OutputImage", "annotation");
    mToolBlock.AddGraphicToRunRecord(t, lastRecord, "CogPMAlignTool1.InputImage", "annotation");
}
```

②使用CogGraphicCollection将多钟多个图形或文本输出到图像，使用脚本给工具输入值。

![3-4-2图像](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-4-2.png)

```C#
// Variables
CogGraphicCollection list = new CogGraphicCollection();
CogPMAlignTool pmAlign;
// GroupRun
list.Clear();
pmAlign = mToolBlock.Tools["CogPMAlignTool1"] as CogPMAlignTool;
CogFindCircleTool findCircle = mToolBlock.Tools["CogFindCircleTool1"] as CogFindCircleTool;
foreach(CogPMAlignResult pmResult in pmAlign.Results)
{
    //findCircle.InputImage = ((CogImageFileTool)mToolBlock.Tools["CogImageFileTool5"]).OutputImage as CogImage8Grey;
    findCircle.RunParams.ExpectedCircularArc.CenterX = pmResult.GetPose().TranslationX;
    findCircle.RunParams.ExpectedCircularArc.CenterY = pmResult.GetPose().TranslationY;
    findCircle.Run();
    CogCircle circle = new CogCircle();
    circle.CenterX = findCircle.Results.GetCircle().CenterX;
    circle.CenterY = findCircle.Results.GetCircle().CenterY;
    circle.Radius = findCircle.Results.GetCircle().Radius;
    list.Add(circle);
    CogGraphicLabel label = new CogGraphicLabel();
    label.SetXYText(pmResult.GetPose().TranslationX, pmResult.GetPose().TranslationY, "半径：" + findCircle.Results.GetCircle().Radius);
    list.Add(label);
}
// ModifyLastRunRecord
CogImage8Grey image = pmAlign.InputImage as CogImage8Grey;
CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
lastRecord.SubRecords.Add(record);
foreach(ICogGraphic item in list)
{
    mToolBlock.AddGraphicToRunRecord(item, lastRecord, "CogPMAlignTool1.InputImage", "anno");
}
```

<Details>
    <summary>No use CogGraphicCollection</summary>
    <pre><code>
    //------------Variable-----------
    List<CogCircle> listCircle = new List<CogCircle>();
  	List<CogGraphicLabel> listLabel = new List<CogGraphicLabel>();
    //------------GroupRun-----------
  	listCircle.Clear();
    listLabel.Clear();
    pmAlign = mToolBlock.Tools["CogPMAlignTool1"] as CogPMAlignTool;
    CogFindCircleTool findCircle = mToolBlock.Tools["CogFindCircleTool1"] as CogFindCircleTool;
    foreach(CogPMAlignResult pmResult in pmAlign.Results)
    {
      findCircle.InputImage = ((CogImageFileTool) mToolBlock.Tools["CogImageFileTool5"]).OutputImage as CogImage8Grey;
      findCircle.RunParams.ExpectedCircularArc.CenterX = pmResult.GetPose().TranslationX;
      findCircle.RunParams.ExpectedCircularArc.CenterY = pmResult.GetPose().TranslationY;
      findCircle.Run();
      CogCircle circle = new CogCircle();
      circle.CenterX = findCircle.Results.GetCircle().CenterX;
      circle.CenterY = findCircle.Results.GetCircle().CenterY;
      circle.Radius = findCircle.Results.GetCircle().Radius;
      listCircle.Add(circle);
      CogGraphicLabel label = new CogGraphicLabel();
      label.SetXYText(pmResult.GetPose().TranslationX, pmResult.GetPose().TranslationY, "半径：" + findCircle.Results.GetCircle().Radius);
      listLabel.Add(label);
    }
    //------------ModifyLastRunRecord-----------
    CogImage8Grey image = pmAlign.InputImage as CogImage8Grey;
    CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
    lastRecord.SubRecords.Add(record);    
    foreach(CogCircle circle in listCircle)
    {
      mToolBlock.AddGraphicToRunRecord(circle, lastRecord, "CogPMAlignTool1.InputImage", "anno");
    }
    foreach(CogGraphicLabel label in listLabel)
    {
      mToolBlock.AddGraphicToRunRecord(label, lastRecord, "CogPMAlignTool1.InputImage", "anno");
    }
  	</code></pre>
</details>
③CogCaliperTool动态调整位置

![3-4-3图像](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-4-3.png)

```C#
//--------------Variable----------------
List<CogGraphicLabel>  labels = new List<CogGraphicLabel>();
//--------------GroupRun----------------
//2.获取斑点信息 
CogBlobTool  blobTool =mToolBlock.Tools["CogBlobTool1"]  as  CogBlobTool;
//斑点集合
//CogBlobResultCollection  blobResults =blobTool.Results.GetBlobs()  as CogBlobResultCollection;
//获取卡尺工具
CogCaliperTool  caliperTool =mToolBlock.Tools["CogCaliperTool1"]  as  CogCaliperTool;  //获取卡尺工具
//设置卡尺的中心点 之前需要获取区域信息 
//CogRectangleAffine   caliperRegion =caliperTool.Region  as CogRectangleAffine; //仿射矩形  caliperRegion 卡尺的区域

labels.Clear();//清空列表

foreach(CogBlobResult  blob in  blobTool.Results.GetBlobs()) // blobResults
{
    //caliperRegion.CenterX = blob.CenterOfMassX;      //斑点的质心
    //caliperRegion.CenterY = blob.CenterOfMassY;
    caliperTool.Region.CenterX = blob.CenterOfMassX;
    caliperTool.Region.CenterY = blob.CenterOfMassY;
    //运行卡尺
    mToolBlock.RunTool(caliperTool, ref message, ref result);  //运行卡尺工具  ***
    CogGraphicLabel myLabel = new CogGraphicLabel();//定义一个图形标签
    if( caliperTool.Results.Count>0 )
    {
        myLabel.SetXYText(blob.CenterOfMassX,blob.CenterOfMassY ,"Good");
        myLabel.Color = CogColorConstants.Green;
    }
    else
    {
        myLabel.SetXYText(blob.CenterOfMassX,blob.CenterOfMassY ,"Bad");
        myLabel.Color = CogColorConstants.Red;
    }
    myLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
    myLabel.Font = new Font("宋体", 14);
    labels.Add(myLabel); //添加到列表当中 
} 
//--------------ModifyLastRunRecord----------------
foreach(CogGraphicLabel  label  in  labels )
{
    mToolBlock.AddGraphicToRunRecord( label, lastRecord,"CogBlobTool1.InputImage","" );
} 
```

##### 5.颜色匹配

①多个零件下，识别某种颜色的零件

1. ColorSegment识别一种需要的颜色，可为不同区域内的同颜色创建多个模板
2. IPOne将颜色分割后的灰度区域膨胀
3. Blob识别区域个数作为零件个数

1. ColorExtractor提取颜色模板
2. IPOne灰度膨胀
3. Blob识别满足要求的区域个数作为需要识别的零件个数

②单个零件，识别不同颜色的零件

1. ImageConvert
2. PMAlign识别出该零件
3. Fixture固定坐标系
4. ColorMatch/CompositeColorMatch制作多种颜色模板，指定匹配区域，匹配出最符合的颜色
5. DataAnalysis

③多个零件，识别不同颜色的零件

1. ImageConvert
2. PMAlign识别出该零件
3. Fixture固定坐标系
4. 为匹配每个颜色使用多个ColorMatch/CompositeColorMatch工具，制作所有颜色模板，匹配出最符合的颜色
   注：当不同图像零件个数变化时，通过ToolBlock脚本生成多个颜色匹配工具，并设置识别区域，此时可不用Fixture工具；或者使用一个颜色匹配工具对通过模板匹配到的区域进行多次颜色匹配
5. DataAnalysis

![3-5-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-5-1.png)

```C#
//--------------Variable----------------
CogGraphicLabel label = new CogGraphicLabel();
//--------------GroupRun----------------
CogPMAlignTool pmAlignTool = mToolBlock.Tools["CogPMAlignTool1"] as CogPMAlignTool;
CogCompositeColorMatchTool ccm = mToolBlock.Tools["CogCompositeColorMatchTool_Yellow"] as CogCompositeColorMatchTool;
CogRectangleAffine rec = ccm.Region as CogRectangleAffine;

int num_Yellow = 0, num_Blue = 0, num_Red = 0, num_Green = 0, num_Orange = 0;

foreach (CogPMAlignResult pmResult in pmAlignTool.Results)
{
    rec.CenterX = pmResult.GetPose().TranslationX;
    rec.CenterY = pmResult.GetPose().TranslationY;
    rec.Rotation = pmResult.GetPose().Rotation;
    ccm.Run();//mToolBlock.RunTool(ccm, ref message, ref result);

    string colorName = ccm.Result.ResultOfBestMatch.Color.Name;
    switch (colorName)
    {
        default:
        case "Yellow": num_Yellow++; break;
        case "Blue": num_Blue++; break;
        case "Red": num_Red++; break;
        case "Green": num_Green++; break;
        case "Orange": num_Orange++; break;
    }
    label.SetXYText(10, 10,
                    "Yellow:" + num_Yellow.ToString() +
                    "，Blue:" + num_Blue.ToString() +
                    "，Red:" + num_Red.ToString() +
                    "，Green:" + num_Green.ToString() +
                    "，Orange:" + num_Orange.ToString());
}
//--------------ModifyLastRunRecord----------------
mToolBlock.AddGraphicToRunRecord(label, lastRecord, "CogImageConvertTool1.InputImage", "annotation");
```

##### 6.胶路检测

1. PMAlign匹配零件，Fixture固定坐标系

2. AffineTransform截取特征图像

3. CopyRegion更改某些不重要区域的灰度值为接近底色的灰度值

4. IPOne像素映射将偏底色的像素的灰度值修改为纯色

5. FindLine找圆，PolarUnwarp极性展开

6. Blob过滤干扰

7. FindLine找到胶路，根据每个卡纸的Found属性确认是否断胶或偏移

   ![3-6-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-6-1.png)

##### 7.齿轮齿数检测

①单齿轮

1. SobelEdge隔离和增强图像的边缘信息

2. Blob筛选出齿边缘

3. CopyRegion将齿轮内除轮齿外的像素灰度值调成0

4. Blob筛选出轮齿

   ![3-7-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-7-1.png)

##### 8.检测缺陷

1. PMAlign匹配零件

2. PatInspect制定多个OK模板，匹配出缺陷位置

3. IPOne使用量化增强缺陷

4. Blob标识缺陷

   ![3-8-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/VPP_3-8-1.png)

### 四、Tips

1. 右键工具选择**保存工具模板**到D:\Cognex_Visionpro\VisionPro\bin\Templates\Tools，可将当前工具作为系统工具使用。
2. ToolBlock工具右键输入/输出选择**添加到已发送项**，在生成应用向导时可输出该值。

