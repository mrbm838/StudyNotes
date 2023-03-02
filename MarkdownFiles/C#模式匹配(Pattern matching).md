---
created: 2023-02-10T10:24:10 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/cqpanda/p/16718934.html
author: 重庆熊猫
            粉丝 - 14
            关注 - 0
        
    
    
    
    
                +加关注
---

# C#教程 - 模式匹配（Pattern matching） - 重庆熊猫 - 博客园

> ## Excerpt
> 更新记录 转载请注明出处： 2022年9月25日 发布。 2022年9月10日 从笔记迁移到博客。 常见匹配模式 类型匹配模式（type pattern） 属性匹配模式（property patter

---
> 更新记录  
> 转载请注明出处：  
> 2022年9月25日 发布。  
> 2022年9月10日 从笔记迁移到博客。

## 常见匹配模式[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E5%B8%B8%E8%A7%81%E5%8C%B9%E9%85%8D%E6%A8%A1%E5%BC%8F)

类型匹配模式（type pattern）

属性匹配模式（property pattern）

匹配模式可以放在多种上下文中：

After the is operator (variable is pattern)

In switch statements

In switch expressions

## 类型匹配模式（type pattern）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E7%B1%BB%E5%9E%8B%E5%8C%B9%E9%85%8D%E6%A8%A1%E5%BC%8Ftype-pattern)

实例：is类型匹配

```
if (obj is string s)
 Console.WriteLine (s.Length);
```

## 属性匹配模式（property pattern）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E5%B1%9E%E6%80%A7%E5%8C%B9%E9%85%8D%E6%A8%A1%E5%BC%8Fproperty-pattern)

注意：从C# 7/8开始引入

实例：属性匹配

```
if (obj is string { Length:4 })
{
    //as same
    // if (obj is string s && s.Length == 4)
    Console.WriteLine ("A string with 4 characters");
}
```

实例：属性匹配

```
bool ShouldAllow (Uri uri) => uri switch
{
    { Scheme: "http", Port: 80 } => true,
    { Scheme: "https", Port: 443 } => true,
    { Scheme: "ftp", Port: 21 } => true,
    { IsLoopback: true } => true,
    _ => false
};
```

实例：

```
{ Scheme: string { Length: 4 }, Port: 80 } => true,
{ Scheme: "http", Port: 80 } when uri.Host.Length < 1000 => true,
```

实例：

```
bool ShouldAllow (object uri) => uri switch
{
    Uri { Scheme: "http", Port: 80 } => true,
    Uri { Scheme: "https", Port: 443 } => true,
}
```

## 元组匹配模式（Tuple Patterns）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E5%85%83%E7%BB%84%E5%8C%B9%E9%85%8D%E6%A8%A1%E5%BC%8Ftuple-patterns)

注意：从C# 8开始支持

实例：

```
int AverageCelsiusTemperature (Season season, bool daytime) => (season, daytime) switch{
    (Season.Spring, true) => 20,
    (Season.Spring, false) => 16,
    (Season.Summer, true) => 27,
    (Season.Summer, false) => 22,
    (Season.Fall, true) => 18,
    (Season.Fall, false) => 12,
    (Season.Winter, true) => 10,
    (Season.Winter, false) => -2,
    _ => throw new Exception ("Unexpected combination")
};
```

## 位置匹配（Positional Patterns）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E4%BD%8D%E7%BD%AE%E5%8C%B9%E9%85%8Dpositional-patterns)

实例：

```
//测试使用的类型
class Point
{
    public readonly int X, Y;
    public Point (int x, int y) => (X, Y) = (x, y);
    //定义解构器
    public void Deconstruct (out int x, out int y)
    {
        x = X; y = Y;
    }
}
var p = new Point (2, 3);
//使用位置匹配模式
Console.WriteLine (p is (2, 3)); // true

//还可以在switch中使用位置匹配模式
string Print (object obj) => obj switch
{
    Point (0, 0) => "Empty point",
    Point (var x, var y) when x == y => "Diagonal"
    //...
};
```

## var匹配（var Pattern）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#var%E5%8C%B9%E9%85%8Dvar-pattern)

注意：从C# 7开始支持

实例：

```
bool Test (int x, int y) =>
         x * y is var product && product > 10 && product < 100;
```

## 常量匹配（Constant Pattern）[#](https://www.cnblogs.com/cqpanda/p/16718934.html#%E5%B8%B8%E9%87%8F%E5%8C%B9%E9%85%8Dconstant-pattern)

可以将常量或字面量作为匹配

实例：

```
void Foo (object obj)
{
    // C# won't let you use the == operator, because obj is object.
    // However, we can use 'is'
    if (obj is 3) //...
    //as same
    //if (obj is int && (int)obj == 3) ...
}
```
