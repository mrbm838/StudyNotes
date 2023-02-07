---
created: 2023-01-20T23:14:17 (UTC +08:00)
tags: [c#任务和线程]
source: https://blog.csdn.net/niechaoya/article/details/103984097
author: 
---

# C# 任务和线程的区别_begeneral的博客-CSDN博客_c#任务和线程

> ## Excerpt
> 任务即Task类，线程即Thread类。使用任务执行并行和并发代码是微软强烈推荐的，因为任务比线程的抽象级别更高，而且任务是并行的。关于并发和并行的区别，这里就不做介绍了，网上有很多资料。1、线程池创建任务的基本原理是使用线程池，也就是说任务最终也是要交给线程去执行的。但是微软优化了任务的线程池，使线程的控制更加精准和高效。对于需要频繁创建线程的程序来说，使用线程池无疑是最好的选择。因...

---
![](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

版权声明：本文为博主原创文章，遵循 [CC 4.0 BY-SA](http://creativecommons.org/licenses/by-sa/4.0/) 版权协议，转载请附上原文出处链接和本声明。

任务即Task类，线程即[Thread类](https://so.csdn.net/so/search?q=Thread%E7%B1%BB&spm=1001.2101.3001.7020)。

使用任务执行并行和并发代码是微软强烈推荐的，因为任务比线程的抽象级别更高，而且任务是并行的。关于并发和并行的区别，这里就不做介绍了，网上有很多资料。

## 1、线程池

==创建任务的基本原理是使用线程池，也就是说任务最终也是要交给线程去执行的。==但是微软优化了任务的线程池，使线程的控制更加精准和高效。对于需要频繁创建线程的程序来说，使用线程池无疑是最好的选择。因为创建一个线程需要消耗大量的系统资源，而线程池很好的解决了这个问题。当你使用线程池创建10个线程时，系统可能只创建了3、4个线程，因为线程池中的线程是可以循环使用的。下面举个例子说明一下：

![](https://img-blog.csdnimg.cn/20200115104134771.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L25pZWNoYW95YQ==,size_16,color_FFFFFF,t_70)

 这里使用task创建了10个任务，但是系统只创建了4个线程。创建的线程数是根据个人电脑配置不同而不同的。

 再看一下使用Thread类创建线程的情况：

![](https://img-blog.csdnimg.cn/20200115104336134.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L25pZWNoYW95YQ==,size_16,color_FFFFFF,t_70)

 可以看到这里创建了10个线程，而且在时间上也比使用任务创建线程的时间要长。

这是任务和线程的区别之一，也是优势之一，下面介绍另一个区别

## 2、并行

我们知道现在的电脑CPU基本上都是多核的，并行就是很好的利用了多核，更加高效的利用了电脑的硬件资源。

==当我们使用task类创建一个任务时，这个任务默认就是并行执行的。而使用Thread创建多个线程时，默认是并发执行的。==

## 3、前台线程和后台线程

task默认是后台线程，而thread默认是前台线程。关于前台线程和后台线程的区别这里不做介绍。

当然我们也可以设置task为前台线程，Thread.CurrentThread.IsBackground，将IsBackground设置为false即可。

我们也可以使用同样的属性把thread设置成后台线程。

## 4、总结

任务是微软强烈推荐处理多线程的有效类库，请尽可能使用任务创建多线程。

# [C# Thread 和 Task](https://www.cnblogs.com/HansZimmer/p/13491455.html)

前言：

　　如果你的任务是射出一万支箭，如果只有你一个人射箭，那你就只能一箭一箭慢慢地射个老半天。如果你找一万个人，来个万箭齐发，岂不是一下子就完事了。Thread就是能让你万箭齐发的好办法。

　　如果你的任务还需要汇报射箭的成绩的话，线程就不行了，得用任务。async/await可以帮你还是来个万箭齐发，但你射完不能走，得等那一万个射手给你回报成绩。

　　如果你本来就只要射一箭就好，那么，async/await能让你在等待报靶的时间里面干点别的小事情，譬如赚上1个亿。如果你射完箭除了等待成绩之外也没别的事情可做，那么，async/await就白用了，和同步没有任何区别。

 

一：线程

　　创建线程有两种方式　　

　　  1.不带参数创建线程  

```C#
var thread1 = new Thread(ThreadTest1)
public static void ThreadTest1()
{
        // 业务代码
}
thread1.start();
```

​     2.带参数创建线程

```C#
var thread2 = new Thread(ThreadTest2);
public static void ThreadTest2(object obj)
{
        //业务代码
}
thread2.Start(obj);
```

　总结：均没有返回值。主线程结束子线程未必结束，子线程出现问题未必能发现，并处于假死状态。

二：任务

　　创建任务有三种方式

　　1.通过构造函数创建(此方法需要手动开始任务)

```C#
var task1 = new Task(() => { });
var task2 = new Task<int>(()=> 
{
    return 0;
});
task1.Start();
task2.Start();
```

　　2.使用任务工厂(任务需要长时间运行)

```C#
var task1 = Task.Factory.StartNew(() => { });
var task2 = Task.Factory.StartNew(() =>
{
    return 0;
});
```

　 3.Task.Run创建

```C#
var task1 = Task.Run(() => { });
var task2 = Task.Run(() =>
{
    return 0;
});
```

总结：==任务的运行不会阻塞主线程==。主线程结束后，任务一定也会结束。任务和主线程关联大，任务出现问题时主线程也会崩溃告知人。所以别用Thread。

# [【.NET】- Task.Run 和 Task.Factory.StartNew 区别](https://www.cnblogs.com/wangwust/p/9493028.html)

`Task.Run` 是在 dotnet framework 4.5 之后才可以使用， `Task.Factory.StartNew` 可以使用比 `Task.Run` 更多的参数，可以做到更多的定制。

可以认为 `Task.Run` 是简化的 `Task.Factory.StartNew` 的使用，除了需要指定一个线程是长时间占用的，否则就使用 `Task.Run`

## 创建新线程

下面来告诉大家使用两个函数创建新的线程

```C#
Task.Run(() =>
{
   var foo = 2;
});
```

这时 foo 的创建就在另一个线程，需要知道 Task.Run 用的是线程池，也就是不是调用这个函数就会一定创建一个新的线程，但是会在另一个线程运行。

```C#
Task.Factory.StartNew(() =>
{
    ar foo = 2;
});
```

可以看到，两个方法实际上是没有差别，但是`Task.Run`比较好看，所以推荐使用`Task.Run`。

## 等待线程

创建的线程，如果需要等待线程执行完成在继续，那么可以使用 await 等待

```C#
private static async void SeenereKousa()
{
     Console.WriteLine("开始 线程"+Thread.CurrentThread.ManagedThreadId);
     await Task.Run(() =>
     {
         Console.WriteLine("进入 线程" + Thread.CurrentThread.ManagedThreadId);
     });
     Console.WriteLine("退出 线程"+Thread.CurrentThread.ManagedThreadId);
}
```

但是需要说的是这里使用 await 主要是给函数调用的外面使用，上面代码在函数里面使用 await 函数是 void 那么和把代码放在 task 里面是相同

```C#
private static async void SeenereKousa()
{
    Console.WriteLine("开始 线程"+Thread.CurrentThread.ManagedThreadId);
    await Task.Run(() =>
    {
         Console.WriteLine("进入 线程" + Thread.CurrentThread.ManagedThreadId);
         Console.WriteLine("退出 线程"+Thread.CurrentThread.ManagedThreadId);
    });
}
```

但是如果把 void 修改为 Task ，那么等待线程才有用

除了使用 await 等待，还可以使用 WaitAll 等待

```C#
 Console.WriteLine("开始 线程" + Thread.CurrentThread.ManagedThreadId);
 var t = Task.Run(() =>
 {
      Console.WriteLine("进入 线程" + Thread.CurrentThread.ManagedThreadId);
 });

 Task.WaitAll(t);
 Console.WriteLine("退出 线程" + Thread.CurrentThread.ManagedThreadId);
```

执行 WaitAll 的地方是在调用 WaitAll() 的线程中，也就是先在线程 1 运行，然后异步到 线程2 运行，这时线程1 等待线程2运行完成再继续，所以输出

```C#
开始 线程1
进入 线程2
退出 线程1
```

## 长时间运行

两个函数最大的不同在于 `Task.Factory.StartNew `可以设置线程是长时间运行，这时线程池就不会等待这个线程回收

```C#
Task.Factory.StartNew(() =>
{
      for (int i = 0; i < 100; i++)
      {
           var foo = 2;
      }
      Console.WriteLine("进行 线程" + Thread.CurrentThread.ManagedThreadId);
}, TaskCreationOptions.LongRunning);
```

**所以在需要设置线程是长时间运行的才需要使用 `Task.Factory.StartNew `不然就使用 `Task.Run`**

调用 `Task.Run(foo)` 就和使用下面代码一样

```C#
Task.Factory.StartNew(foo, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
```

 
