---
created: 2023-01-18T23:10:50 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/whuanle/p/12787505.html
author: 痴者工良
            粉丝 - 452
            关注 - 11
        
    
    
    
    
                +加关注
---

# C#多线程(12)：线程池 - 痴者工良 - 博客园

> ## Excerpt
> 线程池全称为托管线程池，线程池受 .NET 通用语言运行时(CLR)管理，线程的生命周期由 CLR 处理，因此我们可以专注于实现任务，而不需要理会线程管理。 线程池的应用场景：任务并行库 (TPL)操作、异步 I/O 完成、计时器回调、注册的等待操作、使用委托的异步方法调用和套接字连接。

---
-   [线程池](https://www.cnblogs.com/whuanle/p/12787505.html#%E7%BA%BF%E7%A8%8B%E6%B1%A0)
    -   [ThreadPool 常用属性和方法](https://www.cnblogs.com/whuanle/p/12787505.html#threadpool-%E5%B8%B8%E7%94%A8%E5%B1%9E%E6%80%A7%E5%92%8C%E6%96%B9%E6%B3%95)
    -   [线程池说明和示例](https://www.cnblogs.com/whuanle/p/12787505.html#%E7%BA%BF%E7%A8%8B%E6%B1%A0%E8%AF%B4%E6%98%8E%E5%92%8C%E7%A4%BA%E4%BE%8B)
    -   [线程池线程数](https://www.cnblogs.com/whuanle/p/12787505.html#%E7%BA%BF%E7%A8%8B%E6%B1%A0%E7%BA%BF%E7%A8%8B%E6%95%B0)
    -   [线程池线程数说明](https://www.cnblogs.com/whuanle/p/12787505.html#%E7%BA%BF%E7%A8%8B%E6%B1%A0%E7%BA%BF%E7%A8%8B%E6%95%B0%E8%AF%B4%E6%98%8E)
    -   [不支持的线程池异步委托](https://www.cnblogs.com/whuanle/p/12787505.html#%E4%B8%8D%E6%94%AF%E6%8C%81%E7%9A%84%E7%BA%BF%E7%A8%8B%E6%B1%A0%E5%BC%82%E6%AD%A5%E5%A7%94%E6%89%98)
    -   [任务取消功能](https://www.cnblogs.com/whuanle/p/12787505.html#%E4%BB%BB%E5%8A%A1%E5%8F%96%E6%B6%88%E5%8A%9F%E8%83%BD)
    -   [计时器](https://www.cnblogs.com/whuanle/p/12787505.html#%E8%AE%A1%E6%97%B6%E5%99%A8)

## 线程池

线程池全称为托管线程池，线程池受 .NET 通用语言运行时(CLR)管理，线程的生命周期由 CLR 处理，因此我们可以专注于实现任务，而不需要理会线程管理。

线程池的应用场景：任务并行库 (TPL)操作、异步 I/O 完成、计时器回调、注册的等待操作、使用委托的异步方法调用和套接字连接。

很多人不清楚 Task、Task<TResult> 原理，原因是没有好好了解线程池。

## ThreadPool 类

-   命名空间:System.Threading

-   程序集:System.Threading.ThreadPool.dll

提供一个线程池，该线程池可用于执行任务、发送工作项、处理异步 I/O、代表其他线程等待以及处理计时器。

_\* 通过线程池创建的线程默认为后台线程，优先级默认为Normal。_

**为什么用到线程？**

上篇文章介绍了Thread的例子，但在实际开发中使用的线程往往是大量的和更为复杂的，每新建一个线程都需要占用内存空间和其他资源，而新建了那么多线程，有很多在休眠，或者在等待资源释放；又有许多线程只是周期性的做一些小工作，如刷新数据等等，太浪费了，划不来，实际编程中大量线程突发，然后在短时间内结束的情况很少见。于是，为此引入了线程池的概念。

**好处**

  1、减少在创建和销毁线程上所花的时间以及系统资源的开销 ①  
  2、如不使用线程池，有可能造成系统创建大量线程而导致消耗完系统内存以及”过度切换”。

> ① 线程池中的线程执行完指定的方法后并不会自动消除，而是以挂起状态返回线程池，如果应用程序再次向线程池发出请求，那么处以挂起状态的线程就会被激活并执行任务，而不会创建新线程，这就节约了很多开销。只有当线程数达到最大线程数量，系统才会自动销毁线程。因此，使用线程池可以避免大量的创建和销毁的开支，具有更好的性能和稳定性，其次，开发人员把线程交给系统管理，可以集中精力处理其他任务。

**什么时候使用多线程？**

1、并发运行若各个运行时间不长且互不干扰的任务  
2、需要处理的任务的数量大 

线程池最多管理线程数量=“处理器数 \* 250”。也就是说，如果您的机器为2个2核CPU，那么CLR线程池的容量默认上限便是1000。

### ThreadPool 常用属性和方法

属性：

| 属性 | 说明 |
| --- | --- |
| CompletedWorkItemCount | 获取迄今为止已处理的工作项数。 |
| PendingWorkItemCount | 获取当前已加入处理队列的工作项数。 |
| ThreadCount | 获取当前存在的线程池线程数。 |

方法：

| 方法 | 说明 |
| --- | --- |
| BindHandle(IntPtr) | 将操作系统句柄绑定到 ThreadPool。 |
| BindHandle(SafeHandle) | 将操作系统句柄绑定到 ThreadPool。 |
| GetAvailableThreads(Int32, Int32) | 检索由 GetMaxThreads(Int32, Int32) 方法返回的最大线程池线程数和当前活动线程数之间的差值。 |
| GetMaxThreads(Int32, Int32) | 检索可以同时处于活动状态的线程池请求的数目。 所有大于此数目的请求将保持排队状态，直到线程池线程变为可用。 |
| GetMinThreads(Int32, Int32) | 发出新的请求时，在切换到管理线程创建和销毁的算法之前检索线程池按需创建的线程的最小数量。 |
| QueueUserWorkItem(WaitCallback) | 将方法排入队列以便执行。 此方法在有线程池线程变得可用时执行。 |
| QueueUserWorkItem(WaitCallback, Object) | 将方法排入队列以便执行，并指定包含该方法所用数据的对象。 此方法在有线程池线程变得可用时执行。 |
| QueueUserWorkItem(Action, TState, Boolean) | 将 Action 委托指定的方法排入队列以便执行，并提供该方法使用的数据。 此方法在有线程池线程变得可用时执行。 |
| RegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean) | 注册一个等待 WaitHandle 的委托，并指定一个 32 位有符号整数来表示超时值（以毫秒为单位）。 |
| SetMaxThreads(Int32, Int32) | 设置可以同时处于活动状态的线程池的请求数目。 所有大于此数目的请求将保持排队状态，直到线程池线程变为可用。 |
| SetMinThreads(Int32, Int32) | 发出新的请求时，在切换到管理线程创建和销毁的算法之前设置线程池按需创建的线程的最小数量。 |
| UnsafeQueueNativeOverlapped(NativeOverlapped) | 将重叠的 I/O 操作排队以便执行。 |
| UnsafeQueueUserWorkItem(IThreadPoolWorkItem, Boolean) | 将指定的工作项对象排队到线程池。 |
| UnsafeQueueUserWorkItem(WaitCallback, Object) | 将指定的委托排队到线程池，但不会将调用堆栈传播到辅助线程。 |
| UnsafeRegisterWaitForSingleObject(WaitHandle, WaitOrTimerCallback, Object, Int32, Boolean) | 注册一个等待 WaitHandle 的委托，并使用一个 32 位带符号整数来表示超时时间（以毫秒为单位）。 此方法不将调用堆栈传播到辅助线程。 |

### 线程池说明和示例

通过 `System.Threading.ThreadPool` 类，我们可以使用线程池。

ThreadPool 类是静态类，它提供一个线程池，该线程池可用于执行任务、发送工作项、处理异步 I/O、代表其他线程等待以及处理计时器。

> 理论的东西这里不会说太多，你可以参考官方文档地址：[https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.threadpool?view=netcore-3.1](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.threadpool?view=netcore-3.1)

ThreadPool 有一个 `QueueUserWorkItem()` 方法，该方法接受一个代表用户异步操作的委托(名为 WaitCallback )，调用此方法传入委托后，就会进入线程池内部队列中。

WaitCallback 委托的定义如下：

```c#
public delegate void WaitCallback(object state); 
```

现在我们来写一个简单的线程池示例，再扯淡一下。

```c#
class Program
{
    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(MyAction);

        ThreadPool.QueueUserWorkItem(state =>
			{
				Console.WriteLine("任务已被执行2");
			});
        Console.ReadKey();
    }
    // state 表示要传递的参数信息，这里为 null
    private static void MyAction(Object state)
    {
        Console.WriteLine("任务已被执行1");
    }
}
```

十分简单对不对~

这里有几个要点：

-   不要将长时间运行的操作放进线程池中；
-   不应该阻塞线程池中的线程；
-   线程池中的线程都是后台线程(又称工作者线程)；

另外，这里一定要记住 WaitCallback 这个委托。

我们观察创建线程需要的时间：

```c#
static void Main()
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    for (int i = 0; i < 10; i++)
        new Thread(() => { }).Start();
    watch.Stop();
    Console.WriteLine("创建 10 个线程需要花费时间(毫秒)：" + watch.ElapsedMilliseconds);
    Console.ReadKey();
}
```

笔者电脑测试结果大约 160。

### 线程池线程数

线程池中的 `SetMinThreads()`和 `SetMaxThreads()` 可以设置线程池工作的最小和最大线程数。其定义分别如下：

```C#
// 设置线程池最小工作线程数线程
public static bool SetMinThreads (int workerThreads, int completionPortThreads);
```

```C#
// 获取
public static void GetMinThreads (out int workerThreads, out int completionPortThreads);
```

workerThreads：要由线程池根据需要创建的新的最小工作程序线程数。

completionPortThreads：要由线程池根据需要创建的新的最小空闲异步 I/O 线程数。

`SetMinThreads()` 的返回值代表是否设置成功。

```C#
// 设置线程池最大工作线程数
public static bool SetMaxThreads (int workerThreads, int completionPortThreads);
```

```C#
// 获取
public static void GetMaxThreads (out int workerThreads, out int completionPortThreads);
```

workerThreads：线程池中辅助线程的最大数目。

completionPortThreads：线程池中异步 I/O 线程的最大数目。

`SetMaxThreads()` 的返回值代表是否设置成功。

这里就不给出示例了，不过我们也看到了上面出现 **异步 I/O 线程** 这个关键词，下面会学习到相关知识。

### 线程池线程数说明

关于最大最小线程数，这里有一些知识需要说明。在此前，我们来写一个示例：

```C#
class Program
{
    static void Main(string[] args)
    {
        // 不断加入任务
        for (int i = 0; i < 8; i++)
            ThreadPool.QueueUserWorkItem(state =>
			{
                Thread.Sleep(100);
                Console.WriteLine("");
             });
        for (int i = 0; i < 8; i++)
            ThreadPool.QueueUserWorkItem(state =>
			{
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("");
			});

        Console.WriteLine("     此计算机处理器数量：" + Environment.ProcessorCount);

        // 工作项、任务代表同一个意思
        Console.WriteLine("     当前线程池存在线程数：" + ThreadPool.ThreadCount);
        Console.WriteLine("     当前已处理的工作项数：" + ThreadPool.CompletedWorkItemCount);
        Console.WriteLine("     当前已加入处理队列的工作项数：" + ThreadPool.PendingWorkItemCount);
        int count;
        int ioCount;
        ThreadPool.GetMinThreads(out count, out ioCount);
        Console.WriteLine($"     默认最小辅助线程数：{count}，默认最小异步IO线程数：{ioCount}");

        ThreadPool.GetMaxThreads(out count, out ioCount);
        Console.WriteLine($"     默认最大辅助线程数：{count}，默认最大异步IO线程数：{ioCount}");
        Console.ReadKey();
    }
}
```

运行后，笔者电脑输出结果(我们的运行结果可能不一样)：

```
     此计算机处理器数量：8
     当前线程池存在线程数：8
     当前已处理的工作项数：2
     当前已加入处理队列的工作项数：8
     默认最小辅助线程数：8，默认最小异步IO线程数：8
     默认最大辅助线程数：32767，默认最大异步IO线程数：1000
```

我们结合运行结果，来了解一些知识点。

线程池最小线程数，默认是当前计算机处理器数量。另外我们也看到了。当前线程池存在线程数为 8 ，因为线程池创建后，无论有没有任务，都有 8 个线程存活。

如果将线程池最小数设置得过大(`SetMinThreads()`)，会导致任务切换开销变大，消耗更多得性能资源。

如果设置得最小值小于处理器数量，则也可能会影响性能。

Environment.ProcessorCount 可以确定当前计算机上有多少个处理器数量(例如CPU是四核八线程，结果就是八)。

`SetMaxThreads()` 设置的最大工作线程数或 I/O 线程数，不能小于 `SetMinThreads()` 设置的最小工作线程数或 I/O 线程数。

设置线程数过大，会导致任务切换开销变大，消耗更多得性能资源。

如果加入的任务大于设置的最大线程数，那么将会进入等待队列。

不能将工作线程或 I/O 完成线程的最大数目设置为小于计算机上的处理器数。

### 线程池使用后性能提升例子: 

测试下通过创建线程与利用线程池线程来做事所需时间及观察下利用线程池时是不是只用到少数几个线程。

```C#
static void Main(string[] args)
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < 1000; i++)
	{
	   Thread thread = new Thread(() => {
			int count = 0;
			count++;
		});
		thread.Start();        
	}
	sw.Stop();
	Console.WriteLine("运行创建线程所花费时间"+sw.ElapsedMilliseconds);
	sw.Restart();//重置下计时器
	for (int i = 0; i < 1000; i++)
	{
		//此处s为WaitCallback类型，转到定义查看为public delegate void WaitCallback(object state)，即是有一个参数的无返回值的委托
		ThreadPool.QueueUserWorkItem((s) =>
		{
			int count = 0;
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			count++;
		});
	}
	sw.Stop();
	Console.WriteLine("运行线程池线程所花费时间"+sw.ElapsedMilliseconds);
	Console.ReadKey();
}
```

运行结果的部分截图如下：

![](E:\Gitee\Backup\Image\CopyInsert\watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3UwMTIyNzgwMTY=,size_16,color_FFFFFF,t_70.png)

       可以看到通过创建线程循环的输出远远大于利用线程池里线程循环输出所需时间，线程池的效率很高，同时利用线程池的循环只用到了少数几个线程。

### 不支持的线程池异步委托

扯淡了这么久，我们从设置线程数中，发现有个 I/O 异步线程数，这个线程数限制的是执行异步委托的线程数量，这正是本节要介绍的。

异步编程模型(Asynchronous Programming Model，简称 APM)，在日常撸码中，我们可以使用 `async`、`await` 和`Task` 一把梭了事。

.NET Core 不再使用 `BeginInvoke` 这种模式。你可以跟着笔者一起踩坑先。

笔者在看书的时候，写了这个示例：

很多地方也在使用这种形式的示例，但是在 .NET Core 中用不了，只能在 .NET Fx 使用。。。

```c#
class Program
{
    private delegate string MyAsyncDelete(out int thisThreadId);
    static void Main(string[] args)
    {
        int threadId;
        // 不是异步调用
        MyMethodAsync(out threadId);

        // 创建自定义的委托
        MyAsyncDelete myAsync = MyMethodAsync;

        // 初始化异步的委托
        IAsyncResult result = myAsync.BeginInvoke(out threadId, null, null);

        // 当前线程等待异步完成任务，也可以去掉
        result.AsyncWaitHandle.WaitOne();
        Console.WriteLine("异步执行");

        // 检索异步执行结果
        string returnValue = myAsync.EndInvoke(out threadId, result);

        // 关闭
        result.AsyncWaitHandle.Close();

        Console.WriteLine("异步处理结果：" + returnValue);
    }
    private static string MyMethodAsync(out int threadId)
    {
        // 获取当前线程在托管线程池的唯一标识
        threadId = Thread.CurrentThread.ManagedThreadId;
        // 模拟工作请求
        Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 5)));
        // 返回工作完成结果
        return "喜欢我的读者可以关注笔者的博客欧~";
    }
}
```

目前百度到的很多文章也是 .NET FX 时代的代码了，要注意 C# 在版本迭代中，对异步这些 API ，做了很多修改，不要看别人的文章，学完后才发现不能在 .NET Core 中使用(例如我... ...)，浪费时间。

上面这个代码示例，也从侧面说明了，以往 .NET Fx (C# 5.0 以前)中使用异步是很麻烦的。

.NET Core 是不支持异步委托的，具体可以看 [https://github.com/dotnet/runtime/issues/16312](https://github.com/dotnet/runtime/issues/16312)

官网文档明明说支持的[https://docs.microsoft.com/zh-cn/dotnet/api/system.iasyncresult?view=netcore-3.1#examples](https://docs.microsoft.com/zh-cn/dotnet/api/system.iasyncresult?view=netcore-3.1#examples)，而且示例也是这样，搞了这么久，居然不行，我等下一刀过去。

关于为什么不支持，可以看这里：[https://devblogs.microsoft.com/dotnet/migrating-delegate-begininvoke-calls-for-net-core/](https://devblogs.microsoft.com/dotnet/migrating-delegate-begininvoke-calls-for-net-core/)

不支持就算了，我们跳过，后面学习异步时再仔细讨论。

### 任务取消功能

这个取消跟线程池无关。

CancellationToken：传播有关应取消操作的通知。

CancellationTokenSource：向应该被取消的 CancellationToken 发送信号。

两者关系如下：

```c#
CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;  
```

这个取消，在于信号的发生和信号的捕获，任务的取消不是实时的。

示例代码如下：

CancellationTokenSource 实例化一个取消标记，然后传递 CancellationToken 进去；

被启动的线程，每个阶段都判断 `.IsCancellationRequested`，然后确定是否停止运行。这取决于线程的自觉性。

```c#
class Program
{
    static void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        Console.WriteLine("按下回车键，将取消任务");

        new Thread(() => { CanceTask(cts.Token); }).Start();
        new Thread(() => { CanceTask(cts.Token); }).Start();

        Console.ReadKey();

        // 取消执行
        cts.Cancel();
        Console.WriteLine("完成");
        Console.ReadKey();
    }

    private static void CanceTask(CancellationToken token)
    {
        Console.WriteLine("第一阶段");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (token.IsCancellationRequested)
            return;

        Console.WriteLine("第二阶段");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (token.IsCancellationRequested)
            return;

        Console.WriteLine("第三阶段");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (token.IsCancellationRequested)
            return;

        Console.WriteLine("第四阶段");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (token.IsCancellationRequested)
            return;

        Console.WriteLine("第五阶段");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (token.IsCancellationRequested)
            return;
    }
}
```

这个取消标记，在前面的很多同步方式中，都用的上。

### 计时器

常用的定时器有两种，分别是：System.Timers.Timer 和 System.Thread.Timer。

`System.Threading.Timer`是一个普通的计时器，它是线程池中的线程中。

`System.Timers.Timer`包装了`System.Threading.Timer`，并提供了一些用于在特定线程上分派的其他功能。

什么线程安全不安全。。。俺不懂这个。。。不过你可以参考[https://stackoverflow.com/questions/19577296/thread-safety-of-system-timers-timer-vs-system-threading-timer](https://stackoverflow.com/questions/19577296/thread-safety-of-system-timers-timer-vs-system-threading-timer)

如果你想认真区分两者的关系，可以查看：[https://web.archive.org/web/20150329101415/https://msdn.microsoft.com/en-us/magazine/cc164015.aspx](https://web.archive.org/web/20150329101415/https://msdn.microsoft.com/en-us/magazine/cc164015.aspx)

两者主要使用区别：

-   [System.Timers.Timer](https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=netframework-4.7.2)，它会定期触发一个事件并在一个或多个事件接收器中执行代码。
-   [System.Threading.Timer](https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer?view=netframework-4.7.2)，它定期在线程池线程上执行一个回调方法。

大多数情况下使用 System.Threading.Timer，因为它比较“轻”，另外就是 .NET Core 1.0 时，`System.Timers.Timer` 被取消了，NET Core 2.0 时又回来了。主要是为了 .NET FX 和 .NET Core 迁移方便，才加上去的。所以，你懂我的意思吧。

System.Threading.Timer 其中一个构造函数定义如下：

```
public Timer (System.Threading.TimerCallback callback, object state, uint dueTime, uint period);
```

callback：要定时执行的方法；

state：要传递给线程的信息(参数)；

dueTime：延迟时间，避免一创建计时器，马上开始执行方法；

period：设置定时执行方法的时间间隔；

计时器示例：

```c#
class Program
{
    static void Main()
    {
        Timer timer = new Timer(TimeTask,null,100,1000);

        Console.ReadKey();
    }

    // public delegate void TimerCallback(object? state);
    private static void TimeTask(object state)
    {
        Console.WriteLine("www.whuanle.cn");
    }
}
```

Timer 有不少方法，但不常用，可以查看官方文档：[https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.timer?view=netcore-3.1#methods](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.timer?view=netcore-3.1#methods)
