---
created: 2023-03-08T10:45:57 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/shanfeng1000/p/14973804.html
author: 没有星星的夏季
            粉丝 - 144
            关注 - 2
        
    
    
    
    
                +加关注
---

# C#中的记录(record) - 没有星星的夏季 - 博客园

> ## Excerpt
> 从C#9.0开始，我们有了一个有趣的语法糖：记录(record) 为什么提供记录？ 开发过程中，我们往往会创建一些简单的实体，它们仅仅拥有一些简单的属性，可能还有几个简单的方法，比如DTO等等，但是这

---
　　从C#9.0开始，我们有了一个有趣的语法糖：记录(record)　　

## 　　为什么提供记录？

　　开发过程中，我们往往会创建一些简单的实体，它们仅仅拥有一些简单的属性，可能还有几个简单的方法，比如DTO等等，但是这样的简单实体往往又很有用，我们可能会遇到一些情况：

　　比如想要克隆一个新的实体而不是简单的引用传递　　

　　比如想要简单的比较属性值是否都一致，

　　比如在输出，我们希望得到内部数据结构而不是简单的甩给我们一个类型名称

　　其实，这说的有些类似结构体的一些特性，那为什么不直接采用结构体来实现呢？这是因为结构体有它的一些不足：　　

```
    1、结构体不支持继承
    2、结构体是值传递过程，因此，这意味着大量的结构体拥有者相同的数据，但是占用这不同内存
    3、结构体内部相等判断使用ValueType.Equals方法，它是使用反射来实现，因此性能不快
```

　　而引用类型记录，正好弥补了这些缺陷。

　　在C#9.0中，我们使用record关键字声明一个记录类型，它只能是引用类型：　　

　　从C#10开始，我们不仅有引用类型记录，还有结构体记录：

```C#
//使用record class声明为引用类型记录，class关键字是可选的，当缺省时等价于C#9.0中的record用法
public record Animal;
//等价于
public record class Animal;

//使用record struct声明为结构体类型记录
public record struct Animal;
//也可使用readonly record struct声明为只读结构体类型记录
public readonly record struct Animal;
```

　　至于它们是什么，区别上和普通class、struct有什么不一样，我们慢慢道来

## 　　引用类型记录

　　引用类型记录不是一种新的类型，它是class用法的一个新用法，新的语法糖，也就是说record class是引用类型（这个在C#9.0中没有record class的写法，直接使用record）。

　　先看看引用类型记录是什么样子的，首先是**无构造参数的记录**：

```C#
//无构造参数，无其它方法属性等
public record Animal;
//实例化
var animal = new Animal();
```

 　　在编译时，会生成对应的class，大致等价于下面的例子：　　

```C#
public class Animal : IEquatable<Animal>
{
    public Animal() { }
    protected Animal(Animal original) { }

    protected virtual Type EqualityContract => typeof(Animal);

    public virtual Animal <Clone>$() => new Animal(this);
    public virtual bool Equals(Animal? other) => (other != null) && (this.EqualityContract == other.EqualityContract);
    public override bool Equals(object obj) => this.Equals(obj as Animal);
    public override int GetHashCode() => EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract);
    protected virtual bool PrintMembers(StringBuilder builder) => false;
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("Animal");
        builder.Append(" { ");
        if (this.PrintMembers(builder))
        {
            builder.Append(" ");
        }
        builder.Append("}");
        return builder.ToString();
    }

    public static bool operator ==(Animal r1, Animal r2) => (r1 == r2) || ((r1 != null) && r1.Equals(r2));
    public static bool operator !=(Animal r1, Animal r2) => !(r1 == r2);
}
```

　　可以看到，除了几个相比较的方法，那么这个记录的作用几乎等价于object了！这里有一个<Clone>$()，方法，这是编译器生成的，作用后面再解释。

　　再看看**有构造参数的记录：**

```C#
//有构造参数，无其它方法属性等
public record Person(string Name, int Age);
//实例化
var person = new Person("zhangsan", 1);
```

　　注：上面的定义可能会报错：

　　![](https://img2020.cnblogs.com/blog/1033563/202107/1033563-20210719165217198-1026321671.png)

　　据说这是VS2019的一个小BUG，因为记录会生成 init setter，解决办法是添加一个命名空间是System.Runtime.CompilerServices，名称是IsExternalInit类就行了：　　

```C#
namespace System.Runtime.CompilerServices
{
    class IsExternalInit
    {
    }
}
```

　　有构造参数的记录在编译时，会生成对应的class，大致等价于下面的例子：

```C#
public class Person : IEquatable<Person>
{
    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }
    protected Person(Person original)
    {
        this.Name = original.Name;
        this.Age = original.Age;
    }

    protected virtual Type EqualityContract => typeof(Person);
    public string Name { get; init; }
    public int Age { get; init; }

    public virtual Person <Clone>$() => new Person(this);
    public void Deconstruct(out string Name, out int Age) => (Name, Age) = (this.Name, this.Age);
    public virtual bool Equals(Person? other) => (other != null) && (this.EqualityContract == other.EqualityContract) &&
        EqualityComparer<string>.Default.Equals(this.Name, other.Name) && EqualityComparer<int>.Default.Equals(this.Age, other.Age);
    public override bool Equals(object obj) => this.Equals(obj as Person);
    public override int GetHashCode() => (((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Name)) * -1521134295) + EqualityComparer<int>.Default.GetHashCode(this.Age);
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append("Name");
        builder.Append(" = ");
        builder.Append(this.Name);
        builder.Append(", ");
        builder.Append("Age");
        builder.Append(" = ");
        builder.Append(this.Age.ToString());
        return true;
    }
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("Person");
        builder.Append(" { ");
        if (this.PrintMembers(builder))
        {
            builder.Append(" ");
        }
        builder.Append("}");
        return builder.ToString();
    }

    public static bool operator ==(Person r1, Person r2) => (r1 == r2) || ((r1 != null) && r1.Equals(r2));
    public static bool operator !=(Person r1, Person r2) => !(r1 == r2);
}
```

　　可以看到，相比无构造参数的记录，有构造参数的记录将构造参数生成了属性（setter是init），而且Equals、GetHashCode、ToString等方法重载都有这几个属性参与。

　　除此之外，还生成了一个Deconstruct方法，因此，有构造参数的记录就具有解构能力。另外，这里也同样生成了一个<Clone>$方法。

## 记录的属性和方法：

### 　　1、构造函数和属性

　　记录会根据给定的参数生成一个构造函数，同时为每一个构造参数生成一个属性（**为了规范，参数应采用匈牙利命名法，首字符大写**），比如上面的Animal记录，等价于：　　

```C#
public class Animal : IEquatable<Animal>
{
    public Animal(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }

    public string Name { get; init; }
    public int Age { get; init; }

    //其他方法属性
}
```

　　这里的属性的setter是init，也就是说记录具有**不可变性**，记录一旦初始化完成，那么它的属性值将不可修改（可以通过反射修改）。

　　另外，**记录允许我们自定义构造方法和属性，但是需要遵循：**　　

```
    1、记录在编译时会根据构造参数生成一个默认的构造函数，默认构造函数不能被覆盖，如果有自定义的构造函数，那么需要使用this关键字初始化这个默认的构造函数
    2、记录中可以自定义属性，自定义属性名可以与构造参数名重名，也就是说自定义属性可以覆盖构造参数生成的属性，此时对应构造参数将不起任何作用，但是我们可以通过属性指向这个构造参数来自定义这样一个属性
```

　　比如：　　　　

```C#
public record Person(string Name, int Age)
{
    //自定义构造函数需要使用this初始化默认构造函数
    public Person(string Name) : this(Name, 18)
    { }

    //覆盖构造参数中的Age，属性不用是init，可以自定义,public也可以改成internal等等
    internal int Age { get; set; } = Age;//这个赋值很重要，如果没有，构造函数中的参数值将不会给到属性，也就是说构造函数中的Age不起任何作用
    //额外的自定义属性
    public DateTime Birth { get; set; }
}

//等价于

public class Person : IEquatable<Person>
{
    public Person(string Name) : this(Name, 18)
    { }
    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }

    public string Name { get; init; }
    internal int Age { get; set; }//Age改变
    //额外的自定义属性
    public DateTime Birth { get; set; }

    //其他方法及属性
}
```

　　从上面可以看到，虽然记录具有不可变性，但是我们可以通过自定义属性来覆盖原来的行为，让其属性变为可修改的，Age属性有原来的public和init变为internal和set。

　　此外，在创建一个记录时，可以给构造参数指定一些特性标识，在编译时会用这些特性给到生成的对应属性，如：　　

```C#
public record Person([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("age")] int Age);

//等价于

public class Person : IEquatable<Person>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("age")
     public int Age { get; set; }

     //其他方法及属性
}
```

　　其中**property表示特性加在属性上，field表示特性加在字段上，param表示特性加在构造函数的参数上**

### 　　2、记录可以解构

　　上面的例子可以看到，每个记录，在编译时会针对构造参数生成一个Deconstruct 方法，因此记录天生就支持解构：　　

```C#
Person person = new Person("zhangsan", 21);
var (name, age) = person;
Console.WriteLine($"name={name},age={age}");//name=zhangsan,age=21
```

　　**注：解构只针对默认构造函数的构造参数，不计算自定义的属性和构造函数，如果需要，我们还可以重载自己的解构Deconstruct方法**

### 　　3、记录可以继承　　

　　记录可继承，但是需要遵循：　　

```
1、一条记录可以从另一条记录继承，但不能从一个类中继承，一个类也不能从一个记录继承
2、继承的子记录必须声明父记录中各参数
```

　　例如：　　

```C#
public record Person(string Name, int Age);
public record Teacher(string Phone, int Age, string Name) : Person(Name, Age);
public record Student(string Grade, int Age, string Name) : Person(Name, Age);
```

### 　　4、值相等性

　　值相等性一般是值类型的一个概念，而记录是引用类型，要实现值相等性，主要通过三个方面来实现：

-   重写Object的Equals和GetHashCode方法
-   重写运算符 `==` 和 `!=`
-   实现了IEquatable<T>接口

　　重写Object的Equals方法和重写运算符 == 、!=很好理解，因为引用类型在使用Equals方法或者运算符 == 、!=作判断时，是根据对象是否是同一个对象的引用而返回true或者false，例如：　

```C#
public record Person(string Name, int Age);
static void Main(string[] args)
{
    //一般引用类型
    var exception1 = new Exception();
    var exception2 = exception1;
    Console.WriteLine(exception1.Equals(exception2));//true
    Console.WriteLine(exception1 == exception2);//true
    Console.WriteLine(exception1.Equals(new Exception()));//false
    Console.WriteLine(exception1 == new Exception());//false

    //记录
    var person1 = new Person("zhangsan", 18);
    var person2 = person1;
    Console.WriteLine(person1.Equals(person2));//true
    Console.WriteLine(person1 == person2);//true
    Console.WriteLine(person1.Equals(new Person("zhangsan", 18)));//true
    Console.WriteLine(person1 == new Person("zhangsan", 18));//true
}
```

　　对于实现了IEquatable<T>接口，是为了让记录在泛型集合中，如Dictionary<TKey,TValue>, List<T>等，在使用Contains, IndexOf, LastIndexOf, Remove等方法时可以像string，int，bool等类型一样对待，例如：　　

```C#
public record Person(string Name, int Age);
static void Main(string[] args)
{
    //一般引用类型
    List<Exception> exceptions = new List<Exception>() { new Exception() };
    Console.WriteLine(exceptions.IndexOf(new Exception()));//-1
    Console.WriteLine(exceptions.Contains(new Exception()));//false
    Console.WriteLine(exceptions.Remove(new Exception()));//false

    //记录
    List<Person> persons = new List<Person>() { new Person("zhangsan", 18) };
    Console.WriteLine(persons.IndexOf(new Person("zhangsan", 18)));//0
    Console.WriteLine(persons.Contains(new Person("zhangsan", 18)));//true
    Console.WriteLine(persons.Remove(new Person("zhangsan", 18)));//true
}
```

　　换句话说，虽然记录是引用类型，但是我们应该将记录按值类型一样去使用。

　　注意：　　

```
1、实现的IEquatable<T>接口的Equals方法和重写的GetHashCode方法中使用的属性不仅仅是构造参数对应的属性，还包含自定义的属性、继承的属性（包括public，internal，protected，private，但是需要有get获取器）
2、无论是重写Object的Equals方法，还是重写运算符 == 和 !=，最终都是调用实现的IEquatable<T>接口的Equals方法
```

　　虽然记录的值相等性很好用，但是这有个问题，因为记录可继承，那么如果父子记录的属性值一样，如果判定他们相同显然不合理，因此编译时额外生成了一个EqualityContract属性：　　

```
    1、EqualityContract属性指向当前的记录类型（Type），使用protected修饰
    2、如果记录没有从其它记录继承，那么EqualityContract属性会带有virtual修饰，否则将会使用override重写
    3、如果记录指定为sealed，即不可派生，那么EqualityContract属性会带有sealed修饰
```

　　**为了保证父子记录的差异性，在实现的IEquatable<T>接口的Equals方法中，处理判断属性值相同外，还会判断记录类型是否一致，即EqualityContract属性**。

　　那如果说，我们需要只考虑属性值，而不考虑类型时，需要判断他们相等，这时只需要重写EqualityContract属性，将它指向同一个Type即可。

　　此外，可以自定义Equals方法，这样编译时就不会生成Equals方法。

### 　　5、非破坏性变化：with

　　因为记录是引用类型，而属性的setter是init，因此当我们需要克隆一个记录时就出现困难了，我们可以通过自定义属性来修改setter来实现，但这不是记录的初衷。

　　记录可以使用with关键字来实现非破坏性的变化：　　

```C#
public record Person(string Name, DateTime Birth, int Age, string Phone, string Address);
static void Main(string[] args)
{
    //初始化了一个对象
    Person person = new("zhangsan", new DateTime(1999, 1, 1), 22, "13987654321", "中国");
    //如果想改下地址，因为记录的不可变性，不能直接使用属性修改
    //person.Address = "中国深圳";//报错

    //方法一：可以重新初始化，但是不方便
    person = new(person.Name, person.Birth, person.Age, person.Phone, "中国深圳");
    //方法二：可以使用with关键字
    person = person with { Address = "中国深圳" };

    //可以使用with关键字克隆一个对象
    var clone = person with { };
    Console.WriteLine(clone == person);//true
    Console.WriteLine(ReferenceEquals(clone, person));//false
}
```

 　　使用with关键字时会先调用`<Clone>$()`方法来创建一个对象，然后对这个对象进行指定属性的初始化，这就是最开始的例子中`<Clone>$()`方法的作用：　　

```C#
person = person with { Address = "中国深圳" };

//在编译后等价于

var temp=person.<Clone>$();
temp.Address = "中国深圳";
person = temp;
```

　　在写代码时，我们当然不能显式的调用`<Clone>$()`方法，因为名称不合法（它是编译器生成的），`<Clone>$()`方法其实就是调用一个构造函数来实现初始化的，**这表示我们可以通过自定义或者重写这个构造函数来实现我们自己的逻辑**：　

```C#
public class Person : IEquatable<Person>
{
    protected Person(Person original)
    {
        this.Name = original.Name;
        this.Age = original.Age;
    }

    public virtual Person <Clone>$() => new Person(this);

    //其他方法属性
}
```

　　注意，传入构造函数的参数是原始对象，然后使用原始对象中的属性值来进行初始化，如果属性值是一个引用类型，那么它将进行浅复制过程。

　　注：这里with用法针对引用类型记录，值类型记录的with参考后文

### 　　6、内置格式化

　　记录还重写了ToString，可以方便查看，输出格式默认是：　　

```
    记录类型 { 属性名1 = 属性值1, 属性名2 = 属性值2, ...}
```

　　例如：　　

```C#
public record Person(string Name, int Age);
static void Main(string[] args)
{
    //初始化了一个对象
    Person person = new("zhangsan", 22);
    Console.WriteLine(person);
    //输出：Person { Name = zhangsan, Age = 22 }
}
```

　　编译器还合成了一个PrintMembers方法，如果我们有自己提供PrintMembers方法，编译器就不会合成了，所以如果我们想要实现自己的格式化，只需要实现自己的PrintMembers方法，而不用重写ToString方法。　　

```C#
public record Person(string Name, int Age)
{
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append("Name");
        builder.Append(" : ");
        builder.Append(Name);
        builder.Append(", ");
        builder.Append("Age");
        builder.Append(" : ");
        builder.Append(Age.ToString());
        return true;
    }
}
static void Main(string[] args)
{
    //初始化了一个对象
    Person person = new("zhangsan", 22);
    Console.WriteLine(person);
    //输出：Person { Name : zhangsan, Age : 22 }
    //属性名称与值之间使用了：而不是=
}
```

## 　　值类型记录

　　**注：值类型记录只针对C#10及以后的版本有效**

　　值类型记录也就是结构体记录，大体上，值类型记录与引用类型记录的区别，就跟值类型与引用类型的区别差不多，所以具体不介绍，可以参考上面引用类型的介绍，这里只具体介绍它们的区别。

　　值类型记录又分为两种：record struct和readonly record struct，这里结合record class来看看它们的区别：

　　比如有三个record：　　

```C#
public record class Point1(double X, double Y);
public readonly record struct Point2(double X, double Y);
public record struct Point3(double X, double Y);
```

　　这里Point1是record class，Point2是readonly record struct，Point3是record struct，经过编译，它们等价于下面的三个类和结构体（方法体去掉了，具体可参考上面引用类型记录）：　　

```c#
public class Point1 : IEquatable<Point1>
{
    protected Point1(Point1 original);
    public Point1(double X, double Y);

    protected virtual Type EqualityContract { get; }
    public double X { get; set; }
    public double Y { get; set; }

    public virtual Point1 <Clone>$();
    public void Deconstruct(out double X, out double Y);
    public virtual bool Equals(Point1 other);
    public override bool Equals(object obj);
    public override int GetHashCode();
    protected virtual bool PrintMembers(StringBuilder builder);
    public override string ToString();

    public static bool operator ==(Point1 left, Point1 right);
    public static bool operator !=(Point1 left, Point1 right);
}
```

Point1

```C#
public readonly struct Point2 : IEquatable<Point2>
{
    public Point2() { }
    public Point2(double X, double Y);

    public double X { get; init; }
    public double Y { get; init; }

    public void Deconstruct(out double X, out double Y);
    public bool Equals(Point2 other);
    public override bool Equals(object obj);
    public override int GetHashCode();
    private bool PrintMembers(StringBuilder builder);
    public override string ToString();

    public static bool operator !=(Point2 left, Point2 right);
    public static bool operator ==(Point2 left, Point2 right);
}
```

Point2

```C#
public struct Point3 : IEquatable<Point3>
{
    public Point3() { }
    public Point3(double X, double Y);

    public double X {  get; set; }
    public double Y {  get; set; }

    public readonly void Deconstruct(out double X, out double Y);
    public readonly bool Equals(Point3 other);
    public override readonly bool Equals(object obj);
    public override readonly int GetHashCode();
    private bool PrintMembers(StringBuilder builder);
    public override string ToString();

    public static bool operator !=(Point3 left, Point3 right);
    public static bool operator ==(Point3 left, Point3 right);
}
```

Point3

　　可以看到，这三种类型的记录主要有共同点有：　　

```
1、对记录的参数，分别生成了属性
2、生成了一个包含记录所有属性的构造函数
3、重写了 Object.Equals(Object)方法和Object.GetHashCode()方法
4、实现了System.IEquatable<T>接口
5、实现了==和!=运算操作
6、实现了Deconstruct方法而实现解构操作
7、重写了Object.ToString()方法，以及创建了一个PrintMembers用于序列化（但是PrintMembers有些许区别）
```

　　共同点没什么好说的，参考上面引用类型介绍就可以了，接下来说说不同点：

　　**1**、record class和readonly record struct生成的属性是get和init标识，也就是说它们的对象是只读的，而record struct生成的属性是get和set标识，也就是说它的对象是可读可写的

　　例如：

```C#
    var point1 = new Point1(1, 2);
    point1.X = 2;//报错
    var point2 = new Point2(1, 2);
    point2.X = 2;//报错
    var point3 = new Point3(1, 2);
    point3.X = 2;//编译通过
```

　　**2**、在构造函数上，record class会生成两个构造函数：一个是protected修饰，用于`<Clone>$()`方法克隆一个对象，一个public修饰，包含所有的构造参数，而readonly record struct和record struct只包含一个public修饰，包含所有的构造参数的构造函数，但是因为它们的本质还是结构体，因此默认会有一个空构造函数，因此在创建时有区别：

```C#
    //创建时需要指定所有的参数，protected修饰的构造函数不能在记录及子记录外使用
    var point1 = new Point1(1, 2);

    //除了可以指定所有参数的构造函数，还可以使用空构造函数初始化
    var point2 = new Point2(1, 2);
    point2 = new Point2();
    var point3 = new Point3(1, 2);
    point3 = new Point3();
```

　　**3**、record class类型记录会生成一个`<Clone>$()`方法，它通过调用一个protected的构造函数来克隆出一个新的引用对象，而我们可以通过自定义或者重写这个protected的构造函数的构造函数来实现我们自己业务逻辑。

　　其实这个`<Clone>$()`方法是在with关键字中使用的：　　

```C#
    var point1 = new Point1(1, 2);
    var point = point1 with { X = 2 };

    //等价于

    var point1 = new Point1(1, 2);
    var point = point1.<Clone>$();
    point.X = 2;
    //注：编译时给point.X赋值会报错（因为init），这里只是说明
```

　　而对于readonly record struct和record struct类型记录，因为它们的本质是struct，天生是值复制的，因此就不需要这么一个`<Clone>$()`方法了，与此对应的是，结构体默认会有空构造函数（C#10）。

```C#
    var point2 = new Point2(1, 2);
    var point = point2 with { X = 2 };

    //等价于

    var point = point2;//struct是值复制过程
    point.X = 2;
    //注：编译时给readonly record struct声明的属性赋值会报错，而给record struct声明的属性赋值不会报错，这里只是说明
```

　　**4**、record struct，readonly record struct，record class都可以拥有自定义属性，但是有些许区别　　

```
1、record class按类中的属性规则去定义
2、record struct按结构体中的属性规则去定义，此外，定义的属性必须进行初始化
3、readonly record struct按结构体中的属性规则去定义，此外，定义的属性必须进行初始化，而且定义的属性只能是只读的
```

　　例如：　　

```C#
    public record class Point1(double X, double Y)
    {
        public double Z { get; set; }
    }
    public readonly record struct Point2(double X, double Y)
    {
        public double Z { get; } = default;//必须初始化，此外readonly修饰所以只能只读
    }
    public record struct Point3(double X, double Y)
    {
        public double Z { get; set; } = default;//必须初始化
    }
```

　　**5**、record struct，readonly record struct，record class都实现了System.IEquatable<T>接口，而且重写了Object.Equals(Object)方法（本质上是通过System.IEquatable<T>接口来实现），但是record class中实现的Equals方法除了比较属性以外，还会比较记录的类型是否一致（即比较EqualityContract属性，这一点可以参考上面介绍的引用类型记录的值相等性部分），而对于record struct，readonly record struct，在编译时，并没有生成一个EqualityContract属性，在实现的Equals方法也只是比较了属性值，没有比较类似是否一致。

　　其实想想，结构体只能实现接口，而不能从另一个结构体派生，因此在在实现的Equals方法自然就没有进行类型判断的必要了。

　　**6**、record struct，readonly record struct，record class都重写了Object.ToString()方法，而且都是通过创建了一个PrintMembers方法来实现的，但是在PrintMembers方法上表现的行为不一致（这是一点细节，了解即可）。　　

```
1、如果记录是结构体记录（即record struct和readonly record struct），或者使用sealed关键字修饰，那么生成的PrintMembers方法是：private bool PrintMembers(StringBuilder builder);
2、如果记录没有使用sealed关键字修饰，且记录直接派生自Object（即没有派生自一个父记录），那么生成的PrintMembers方法是：protected virtual bool PrintMembers(StringBuilder builder);
3、如果记录派生自一个父记录，那么生成的PrintMembers方法是：protected override bool PrintMembers(StringBuilder builder);
```

　　**总结**

　　记录是一个语法糖，本质上还是class或者struct，它只编译时生效，运行时并没有记录这个东西，此外，根据官网介绍，**记录不适合在EntityFrameworkCore中使用，毕竟它重写了Equals方法和相等运算（==和!=），这样可能会对EntityFrameworkCore的实体跟踪机制造成影响**

　　参考文档：[https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
