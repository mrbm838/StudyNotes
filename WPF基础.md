# WPF布局介绍(1) 

---
## 学习平台

微软开发者博客:  
[https://devblogs.microsoft.com/?WT.mc\_id=DT-MVP-5003986](https://devblogs.microsoft.com/?WT.mc_id=DT-MVP-5003986)  
微软文档与学习:  
[https://docs.microsoft.com/zh-cn/?WT.mc\_id=DT-MVP-5003986](https://docs.microsoft.com/zh-cn/?WT.mc_id=DT-MVP-5003986)  
微软开发者平台:  
[https://developer.microsoft.com/en-us/?WT.mc\_id=DT-MVP-5003986](https://developer.microsoft.com/en-us/?WT.mc_id=DT-MVP-5003986)

开局一张图,内容全靠...,本系列的文章, 主要针对刚入门、亦或是从 winform/bs转过来的开发人员快速入门的指南, 相对于其它一些文章中会详细的从项目如何建立到其实现的原理及组成部分, 本系列的文章则旨在如果快速的构建: 从布局、样式、触发器、绑定、显示、MVVM架构一系列的阶段学习,构建一个基础的呈现以达到学习的目的。

## WPF相关资料合集 (含书籍、框架、及开源UI组件等)

-   WPF编程宝典.pdf
-   深入浅出WPF.pdf
-   [MaterialDesignInXamlToolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
-   [MVVM Light Toolkit](http://www.mvvmlight.net/)
-   [Prism-Samples-Wpf](https://github.com/PrismLibrary/Prism)

___

## WPF布局基础

-   WPF布局原则
    
    -   一个窗口中只能包含一个元素
    -   不应显示设置元素尺寸
    -   不应使用坐标设置元素的位置
    -   可以嵌套布局容器
-   WPF布局容器
    
    -   _StackPanel_: 水平或垂直排列元素、Orientation属性分别: Horizontal / Vertical
    -   _WrapPanel_ : 水平或垂直排列元素、针对剩余空间不足会进行换行或换列进行排列
    -   _DockPanel_ : 根据容器的边界、元素进行Dock.Top、Left、Right、Bottom设置
    -   _Grid_ : 类似table表格、可灵活设置行列并放置控件元素、比较常用
    -   _UniformGrid_ : 指定行和列的数量, 均分有限的容器空间
    -   _Canvas_ : 使用固定的坐标设置元素的位置、不具备锚定停靠等功能。

## 布局容器详解

-   StackPanel
    
    > StackPanel主要用于垂直或水平排列元素、在容器的可用尺寸内放置有限个元素，元素的  
    > 尺寸总和(长/高)不允许超过StackPanel的尺寸, 否则超出的部分不可见。  
    > ![布局介绍1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/布局介绍1.png)
    
-   WrapPanel
    
    > WrapPanel默认排列方向与StackPanel相反、WrapPanel的Orientation默认为Horizontal。  
    > WrapPanel具备StackPanel的功能基础上具备在尺寸变更后自动适应容器的宽高进行换行换列处理。  
    > ![布局介绍2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/布局介绍2.png)
    
-   DockPanel

    > 默认DockPanel中的元素具备DockPanel.Dock属性, 该属性为枚举具备: Top、Left、Right、Bottom。  
    > 默认情况下, DockPanel中的元素不添加DockPanel.Dock属性, 则系统则会默认添加 Left。  
    > DockPanel有一个LastChildFill属性, 该属性默认为true, 该属性作用为, 当容器中的最后一个元素时, 默认该元素填充DockPanel所有空间。  
    > ![布局介绍3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/布局介绍3.png)

-   Grid
    
    > 学过web的老弟应该知道table表格, 而Grid与其类似, Grid具备分割空间的能力。  
    > RowDefinitions / ColumnDefinitions 用于给Grid分配行与列。  
    > ColumnSpan / RowSpan 则用于设置空间元素的 跨列与阔行。  
    > ![](https://gitee.com/mrbm868/graphic-bed/raw/master/img/布局介绍4.png)[![](https://gitee.com/mrbm868/graphic-bed/raw/master/img/布局介绍5.png)
    
-   Canvas
    
    > 该容器就相当于一个 "地图", 包含内的所有控件元素, 则都通过使用XY来定位, 由于不太常用, 所以简单掠过。

# WPF控件介绍(2)



上一章讲到了布局、这点就有点类似建筑设计、第一步是出图纸、整体的结构、而第二步就是堆砌, 建筑学里面也会有很多描述, 例如砖头，水泥、玻璃、瓷板。而在WPF中, 这一切的基础也就是控件、用于填充结构的UI控件。

## WPF的控件结构

![控件介绍1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍1.png)

## 各种控件类型详解

-   ContentControl 类

    > 设置内容的属性为 Content, 例如  
    > ![控件介绍2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍2.png)

    > 控件目录下只允许设置一次Content, 如下演示给按钮添加一个Image和一个文本显示Label, 错误如下:  
    > ![控件介绍3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍3.png)

    正确的使用方式:  
    <!利用我们上一章说讲到的布局容器装载在其中, 则可避免这种情形>  
    ![控件介绍4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍4.png)

-   HeaderedContentControl 类

    > 相对于ContentControl来说、这类控件即可设置Content, 还有带标题的Header。  
    > 像比较常见的分组控件GroupBox、TabControl子元素TabItem、它们都是具备标题和内容的控件。  
    > ![控件介绍5](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍5.png)

    > 同样,该类控件目录下只允许设置一次Conent和Header, 如下错误所示, 出现2次设置Header与Content报错:  
    > ![控件介绍6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍6.png)

-   ItemsControl 类

    > 此类控件大多数属于显示列表类的数据、设置数据源的方式一般通过 ItemSource 设置。如下所示:  
    > ![控件介绍7](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍7.png)

-   重点常用的控件介绍:

    > TextBlock: 用于显示文本, 不允许编辑的静态文本。 Text设置显示文本的内容。  
    > ![控件介绍8](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍8.png)

    > TextBox: 用于输入/编辑内容的控件、作用与winform中TextBox类似, Text设置输入显示的内容。  
    > ![控件介绍9](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍9.png)

    > Button: 简单按钮、Content显示文本、Click可设置点击事件、Command可设置后台的绑定命令  
    > ![控件介绍10](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍10.png)

    > ComboBox: 下拉框控件, ItemSource设置下拉列表的数据源, 也可以显示设置, 如下  
    > ![控件介绍11](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件介绍11.png)

# WPF样式(3)

WPF中的各类控件元素, 都可以自由的设置其样式。 诸如:

- 字体(FontFamily)
- 字体大小(FontSize)
- 背景颜色(Background)
- 字体颜色(Foreground)
- 边距(Margin)
- 水平位置(HorizontalAlignment)
- 垂直位置(VerticalAlignment) 等等。

而样式则是组织和重用以上的重要工具。不是使用重复的标记填充XAML, 通过Styles创建一系列封装所有这些细节的样式。然后通过Style属性应用封装好的样式。这点类似于CSS样式。然而, WPF样式的功能更加强大, 如控件的行为。WPF的样式还支持触发器(后面章节会讲到)。

## 示例

为了能够直观了解到样式(Style)的使用方法, 下面演示一个从传统的定义控件样式到使用Style组织样式的方法。

下面的例子中, 给4个TextBlock设置同样的样式: 字体、字体大小、字体颜色、加粗设置。

效果图与实际代码如下所示:
![样式1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式1.png)

![样式2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式2.png)

- 上面有讲到, 样式是组织和重用的工具。 而上面的代码, 由于每个元素都是相同的, 但是每个元素XAML都重复定义。 下面将介绍通过样式如何优化上面的代码。

  - 第一步: 在Resources目录下定义一个TextBlockStyle的样式, 完整代码如下:

  > Style结构定义了一个 x:key 这点类似于Html中定义id和class, 然后css即可对相应的class和id样式生效。
  > TargetType 的设置为类型TextBlock, 设置目标类型静态文本TextBlock。
  > ![样式3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式3.png)

  - 第二步:通过控件的Style属性 来引用x:key 的样式, 代码如下:
    ![样式4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式4.png)

注意: 

- 当未指定`x:key:`样式名称时，即作用于此页面所有的目标控件

- `BaseOn`表示继承某个样式，`TargetType="Button"`用了默认的隐式的方式，`TargetType="{x:Type Button}"`用了一个显式的命名空间引用，完全没区别。

  ```xaml
  <Window.Resources>
      <Style x:Key="ButtonStyleBase" TargetType="Button">
          <Setter Property="Foreground" Value="White"></Setter>
          <Setter Property="Background" Value="Blue"></Setter>
      </Style>
      <Style x:Key="ButtonStyle"  TargetType="{x:Type Button}" BasedOn="{StaticResource ButtonStyleBase}">
          <Setter Property="FontSize" Value="18"/>
      </Style>
  </Window.Resources>
  ```

- 当控件引用了某个样式, 在控件本身并没有定义该属性的情况下,优先使用样式中的定义,否则优先控件本身的定义。如下所示, 样式中设置了颜色为 Red, 但是控件本身又设置了Green, 那么控件的最终效果 Green。

  ![样式5](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式5.png)

![样式6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/样式6.png)

# [WPF控件模板(6)](https://www.cnblogs.com/zh7791/p/11421386.html)

## 什么是ControlTemplate?

ControlTemplate(控件模板)不仅是用于来定义控件的外观、样式, 还可通过控件模板的触发器(ControlTemplate.Triggers)修改控件的行为、响应动画等。通过控件，为使用该控件的用户提供了利用属性名设置属性值的接口。

通过剖析控件了解ControlTemplate的组成:

- 首先,创建一个WPF项目, 创建一个Button按钮, 然后选中该按钮, 右键选择编辑模板>编辑副本:
  ![控件模板1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板1.png)

- 创建完成后, 会在当前页面<Windows.Resources> 键下面生成一些样式片段 , 一个key为ButtonStyle1的样式:

  ![控件模板2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板2.png)

  - 在看到该样式定义了一些基础的样式, 背景颜色、字体颜色、边框大小、垂直水平位置等, 除此之外, 下方则有一个Template的对象, 其中则就是ControlTemplate, 可以看到, ControlTemplate定义了一个Border ,然后其中定义了一个内弄呈现的控件, ContentPresenter则主要用于呈现按钮的显示内容主体, 如下标记:
    ![控件模板3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板3.png)
  - 我们可以进行一些尝试, 试图修改border的属性, 观察Button会发生怎样的变化, 通过为Border 添加一个 圆角矩形参数， 将背景颜色设置成固定的值, 如下:
    ![控件模板4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板4.png)

> 通过简单的尝试,可以观察到, 该Border 作为Button按钮的边缘样式和整体的外观控制。
> \- 接下来, 我们可以通过修改ContentPresenter 中的一些参数, 看看该控件是怎样的一个存在。 修改其中的垂直位置为居下, 为Button设置一个固定Content的值 “Hello”, 观察Hello的位置:
> ![控件模板5](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板5.png)
> 通道实践, 可以了解到, 该内容呈现控件(ContentPresenter) 负责了内容的展示、和一部分属性的控制。

## ControlTemplate中的TemplateBinding 的作用?

> 在ControlTemplate中, 可以看多多次有定义 TemplateBinding 的代码:
> ![控件模板6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板6.png)

> TemplateBinding 可以理解为, 通过模板绑定关联到指定的样式、属性。 如此一来 , 当按钮通过显示设置该属性, 则最终会影响着Template绑定的属性值。

> 下面将通过代码演示, 有 TemplateBinding 和 无TemplateBinding 的区别, 在Button按钮中, 显示定义 按钮的边框颜色为 “Blue”, 分别看两者中的影响:

图(1), 有TemplateBinding :
![控件模板7](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板7.png)

图(2), 无TemplateBinding:
![控件模板8](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板8.png)

> 可以理解, TemplateBinding 主要的作用为, 与外部的属性关系起来, 使其达到改变样式属性的作用。

## ControlTemplate.Triggers 触发器

展开ControlTemplate.Triggers 节点, 可以看到其中定义了一些触发条件和改变的样式。
![控件模板9](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板9.png)

> 可以看到, 定义了4个触发器, 分别满足条件之后, 改变Border的一些样式, 接下来, 通过一张图,来解释其影响的过程:![控件模板11](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板11.png)

实际效果:<img src="https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板10.gif" alt="控件模板10"  />

> 同样, 其他的触发器也是通过这样的操作, 来控制着控件的属性变化。

## ControlTemplate.EventTrigger 事件触发器

> 下面定义了一个EventTrigger 事件触发器,
> 当鼠标进入按钮区域时, 执行一个0.5秒的动画, 将按钮的背景颜色设置为 pink,
> 当鼠标离开按钮区域时, 执行一个0.5秒的动画,将按钮的背景颜色设置为Green:
> ![控件模板12](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板12.png)

实际效果:
![控件模板13](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板13.gif)

## 自定义ControlTemplate

> 控件模板可以独立存在, 上面的例子中, 包含在样式文件中, 下面, 单独声明一个独立的控件模板:

- 1.创建一个ControlTemplate ,设定一个键名称, 指定其模板的类型
- 2.创建一个Border 用于设置按钮边样式
- 3.创建一个内容呈现的控件, 设置几个参数的TemplateBinding
- 4.按钮的Template 绑定该模板
  ![控件模板14](https://gitee.com/mrbm868/graphic-bed/raw/master/img/控件模板14.png)

# WPF触发器

> 顾名思义, 触发器可以理解为, 当达到了触发的条件, 那么就执行预期内的响应, 可以是样式、数据变化、动画等。
> 触发器通过 Style.Triggers集合连接到样式中, 每个样式都可以有任意多个触发器, 并且每个触发器都是 System.Windows.TriggerBase的派生类实例, 以下是触发器的类型

- Trigger : 监测依赖属性的变化、触发器生效
- MultiTrigger : 通过多个条件的设置、达到满足条件、触发器生效
- DataTrigger : 通过数据的变化、触发器生效
- MultiDataTrigger : 多个数据条件的触发器
- EventTrigger : 事件触发器, 触发了某类事件时, 触发器生效。

## Trigger

> 下面以Border为例, 演示一个简单的Trigger触发器。
> 当鼠标进入Border的范围, 改变Border的背景颜色和边框颜色, 当鼠标离开Border的范围, 还原Border的颜色。
> 代码如下所示:
> ![触发器1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器1.png)
> 实际效果:
> ![触发器2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器2.gif)

## MultiTrigger

> 和Trugger类似, MultiTrigger可以设置多个条件满足时, 触发, 下面以TextBox为例, 做一个简单的Demo
> 当鼠标进入文本框的范围, 并且光标设置到TextBox上, 则把TextBox的背景颜色改变成Red
> ![触发器3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器3.png)
> 实际效果:
> ![触发器4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器4.gif)

## EventTrigger

> 事件触发器, 当触发了某类事件, 触发器执行响应。
> 当鼠标进入按钮的范围中, 在0.02秒内, 把按钮的字体变成18号
> 当鼠标离开按钮的范围时, 在0.02秒内, 把按钮的字体变成13号 。 代码及效果如下所示:
> ![触发器5](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器5.png)
> 实际效果:
> ![触发器6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/触发器6.gif)

结尾: 对于 DataTrigger / MultiDataTrigger 的功能类似, 只不过触发条件变成了以数据的方式为条件。

# WPF数据模板(7) 

> 数据模板常用在3种类型的控件, 下图形式:
> ![数据模板1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板1.png)

- 1.Grid这种列表表格中修改Cell的数据格式, CellTemplate可以修改单元格的展示数据的方式。
- 2.针对列表类型的控件, 例如树形控件，下拉列表，列表控件, 可以修改其中的ItemTemplate。
- 3.修改ContentTemplate, 例UserControl控件的数据展现形式。

## CellTemplate 

> 下面用一个例子, 来演示CellTemplate使用。例子实现一个DataGrid 展示一个普通的数据标, 同时新增一列CellTemplate添加两个自定义的按钮, 如下图所示。

```xaml
<DataGrid Name="gd" AutoGenerateColumns="False" CanUserSortColumns="True"  CanUserAddRows="False">
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding UserName}" Width="100" Header="学生姓名"/>
        <DataGridTextColumn Binding="{Binding ClassName}" Width="100" Header="班级名称"/>
        <DataGridTextColumn Binding="{Binding Address}" Width="200" Header="地址"/>
        <DataGridTemplateColumn Header="操作" Width="100" >
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal" VerticalAlignment="Center" HorizontalAlignment="Left">
                        <Button Content="编辑"/>
                        <Button Margin="8 0 0 0" Content="删除" />
                    </StackPanel>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
    </DataGrid.Columns>
</DataGrid>
```

> 完成操作, 然后后台进行该DataGrid进行绑定数据, 查询绑定后的效果。

```C#
List<Student> students = new List<Student>();
students.Add(new Student() { UserName = "小王", ClassName = "高二三班", Address = "广州市" });
students.Add(new Student() { UserName = "小李", ClassName = "高三六班", Address = "清远市" });
students.Add(new Student() { UserName = "小张", ClassName = "高一一班", Address = "深圳市" });
students.Add(new Student() { UserName = "小黑", ClassName = "高一三班", Address = "赣州市" });
gd.ItemsSource = students;
```

> 最终的效果, 在数据的表格最后一列, 将会在一列中分别生成 两个普通按钮。
> ![数据模板2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板2.png)

## ItemTemplate

> 在列表的控件中, 常常会出现一些需求, 类似在下拉控件或树控件中添加一个 CheckBox选择框, 一个图标或图片, 这个时候, 我们就可以利用自定义的DataTemplate 来实现这个功能,
> 接下来, 用一个示例来简单演示其功能, 同样, 该例子演示利用 ListBox 和 ComboBox来绑定一个 颜色代码列表, 同时展示其颜色。

```xaml
<Window.Resources>
    <DataTemplate x:Key="comTemplate">
        <StackPanel Orientation="Horizontal" Margin="5,0">
            <Border Width="10" Height="10" Background="{Binding Code}"/>
            <TextBlock Text="{Binding Code}" Margin="5,0"/>
        </StackPanel>
    </DataTemplate>
</Window.Resources>
<Grid>
    <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
        <ComboBox Name="cob" Width="120" Height="30" ItemTemplate="{StaticResource comTemplate}"/>
        <ListBox Name="lib" Width="120" Height="100" Margin="5,0"  ItemTemplate="{StaticResource comTemplate}"/>
    </StackPanel>
</Grid>
```

> 上面的代码中, 定义了一个DataTemplate , 顶一个 长宽10px的border用于显示颜色代码, 绑定到Border背景颜色上, 定义了一个TextBlock用于展示颜色的代码。
> 下面为后台的绑定代码

```c#
List<Color> ColorList = new List<Color>();
ColorList.Add(new Color() { Code = "#FF8C00" });
ColorList.Add(new Color() { Code = "#FF7F50" });
ColorList.Add(new Color() { Code = "#FF6EB4" });
ColorList.Add(new Color() { Code = "#FF4500" });
ColorList.Add(new Color() { Code = "#FF3030" });
ColorList.Add(new Color() { Code = "#CD5B45" });

cob.ItemsSource = ColorList;
lib.ItemsSource = ColorList;
```

> 最终的测试效果如下所示:
> ![数据模板3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板3.gif)

## ItemsControl

> 定义ItemsControl 主要分两个步骤: 1.设置ItemsPanel容器, 用于容纳列表的最外层容器 2.定义子项的DataTemplate

```xaml
<ItemsControl Name="ic">
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <WrapPanel Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>

    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Button Width="50" Height="50" Content="{Binding Code}"/>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
```

> 上面代码中, 定义了一个WarpPanel 容器为ItemControl的 最外层容器, 子项数据模板则绑定了一个按钮, 后台代码绑定几条数据, 查看其效果: 横排排列五个按钮, 内容分别是 1~6.

```c#
List<Test> tests = new List<Test>();
tests.Add(new Test() { Code = "1" });
tests.Add(new Test() { Code = "2" });
tests.Add(new Test() { Code = "3" });
tests.Add(new Test() { Code = "4" });
tests.Add(new Test() { Code = "6" });
ic.ItemsSource = tests;
```

![数据模板4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板4.png)

**查看ItemsControl可视化树的结构组成?**

![数据模板5](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板5.png)

> 剖析该结构, 可以看到, 紫色的1处, 为最外层的WrapPanel容器, 用于容纳排列按钮, 由于该示例设置了 Orientation="Horizontal" , 所以按钮则按水平排列, 再看 橘色 2处, 可以看见子项外层由一个内容呈现包括着, 内容为一个按钮, 由于绑定搞得数据是5个, 所以分别生成了内容为1~6的5个按钮。

- 说明: 那是不是以为则ItemsPanel 放置任何元素都行? 很明显是不行的。 ItemsPanel的容器需要满足一个条件, 则是属于Panel族的元素, 否则会提示以下错误:
  ![数据模板6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/数据模板6.png)

> 关于每种元素的分类可以看关于控件介绍的文章: https://www.cnblogs.com/zh7791/p/11372473.html

## ContentTemplate

> 长话短说, 这个东西用的太少了, 详细的可以搜索一下相关的使用资料。](https://github.com/esofar/cnblogs-theme-silence)

# [WPF绑定(Binding)(4) ](https://www.cnblogs.com/zh7791/p/11379942.html)

## 什么是绑定(Binding)

在winform中, 我们常常会用到各种类型的赋值, 例如:

- button1.Text="Hello";
- label.Text="Hello";
- ...

类似这种赋值操作, 我们之所以不称之为绑定, 主要原因是因为他们大多数操作都是一次性的, 无论是数据还是按钮本身发生变化,对两者而言都是不可见的。
而绑定的概念则侧重于: 两者的关联,协议与两者之间的影响。

## 控件绑定控件

### 1.事件驱动

```xaml
<StackPanel>
    <Slider x:Name="Slider" Margin="5" ValueChanged="Slider_OnValueChanged"/>
    <TextBox x:Name="TextBox" Margin="5" TextChanged="TextBox_OnTextChanged"></TextBox>
</StackPanel>
```

```C#
private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
{
    if (Double.TryParse(TextBox.Text, out double value))
        Slider.Value = value;
}

private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
{
    TextBox.Text = Slider.Value.ToString(CultureInfo.InvariantCulture);
}
```

### 2.数据驱动

首先, 从一个简单的例子来理解什么是绑定。

- 创建一个滑块控件, 并且希望在滑动的过程中, 把值更新到另外一个静态文本上。代码如下:
  ![绑定(Binding)1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)1.png)

在winform中, 我们常规的做法会给滑块创建一个值改变事件,同时将滑块的值赋值给文本。
接下来, 我只需要在静态文本中添加一小段绑定的声明,即可完整原本很复杂的操作:

- Text=
  - {Binding }: Binding的声明语法, 一对尖括号, 开头声明以Binding 开始
  - ElementName= : 该声明意为, 设置元素的名称
  - Path: 设置关联元素的位置,上例中设置为元素的value属性
  - `UpdateSourceTrigger=PropertyChanged`框内的值一改变立即触发
  - `StringFormat=f3 or StringFormat=0.000`值保留3位小数

那么该如何理解整句话的意义, 翻译: 静态文本TextBlock的Text属性将通过绑定的方式关联到元素名'slider'的value属性上。
![绑定(Binding)2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)2.png)

效果图所示:
![绑定(Binding)3](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)3.gif)
可以看到,在滑块不断的滑动过程中, TextBlock也在不断的发生变化, 说明TextBlock已经得到了滑动滑动过程中的值变化, 这种关联, 我们称之为绑定, 在WPF当中, 绑定又分很多种, 而上面这种则是通过元素绑定的方式。
理解了基础的绑定之后,然后就是理解绑定的模式。

> 绑定的模式就类似我们商业中的合作, 是一次性回报还是持续获益, 是否可以单方面终止, 是否具有投票权等, 在WPF中绑定的模式又分为五种:

- OneWay(单向绑定) : 当源属性发生变化更新目标属性, 类似上面的例子中, 滑动变化更新文本的数据。示例:
  ![绑定(Binding)4](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)4.png)
  效果:
  ![绑定(Binding)6](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)6.gif)
- TwoWay(双向绑定) : 当源属性发生变化更新目标属性, 目标属性发生变化也更新源属性。
  - 与单向绑定的区别可以理解为, 前者只能打你,被打者不能还手, 双向绑定的意思则是: 你敢打我一巴掌,我也能回你一巴掌。示例:
    ![绑定(Binding)7](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)7.png)
    效果:
    ![绑定(Binding)8](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)8.gif)
- OneTime(单次模式) : 根据第一次源属性设置目标属性, 在此之后所有改变都无效。
  - 如第一次绑定了数据源为0, 那么无论后面如何改变 2、3、4... 都无法更新到目标属性上。示例:
    ![绑定(Binding)9](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)9.png)
    效果:
    ![绑定(Binding)10](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)10.gif)
- OneWayToSource : 和OneWay类型, 只不过整个过程倒置。示例:
  ![绑定(Binding)11](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)11.png)
  效果:
  ![绑定(Binding)12](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)12.gif)
- Default : 既可以是双向,也可以是单项, 除非明确表明某种模式, 否则采用该默认绑定

## 控件绑定属性（非元素）

上面的代码中,使用的绑定方式是根据元素的方式: ElementName=xxx, 如需绑定到一个非元素的对象, 则有一下几属性:

- Source : 指向一个数据源, 示例, TextBox使用绑定的方式用Source指向一个静态资源ABC:
  ![绑定(Binding)13](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)13.png)
- RelativeSource : 使用一个名为RelativeSource的对象来根据不同的模式查找源对象,

> 示例, 使用RelativeSource的FindAncestor模式, 查找父元素为StackPanel的Width值
> ![绑定(Binding)14](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)14.png)

- DataContext: 从当前的元素树向上查找到第一个非空的DataContext属性为源对象。

> 示例, 该示例用后台代码创建一个只包含Name的类, Test, 通过绑定窗口的DataContext上下文:
> ![绑定(Binding)15](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)15.png)

**后台代码绑定简单文本与列表**

> 创建一个PageModel类, 定一个ClassName为班级名称, 和一个Students学生列表, 后台代码:
> ![绑定(Binding)16](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)16.png)
> 窗口代码
> ![绑定(Binding)17](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)17.png)
> 效果预览
> ![绑定(Binding)18](https://gitee.com/mrbm868/graphic-bed/raw/master/img/绑定(Binding)18.png)

------

关于以上, 基本介绍了WPF元素绑定的方式与几种模式, 接下讲的是, WPF中的事件如果通过绑定的方式和UI分离。尽管WPF中仍然可以兼容winform中的事件模型, 而binding也是MVVM架构中的重要组成部分。

# WPF命令(ICommand)

> 命令的目的是为了使UI的变动不影响到业务，业务的变动不影响到UI
>
> 回调 就是委托或事件触发后 去执行先前绑定的一系列方法；回调有柱塞 和 非柱塞两种回调方式

MainWindow.xaml

```xaml
<Button Height="10" Command="{Binding MainCommand}" CommandParameter="yjq"></Button>
```

MainWindow.xaml.cs

```C#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}
```

MainViewModel.cs

```C#
public class MainViewModel
{
    public MainCommand MainCommand { get; set; }

    public MainViewModel()
    {
        MainCommand = new MainCommand(Show);
    }

    public void Show(string message)
    {
        MessageBox.Show(message);
    }
}
```

MainCommand.cs

```C#
public class MainCommand : ICommand
{
    Action<string> _action;

    public MainCommand(Action<string> action)
    {
        _action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action.Invoke(parameter.ToString());
    }

    public event EventHandler? CanExecuteChanged;
}
```

# WPF通知属性(INotifyPropertyChanged)

> 目的是实现当属性值改变后，及时更新到UI上
>
> 可以理解为  binding 把UI的一个Update 绑在了 event 上，所以值改变，就调用所有Update。

MainViewModel.cs

```C#
public class MainViewModel : INotifyPropertyChanged
{
    public MainCommand MainCommand { get; set; }

    private string _name;

    public string Name
    {
        get { return _name;}
        set
        {
            _name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }

    public MainViewModel()
    {
        Name = "mrbm";
        MainCommand = new MainCommand(Show);
    }

    public void Show(string message)
    {
        Name = message;
        MessageBox.Show(message);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
```

**单独创建一个类，简化属性set访问器**

MainViewModel.cs

```C#
public string Name
{
    get { return _name;}
    set
    {
        _name = value;
        OnPropertyChanged();
    }
}
```

ViewModelBase.cs

`[CallerMemberName]`该特性用于自动识别属性

```C#
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
```

# WPF动画

## XAML创建动画

```xaml
<Window.Resources>
    <Storyboard x:Key="Loading">
        <ThicknessAnimation Duration="0:0:0.3" From="0,100,0,100"  To="0"
                            Storyboard.TargetName="GridMain" Storyboard.TargetProperty="Margin" />
    </Storyboard>
    <Storyboard x:Key="Closing">
        <ThicknessAnimation Duration="0:0:0.6" From="0" To="0,100,0,100" Storyboard.TargetName="GridMain" 
                            Storyboard.TargetProperty="Margin" Completed="Timeline_OnCompleted"/>
    </Storyboard>
</Window.Resources>
<Window.Triggers>
    <EventTrigger RoutedEvent="Loaded" >
        <BeginStoryboard Storyboard="{StaticResource Loading}"/>
    </EventTrigger>
    <EventTrigger RoutedEvent="TextBlock.MouseLeftButtonDown">
        <BeginStoryboard Storyboard="{StaticResource Closing}"/>
    </EventTrigger>
</Window.Triggers>
<Grid x:Name="GridMain">
    <TextBlock Name="block" TextAlignment="Justify" Background="Beige">This is a Text</TextBlock>
</Grid>
```

```C#
private void Timeline_OnCompleted(object? sender, EventArgs e)
{
    block.Text = "Over";
}
```

## 代码创建

### Storyboard 

1.创建 Storyboard 对象, 用于装配子动画对象和属性信息。
2.由于控制Margin, 用到的属于 Thickness 结构的数据类型, 所以需要创建 ThicknessAnimation 对象。
3.设置 ThicknessAnimation 其子属性的参数: 动画时间、 初始值、结束值。
4.绑定其元素对象GridMain
5.绑定依赖属性 Margin
6.添加到 Storyboard 容器中
7.运行动画

```C#
System.Windows.Media.Animation.Storyboard sb = new System.Windows.Media.Animation.Storyboard();
System.Windows.Media.Animation.ThicknessAnimation dmargin = new System.Windows.Media.Animation.ThicknessAnimation();
dmargin.Duration = new TimeSpan(0, 0, 0, 0, 300);
dmargin.From = new Thickness(0, 300, 0, 300);
dmargin.To = new Thickness(0, 0, 0, 0);
System.Windows.Media.Animation.Storyboard.SetTarget(dmargin, GridMain);
System.Windows.Media.Animation.Storyboard.SetTargetProperty(dmargin, new PropertyPath("Margin", new object[] { }));
sb.Children.Add(dmargin);
sb.Begin();
```

### DoubleAnimation

- `From` `To` 可直接替换成值，因为BeginAnimation绑定了按钮的宽度属性，等价于`By`
- `AutoReverse`表示是否往返，默认在指定时间内(`Duration`)往返一次
- `RepeatBehavior`表示重复行为
  - new(4)指重复4次，AutoReverse = true时，往返4次，每次时间为指定时间(`Duration`)
  - new(TimeSpan.FromMilliseconds(800))指重复800ms，AutoReverse = true时，往返800ms，每次时间为指定时间(`Duration`)

```C#
private void Btn_OnClick(object sender, RoutedEventArgs e)
{
    DoubleAnimation animation = new DoubleAnimation
    {
        From = 60,//btn.Width,
        To = 30,//btn.Height /2,
        // By = -30,
        Duration = TimeSpan.FromMilliseconds(200),
        AutoReverse = true,
        RepeatBehavior = new(4)// new(TimeSpan.FromMilliseconds(800)),
    };
    btn.BeginAnimation(Button.WidthProperty, animation);
}
```

# WPF资源

### 静态资源(StaticResource)

指的是在程序载入内存时对资源的一次性使用，之后就不再访问这个资源了。

### 动态资源(DynamicResource)

指的是在程序运行过程中然会去访问资源。

```xaml
<StackPanel>
    <Button x:Name="UpdateControl"  Margin="10"  Content="点击更新" Click="UpdateControl_Click"></Button>
    <Button BorderThickness="5" x:Name="button1" Content="测试1" Height="40"  Margin="10" BorderBrush="{StaticResource SolidColor}"></Button>
    <Button BorderThickness="5"  x:Name="button2" Content="测试1" Height="40"  Margin="10" BorderBrush="{DynamicResource SolidColor}"></Button>
</StackPanel>
```

AppBrush.xaml

```xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
 
    <SolidColorBrush x:Key="SolidColor" Color="Red"></SolidColorBrush>
    <Style x:Key="DefaultButtonStyle" TargetType="Button">
        <Setter Property="Foreground" Value="Blue"></Setter>
        <Setter Property="FontSize" Value="15"></Setter>
    </Style>
</ResourceDictionary>
```

```c#
private void UpdateControl_Click(object sender, RoutedEventArgs e)
{
    //动态改变资源的样式
    this.Resources["SolidColor"] = new SolidColorBrush(Colors.Black);
    //动态获取样式的详细信息
    var solidColor = App.Current.FindResource("SolidColor");
    var defaultButtonStyle = App.Current.FindResource("DefaultButtonStyle");
}
```

### 资源字典(ResourceDictionary)

单独的XAML文档，如果希望在多个项目之间共享资源，可创建资源字典。除了存储希望使用的资源外，不做其他任何事情。

如上新建的AppBrush.xaml。为了使用资源字典，需要将其合并到应用程序的资源集合中。

- App.xaml 即可全局引用
- 具体的xaml 如Page\Window\UserControl，则包含在`<*.Resources>`标签内，只供该xaml引用

如果希望添加自己的资源并合并到资源字典中，只需要在MergedDictionaries部分之前或之后放置资源就可以了。

```xaml
<Application x:Class="Resources.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="Menu.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
            </ResourceDictionary.MergedDictionaries>
            <sys:String x:Key="txt" >I am ViewA</sys:String>
            <sys:Double x:Key="textBlock">28</sys:Double>
            <Color x:Key="GraphicalBrush1" >Blue</Color>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

Dictionary1.xaml

```xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style x:Key="styleBlock" TargetType="TextBlock">
        <Setter Property="FontSize" Value="38"/>
    </Style>
</ResourceDictionary>
```

View.xaml

```xaml
<TextBlock Text ="{StaticResource txt}" FontSize="{StaticResource textBlock}"></TextBlock>
<TextBlock Text ="I am ViewC" Style="{StaticResource styleBlock}" ></TextBlock>
```

# Prism区域(Region)

---

MainWindowView.xaml

```xaml
<WrapPanel>
    <Button Content="OpenA" Command="{Binding OpenCommand}" CommandParameter="ViewA"/>
    <Button Content="OpenB" Command="{Binding OpenCommand}" CommandParameter="B"/>
    <Button Content="OpenC" Command="{Binding OpenCommand}" CommandParameter="C"/>
</WrapPanel>
<!--声明一个区域-->
<ContentControl Grid.Row="1" prism:RegionManager.RegionName="ContentRegion"/>
```

创建ViewA,ViewB,ViewC三个用户控件

App.xaml.cs

```c#
protected override Window CreateShell()
{
    return Container.Resolve<MainWindow>();
}

protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    //注册3个用户控件
    containerRegistry.RegisterForNavigation<ViewA>();
    containerRegistry.RegisterForNavigation<ViewB>("B");
    containerRegistry.RegisterForNavigation<ViewC>("C");
}
```

MainWindowVewModel.cs

```C#
public class MainWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    private DelegateCommand<string> _openCommand;

    public DelegateCommand<string> OpenCommand => _openCommand ??= new DelegateCommand<string>(ExecuteCommandName);


    void ExecuteCommandName(string obj)
    {
        // 通过IRegionManager接口获取全局定义的可用区域
        // 往这个区域以依赖注入的方式去动态设置内容
        _regionManager.Regions["ContentRegion"].RequestNavigate(obj);
        //等价于
        //_regionManager.RequestNavigate("ContentRegion", obj);
    }

    public MainWindowViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        _openCommand = new DelegateCommand<string>(ExecuteCommandName);
    }
}
```

# Prism模块

---

在Prism区域程序上，创建模块（类库）ModuleA，ModuleA添加ModuleAProfile.cs，将ModuleA中的Views/ViewA注册到导航。

```C#
public class ModuleAProfile : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
    }
}
```



## 引用+代码的方式

**缺点：耦合度较高，取消模块时，需要取消引用，再修改App.xaml.cs的代码**

主项目添加ModuleA的项目引用

![模块1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/%E6%A8%A1%E5%9D%971.jpg)

MainWindow.xaml

```xaml
<WrapPanel>
    <Button Content="OpenA" Command="{Binding OpenCommand}" CommandParameter="A"/>
    <Button Content="OpenB" Command="{Binding OpenCommand}" CommandParameter="B"/>
    <Button Content="OpenC" Command="{Binding OpenCommand}" CommandParameter="C"/>
    <Button Content="OpenD" Command="{Binding OpenCommand}" CommandParameter="ViewA"/>
</WrapPanel>

<!--声明一个区域-->
<ContentControl Grid.Row="1" prism:RegionManager.RegionName="ContentRegion"/>
```

App.xaml.cs，覆盖ConfigureModuleCatalog方法添加模块A

```C#
using ModuleA.Views;

public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>("A");
        containerRegistry.RegisterForNavigation<ViewB>("B");
        containerRegistry.RegisterForNavigation<ViewC>("C");
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleAProfile>();
        base.ConfigureModuleCatalog(moduleCatalog);
    }
}
```

*注意：先注册主项目的视图导航，ModuleA的视图ViewA最后注册进来。如果主程序的存在和模块同名的ViewA，则会被覆盖，可换名称或使用别名。*

## DLL+配置方式

优点：取消模块时，将模块项目的生成后事件清空，再删除DLL所在的目录内（Modules文件夹下）对应模块的DLL

App.xaml.cs，覆盖CreateModuleCatalog方法添加模块生成DLL所在的目录

```C#
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>("A");
        containerRegistry.RegisterForNavigation<ViewB>("B");
        containerRegistry.RegisterForNavigation<ViewC>("C");
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        //moduleCatalog.AddModule<ModuleAProfile>();
        //base.ConfigureModuleCatalog(moduleCatalog);
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        string projName = Assembly.GetExecutingAssembly().GetName().Name;
        string directory = Environment.CurrentDirectory;
        int removeIndex = directory.IndexOf(projName, StringComparison.Ordinal);
        string path = directory.Remove(removeIndex, projName.Length + 1);

        return new DirectoryModuleCatalog()
        {
            ModulePath = path + "\\Modules"
        };
    }
}
```

在ModuleA项目属性的生成后事件添加下行代码，将其生成的DLL复制到解决方案目录下

`xcopy "$(TargetDir)$(TargetName)*$(TargetExt)" "$(SolutionDir)\$(OutDir)Modules\" /Y /S`

![模块2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/%E6%A8%A1%E5%9D%972.jpg)

# Prism导航

---

## 约定大于配置

prism中视图的主标签内有如下标签，可以自动建立起View和ViewModel的关系

```xaml
prism:ViewModelLocator.AutoWireViewModel="True"
```

但是约定大于配置，且为了方便查找，通常显式建立View和ViewModel的对应关系

```C#
public void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
}
```

## 导航传参

MainWindowViewModel.cs，在命令的执行函数中，向Message字段传“I am Main”字符串

```C#
void ExecuteCommandName(string obj)
{    
    //this.regionManager.RequestNavigate("ContentRegion", "WViewA");= {  }
    NavigationParameters parameters = new NavigationParameters { { "Message", "I am Main" } };
    // 等价于 parameters.Add("Message", "I am Main");
	regionManager.Regions["ContentRegion"].RequestNavigate(obj, parameters);
}
```

ModuleA.ViewAViewModel.cs

```C#
public class ViewAViewModel : BindableBase, INavigationAware
{
    private string message;

    public ViewAViewModel()
    {
        Message = "View A from your Prism Module";
    }

    public string Message
    {
        get => message;
        set => SetProperty(ref message, value);
    }
    
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        if (navigationContext.Parameters.ContainsKey("Message"))
            this.Message = (string)navigationContext.Parameters["Message"];
        // 等价于 Message = navigationContext.Parameters.GetValue<string>("Message");
        
        // 下式则减少了if判断
        navigationContext.Parameters.TryGetValue("Message", out message);
    }

    /// <summary>
    /// 每次重新导航时，是否重用原来的实例
    /// </summary>
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}
```

## 导航请求

ModuleA.ViewAViewModel.cs，**INavigationAware替换成IConfirmNavigationRequest**

```C#
public class ViewAViewModel : BindableBase, IConfirmNavigationRequest
{
    private string _message;
    public string Message
    {
        get { return _message; }
        set { SetProperty(ref _message, value); }
    }

    public ViewAViewModel()
    {
        Message = "View A from your Prism Module";
    }

    /// <summary>
    /// 导航到本页面时触发
    /// </summary>
    /// <param name="navigationContext"></param>
    public void OnNavigatedTo(NavigationContext navigationContext)
    {

    }

    /// <summary>
    /// 重新导航到本页面时触发，是否重用原来的实例
    /// </summary>
    /// <param name="navigationContext"></param>
    /// <returns></returns>
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    /// <summary>
    /// 从本页面重新导航时触发
    /// </summary>
    /// <param name="navigationContext"></param>
    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    /// <summary>
    /// 本页面接受导航请求时触发
    /// </summary>
    /// <param name="navigationContext"></param>
    /// <param name="continuationCallback"></param>
    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        bool bResult = MessageBox.Show("是否确认导航？", "提示", MessageBoxButton.YesNo) != MessageBoxResult.No;
        continuationCallback(bResult);
    }
}
```

## 导航日志

MainWindow.xaml，添加按钮

```xaml
<Button Content="Back" Command="{Binding BackCommand}"/>
```

MainWindowViewModel.cs

```C#
private IRegionNavigationJournal _navigationJournal;

private DelegateCommand _backCommand;
public DelegateCommand BackCommand =>
            _backCommand ??= new DelegateCommand(ExecuteBackCommand);

void ExecuteBackCommand()
{   
    if (_navigationJournal is { CanGoBack: true })
    {
        _navigationJournal.GoBack();
    }
}

public MainWindowViewModel(IRegionManager regionManager)
{
    _regionManager = regionManager;
    _openCommand = new DelegateCommand<string>(ExecuteCommandName);
    _backCommand = new DelegateCommand(ExecuteBackCommand);
} 

void ExecuteCommandName(string obj)
 {
     NavigationParameters parameters = new NavigationParameters();

     _regionManager.RequestNavigate("ContentRegion", obj, callback =>
                                    {
                                        if ((bool)callback.Result)
                                            _navigationJournal = callback.Context.NavigationService.Journal;
                                    }, parameters);
     // 通过IRegionManager接口获取全局定义的可用区域
     // 往这个区域以依赖注入的方式去动态设置内容
     //_regionManager.Regions["ContentRegion"].RequestNavigate("ViewA");
 }
```

# Prism对话

MainWindow.xaml

```xaml
<Button Content="Dialog" Command="{Binding DialogCommand}" CommandParameter="ViewDialog"/>
```

MainWindowViewModel.cs

```C#
private string _value = "value";

private IDialogService _dialogService;

private DelegateCommand<string> _dialogCommand;
public DelegateCommand<string> DialogCommand =>
    _dialogCommand ??= new DelegateCommand<string>(ExecuteDialogCommand);

void ExecuteDialogCommand(string obj)
{
    _dialogService.ShowDialog(obj, new DialogParameters{{nameof(Title), "parm"}}, callback =>
                              {
                                  if (callback.Result == ButtonResult.OK)
                                      Title = "I get Dialog reply => OK" + callback.Parameters.GetValue<string>(_value);
                                  if (callback.Result == ButtonResult.No)
                                      Title = "I get Dialog reply => No" + callback.Parameters.GetValue<string>(_value);
                                  if (callback.Result == ButtonResult.None)
                                      Title = "I get Dialog reply => None" + callback.Parameters.GetValue<string>(_value);

                              });
}

public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
{
    _regionManager = regionManager;
}
```

ModuleA新建ViewDialog.xaml

```xaml
<UserControl.Resources>
    <Style TargetType="{x:Type Button}">
        <Setter Property="Height" Value="50"/>
        <Setter Property="Width" Value="100"/>
        <Setter Property="Margin" Value="20, 10"/>
    </Style>
</UserControl.Resources>
<Grid Background="Wheat" Height="176" Width="359">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"></RowDefinition>
        <RowDefinition></RowDefinition>
        <RowDefinition Height="Auto"></RowDefinition>
    </Grid.RowDefinitions>

    <TextBlock Text="I am Dialog"/>
    <TextBlock Grid.Row="1" Text="{Binding Title}"/>
    <DockPanel Grid.Row="2" LastChildFill="False" HorizontalAlignment="Right">
        <Button Content="确定" Command="{Binding ConfirmCommand}"/>
        <Button Content="取消" Command="{Binding ConcelCommand}"/>
    </DockPanel>
</Grid>
```

ModuleA新建View DialogViewModel.cs

```C#
internal class ViewDialogViewModel : BindableBase, IDialogAware
{
    /// <summary>
    /// 调用RequestClose后即需要弹窗关闭时触发
    /// </summary>
    public bool CanCloseDialog() { return true; }

    public void OnDialogClosed()
    {
        RequestClose?.Invoke(new DialogResult(ButtonResult.None, new DialogParameters { { _value, "nope"}}));
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Title = parameters.GetValue<string>(nameof(Title));
    }

    public string Title { get; set; }
    
    // 弹窗关闭的委托
    public event Action<IDialogResult> RequestClose;

    private string _value = "value";

    private DelegateCommand _confirmCommand;
    public DelegateCommand ConfirmCommand => _confirmCommand ??= new DelegateCommand(ExecuteConfirmCommand);

    void ExecuteConfirmCommand()
    {
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK, new DialogParameters { { _value, "OK" } }));
    }

    private DelegateCommand _concelCommand;
    public DelegateCommand ConcelCommand => _concelCommand ??= new DelegateCommand(ExecuteConcelCommand);

    void ExecuteConcelCommand()
    {
        RequestClose?.Invoke(new DialogResult(ButtonResult.No, new DialogParameters { { _value, "No" } }));
    }

    public ViewDialogViewModel()
    {
        _concelCommand = new DelegateCommand(ExecuteConcelCommand);
        _confirmCommand = new DelegateCommand(ExecuteConfirmCommand);
    }
}
```

ModuleAProfile.cs

```C#
public void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterDialog<ViewDialog, ViewDialogViewModel>();
}
```

# Prism订阅

在ModuleA下新建Event文件夹，文件夹内新建MessageEvent.cs

```C#
public class MessageEvent : PubSubEvent<string>
{
}
```

ViewAViewModel.cs，发布订阅

```C#
private readonly IEventAggregator _aggregator;

public ViewAViewModel(IEventAggregator aggregator)
{
    Message = "View A from your Prism Module";
    _aggregator = aggregator;
}

// Somewhere publish
_aggregator.GetEvent<MessageEvent>().Publish("Hello");
```

ViewA.xaml.cs，收到信息后取消订阅

```C#
public partial class ViewA : UserControl
{
    private IEventAggregator _aggregator;

    public ViewA(IEventAggregator aggregator)
    {
        InitializeComponent();
        _aggregator = aggregator;
        aggregator.GetEvent<MessageEvent>().Subscribe(SubMsg);
    }

    private void SubMsg(string arg)
    {
        MessageBox.Show(arg);
        _aggregator.GetEvent<MessageEvent>().Unsubscribe(SubMsg);
    }
}
```



# Attention

---

## x:Name和x:Key

XAML的标签声明的是对象，一个XAML标签会对应着一个对象，这个对象一般是一个控件类的实例。

### x:Name的作用有两个：

（1）告诉XAML编译器，当一个标签带有x:Name时，除了为这个标签生成对应实例外，还要为这个实例声明一个引用变量，变量名就是x:Name的值。

（2）将XAML标签所对应对象的Name属性（如果有）也设为x:Name的值，并把这个值注册到UI树上，以方便查找。

Name属性定义在FrameworkElement类中，这个类是WPF控件的基类，所以所有WPF控件都具有Name这个属性。当一个元素具有Name属性时，使用Name或x:Name效果是一样的。Name和x:Name是可以互换的，只是不能同时出现在一个元素中。因为x:Name的功能涵盖了Name属性的功能，所以全部使用x:Name以增强代码的统一性和可读性。

### x:Key的作用是为资源贴上用于检索的索引。

在WPF中，几乎每个元素都有自己的Resources属性，这个属性是个“Key-Value”式的集合，只要把元素放进这个集合，这个元素就成为资源字典中的一个条目，当然，为了能够检索到这个条件，就必须为它添加x:Key。

```xaml
<Window .......>
	<Window.Resources>
        <sys:String x:Key="myString">Hello WPF Resource!</sys:String>
    </Window.Resources>
    <StackPanel>
        <TextBox Text="{StaticResource ResourceKey=myString}"/>
    </StackPanel>
</Window >
```

区别：

x:Key用在XAML Resources，ResourceDictionary需要key来访问。
x:Name用在ResourceDictionary以外任何地方，可以使用x:Name在code-behind访问对象。
x：Key唯一地标识作为资源创建和引用且存在于 ResourceDictionary 中的元素。
x:Name 唯一标识对象元素，以便于从代码隐藏或通用代码中访问实例化的元素。 
x:key和x:name的区别，前者是为XAML中定义的资源文件提供唯一的标识，后者是为XAML中定义的控件元素提供唯一标识。

