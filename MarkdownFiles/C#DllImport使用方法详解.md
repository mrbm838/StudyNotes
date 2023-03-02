---
created: 2023-03-02T10:37:46 (UTC +08:00)
tags: [dllimport]
source: https://blog.csdn.net/niudongling/article/details/120416823
author: 成就一亿技术人!
---

# (6条消息) C#的DllImport使用方法详解_牛小花❀的博客-CSDN博客

> ## Excerpt
> 1. 托管代码与非托管代码在学习DllImport方法之前，先了解下托管代码和非托管代码的概念。我们编写的C#代码（不只是C#，也包括.net平台上的其他语言，如VB，J#等），首先经过编译器把代码编译成中间语言（IL），当方法被调用时，公共语言运行库CLR把具体的方法编译成适合本地计算机运行的机器码，并且将编译好的机器码缓存起来，以备下次调用使用。托管代码的源代码在运行时分为两个阶段： 源代码编译为托管代码,（源代码可以有很多种，如VB,C#,J#) 托管代码编译为...

---
![](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

[牛小花❀](https://blog.csdn.net/niudongling "牛小花❀") ![](https://csdnimg.cn/release/blogv2/dist/pc/img/newCurrentTime2.png) 于 2021-09-22 17:20:54 发布 ![](https://csdnimg.cn/release/blogv2/dist/pc/img/articleReadEyes2.png) 7858 ![](https://csdnimg.cn/release/blogv2/dist/pc/img/tobarCollectionActive2.png) 已收藏 58

版权声明：本文为博主原创文章，遵循 [CC 4.0 BY-SA](http://creativecommons.org/licenses/by-sa/4.0/) 版权协议，转载请附上原文出处链接和本声明。

## 1\. 托管代码与非托管代码

在学习DllImport方法之前，先了解下托管代码和非托管代码的概念。

我们编写的C#代码（不只是C#，也包括.net平台上的其他语言，如VB，J#等），首先经过[编译器](https://so.csdn.net/so/search?q=%E7%BC%96%E8%AF%91%E5%99%A8&spm=1001.2101.3001.7020)把代码编译成中间语言（IL），当方法被调用时，公共语言运行库CLR把具体的方法编译成适合本地计算机运行的机器码，并且将编译好的机器码缓存起来，以备下次调用使用。

托管代码的源代码在运行时分为两个阶段：      

-   源代码编译为托管代码,（源代码可以有很多种，如VB,C#,J#)      
-   托管代码编译为microsoft的平台专用语言，也叫机器代码

非托管代码，是运行在[公共语言运行库](http://baike.baidu.com/view/159628.htm "公共语言运行库")环境的外部，直接编译成目标计算机码，由操作系统直接执行的代码，代码必须自己提供垃圾回收，类型检查，安全支持等服务。如需要内存管理等服务，必须显示调用操作系统的接口，通常调用Windows SDK所提供的API来实现内存管理。

### **托管代码和非托管代码的区别**

1、托管代码是一种中间语言，运行在CLR上；非托管代码被编译为机器码，运行在机器上。

2、托管代码独立于平台和语言，能更好的实现不同语言平台之间的兼容；非托管代码依赖于平台和语言。

3、托管代码可享受CLR提供的服务（如安全检测、垃圾回收等），不需要自己完成这些操作；非托管代码需要自己提供安全检测、垃圾回收等操作。 

## 2.Dll文件的使用

DLL文件是动态链接库，也叫程序集，是一个包含可由多个程序，同时使用的代码和数据的库。

程序集是在 .NET [公共语言运行库](https://baike.baidu.com/item/%E5%85%AC%E5%85%B1%E8%AF%AD%E8%A8%80%E8%BF%90%E8%A1%8C%E5%BA%93 "公共语言运行库") (CLR) 控制之下运行的逻辑功能单元。程序集实际上是作为 .dll 文件或 .exe 文件存在的。

托管代码生成的DLL文件，可以在VS中直接通过添加引用的方式使用。

非托管代码生成的DLL文件，比如使用C++编写的代码编译生成的DLL，不能在VS中直接引用，可以通过DllImport方法来使用。

## 3.DllImport的基本使用

DllImport是System.Runtime.InteropServices命名空间下的一个属性类，其功能是提供从非托管DLL导出函数的必要调用信息。

其中，引入到C#中的只能是非托管dll中的方法（或者说函数），而不能是数据（或者说变量）

### （1）引入命名空间

```
using System.Runtime.InteropServices;
```

###  （2）创建函数名称

```
[DllImport("demo.dll")]public static extern bool OpenDemo();
```

其中：

修饰符static和extern是必不可少的（extern外部修饰符，常与DllImport属性一起使用，用于支持在外部实现方法）

最少要提供包含入口点的dll的名称

### （3）DllImportAttribute属性用法

```
[AttributeUsage(AttributeTargets.Method)] class DllImportAttribute: System.Attribute{lic DllImportAttribute(string dllName) {…}    //定位参数为dllNamelic CallingConvention CallingConvention;      //入口点调用约定lic CharSet CharSet;                              //入口点采用的字符接lic string EntryPoint;                //入口点名称lic bool ExactSpelling;               //是否必须与指示的入口点拼写完全一致，默认falselic bool PreserveSig;                 //方法的签名是被保留还是被转换lic bool SetLastError;                //FindLastError方法的返回值保存在这里lic string Value { get {…} }}
```

## 4.DllImport详解

### DllImport的使用规范：

（1）DllImport只能放置在方法声明上。  
（2）DllImport具有单个定位参数：指定包含被导入方法的 dll 名称的 dllName 参数。  
（3）DllImport具有五个命名参数：  
　a、CallingConvention 参数指示入口点的调用约定。如果未指定 CallingConvention，则使用默认值 CallingConvention.Winapi。  
　b、CharSet 参数指示用在入口点中的字符集。如果未指定 CharSet，则使用默认值 CharSet.Auto。  
　c、EntryPoint 参数给出 dll 中入口点的名称。如果未指定 EntryPoint，则使用方法本身的名称。  
　d、ExactSpelling 参数指示 EntryPoint 是否必须与指示的入口点的拼写完全匹配。如果未指定 ExactSpelling，则使用默认值 false。  
　e、PreserveSig 参数指示方法的签名应当被保留还是被转换。当签名被转换时，它被转换为一个具有 HRESULT 返回值和该返回值的一个名为 retval 的附加输出参数的签名。如果未指定 PreserveSig，则使用默认值 true。  
　f、SetLastError 参数指示方法是否保留 Win32"上一错误"。如果未指定 SetLastError，则使用默认值 false。  
（4）它是一次性属性类。  
（5）此外，用 DllImport 属性修饰的方法必须具有 extern 修饰符。

### **Dll引用路径**

  (1)exe运行程序所在的目录

  (2)System32目录

  (3)环境变量目录

  (4)自定义路径，如：DllImport(@"C:\\OJ\\Bin\\Judge.dll")
