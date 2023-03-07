# C# 关于自定义泛型约束 (where T : class)_c# where t : class

> ## Excerpt
> C# 关于自定义泛型约束 (where T : class)

---
C# 关于[泛型](https://so.csdn.net/so/search?q=%E6%B3%9B%E5%9E%8B&spm=1001.2101.3001.7020)约束 (where T : class)  
1.main 调用处代码段

```C#
static void Main(string[] args)
{
    IFactory<string, string, int, string, int, double,object> fct = new MyClass<string, string, int, string, int, double,object>();
    var eat1 = fct.Eat();
    Console.WriteLine("eat1返回值：{0}", eat1);

    fct.Eat("我爱吃大熊猫");

    var sayhi1 = fct.sayHi();
    Console.WriteLine(sayhi1);

    var sayhello1 = fct.sayHello("万花筒写轮眼");
    Console.WriteLine("sayhello1返回值：{0}", sayhello1);

    Console.ReadKey();
}
```

2.添加了泛型约束的泛型接口代码段

```C#
/// <summary>
/// 泛型接口
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
/// <typeparam name="V"></typeparam>
/// <typeparam name="HL"></typeparam>
/// <typeparam name="W"></typeparam>
/// <typeparam name="HE"></typeparam>
public interface IFactory<T, U, V, HL, W, HE, HW>
    where T : class //约束T必须是引用类型
        where U : T//约束U必须是T类型或者T类型的子类
            where V : struct //约束V必须是值类型
                where HL : IComparable //约束HL必须实现了 IComparable 接口
                    where W : struct //约束W必须是值类型
                        where HE : struct //约束HE必须是值类型
                            where HW : class, new() //约束HE必须是引用类型，且有无参构造函数
                            {
                                T sayHi();//返回值泛型
                                HL sayHello(U msg);//参数泛型
                                V Eat();
                                void Eat(HL str);
                            }
```

3.实现了添加泛型约束接口类代码段

```C#
/// <summary>
/// 泛型类实现泛型接口
/// </summary>
/// <typeparam name="T">string</typeparam>
/// <typeparam name="U">string</typeparam>
/// <typeparam name="V">int</typeparam>
/// <typeparam name="HL">string</typeparam>
/// <typeparam name="W">int</typeparam>
/// <typeparam name="HE">double</typeparam>
public class MyClass<T, U, V, HL, W, HE, HW> : IFactory<T, U, V, HL, W, HE, HW>
    where T : class //约束T必须是引用类型
    where U : T //约束U必须是T类型或者T类型的子类
    where V : struct //约束V必须是值类型
    where HL : IComparable //约束HL必须实现了 IComparable 接口
    where W : struct //约束W必须是值类型
    where HE : struct //约束HE必须是值类型，且有无参构造函数
    where HW : class, new() //约束HE必须是值类型，且有无参构造函数
{
    /// <summary>
    /// 返回值泛型
    /// </summary>
    /// <returns></returns>
    public V Eat()
    {
        object obj = 5;
        return (V)obj;
    }

    /// <summary>
    /// 参数列表泛型
    /// </summary>
    /// <param name="str"></param>
    public void Eat(HL str)
    {
        Console.WriteLine(str);
    }

    /// <summary>
    /// 参数列表&返回值均泛型
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public HL sayHello(U msg)
    {
        Console.WriteLine("这是sayHello泛型方法参数：{0}", msg);
        object rest = (object)msg;
        return (HL)rest;
    }

    public T sayHi()
    {
        object ret = "小鸟说早早早";
        return (T)ret;
    }
}
```
