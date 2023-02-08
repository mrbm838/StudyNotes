---
created: 2023-01-20T23:18:30 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/yilezhu/p/10555849.html
author: 依乐祝
            粉丝 - 1112
            关注 - 33
        
    
    
    
    
                +加关注
---

# C# 中的Async 和 Await 的用法详解 - 依乐祝 - 博客园

> ## Excerpt
> 众所周知C 提供Async和Await关键字来实现异步编程。在本文中，我们将共同探讨并介绍什么是Async 和 Await，以及如何在C 中使用Async 和 Await。 同样本文的内容也大多是翻译

---
众所周知C#提供Async和Await关键字来实现异步编程。在本文中，我们将共同探讨并介绍什么是Async 和 Await，以及如何在C#中使用Async 和 Await。  
同样本文的内容也大多是翻译的，只不过加上了自己的理解进行了相关知识点的补充，如果你认为自己的英文水平还不错，大可直接跳转到文章末尾查看原文链接进行阅读。

> 作者：依乐祝  
> 原文链接：[https://www.cnblogs.com/yilezhu/p/10555849.html](https://www.cnblogs.com/yilezhu/p/10555849.html)

## 写在前面

自从C# 5.0时代引入async和await关键字后，异步编程就变得流行起来。尤其在现在的.NET Core时代，如果你的代码中没有出现async或者await关键字，都会让人感觉到很奇怪。

想象一下当我们***在处理UI和按钮单击时，我们需要运行一个长时间运行的方法***，比如读取一个大文件或其他需要很长时间的任务，在这种情况下，整个应用程序必须等待这个长时间运行的任务完成才算完成整个任务。

换句话说，如果同步应用程序中的任何进程被阻塞，则整个应用程序将被阻塞，我们的应用程序将停止响应，直到整个任务完成。

在这种情况下，异步编程将非常有用。通过使用异步编程，应用程序可以继续进行不依赖于整个任务完成的其他工作。

在Async 和 await关键字的帮助下，使得异步编程变得很简单，而且我们将获得传统异步编程的所有好处。

async/await的全称叫做 异步IO及等待 所以他跟线程没有任何关系，只是他们在单边输出的时候喜欢拽上task，所以在跟线程挂上了边。因为task才是线程的升级，async并不是。async只是异步IO的升级封装.

1、异步 往往（不是一定） 需要多线程配合去完成不同的工作，比如Task实现了多线程。简单的说：异步需要多线程，但异步是不多线程 
2、async和await不是多线程，是异步，所以你看到的async包含的代码中，线程id是一样的，因为它代码仍然运行在主线程中。 
3、只有Task.Run()所包含的代码，才运行在另外一个线程中
4、假设你的代码，使用async await模式能实现10万个并发，但为什么不是实现100万个并发，1000万个并发？是因为仍然有部分代码运行在主线程中，主线程仍然消耗了cpu资源，只不过较少。消耗cpu的，就是你async开始到Task.Run（）之间的那部分代码。

## 实例讲解

假设我们分别使用了两种方法，即Method 1和Method 2，这两种方法不相互依赖，而Method 1需要很长时间才能完成它的任务。在同步编程中，它将执行第一个Method 1，并等待该方法的完成，然后执行Method 2。因此，这将是一个时间密集型的过程，即使这两种方法并不相互依赖。

我们可以使用简单的多线程编程并行运行所有方法，但是它会阻塞UI并等待完成所有任务。要解决这个问题，我们必须在传统编程中编写很多的代码，但是现在我们有了Async 和 await关键字，那么我们将通过书写很少的并且简洁的代码来解决这个问题。

此外，我们还将看到更多的示例，如果任何第三个方法(如Method 3)都依赖于Method 1，那么它将在Wait关键字的帮助下等待Method 1的完成。

Async 和 await是代码标记，它标记代码位置为任务完成后控件应该恢复的位置。

下面让我们举几个例子来更好进行理解吧

C#中Async 和 await关键字的示例

我们将采用控制台应用程序进行演示。

### 第一个例子

在这个例子中，我们将采取两个不相互依赖的方法。

```C#
class Program
{  
    static void Main(string[] args)
    {  
        Method1();
        Method2();
        Console.ReadKey();
    }  
  
    public static async Task Method1()
    {  
a		wait Task.Run(() =>
            {  
                for (int i = 0; i < 100; i++)
                {  
                    Console.WriteLine(" Method 1");  
                }  
            });  
    }  
  
  
    public static void Method2()
    {  
        for (int i = 0; i < 25; i++)
        {  
            Console.WriteLine(" Method 2");  	
        }  
    }  
}  
```

在上面给出的代码中，Method 1和Method 2不相互依赖，我们是从主方法调用的。

在这里，我们可以清楚地看到，方法1和方法2并不是在等待对方完成。

**输出**

**![img](https://img2018.cnblogs.com/blog/1377250/201903/1377250-20190318225205912-696038953.jpg)**

现在来看第二个例子，假设我们有Method 3，它依赖于Method 1

### 第二个例子

在本例中，Method 1将总长度作为整数值返回，我们在Method 3中以长度的形式传递一个参数，它来自Method 1。

在这里，在传递Method 3中的参数之前，我们必须使用await关键字，为此，我们必须使用调用方法中的async 关键字。

在控制台应用程序的Main方法中，因为不能使用async关键字而不能使用await 关键字，因为它会给出下面给出的错误。(但是如果你使用的是C#7.1及以上的方法是不会有问题的，因为C#7.1及以上的语法支持Mian方法前加async)

![img](https://img2018.cnblogs.com/blog/1377250/201903/1377250-20190318225205653-2039239103.jpg)  
我们将创建一个新的方法，作为CallMethod，在这个方法中，我们将调用我们的所有方法，分别为Method 1、Method 2和Method 3。

```C#
class Program
{  
    static void Main(string[] args)
    {  
        callMethod();
        Console.ReadKey();
    }  
  
    public static async void callMethod()
    {  
        Task<int> task = Method1();
        Method2();
        int count = await task;
        Method3(count);
    }  
  
    public static async Task<int> Method1()
    {  
        int count = 0;
        await Task.Run(() =>
            {  
                for (int i = 0; i < 100; i++)
                {  
                    Console.WriteLine(" Method 1");  
                    count += 1;
                }  
            });  
        return count;
    }  
  
    public static void Method2()
    {  
        for (int i = 0; i < 25; i++)
        {  
			Console.WriteLine(" Method 2");  
        }  
    }  
  
    public static void Method3(int count)
    {  
		Console.WriteLine("Total count is " + count);
    }  
}  
```

在上面给出的代码中，Method 3需要一个参数，即Method 1的返回类型。在这里，await关键字对于等待Method 1任务的完成起着至关重要的作用。

**输出**

**![img](https://img2018.cnblogs.com/blog/1377250/201903/1377250-20190318225205378-1554546298.jpg)**

### 第三个例子

.NET Framework4.5中有一些支持API，Windows运行时包含支持异步编程的方法。

在Async 和 await关键字的帮助下，我们可以在实时项目中使用所有这些，以便更快地执行任务。

包含异步方法的API有HttpClient, SyndicationClient, StorageFile, StreamWriter, StreamReader, XmlReader, MediaCapture, BitmapEncoder, BitmapDecoder 等。

在本例中，我们将异步读取大型文本文件中的所有字符，并获取所有字符的总长度。

```C#
class Program
{  
    static void Main()
    {  
        Task task = new Task(CallMethod);
        task.Start();
        task.Wait();
        Console.ReadLine();
    }  
  
    static async void CallMethod()
    {  
        string filePath = "E:\\sampleFile.txt";  
        Task<int> task = ReadFile(filePath);

        Console.WriteLine(" Other Work 1");  
        Console.WriteLine(" Other Work 2");  
        Console.WriteLine(" Other Work 3");  
  
        int length = await task;
        Console.WriteLine(" Total length: " + length);

        Console.WriteLine(" After work 1");  
        Console.WriteLine(" After work 2");  
    }  
  
    static async Task<int> ReadFile(string file)
    {  
		int length = 0;
  
		Console.WriteLine(" File reading is stating");  
         using (StreamReader reader = new StreamReader(file))
         {    
			string s = await reader.ReadToEndAsync();
			length = s.Length;
         }  
		Console.WriteLine(" File reading is completed");  
         return length;
    }  
}  
```

在上面给出的代码中，我们调用ReadFile方法来读取文本文件的内容，并获取文本文件中总字符的长度。

在sampleText.txt中，文件包含了太多的字符，因此读取所有字符需要很长时间。

在这里，我们使用异步编程从文件中读取所有内容，所以它不会等待从这个方法获得一个返回值并执行其他代码行，但是它必须等待下面给出的代码行，因为我们使用的是等待关键字，我们将对下面给出的代码行使用返回值。

```C#
int length = await task;
Console.WriteLine(" Total length: " + length);  
```

随后，将按顺序执行其他代码行。

```C#
Console.WriteLine(" After work 1");  
Console.WriteLine(" After work 2");   
```

**输出**

**![img](https://img2018.cnblogs.com/blog/1377250/201903/1377250-20190318225204721-965583889.jpg)**

### await 和task.Wait()

await 和task.Wait()的相同点都是等待函数执行完后，才能执行后续的代码。不同点是：await是异步等待，而Wait()是同步等待，比如在winform程序中，await是可以立即拖动窗体，继续点击其他按钮的，Wait是不可以立即拖动窗体等操作，但是可以有后续操作，等执行完后，再执行。

```C#
// task.WhenAll()
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      int failed = 0;
      var tasks = new List<Task>();
      String[] urls = { "www.adatum.com", "www.cohovineyard.com",
                        "www.cohowinery.com", "www.northwindtraders.com",
                        "www.contoso.com" };
      
      foreach (var value in urls)
      {
         var url = value;
         tasks.Add(Task.Run(() =>
                            {
                                var png = new Ping();
                                try {
                                    var reply = png.Send(url);
                                    if (! (reply.Status == IPStatus.Success)) {
                                        Interlocked.Increment(ref failed);
                                        throw new TimeoutException("Unable to reach " + url + ".");
                                    }
                                }
                                catch (PingException) {
                                    Interlocked.Increment(ref failed);
                                    throw;
                                }
                            }));
      }
      Task t = Task.WhenAll(tasks);
      try {
         t.Wait();
      }
      catch {}   

      if (t.Status == TaskStatus.RanToCompletion)
         Console.WriteLine("All ping attempts succeeded.");
      else if (t.Status == TaskStatus.Faulted)
         Console.WriteLine("{0} ping attempts failed", failed);      
   }
}
// The example displays output like the following:
//       5 ping attempts failed
```



## 最后

在这里，我们必须了解非常重要的一点，如果我们没有使用await 关键字，那么该方法就作为一个同步方法。编译器将向我们显示警告，但不会显示任何错误。  
像上面这种简单的方式一样，我们可以在C#代码中使用async 和await关键字来愉快的进行异步编程了。  
最后的最后感谢大家的阅读！  
本文大部分内容翻译自：[https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/](https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/)

## 语法使用规则

1. `await` 必须且只能使用在 `async` 函数中。
2. `async` 函数体中如果没有 `await` 关键字，则此函数永远不会被异步执行，而是和普通函数一样执行。
3. 异步代码使用任务的概念（`Task`和`Task<T>`）对异步工作进行抽象。
4. 作为一种命名传统，请为每个异步函数名添加 Async 后缀。
5. 除非是winform程序中（事件处理），请避免使用 `async void`，而应该使用 `async Task` 或 `async Task<T>`。
6. 如果使用 `Task<T>` ，`await`将在任务完成后自动展开值。
7. 被 `await`修饰的只能是 `Task` 或 `Task<T>` 类型。
   [Asynchronous programming](https://docs.microsoft.com/en-us/dotnet/csharp/async)
   [Async in depth](https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth)
   [彻底搞懂 C# 的 async/await](https://www.cnblogs.com/feipeng8848/p/10188871.html#!comments)

## 实际使用的经验教训

1. 任务（tasks）只是对异步工作的抽象，而不是对线程的抽象。默认情况下，任务在当前线程上执行。如果要新开线程执行任务，使用 `Task.Run();`。
2. 但是使用`Task.Run();` 开新线程做异步的开销很大，实测可以达到网络访问延迟的三分之二。
3. 如果函数体中有 `await Task.WhenAll()`， 则此函数应该由 `async Task`修饰， 而不是 `async void`。[参考1](https://stackoverflow.com/questions/36905187/task-whenall-not-waiting?rq=1) [参考2](https://jeremylindsayni.wordpress.com/2019/03/11/using-async-await-and-task-whenall-to-improve-the-overall-speed-of-your-c-code/)
4. 使用 Tuple 可以解决不能在`async`函数中使用out参数的问题：[How to write an async method with out parameter?](https://stackoverflow.com/questions/18716928/how-to-write-an-async-method-with-out-parameter)，如果参数超过7个，还可以使用嵌套 Tuple。
5. 调用 `.Result` 属性获取返回值时，注意死锁问题。[彻底搞懂 C# 的 async/await](https://www.cnblogs.com/feipeng8848/p/10188871.html#!comments)
   [C#异步的世界【下】](https://www.cnblogs.com/zhaopei/p/async_two.html#autoid-2-2)

## `Task.WaitAll()` 和 `Task.WhenAll()` 的区别

1. `Task.WaitAll()` 会阻塞当前线程直到所有任务完成； `Task.WhenAll()` 会创建一个新的任务，此任务只有在其他所有任务完成后才完成。
2. 由此可知，`Task.WaitAll()`是阻塞的方法，`Task.WhenAll()` 是非阻塞方法。
   [参考链接](https://www.tutorialspoint.com/what-is-the-difference-between-task-whenall-and-task-waitall-in-chash)

## 声明方式

异步方法的声明语法与其他方法完全一样, 只是需要包含 async 关键字。async可以出现在返回值之前的任何位置, 如下示例:

```C#
async public static void GetInfoAsync()
{
   //...
}

public async static void GetInfoAsync()
{
   //...
}

public static async void GetInfoAsync()
{
    //...
}
```

## 异步方法的返回类型

异步函数的返回类型只能为: void、Task、Task<TResult>。

1. Task<TResult>: 代表一个返回值T类型的操作。

2. Task: 代表一个无返回值的操作。

3. void: 为了和传统的事件处理程序兼容而设计。


## await(等待)

await等待的是什么? 可以是一个异步操作(Task)、亦或者是具备返回值的异步操作(Task<TResult>)的值, 如下:

```C#
public async static void GetInfoAsync()
{
    await GetData(); // 等待异步操作, 无返回值
    await GetData<int>(1); //等待异步操作, 返回值 int
}

static Task GetData()
{
    //...
    return null;
}

static Task<T> GetData<T>(int a)
{
    //...
    return null;
}
public async static void GetInfoAsync()
{
    await GetData(); // 等待异步操作, 无返回值
    await GetData<int>(1); //等待异步操作, 返回值 int
}
static Task GetData()
{
    //...
    return null;
}

static Task<T> GetData<T>(int a)
{
    //...
    return null;
}
```
注: await 最终操作的是一个值, 当然, 也可以是无值, 如上GetData() , 否则就是一个 Task<T> 如上: GetData<T>()
