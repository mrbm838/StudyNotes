---
created: 2023-01-23T16:35:56 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/zh7791/p/11369020.html
author: 痕迹g
            粉丝 - 2350
            关注 - 4
---

# WPF布局介绍(1) - 痕迹g - 博客园

> ## Excerpt
> 学习平台 微软开发者博客: https://devblogs.microsoft.com/?WT.mc_id=DT-MVP-5003986 微软文档与学习: https://docs.microsof

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
    > [![](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161544750-1520158829.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161544750-1520158829.png)
    
-   WrapPanel
    
    > WrapPanel默认排列方向与StackPanel相反、WrapPanel的Orientation默认为Horizontal。  
    > WrapPanel具备StackPanel的功能基础上具备在尺寸变更后自动适应容器的宽高进行换行换列处理。  
    > [![](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161524178-1524938850.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161524178-1524938850.png)
    
-   DockPanel
    
    > 默认DockPanel中的元素具备DockPanel.Dock属性, 该属性为枚举具备: Top、Left、Right、Bottom。  
    > 默认情况下, DockPanel中的元素不添加DockPanel.Dock属性, 则系统则会默认添加 Left。  
    > DockPanel有一个LastChildFill属性, 该属性默认为true, 该属性作用为, 当容器中的最后一个元素时, 默认该元素填充DockPanel所有空间。  
    > [![](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161456533-237089632.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161456533-237089632.png)
    
-   Grid
    
    > 学过web的老弟应该知道table表格, 而Grid与其类似, Grid具备分割空间的能力。  
    > RowDefinitions / ColumnDefinitions 用于给Grid分配行与列。  
    > ColumnSpan / RowSpan 则用于设置空间元素的 跨列与阔行。  
    > [![](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161655841-623745756.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161655841-623745756.png)
    

[![](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161120357-1187850216.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190817161120357-1187850216.png)

-   Canvas
    
    > 该容器就相当于一个 "地图", 包含内的所有控件元素, 则都通过使用XY来定位, 由于不太常用, 所以简单掠过。

# WPF控件介绍(2) - 痕迹g - 博客园

> ## Excerpt
>
> 学习平台 微软开发者博客: https://devblogs.microsoft.com/?WT.mc_id=DT-MVP-5003986 微软文档与学习: https://docs.microsof

---

## 学习平台

微软开发者博客:  
[https://devblogs.microsoft.com/?WT.mc\_id=DT-MVP-5003986](https://devblogs.microsoft.com/?WT.mc_id=DT-MVP-5003986)  
微软文档与学习:  
[https://docs.microsoft.com/zh-cn/?WT.mc\_id=DT-MVP-5003986](https://docs.microsoft.com/zh-cn/?WT.mc_id=DT-MVP-5003986)  
微软开发者平台:  
[https://developer.microsoft.com/en-us/?WT.mc\_id=DT-MVP-5003986](https://developer.microsoft.com/en-us/?WT.mc_id=DT-MVP-5003986)

上一章讲到了布局、这点就有点类似建筑设计、第一步是出图纸、整体的结构、而第二步就是堆砌, 建筑学里面也会有很多描述, 例如砖头，水泥、玻璃、瓷板。而在WPF中, 这一切的基础也就是控件、用于填充结构的UI控件。

## WPF的控件结构

[![](E:\Gitee\Backup\Image\CopyInsert\1161656-20210126175728356-1415069891.png)](https://img2020.cnblogs.com/blog/1161656/202101/1161656-20210126175728356-1415069891.png)

## 各种控件类型详解

-   ContentControl 类

    > 设置内容的属性为 Content, 例如  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150726348-1929076279.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150726348-1929076279.png)

    > 控件目录下只允许设置一次Content, 如下演示给按钮添加一个Image和一个文本显示Label, 错误如下:  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150743990-856447061.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150743990-856447061.png)

    正确的使用方式:  
    <!利用我们上一章说讲到的布局容器装载在其中, 则可避免这种情形>  
    [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150756835-1985550844.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150756835-1985550844.png)

-   HeaderedContentControl 类

    > 相对于ContentControl来说、这类控件即可设置Content, 还有带标题的Header。  
    > 像比较常见的分组控件GroupBox、TabControl子元素TabItem、它们都是具备标题和内容的控件。  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150823403-463390781.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150823403-463390781.png)

    > 同样,该类控件目录下只允许设置一次Conent和Header, 如下错误所示, 出现2次设置Header与Content报错:  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150841291-566061376.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150841291-566061376.png)

    正确的使用方式:  
    [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150856693-362303989.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150856693-362303989.png)

-   ItemsControl 类

    > 此类控件大多数属于显示列表类的数据、设置数据源的方式一般通过 ItemSource 设置。如下所示:  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150915320-1223545686.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150915320-1223545686.png)

-   重点常用的控件介绍:

    > TextBlock: 用于显示文本, 不允许编辑的静态文本。 Text设置显示文本的内容。  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150925643-1051510891.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150925643-1051510891.png)

    > TextBox: 用于输入/编辑内容的控件、作用与winform中TextBox类似, Text设置输入显示的内容。  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150937134-1406189370.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150937134-1406189370.png)

    > Button: 简单按钮、Content显示文本、Click可设置点击事件、Command可设置后台的绑定命令  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818150948518-328432923.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818150948518-328432923.png)

    > ComboBox: 下拉框控件, ItemSource设置下拉列表的数据源, 也可以显示设置, 如下  
    > [![](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818151000803-1439734910.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818151000803-1439734910.png)

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

#### 下面的例子中, 给4个TextBlock设置同样的样式: 字体、字体大小、字体颜色、加粗设置。

效果图与实际代码如下所示:
[![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818153823767-950889666.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818153823767-950889666.png)

[![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818153903397-1500018539.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818153903397-1500018539.png)

- 上面有讲到, 样式是组织和重用的工具。 而上面的代码, 由于每个元素都是相同的, 但是每个元素XAML都重复定义。 下面将介绍通过样式如何优化上面的代码。

  - 第一步: 在Resources目录下定义一个TextBlockStyle的样式, 完整代码如下:

  > Style结构定义了一个 x:key 这点类似于Html中定义id和class, 然后css即可对相应的class和id样式生效。
  > TargetType 的设置为类型TextBlock, 设置目标类型静态文本TextBlock。
  > [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818154635367-1250117512.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818154635367-1250117512.png)

  - 第二步:通过控件的Style属性 来引用x:key 的样式, 代码如下:
    [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818155145848-931439312.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818155145848-931439312.png)

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

  [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818155738633-1715634837.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818155738633-1715634837.png)

[![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818155742067-1853761592.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818155742067-1853761592.png)

# [WPF控件模板(6)](https://www.cnblogs.com/zh7791/p/11421386.html)

## 什么是ControlTemplate?

ControlTemplate(控件模板)不仅是用于来定义控件的外观、样式, 还可通过控件模板的触发器(ControlTemplate.Triggers)修改控件的行为、响应动画等。通过控件，为使用该控件的用户提供了利用属性名设置属性值的接口。

通过剖析控件了解ControlTemplate的组成:

- 首先,创建一个WPF项目, 创建一个Button按钮, 然后选中该按钮, 右键选择编辑模板>编辑副本:
  [![控件模板1](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827231334348-352988198.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827231334348-352988198.png)

- 创建完成后, 会在当前页面<Windows.Resources> 键下面生成一些样式片段 , 一个key为ButtonStyle1的样式:

  ![控件模板2](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827231620239-1837960527.png)

  - 在看到该样式定义了一些基础的样式, 背景颜色、字体颜色、边框大小、垂直水平位置等, 除此之外, 下方则有一个Template的对象, 其中则就是ControlTemplate, 可以看到, ControlTemplate定义了一个Border ,然后其中定义了一个内弄呈现的控件, ContentPresenter则主要用于呈现按钮的显示内容主体, 如下标记:
    [![控件模板3](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827232102889-1193236219.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827232102889-1193236219.png)
  - 我们可以进行一些尝试, 试图修改border的属性, 观察Button会发生怎样的变化, 通过为Border 添加一个 圆角矩形参数， 将背景颜色设置成固定的值, 如下:
    [![控件模板4](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827232846378-2046149153.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827232846378-2046149153.png)

> 通过简单的尝试,可以观察到, 该Border 作为Button按钮的边缘样式和整体的外观控制。
> \- 接下来, 我们可以通过修改ContentPresenter 中的一些参数, 看看该控件是怎样的一个存在。 修改其中的垂直位置为居下, 为Button设置一个固定Content的值 “Hello”, 观察Hello的位置:
> [![控件模板5](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827233351225-1641545831.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827233351225-1641545831.png)
> 通道实践, 可以了解到, 该内容呈现控件(ContentPresenter) 负责了内容的展示、和一部分属性的控制。

## ControlTemplate中的TemplateBinding 的作用?

> 在ControlTemplate中, 可以看多多次有定义 TemplateBinding 的代码:
> [![控件模板6](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827233953156-960936008.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827233953156-960936008.png)

> TemplateBinding 可以理解为, 通过模板绑定关联到指定的样式、属性。 如此一来 , 当按钮通过显示设置该属性, 则最终会影响着Template绑定的属性值。

> 下面将通过代码演示, 有 TemplateBinding 和 无TemplateBinding 的区别, 在Button按钮中, 显示定义 按钮的边框颜色为 “Blue”, 分别看两者中的影响:

图(1), 有TemplateBinding :
[![控件模板7](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827234635019-215630097.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827234635019-215630097.png)

图(2), 无TemplateBinding:
[![控件模板8](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827234820867-382982022.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827234820867-382982022.png)

> 可以理解, TemplateBinding 主要的作用为, 与外部的属性关系起来, 使其达到改变样式属性的作用。

## ControlTemplate.Triggers 触发器

展开ControlTemplate.Triggers 节点, 可以看到其中定义了一些触发条件和改变的样式。
[![控件模板9](E:\Gitee\Backup\Image\CopyInsert\1161656-20190827235429393-701105681.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190827235429393-701105681.png)

> 可以看到, 定义了4个触发器, 分别满足条件之后, 改变Border的一些样式, 接下来, 通过一张图,来解释其影响的过程:
> [![控件模板10](E:\Gitee\Backup\Image\CopyInsert\1161656-20190828000228349-1414677084.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190828000228349-1414677084.png)

实际效果:
[![控件模板11](E:\Gitee\Backup\Image\CopyInsert\1161656-20190828000346718-885219220.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190828000346718-885219220.gif)

> 同样, 其他的触发器也是通过这样的操作, 来控制着控件的属性变化。

## ControlTemplate.EventTrigger 事件触发器

> 下面定义了一个EventTrigger 事件触发器,
> 当鼠标进入按钮区域时, 执行一个0.5秒的动画, 将按钮的背景颜色设置为 pink,
> 当鼠标离开按钮区域时, 执行一个0.5秒的动画,将按钮的背景颜色设置为Green:
> [![控件模板12](E:\Gitee\Backup\Image\CopyInsert\1161656-20190828001930318-1080236976.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190828001930318-1080236976.png)

实际效果:
[![控件模板13](E:\Gitee\Backup\Image\CopyInsert\1161656-20190828002016060-1592157716.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190828002016060-1592157716.gif)

## 自定义ControlTemplate

> 控件模板可以独立存在, 上面的例子中, 包含在样式文件中, 下面, 单独声明一个独立的控件模板:

- 1.创建一个ControlTemplate ,设定一个键名称, 指定其模板的类型
- 2.创建一个Border 用于设置按钮边样式
- 3.创建一个内容呈现的控件, 设置几个参数的TemplateBinding.
- 4.按钮的Template 绑定该模板
  [![控件模板14](E:\Gitee\Backup\Image\CopyInsert\1161656-20190828213817129-284228633.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190828213817129-284228633.png)

# 触发器介绍

> 顾名思义, 触发器可以理解为, 当达到了触发的条件, 那么就执行预期内的响应, 可以是样式、数据变化、动画等。
> 触发器通过 Style.Triggers集合连接到样式中, 每个样式都可以有任意多个触发器, 并且每个触发器都是 System.Windows.TriggerBase的派生类实例, 以下是触发器的类型

- Trigger : 监测依赖属性的变化、触发器生效
- MultiTrigger : 通过多个条件的设置、达到满足条件、触发器生效
- DataTrigger : 通过数据的变化、触发器生效
- MultiDataTrigger : 多个数据条件的触发器
- EventTrigger : 事件触发器, 触发了某类事件时, 触发器生效。

### Trigger

> 下面以Border为例, 演示一个简单的Trigger触发器。
> 当鼠标进入Border的范围, 改变Border的背景颜色和边框颜色, 当鼠标离开Border的范围, 还原Border的颜色。
> 代码如下所示:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818164101687-1940175933.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818164101687-1940175933.png)
> 实际效果:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818164244329-394440478.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818164244329-394440478.gif)

### MultiTrigger

> 和Trugger类似, MultiTrigger可以设置多个条件满足时, 触发, 下面以TextBox为例, 做一个简单的Demo
> 当鼠标进入文本框的范围, 并且光标设置到TextBox上, 则把TextBox的背景颜色改变成Red
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818165349801-924338192.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818165349801-924338192.png)
> 实际效果:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818165439434-1090965041.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818165439434-1090965041.gif)

### EventTrigger

> 事件触发器, 故... 是的, 当触发了某类事件, 触发器执行响应。
> 下面用实例演示, 为了能直观感受到这类触发器的作用, 用动画演示其功能,下面使用了动画相关的知识, 在学习到
> 后面几个章节, 读者可以进行相关的内容学习。
> 当鼠标进入按钮的范围中, 在0.02秒内, 把按钮的字体变成18号
> 当鼠标离开按钮的范围时, 在0.02秒内, 把按钮的字体变成13号 。 代码及效果如下所示:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818171109021-1737712361.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818171109021-1737712361.png)
> 实际效果:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190818171125495-269065249.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190818171125495-269065249.gif)

结尾: 对于 DataTrigger / MultiDataTrigger 的功能类似, 只不过触发条件变成了以数据的方式为条件, 这块, 需要了解的可以自个儿进行研究, 本章基础的介绍到此结束, 致谢观看！

# WPF数据模板(7) 

> 数据模板常用在3种类型的控件, 下图形式:
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20201228130825259-95107469.png)](https://img2020.cnblogs.com/blog/1161656/202012/1161656-20201228130825259-95107469.png)

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
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190902232222418-286473478.png)](https://img2018.cnblogs.com/blog/1161656/201909/1161656-20190902232222418-286473478.png)

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
> [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190902233151857-415873225.gif)](https://img2018.cnblogs.com/blog/1161656/201909/1161656-20190902233151857-415873225.gif)

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

[![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190903214940232-18576554.png)](https://img2018.cnblogs.com/blog/1161656/201909/1161656-20190903214940232-18576554.png)

**查看ItemsControl可视化树的结构组成?**

[![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190903215240153-1017469948.png)](https://img2018.cnblogs.com/blog/1161656/201909/1161656-20190903215240153-1017469948.png)

> 剖析该结构, 可以看到, 紫色的1处, 为最外层的WrapPanel容器, 用于容纳排列按钮, 由于该示例设置了 Orientation="Horizontal" , 所以按钮则按水平排列, 再看 橘色 2处, 可以看见子项外层由一个内容呈现包括着, 内容为一个按钮, 由于绑定搞得数据是5个, 所以分别生成了内容为1~6的5个按钮。

- 说明: 那是不是以为则ItemsPanel 放置任何元素都行? 很明显是不行的。 ItemsPanel的容器需要满足一个条件, 则是属于Panel族的元素, 否则会提示以下错误:
  [![img](E:\Gitee\Backup\Image\CopyInsert\1161656-20190903215914537-1300261125.png)](https://img2018.cnblogs.com/blog/1161656/201909/1161656-20190903215914537-1300261125.png)

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
  [![绑定1](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819214501647-2078110800.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819214501647-2078110800.png)

在winform中, 我们常规的做法会给滑块创建一个值改变事件,同时将滑块的值赋值给文本。
接下来, 我只需要在静态文本中添加一小段绑定的声明,即可完整原本很复杂的操作:

- Text=
  - {Binding }: Binding的声明语法, 一对尖括号,开头声明以Binding 开始。
  - ElementName= : 该声明意为, 设置元素的名称
  - Path: 设置关联元素的位置,上例中设置为元素的value属性。
  - `UpdateSourceTrigger=PropertyChanged`框内的值一改变立即触发
  - `StringFormat=f3 or StringFormat=0.000`值保留3位小数

那么该如何理解整句话的意义, 翻译: 静态文本TextBlock的Text属性将通过绑定的方式关联到元素名'slider'的value属性上。
[![绑定2](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819214600631-1826073241.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819214600631-1826073241.png)

效果图所示:
[![绑定3](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819214724463-1902775008.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819214724463-1902775008.gif)
可以看到,在滑块不断的滑动过程中, TextBlock也在不断的发生变化, 说明TextBlock已经得到了滑动滑动过程中的值变化, 这种关联, 我们称之为绑定, 在WPF当中, 绑定又分很多种, 而上面这种则是通过元素绑定的方式。
理解了基础的绑定之后,然后就是理解绑定的模式。

> 绑定的模式就类似我们商业中的合作, 是一次性回报还是持续获益, 是否可以单方面终止, 是否具有投票权等, 在WPF中绑定的模式又分为五种:

- OneWay(单向绑定) : 当源属性发生变化更新目标属性, 类似上面的例子中, 滑动变化更新文本的数据。示例:
  [![绑定4](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222321581-1026939165.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222321581-1026939165.png)
  效果:
  [![绑定5](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222407032-1871959888.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222407032-1871959888.gif)
- TwoWay(双向绑定) : 当源属性发生变化更新目标属性, 目标属性发生变化也更新源属性。
  - 与单向绑定的区别可以理解为, 前者只能打你,被打者不能还手, 双向绑定的意思则是: 你敢打我一巴掌,我也能回你一巴掌。示例:
    [![绑定6](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222443371-362946021.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222443371-362946021.png)
    效果:
    [![绑定7](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222522076-739197152.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222522076-739197152.gif)
- OneTime(单次模式) : 根据第一次源属性设置目标属性, 在此之后所有改变都无效。
  - 如第一次绑定了数据源为0, 那么无论后面如何改变 2、3、4... 都无法更新到目标属性上。示例:
    [![绑定8](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222919116-1272854998.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222919116-1272854998.png)
    效果:
    [![绑定9](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819222931138-716324305.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819222931138-716324305.gif)
- OneWayToSource : 和OneWay类型, 只不过整个过程倒置。示例:
  [![绑定10](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819223227346-266371953.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819223227346-266371953.png)
  效果:
  [![绑定11](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819223238353-575794340.gif)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819223238353-575794340.gif)
- Default : 既可以是双向,也可以是单项, 除非明确表明某种模式, 否则采用该默认绑定

## 绑定到属性（非元素）

上面的代码中,使用的绑定方式是根据元素的方式: ElementName=xxx, 如需绑定到一个非元素的对象, 则有一下几属性:

- Source : 指向一个数据源, 示例, TextBox使用绑定的方式用Source指向一个静态资源ABC:
  [![绑定12](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819230231428-1644097176.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819230231428-1644097176.png)
- RelativeSource : 使用一个名为RelativeSource的对象来根据不同的模式查找源对象,

> 示例, 使用RelativeSource的FindAncestor模式, 查找父元素为StackPanel的Width值
> [![绑定13](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819230250748-1015220615.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819230250748-1015220615.png)

- DataContext: 从当前的元素树向上查找到第一个非空的DataContext属性为源对象。

> 示例, 该示例用后台代码创建一个只包含Name的类, Test, 通过绑定窗口的DataContext上下文:
> [![绑定14](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819230309148-1794060341.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819230309148-1794060341.png)

**后台代码绑定简单文本与列表**

> 创建一个PageModel类, 定一个ClassName为班级名称, 和一个Students学生列表, 后台代码:
> [![绑定15](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819232328241-485423530.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819232328241-485423530.png)
> 窗口代码
> [![绑定16](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819232353224-1811144373.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819232353224-1811144373.png)
> 效果预览
> [![绑定17](E:\Gitee\Backup\Image\CopyInsert\1161656-20190819232834855-950383311.png)](https://img2018.cnblogs.com/blog/1161656/201908/1161656-20190819232834855-950383311.png)

------

关于以上, 基本介绍了WPF元素绑定的方式与几种模式, 接下讲的是, WPF中的事件如果通过绑定的方式和UI分离。尽管WPF中仍然可以兼容winform中的事件模型, 而binding也是MVVM架构中的重要组成部分。
