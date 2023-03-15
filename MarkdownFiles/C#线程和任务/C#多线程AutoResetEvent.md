---
created: 2023-01-20T16:16:00 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/yifengjianbai/p/5463350.html
author: 依封剑白
            粉丝 - 12
            关注 - 0
        
    
    
    
    
                +加关注
---

# 多线程AutoResetEvent - 依封剑白 - 博客园

> ## Excerpt
> 多线程基础，AutoResetEvent和ManualResetEvent的基本用法

---
> 我们在线程编程的时候往往会涉及到线程的通信，通过信号的接受来进行线程是否阻塞的操作。
>
> ## AutoResetEvent概念
>
> - AutoResetEvent对象用来进行线程同步操作，AutoResetEvent类继承waitHandle类。waitOne()方法就继承来自waitHandle类。
> - AutoResetEvent对象有终止和非终止两种状态，终止状态是线程继续执行，非终止状态使线程阻塞，可以调用set和reset方法使对象进入终止和非终止状态。-》可以简单理解如果AutoResetEvent对象是终止状态，就像不管别人了，任你撒野去（waitOne()得到的都是撒野信号）
> - AutoResetEvent顾名思义，其对象在调用一次set之后会自动调用一次reset，进入非终止状态使调用了等待方法的线程进入阻塞状态。-》可以简单理解如果AutoResetEvent对象是非终止状态，就开始管理起别人来了，此时waitOne()得到的信号都是呆在原地不动信号。
> - waitHandle对象的waitone可以使当前线程进入阻塞状态，等待一个信号。直到当前 waitHandle对象收到信号，才会继续执行。
> - set可以发送一个信号，允许一个调用waitone而等待线程继续执行。 ManulResetEvent的set方法可以允许多个。但是要手动关闭，即调用reset()；
> - reset可以使因为调用waitone() 而等待线程都进入阻塞状态。
>
> ## AutoResetEvent主要方法及实践
>
> 1. AutoResetEvent(bool initialState)：构造函数，用一个指示是否将初始状态设置为终止的布尔值初始化该类的新实例。 false：无信号，子线程的WaitOne方法不会被自动调用 true：有信号，子线程的WaitOne方法会被自动调用
> 2. Reset ()：修改bool值为false，将事件状态设置为非终止状态，导致线程阻止；如果该操作成功，则返回true；否则，返回false。
> 3. Set ()：修改bool值为true，将事件状态设置为终止状态，允许一个或多个等待线程继续；如果该操作成功，则返回true；否则，返回false。
> 4. WaitOne()： 阻止当前线程，直到收到信号。
> 5. WaitOne(TimeSpan, Boolean) ：阻止当前线程，直到当前实例收到信号，使用 TimeSpan 度量时间间隔并指定是否在等待之前退出同步域。
>
> **AutoResetEvent** 允许线程通过发信号互相通信。通常，此通信涉及线程需要独占访问的资源。
>
> **AutoResetEvent** 的方法有很多，具体方法和扩展方法请详见[AutoResetEvent类](https://msdn.microsoft.com/zh-cn/library/system.threading.autoresetevent.aspx)，最常用方法中就有Set()和WaitOne()。
>
> 线程通过调用 **AutoResetEvent** 上的 WaitOne 来等待信号。如果 **AutoResetEvent** 处于非终止状态，则该线程阻塞，并等待当前控制资源的线程通过调用 Set 发出资源可用的信号。**AutoResetEvent** 的非终止状态可以通过构造函数在设置：
>
> ```C#
> static AutoResetEvent myResetEvent = new AutoResetEvent(false);
> ```
>
> 这里构造函数中的参数false就代表该状态为非终止状态，相反若为true则为终止状态。
>
> 通俗的来讲只有等myResetEven.Set()成功运行后,myResetEven.WaitOne()才能够获得运行机会;Set是发信号，WaitOne是等待信号，只有发了信号，  
> 等待的才会执行。如果不发的话，WaitOne后面的程序就永远不会执行。下面我们来举一个例子：
>
> ```C#
> public class Program
>  {
>      static AutoResetEvent myResetEvent = new AutoResetEvent(false);
>      const int cycleNum = 5;
>      static void Main(string[] args)
>      {
>          Thread td = new Thread(new ThreadStart(sqrt));
>          td.Name = "线程一";
>          td.Start();
>          Console.ReadKey();
>      }
>      /// <summary>
>      /// 计算平方
>      /// </summary>
>      /// <param name="i"></param>
>      public static void sqrt()
>      {
>          myResetEvent.WaitOne();
>          Console.WriteLine(DateTime.Now.ToShortTimeString() + "线程一执行");
>          Thread.Sleep(500);
>      }
>  }
> ```
>

> 上面例子中一开始非终止状态，当遇到WaitOne()方法时则会阻塞线程，在没有set()时将一直处于阻塞状态，运行结果如下：
>
> [![QQ20160505194632_thumb5](https://images2015.cnblogs.com/blog/781791/201605/781791-20160505210027232-472735132.png "QQ20160505194632_thumb5")](http://images2015.cnblogs.com/blog/781791/201605/781791-20160505210026451-209239192.png)
>
> 接下来我们在主函数中执行Set()方法来解放被阻塞的线程：
>
> ```C#
> public class Program
>  {
>      static AutoResetEvent myResetEvent = new AutoResetEvent(false);
>      const int cycleNum = 5;
>      static void Main(string[] args)
>      {
>          Thread td = new Thread(new ThreadStart(sqrt));
>          td.Name = "线程一";
>          td.Start();
>          myResetEvent.Set();//WaitOne方法阻塞，Set()方法执行后则继续执行
>          Console.ReadKey();
>      }
>      /// <summary>
>      /// 计算平方
>      /// </summary>
>      /// <param name="i"></param>
>      public static void sqrt()
>      {
>          myResetEvent.WaitOne();
>          Console.WriteLine(DateTime.Now.ToShortTimeString() + "线程一执行");
>          Thread.Sleep(500);
>      }
>  }
> ```
>
> 运行结果如下：
>
> [![image_thumb1](https://images2015.cnblogs.com/blog/781791/201605/781791-20160505210028701-714764502.png "image_thumb1")](http://images2015.cnblogs.com/blog/781791/201605/781791-20160505210027966-429794917.png)

**奇数偶数交替输出的例子**

```c#
 //若要将初始状态设置为终止，则为 true；若要将初始状态设置为非终止，则为 false
static AutoResetEvent oddResetEvent = new AutoResetEvent(false);
static AutoResetEvent evenResetEvent = new AutoResetEvent(false);
static int i = 0;
static void Main(string[] args)
{
    //ThreadStart是个委托
    Thread thread1 = new Thread(new ThreadStart(show));
    thread1.Name = "偶数线程";
    Thread thread2 = new Thread(new ThreadStart(show));
    thread2.Name = "奇数线程";
    thread1.Start();
    Thread.Sleep(2); //保证偶数线程先运行。
    thread2.Start();
    Console.Read();

}
public static void show()
{
    while (i <= 100)
    {
        int num = i % 2;
        if (num == 0)
        {
            Console.WriteLine("{0}:{1} {2}  ", Thread.CurrentThread.Name, i++, "evenResetEvent");
            if(i!=1) evenResetEvent.Set(); 
            oddResetEvent.WaitOne(); //当前线程阻塞

        }
        else
        {  
            Console.WriteLine("{0}:{1} {2} ", Thread.CurrentThread.Name, i++, "oddResetEvent");
            //如果此时AutoResetEvent 为非终止状态，则线程会被阻止，并等待当前控制资源的线程通过调用 Set 来通知资源可用。否则不会被阻止
            oddResetEvent.Set();
            evenResetEvent.WaitOne();
        }
    }
}
```



___

既然说到了**AutoResetEvent，**就不得不说**ManualResetEvent**，这两个方法几乎相同，不同的地方就在于**AutoResetEvent**的WaitOne()方法执行后会自动又将信号置为不发送状态也就是阻塞状态，当再次遇到WaitOne()方法是又会被阻塞，而**ManualResetEvent**则不会，只要线程处于非阻塞状态则无论遇到多少次WaitOne()方法都不会被阻塞，除非调用ReSet()方法来手动阻塞线程。这里就不截图运行结果了，有兴趣的朋友可以自己试一试。

本博客不保证所有信息全部正确，有错误还希望指出。

作者：[依封剑白](http://www.cnblogs.com/yifengjianbai)  
出处：[多线程AutoResetEvent](http://www.cnblogs.com/yifengjianbai/p/5463350.html "学习：多线程之AutoResetEvent")  
本文版权归作者和博客园共有，欢迎转载，但未经作者同意必须保留此段声明，且在文章页面明显位置给出原文连接，否则保留追究法律责任的权利。如有问题或建议，请多多赐教，非常感谢。
