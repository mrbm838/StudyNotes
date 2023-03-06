---
created: 2023-02-28T09:28:53 (UTC +08:00)
tags: []
source: https://www.bbsmax.com/A/kmzL18kGJG/
author: 
---

# 对C# 中Readonly的再认识

> ## Excerpt
> 

---
[![](https://bkqsimg.ikafan.com/upload/chatgpt-s.png?!)](https://www.niugongju.com/chatgpt-acount.html "点此去淘宝店购买")

C#中有两种常量类型，分别为readonly(运行时常量)与const(编译时常量)，本文将就这两种类型的不同特性进行比较并说明各自的适用场景。

**工作原理**  
    readonly为运行时常量，程序运行时进行赋值，赋值完成后便无法更改，因此也有人称其为只读变量。  
    const为编译时常量，程序编译时将对常量值进行解析，并将所有常量引用替换为相应值。  
    下面声明两个常量：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public static readonly int A = 2; //A为运行时常量  
![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public const int B = 3; //B为编译时常量

下面的表达式：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)int C = A + B;

经过编译后与下面的形式等价：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)int C = A + 3;

可以看到，其中的const常量B被替换成字面量3，而readonly常量A则保持引用方式。

**声明及初始化**  
    readonly常量只能声明为类字段，支持实例类型或静态类型，可以在声明的同时初始化或者在构造函数中进行初始化，初始化完成后便无法更改。  
    const常量除了可以声明为类字段之外，还可以声明为方法中的局部常量，默认为静态类型(无需用static修饰，否则将导致编译错误)，但必须在声明的同时完成初始化。  
**  
数据类型支持**  
    由于const常量在编译时将被替换为字面量，使得其取值类型受到了一定限制。const常量只能被赋予数字(整数、浮点数)、字符串以及枚举类型。下面的代码无法通过编译：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public const DateTime D = DateTime.MinValue;

改成readonly就可以正常编译：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public readonly DateTime D = DateTime.MinValue;

**  
可维护性**  
    readonly以引用方式进行工作，某个常量更新后，所有引用该常量的地方均能得到更新后的值。  
    const的情况要稍稍复杂些，特别是跨程序集调用：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public class Class1  
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif){  
![](https://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    public static readonly int A = 2; //A为运行时常量  
![](https://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    public const int B = 3; //B为编译时常量  
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockEnd.gif)}  
![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)  
![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public class Class2  
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif){  
![](https://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    public static int C = Class1.A + Class1.B; //变量C的值为A、B之和   
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockEnd.gif)}  
![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)  
![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)Console.WriteLine(Class2.C); //输出"5"

假设Class1与Class2位于两个不同的程序集，现在更改Class1中的常量值：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public class Class1  
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif){  
![](https://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    public static readonly int A = 4; //A为运行时常量  
![](https://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    public const int B = 5; //B为编译时常量  
![](https://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockEnd.gif)}

编译Class1并部署（注意：这时并没有重新编译Class2），再次查看变量C的值：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)Console.WriteLine(Class2.C); //输出"7"

结果可能有点出乎意料，让我们来仔细观察变量C的赋值表达式：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public static int C = Class1.A + Class1.B;

编译后与下面的形式等价：

![](https://www.cnblogs.com/Images/OutliningIndicators/None.gif)public static int C = Class1.A + 3;

因此不管常量B的值如何变，对最终结果都不会产生影响。虽说重新编译Class2即可解决这个问题，但至少让我们看到了const可能带来的维护问题。

**性能比较**  
    const直接以字面量形式参与运算，性能要略高于readonly，但对于一般应用而言，这种性能上的差别可以说是微乎其微。

**适用场景  
**    在下面两种情况下：  
    a.取值永久不变(比如圆周率、一天包含的小时数、地球的半径等)  
    b.对程序性能要求非常苛刻  
    可以使用const常量，除此之外的其他情况都应该优先采用readonly常量。

## [对C# 中Readonly的再认识](http://www.cnblogs.com/zhaodayou/p/3195414.html)

　很多人知道readonly 和 const 以及他们的区别和联系，本文只要对readonly 的一个小特性进行记录，属于读书笔记吧

请看如下代码

```
    public sealed class AType    {        public static readonly Char[] TestChars = new Char[] {'A', 'B', 'C'};    }
```

　　这句代码很简单 我只是对静态只读字段TestChars赋初始值。这时候如果我问你我现在可以改变TestChars的值吗，你肯定会回答当然不可以，真的是这样吗，请仔细思考下.

请看如下代码

![](https://common.cnblogs.com/images/copycode.gif)

```
    class Program    {        static void Main(string[] args)        {            AType.TestChars[0] = 'X';            AType.TestChars[1] = 'Y';            AType.TestChars[2] = 'Z';            Console.WriteLine(AType.TestChars[0]);            Console.Read();        }    }
```

![](https://common.cnblogs.com/images/copycode.gif)

　　这个输出结果是什么呢，是编译的时候报错还是会输出修改后的值“X”呢 答案是输出为“X”

　　在看如下代码

![](https://common.cnblogs.com/images/copycode.gif)

```
    class Program    {        static void Main(string[] args)        {            AType.TestChars = new Char[] {'X', 'Y', 'Z'};            Console.WriteLine(AType.TestChars[0]);            Console.Read();        }    }
```

![](https://common.cnblogs.com/images/copycode.gif)

　　这个输出结果又是什么呢。。。 答案是编译出错提示“无法对静态只读字段赋值”

　　看到这里，我想大家都明白了：当某个字段是引用类型，并且该字段标记为readonly时，那么不可改变的是引用，而非字段引用的对象.

## [对C# 中Readonly的再认识的更多相关文章](https://www.bbsmax.com/R/kmzL18kGJG/)

1.  [关于C#中readonly](https://www.bbsmax.com/A/x9J2W7ye56/)
    
    关于C#中readonly的一点小研究 关于C#中readonly的一点小研究   可能园子里有不少文章已经说明了这个问题了,但是我在这里写这篇博客只是写写自己的一些体会,也权当是整理归纳,高手莫见笑 ...
    
2.  [winform中button点击后再点击其他控件致使button失去焦点，此时button出现黑色边线，去掉黑色边线的方法](https://www.bbsmax.com/A/E35po1RAJv/)
    
    winform中button点击后再点击其他控件致使button失去焦点,此时button出现黑色边线,去掉黑色边线的方法 button的FlatAppearence属性下,设置BorderSize= ...
    
3.  [关于C#中readonly的一点小研究](https://www.bbsmax.com/A/gGdXM1pz4m/)
    
    可能园子里有不少文章已经说明了这个问题了,但是我在这里写这篇博客只是写写自己的一些体会,也权当是整理归纳,高手莫见笑. ===============正文分割线================== 现 ...
    
4.  [Spring 事务中 readOnly 的解释](https://www.bbsmax.com/A/Vx5MxYr7JN/)
    
      spring 中事务的PROPAGATION\_REQUIRED,Readonly的解释  (2012-11-21 16:29:38) 转载▼ 标签:  杂谈                  一. ...
    
5.  [小鱼提问2 属性访问器中get,set再用public修饰行吗，private呢？](https://www.bbsmax.com/A/KE5QOPLMzL/)
    
    /// <summary> /// 是否有一个用户正在连接服务器中 /// </summary> public bool IsConnectting { get { retur ...
    
6.  [python+opencv选出视频中一帧再利用鼠标回调实现图像上画矩形框](https://www.bbsmax.com/A/kPzOQ84o5x/)
    
    最近因为要实现模板匹配,需要在视频中选中一个目标,然后框出(即作为模板),对其利用模板匹配的方法进行检测.于是需要首先选出视频中的一帧,但是在利用摄像头读视频的过程中我唯一能想到的方法就是: 1.在视 ...
    
7.  [Q他中的乱码再理解](https://www.bbsmax.com/A/kjdwDDp2zN/)
    
    Qt版本有用4的版本的也有用5的版本,并且还有windows与linux跨平台的需求. 经常出现个问题是windows的解决了,源代码放到linux上编译不通过或者中文会乱码,本文主要是得出一个解决方 ...
    
8.  [IOS中录音后再播放声音太小问题解决](https://www.bbsmax.com/A/pRdB6rw9dn/)
    
    1.AVAudioSessionCategory说明 1.1 AVAudioSessionCategoryAmbient 或 kAudioSessionCategory\_AmbientSound 用于 ...
    
9.  [PL/SQL中复制中文再粘贴出现乱码问题的解决【转】](https://www.bbsmax.com/A/kmzL71lYdG/)
    
    前不久!我对我的windowsxp做了一番大规模的设置:包括区域.系统.网络等方面的,结果当我设置完成以后,发现如果我从一些软件上复制内容到记事本里面会出现乱码,而且如果复制到word里面也不能够正常 ...
    

## 随机推荐

1.  [Web API 2：Action的返回类型](https://www.bbsmax.com/A/x9J2Wk2K56/)
    
    Web API 2:Action的返回类型 Web API控制器中的Action方法有如下几种返回类型: void HttpResponseMessage IHttpActionResult 其它类型 ...
    
2.  [Require.JS 2.0](https://www.bbsmax.com/A/n2d9pGVQ5D/)
    
    就在前天晚上RequireJS发布了一个大版本,直接从version1.0.8升级到了2.0.随后的几小时James Burke又迅速的将版本调整为2.0.1,当然其配套的打包压缩工具r.js也同时升 ...
    
3.  [LeetCode——Longest Palindromic Substring](https://www.bbsmax.com/A/gGdXGBn754/)
    
    Given a string S, find the longest palindromic substring in S. You may assume that the maximum lengt ...
    
4.  [How to: Installshield做安装包时如何添加文件](https://www.bbsmax.com/A/qVdeyNA8dP/)
    
    原文:How to: Installshield做安装包时如何添加文件 我一直以为这不是一个问题,可是没想到在几个群内,对于如何向安装包添加文件不解的大有人在,今日稍暇,整理成篇,以供参考 首先我想再 ...
    
5.  [ActiveReports 9实战教程（1）： 手把手搭建环境Visual Studio 2013 社区版](https://www.bbsmax.com/A/amd06vG2Jg/)
    
    原文:ActiveReports 9实战教程(1): 手把手搭建环境Visual Studio 2013 社区版 ActiveReports 9刚刚发布3天,微软就发布了 Visual Studio ...
    
6.  [MVC+Bootstrap设计](https://www.bbsmax.com/A/nAJvmv33zr/)
    
    MVC+Bootstrap) 二 框架设计 文章目录: 一.前言 二.结构图 三.项目搭建 四.代码生成 五.实现接口 六.依赖倒置 七.登录实现 八.最后 一.前言 这个框架是从最近几年做过的项目中 ...
    
7.  [June本地环境搭建](https://www.bbsmax.com/A/xl563G2kdr/)
    
    python-china.org论坛使用的June程序就是这货了,使用了Python Flask + SQLite + Node.js 的轻论坛,以后就打算拿这个学习了,如果可能,进行二次开发. Gi ...
    
8.  [Elegant Box主题wpdb::prepare() 报错\[已解决\]](https://www.bbsmax.com/A/GBJrWrjE50/)
    
    整理书签,发现个网页,是解决Elegant Box主题与新版Wordpress3.5主题不兼容的(3.5改了一个函数的参数个数所致).记得当时使用NeoEase出的主题的时候两次遇到这个问题,费了点功 ...
    
9.  [Retrofit相关资料](https://www.bbsmax.com/A/1O5EpYp3J7/)
    
    高速Android开发系列网络篇之Retrofithttp://www.w3c.com.cn/%E5%BF%AB%E9%80%9Fandroid%E5%BC%80%E5%8F%91%E7%B3%BB% ...
    
10.  [.net的页面在大并发下出现503错误](https://www.bbsmax.com/A/n2d9pY2Y5D/)
    
    .net的页面在大并发下偶尔出现503错误 我们开发了一个回调页面,由一个工具负责调用,由于压力非常大,回调页面通过6台服务器负载均衡的: 最近业务系统又再次扩容,回调页面压力成倍增加,在高峰时间段偶 ...
