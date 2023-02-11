---
created: 2023-02-11T19:40:31 (UTC +08:00)
tags: [C# 事件（Event）]
source: https://www.nhooo.com/csharp/csharp-event.html#top
author: 
---

# C# 事件（Event） - C#教程 - 基础教程在线

> ## Excerpt
> 事件是对象发送的通知，用于表示操作的发生。.NET中的事件遵循观察者设计模式。引发事件的类称为 Publisher（发布者），接收通知的类称为 Subscriber（订阅者）。一个事件可以有多个订阅者。通常，发布者在发生某个操作时引发事件。

---
## C# 事件（Event）

事件是对象发送的通知，用于表示操作的发生。.NET中的事件遵循观察者设计模式。

引发事件的类称为 Publisher（发布者），接收通知的类称为 Subscriber（订阅者）。一个事件可以有多个订阅者。通常，发布者在发生某个操作时引发事件。订阅者希望在操作发生时获得通知，他们应该向事件注册并处理它。

在C＃中，事件是封装的委托。它取决于委托。委托为订阅者类的事件处理程序方法定义签名。

## 通过事件使用委托

事件在类中声明且生成，且通过使用同一个类或其他类中的委托与事件处理程序关联。包含事件的类用于发布事件。这被称为 **发布者(publisher)** 类。其他接受该事件的类被称为 订阅者(subscriber) 类。事件使用 **发布-订阅(publisher-subscriber)** 模型。

**发布者(publisher)**\- 是一个包含事件和委托定义的对象。事件和委托之间的联系也定义在这个对象中。发布者(publisher)类的对象调用这个事件，并通知其他的对象。

**订阅者(subscriber)**\- 是一个接受事件并提供事件处理程序的对象。在发布者(publisher)类中的委托调用订阅者(subscriber)类中的方法（事件处理程序）。

## 声明事件

可以通过两个步骤声明一个事件：

1.  声明委托
    
2.  使用 event 关键字声明委托的变量
    

下面的示例演示如何在发布者类中声明事件。

示例：声明一个事件

```C#
public delegate void Notify();  
                    
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; 
}
```

在上面的示例中，我们声明了一个委托 Notify，然后在 ProcessBusinessLogic 类中使用“event”关键字声明了委托类型Notify的事件ProcessCompleted。因此，ProcessBusinessLogic类称为publisher（发布者）。Notify委托指定ProcessCompleted事件处理程序的签名。它指定subscriber（订阅者）类中的事件处理程序方法必须具有 void 返回类型，并且没有参数。

现在，让我们看看如何引发ProcessCompleted事件。请看以下实现。

示例：引发事件

```C#
public delegate void Notify();  
                    
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; 

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");        
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted() 
    {        
        ProcessCompleted?.Invoke(); 
    }
}
```

上面，StartProcess()方法在末尾调用onProcessCompleted()方法，这将引发一个事件。通常，要引发事件，应使用<EventName>上的名称定义protected和virtual方法。受保护和虚拟使派生类重写引发事件的逻辑。但是，派生类应该始终调用基类的On<EventName>方法，以确保注册的委托接收事件。

OnProcessCompleted() 方法使用 ProcessCompleted?. invoke() 调用委托。这将调用所有注册到 ProcessCompleted 事件的事件处理程序方法。

订阅者类必须注册到ProcessCompleted事件，并使用签名匹配Notify委托的方法来处理它，如下所示。

示例：消费事件

```C#
class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; 
        bl.StartProcess();
    }

    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }
}
```

上面，Program 类是 ProcessCompleted 事件的订阅者。它使用 + = 运算符向事件注册。请记住，这与我们在多播委托的调用列表中添加方法的方式是一样的。bl\_processcompleted ()方法处理该事件，因为它与 Notify 委托的签名匹配。

## 内置 EventHandler 委托

.NET Framework包含用于最常见事件的内置委托类型EventHandler和EventHandler <TEventArgs>。通常，任何事件都应包括两个参数：事件源和事件数据。。对不包含事件数据的所有事件使用EventHandler委托。对于包含要发送到处理程序的数据的事件，请使用 EventHandler<TEventArgs> 委托。

上面显示的示例可以使用EventHandler委托，而无需声明自定义Notify委托，如下所示。

示例：EventHandler 委托  

```C#
class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; 
        bl.StartProcess();
    }
    
    public static void bl_ProcessCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("Process Completed!");
    }
}

public class ProcessBusinessLogic
{
    
    public event EventHandler ProcessCompleted; 

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");        
        OnProcessCompleted(EventArgs.Empty); 
    }

    protected virtual void OnProcessCompleted(EventArgs e)
    {
        ProcessCompleted?.Invoke(this, e);
    }
}
```

在上面的示例中，事件处理程序bl\_ProcessCompleted()方法包含两个与 EventHandler 委托匹配的参数。同时，传递 this 作为发送者和EventArgs。当我们在OnProcessCompleted()方法中使用Invoke()引发事件时为空。因为我们的事件不需要任何数据，它只是通知订阅者流程已经完成，所以我们传递了 EventArgs.Empty。

## 传递事件数据

大多数事件向订阅者发送一些数据。EventArgs类是所有事件数据类的基类。NET包含许多内置事件数据类，如 SerialDataReceivedEventArgs。它遵循以EventArgs结束所有事件数据类的命名模式。您可以通过派生 EventArgs 类为事件数据创建自定义类。

使用EventHandler \<TEventArgs>将数据传递到处理程序，如下所示。

示例：传递事件数据

```C#
class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; 
        bl.StartProcess();
    }

    
    public static void bl_ProcessCompleted(object sender, bool IsSuccessful)
    {
        Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
    }
}

public class ProcessBusinessLogic
{
    
    public event EventHandler<bool> ProcessCompleted; 

    public void StartProcess()
    {
        try
        {
            Console.WriteLine("Process Started!");

            

            OnProcessCompleted(true);
        }
        catch(Exception ex)
        {
            OnProcessCompleted(false);
        }
    }

    protected virtual void OnProcessCompleted(bool IsSuccessful)
    {
        ProcessCompleted?.Invoke(this, IsSuccessful);
    }
}
```

在上面的示例中，我们将单个布尔值传递给处理程序，以指示该过程是否成功完成。

如果希望将多个值作为事件数据传递，那么可以创建一个从 EventArgs 基类派生的类，如下所示。

示例：自定义EventArgs类

```C#
class ProcessEventArgs : EventArgs
{
    public bool IsSuccessful { get; set; }
    public DateTime CompletionTime { get; set; }
}
```

下面的示例演示如何将自定义 ProcessEventArgs 类传递给处理程序。

示例：传递自定义EventArgs

```C#
class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; 
        bl.StartProcess();
    }
    
    public static void bl_ProcessCompleted(object sender, ProcessEventArgs e)
    {
        Console.WriteLine("Process " + (e.IsSuccessful? "Completed Successfully": "failed"));
        Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
    }
}

public class ProcessBusinessLogic
{
    
    public event EventHandler<ProcessEventArgs> ProcessCompleted; 

    public void StartProcess()
    {
        var data = new ProcessEventArgs();

        try
        {
            Console.WriteLine("Process Started!");
            data.IsSuccessful = true;
            data.CompletionTime = DateTime.Now;
            OnProcessCompleted(data);
        }
        catch(Exception ex)
        {
            data.IsSuccessful = false;
            data.CompletionTime = DateTime.Now;
            OnProcessCompleted(data);
        }
    }

    protected virtual void OnProcessCompleted(ProcessEventArgs e)
    {
        ProcessCompleted?.Invoke(this, e);
    }
}
```

因此，您可以在C＃中创建，引发，注册和处理事件。

## 要记住的要点

1.  事件是对委托的包装。这取决于委托。
    
2.  将“ event”关键字与委托类型变量一起使用来声明事件。
    
3.  将内置委托EventHandler或EventHandler <TEventArgs>用于常见事件。
    
4.  发布者类引发一个事件，而订阅者类注册一个事件并提供事件处理程序方法。
    
5.  用事件名称命名引发事件的方法，该方法以“ On”为前缀。
    
6.  处理程序方法的签名必须与委托签名匹配。
    
7.  使用+ =运算符注册事件。使用 -= 运算符取消订阅，不能使用=运算符。
    
8.  使用EventHandler <TEventArgs>传递事件数据。
    
9.  派生EventArgs基类以创建自定义事件数据类。
    
10.  可以将事件声明为静态，虚拟，密封和抽象（static, virtual, sealed, abstract）。
    
11.  接口可以将事件作为成员包含。
    
12.  如果有多个订阅者，则将同步调用事件处理程序。

# C#winform窗体用户控件自定义事件

> ## Excerpt
>
> C#许多事情都和事件有关系，大部分的事情我们可以通过C#自己的事件来完成，但如果我们自己新建了一个自定义控件，我们该如何定义自己想要的事件呢？下面我就来为大家粗略的讲解一番。

---

C#许多事情都和事件有关系，大部分的事情我们可以通过C#自己的事件来完成，但如果我们自己新建了一个自定义控件，我们该如何定义自己想要的事件呢？下面我就来为大家粗略的讲解一番。

假设我们自定义了一个控件，它的类名是MyControl，我们在test类（test也是一个窗体）中使用它，我们要在test中写方法，在MyControl中写事件，这该怎么做？如何在test中捕获Mycontrol中的事件，如何让事件绑定test中的方法？

假设MyControl是一个组合控件，假设有一个按钮btn\_Ok，它在组合控件System.Windows.Forms.ToolStrip中，假设这个容器叫toolstrip，当我们点击了之后需要响应一个事件，提示我们数据保存了，这个事件我们起个名字叫Btn\_Ok\_Clicked（当然也可以叫datasaved或者其它），下面要定义这个事件，我们这么定义：

```C#
private static readonly object Event\_Btn\_Ok\_Clicked = new object();
public event EventHandler Btn_Ok_Clicked
{
    add { base.Events.AddHandler(Event\_Btn\_Ok\_Clicked , value); }
    remove { base.Events.RemoveHandler(Event\_Btn\_Ok\_Clicked , value); }
}
```

然后我们需要定义一个方法，用来引发这个事件

```C#
protected virtual void OnBtn\_OK\_Click(EventArgs e)
{
    EventHandler handler = base.Events\[Event_Btn_Ok_Clicked] as EventHandler;
    if (handler != null)
    {
        handler(this, e);
    }
}
```

该方法定义完了之后，我们需要通过捕获原本的事件，然后引发该事件

点击btn\_Ok会引发toolstrip的click事件，我们在捕获click事件后对数据进行处理

      

```C#
private void ToolStripItemClicked(    object sender, ToolStripItemClickedEventArgs e)
{
    switch (e.ClickedItem.Name)
    {
        case "btn\_Ok":
            OnBtn\_OK\_Click(e);
            break;
    }
}
```

以上方法定义在MyControl类中

到这里，MyControls中的事件和方法就都定义和实现完了，下面我们来讲在test中如何对这个事件的引用。

以下代码都在test类中

我们通过拖控件或者代码的方式在test窗体中添加控件

        private MyControl control；

在窗体初始化的时候为刚才我们自定义的事件添加方法,方法名是functiontest

        control. Btn\_Ok\_Clicked += new EventHandler(functiontest);

现在我们来定义functiontest方法，假设我们就是为了提示“数据已保存”

        private void functiontest(object sender, EventArgs e)

        {

                MessageBox.Show("数据已保存");

        }

