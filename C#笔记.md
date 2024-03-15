### 第二天
##### 9.转义符
"\n"虽然可以被控制台识别为换行，当不能被文本识别，需要”\r\n“。
"\b"表示一个退格键，但是在字符串两侧时不启用。
"\t"表示Tab键，用于对齐。
@表示取消\在字符串中的转义作用，让代码按编译的原格式输出。

##### 11.强制类型转换
```c#
double = int / int;//只能输出int，输出double最快是(int * 1.0)/int
```

{0:0.00}，使用占位符保留两位小数。

### 第三天

##### 2.交换变量

```C#
//不增加变量的情况下交换两个变量的值
int a = 10;
int b = 20;
a = a - b;
b = a + b;
a = b - a;
Console.WriteLine(a, b);
```

##### 3.自增自减运算符

```c#
int a = 5;
int b = a++ + (++a) * 2 + ++a;
//		5	+	 7  * 2 + 	8
//a = 8; b = 27
```

##### 4.关系运算符和逻辑运算符

```c#
Console.WriteLine(1 == 5);//结果为False

5 < 4 & 4 < 9;
5 < 4 && 4 < 9;
//&&如果第一个式子为False则不会运算第二个式子，&则会，&&效率更高
```

### 第五天

##### 1.for循环的快捷键：

正序：for+tab，倒序：forr+tab

##### 2.out\ref 关键字

```c#
static void ShowDouble(int num)
{
    num = num * 2;
    Console.WriteLine("num*2={0}", num);
}

int num = 5;
Console.WriteLine("num={0}", num);
ShowDouble(num);
Console.WriteLine("num={0}", num);
```

①以上num值不变；当需要改变时，修改如下：

```c#
num = DoubleNum(num);
```

②使用ref关键字，将值传递变成引用传递。侧重于将变量带入方法内进行改变，使得函数处理的变量和调用的变量相同

```c#
ShowDouble(ref num);
//使用条件
//1.改变量（num）不能是常量（const）
//2.必须使用初始化的变量
//此时实参num和形参num在栈上的地址是一样的，因此两个参数的值也是一样的
```

③out关键字

```c#
int result = 100;
bool b = int.TryParse("12abc3", out result);
Console.WriteLine(result);
Console.WriteLine(b);
Console.ReadKey();
//TryParse()尝试转换为int类型
//输出结果：0  false
```

out的执行方式与ref一样，区别在于：

**赋值要求：**

- `ref`关键字要求在传递给方法之前，参数必须被初始化。这意味着在调用方法之前，你需要为`ref`参数分配一个初始值。
- `out`关键字不要求在传递给方法之前对参数进行初始化。在调用方法时，可以将未初始化的变量传递给`out`参数，但在方法内部，必须确保在离开方法之前给`out`参数赋值。

```c#
int result;
MyTryParse("aa", out result);
bool MyTryParse(string str, out int result)
{
    try
    {
        result = Convert.ToInt32(str);
        return true;
    }
    catch
    {
        result=0;//转换失败，这也是为什么TryParse()其修饰的变量的值会丢失，重新赋值为0
        return false;        
    }
}
```

##### 8.输出质数

```c#
for(int i = 2; i <= 100; i++)
{
    bool b = ture;
    for(int j = 2; j < i; j++)
    {
        if(i / j == 0)
        {
            b = false;
            break;
        }
    }
    if(b)
    	Console.WriteLine(i);
}
```

##### 9.随机数

```c#
Random r = new Random();
while(true)
{
    int rNUm = r.Next(1,10);//产生1-9的随机数
    Console.WriteLine(rNum);
    Console.ReadKey();
}
```

##### 11.枚举类型

<details>
    <summary>枚举</summary>
    <pre><code>
     public enum QQState
     {
         OnLine,
         OffLine = 5,
         Leave,
         Busy,
         QMe
     }
    /// <summary>
    /// enum convery to int 
    /// </summary>
    int n = (int)QQState.OnLine;
    Console.WriteLine(n);
    Console.WriteLine(QQState.OffLine); 
    Console.WriteLine((int)QQState.Leave);
    //输出： 0  OffLine  6
    /// <summary>
    /// int convery to enum
    /// </summary>
    int a = 1;
    QQState qQState = new QQState();
    qQState = (QQState)a;
    Console.WriteLine(qQState);
    QQState qQState1 = (QQState)5;
    Console.WriteLine(qQState1);
    //输出： 1  OffLine
    //因为从OffLine就是从5开始，顾没有1，原样输出
    /// <summary>
    /// Type enum to string
    /// </summary>
    string str1 = QQState.OnLine.ToString();
    Console.WriteLine(str1);
    //输出：OnLine
    //所有类型都能转换为string类型
    Console.WriteLine(QQState.Leave.ToString());
    Console.WriteLine(QQState.Leave);//隐式转换
    /// <summary>
    /// Type string to enum
    /// </summary>
    QQState q = (QQState)Enum.Parse(typeof(QQState), "0");
    Console.WriteLine(q);
    //输出：OnLine
    QQState q = (QQState)Enum.Parse(typeof(QQState), "10");
    Console.WriteLine(q);
    //输出：10
    //没有10，原样输出
    QQState q = (QQState)Enum.Parse(typeof(QQState), "OnLine");
    Console.WriteLine(q);
    //输出：OnLine
    QQState q = (QQState)Enum.Parse(typeof(QQState), "Hello");
    //抛出异常，枚举内无Hello
    </code></pre>
</details>

##### 12.结构体

字段与变量的区别在于，字段能存储多个值，例如下面的性别。

<details>
    <pre><code>
    public struct Person
    {
        public string _name;
        public int _age;
        public Sex _sex;
    }
    public enum Sex
    {
        man,
        woman
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person._name = "Kobe";
            person._age = 11;
            person._sex = Sex.man;
            Console.WriteLine(person);
            FieldInfo[] fieldInfos = typeof(Person).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine(fieldInfo.Name);
                Console.WriteLine(fieldInfo.GetValue(person));
                Console.WriteLine(fieldInfo.FieldType);
            }
            Console.ReadLine();
        }
    }
    //输出：
    Person
    _name
    Kobe
    System.String
    _age
    11
    System.Int32
    _sex
    man
    Sex
    </code></pre>
</details>

### 第六天

##### 1.数组升序、降序和求平均

```c#
string[] arr = { "abc", "ghi", "def", "bbb", "waa","a11","acd" ,"66666","11a","11b"};

//Array.Reverse(arr);
Array.Sort(arr);
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
//输出
//11a 11b 66666 a11 abc acd bbb def ghi waa
```

Array.Sort()实现数组的升序排列。

```c#
int[] num = { 001, 2, 366, 42, 5, 87, 9 , -100, -0};

Array.Sort(num);
for (int i = 0; i < num.Length; i++)
{
    Console.Write(num[i] + " ");
}
//输出
//-100 0 1 2 5 9 42 87 366
```

Array.Reverse()实现数组的反转。

```c#
//实现数组降序排列-先升序后反转
Array.Sort(num);
Array.Reverse(num);
for (int i = 0; i < num.Length; i++)
{
    Console.Write(num[i] + " ");
}
//输出
//366 87 42 9 5 2 1 0 -100
```

`doublenum.Average();`实现求数组平均值，返回double类型数据。

##### 2.调用方法

方法实现单一功能， 用于解决代码冗余，实代码重复使用。

方法只实现功能，要避免出现提示性内容。

返回类型 变量名 = 类名.方法名(参数)；

##### 3.方法中return的作用

①返回函数的返回值

②立即结束该方法

##### 4.方法获取调用者的值

①传递参数

②（在类里面）声明静态字段，C#没有“全局变量”

##### 5.调用者获取方法的值

##### 6.Try_Catch_Finally

[(21条消息) try-catch-finally的执行顺序_近未来-CSDN博客](https://blog.csdn.net/qq_40933663/article/details/88824391)

①finally代码块始终会执行

②无return：按执行顺序执行

finally无return：将try和catch里面的return值存储起来，执行完finally后return。

finally有return：将返回finally内的值。

### 第七天

##### 1.方法的重载

指方法的名称相同，但是参数不同，与返回类型无关。

##### 2.params可变参数数组

将方法内最后且连续的所有相同类型的实参归为同一个数组里

```c#
GetSum("yjq", 1, 2, 3, 4, 5);
GetSum("yjq", 0.1, 1, 2, 3, 4, 5);

static void GetSum(string name,double d_n, int i_n, params int[] n)
{
    int sum = 0;
    for (int i = 0; i < n.Length; i++)
    {
        sum += n[i];
    }
    Console.WriteLine("the sum of {0} is {1}",name,sum);
}

//输出
//the sum of yjq is 12
//the sum of yjq is 14
```

##### 3.方法的递归

```c#
int i = 0;
Tell(i);

static void Tell(int i)
{
    Console.WriteLine(i);
    i++;
    if (i > 3)
    {
        return;
    }
    Tell(i);
}
```

return中止当前方法的执行，故返回上一层，则i变量的值的变化是：0-1-2-3-4-3-2-1-0

##### 4.保留两位小数

```C#
int[] num = { 22, 43, 3, 55, 2, 66 };
double avg = GetAvg(num);

//输出时保留两位小数
Console.WriteLine("{0:0.00}", avg);
Console.WriteLine(avg);

//存储为两位小数
avg = Convert.ToDouble(avg.ToString("0.00"));//("f2")
Console.WriteLine(avg);

Console.Read();

static double GetAvg(int[] num)
{
    double sum = 0;
    for (int i = 0; i < num.Length; i++)
    {
        sum += num[i];
    }
    return sum / num.Length;
}

//输出
//31.83
//31.833333333333332
//31.83
```

##### 5.分割数组元素

```C#
static void CutApart(int[] num)
{
    string str = null;
    for (int i = 0; i < num.Length - 1 ; i++)
    {
        str += num[i] + ",";
    }
    Console.WriteLine(str + num[num.Length - 1]);
}
```

### 第八天

##### 1.控制台颜色

```C#
Console.ForegroundColor = ConsoleColor.Blue;
```

##### 2.按下的键不显示在控制台

```C#
Console.ReadKey(true);
```

##### 3.面对对象

* 程序中，描述一个对象（被操作的事物），描述的是对象的属性和方法
* 类中成员：字段、属性、方法、构造函数
* 字段：类中唯一用于存储数据
* 属性即对象具有的各种特征
* 方法即对象能进行的行为
* 类是模板、标准，确定对象拥有的特征和行为

### 第九天

##### 1.类的实例化

1. 类中成员不加访问修饰符，默认是private，只能在类内访问。
   类的成员：数据成员（常量和字段）和函数成员（属性和方法）。
2. this关键字代表当前类的对象(在没有与字段同名的局部变量时也可省略)。

##### 2.类的属性

```C#
private string _name; // field
public string Name // property
{
    get { return _name; }
    set { _name = value; }
}
// equivalent to
public string get_Name()
{
    return this._name;
}
public void set_Name(string value)
{
    this._name = value;
}
```

**属性的本质是方法，是为了保护字段，对字段的取值和设置进行限定。字段在类内使用，属性供类外部访问。**

```C#
int _age;
public int Age
{
    get { return _age; }
    set
    {
        if (value < 0 || value > 130)
        {
            value = 0;
        }
        _age = value;
    }
}
char _gender;
public char Gender
{
    get
    {
        if (_gender != '男' || _gender != '女')
        {
			return _gender = '男';
        }
        return _gender;
    }
    set { _gender = value; }
}
// Equal to automatic attribute, but the bottom one can't add condition。
// In addition, automatic attribute still implicit creation of field.
public int Age
{
	get;
    set;
}
```

1. 既有get方法又有set方法称为可读可写属性。
2. 只有get方法称为只读属性。
3. 只有set方法称为只写属性。（类似文件的属性）

用new创建对象称为类的实例化，依次给对象的每个属性赋值称为对象的初始化。

为属性赋值：
①在构造函数内
②在类实例化时

```C#
YDog sourceP = new YDog() { Name = "大黄" };
```

##### 3.构造函数

该函数主要用来在创建对象时初始化对象，即为所创建对象的成员变量（字段和属性）赋初值。

```C#
public Student(string name, int age, char gender)
{
    this.Name = name;
    if (age < 0 || age > 130)
    {
        age = 0;
    }
    this.Age = age;
    this.Gender = gender;
}
```

new关键字的作用：

1. 开辟内存空间（在内存的堆中开辟）
2. 在开辟的内存空间中创建对象
3. 调用对象的构造函数（此时构造函数的访问修饰符必须为public）

构造函数的访问修饰符：

一般情况下使用的是public。如果有特殊要求的情况下，可能使用private修饰。

如果一般常见的单例模式:

```C#
public class Singlton
{
    private static Singleton _Instance;
    provate static readonly object syslocker = new object();
    //私有化构造函数
    private Sinalton()
    {
    }
    public static Singlton GetInstance()
    {
        if(_Instance == null)
        {
            lock(syslocker)
            {
                if(_Instance == null)
                {
                    _Instance = new Singlton();
                }
            }
        }
        return _Instance;
    }
}
```

这种形式就必须使用private将构造私有化，然后通过GetInstance()方法获得实例。这样能保存生成的实例是单一的。不允许用户使用构造函数重新构造。

不管怎么说，==虽然我们可以对实例进行私有化，但必须有其他的静态方法来获得实例==。如果不通过静态方法或静态属性来获得得实例，那么这么类就没有存在的必要了。

构造函数的特点：

1. 没有返回类型
2. 类自动生成一个无参构造函数
3. 构造函数可以重载（重载的构造函数后会替换掉自动生成的）

##### 4.C#数据类型

1. 值类型（int,double,char,bool,decimal,struct,enum...）
   
   * 值类型的值存储在栈中，继承与System.ValueType(依然继承object)。
   * ValueType重写了Equals()方法，故值类型只比较地址上的值
   * 值类型之间赋值只是传递值，即两个不同地址存储相同的值。
   * 值类型是密封的（seal），不能派生新的类型。
   * 值类型不能包含null值，但是可空类型允许将null赋值给值类型`int? a = null;`
2. 引用类型（string,数组,集合,类,接口,委托）
   
   * 引用类型的值存储在堆中，栈中存储指向堆的地址，均继承于System.Object。
   
   * `Person person = null;`此语句在栈上开辟一个内存空间用于容纳一个地址。
     `person = new Person();`此语句在堆上开辟一个内存空间存储对象，并将堆地址存储在栈上。
   * 引用类型之间的赋值是传递引用，即传递堆的地址，改变栈存储的地址，不会回收释放原先对象的内存空间；只复制对象的引用，而不复制对象本身。
   * 引用类型可以派生新的类型。
   * 引用类型可以包含null值。
3. 指针类型

##### 5.静态类

1. 静态类不能实例化。
   意义：①防止将该类实例化。②防止在类内声明任何实例字段或方法。
2. 仅包含静态成员。
3. 密封。
4. 不包含实例构造函数。

用法：

1. 工具类（常用）写成静态类。
2. 资源共享。静态类是自程序开始运行时就占内存空间的，程序结束才释放；例：登录QQ时，将账号密码放在静态类中，后续用QQ账号登录其它应用时可用QQ登录。

**静态成员和实例成员**

1. 被static修饰的成员是静态成员，是属于类的，==通过类名访问==。不被static修饰的成员是实例成员，是属于对象的，==通过对象名访问==。

2. 静态成员创建在静态存储区。实例成员随对象创建在堆中。（C#中内存分为堆、栈、自由存储区、全局/静态存储区和常量存储区5个区）

3. 静态成员只在类第一次访问时创建一次。~~实例成员数量和对象数量一致。~~

4. 静态成员一旦创建就不会被回收，直到程序结束。实例成员随对象一起回收。

5. |          静态          |          实例          |
   | :--------------------: | :--------------------: |
   |    static关键字修饰    |     无static关键字     |
   |      使用类名调用      |      使用对象调用      |
   | 方法中可以访问静态成员 | 方法中可以访问静态成员 |
   |  通过对象访问实例成员  | 方法中可以访问实例成员 |
   |   调用前就已经初始化   |   实例化对象时初始化   |

##### 6.不同项目之间类的应用

1. 在该项目的引用中，添加其它项目。
2. 在该项目的类中，引用其它项目的命名空间。

**访问修饰符**

public:可被外部的类访问。
protected:只能在当前类或其派生类中访问。
private(field&function default):只能在类内访问。
internal(class default):只能在当前程序集中使用。

**内部类和外部类**：

[C#中的成员内部类(实例讲解)_椰子树的博客-CSDN博客](https://blog.csdn.net/qq_42630106/article/details/106862735?ops_request_misc=%7B%22request%5Fid%22%3A%22164524799616781683920994%22%2C%22scm%22%3A%2220140713.130102334.pc%5Fall.%22%7D&request_id=164524799616781683920994&biz_id=0&utm_medium=distribute.pc_search_result.none-task-blog-2~all~first_rank_ecpm_v1~rank_v31_ecpm-3-106862735.pc_search_result_cache&utm_term=C%23内部类&spm=1018.2226.3001.4187)

1. 外部类和内部类互相访问对方的静态成员时，必须通过“类名.成员名”的形式访问。
2. 外部类只能访问内部类用public或者internal修饰的成员；内部类可以访问外部类任何访问级别的成员。
3. 其它类访问内部类时，类名为“外部类.内部类”。

##### 7.StringBuilder

在一般情况下，`StringBuilder` 的性能通常优于使用 `string` 的 `+=` 操作符来拼接字符串，主要是因为字符串是不可变的（immutable），String对象在声明之后在内存中的大小是不可修改的。

当你使用 `string` 类型的 `+=` 操作符来拼接字符串时，每次进行拼接都会创建一个新的字符串对象，都会在堆中开辟新空间（引用类型），而原有的字符串对象并没有被修改，而是被丢弃。这意味着在循环或大量字符串拼接的情况下，会产生大量的临时字符串对象，造成额外的内存开销和性能损耗。

`StringBuilder` 类通过维护一个可变的字符缓冲区来解决这个问题。它允许你在同一个对象上进行多次追加操作，而不需要创建新的对象。这样可以避免创建大量的中间字符串，提高字符串拼接的性能。

然而，当涉及到 `Replace()` 方法时，`StringBuilder` 的性能可能受到影响。因为 `Replace()` 操作实际上也会创建一个新的 `StringBuilder` 对象，而不是在原有的对象上直接进行替换。这可能导致在使用 `Replace()` 方法时，`StringBuilder` 的性能不如 `string` 的 `Replace()` 方法。

总的来说，`StringBuilder` 在大多数情况下提供了更好的性能，尤其是在循环或大量字符串拼接的情况下。但是，对于单次替换操作，可能 `string` 的 `Replace()` 方法更为直接。

```C#
string str = "aa";
StringBuilder sb = new StringBuilder();
sb.Append(str);
Stopwatch sw = new Stopwatch();
sw.Start();
for (int i = 0; i < 100000; i++)
{
    sb.Replace("aa", "aa", 0, 2);
}
sw.Stop();
Console.WriteLine(sw.Elapsed);
sw.Restart();
for (int i = 0; i < 100000; i++)
{
    str += "aa";
}
sw.Stop();
Console.WriteLine(sw.Elapsed);
Console.ReadKey();
```

##### 8.StringBuilder和String的性能比较

```
|                   Method |      Mean | Allocated |
|------------------------- |----------:|----------:|
|  AppendWithStringBuilder |  38.05 μs |     40 KB |
|         AppendWithString | 411.68 μs |  2,791 KB |
|  InsertWithStringBuilder | 116.05 μs |    100 KB |
|         InsertWithString | 179.68 μs |  1,004 KB |
|  RemoveWithStringBuilder |  90.62 μs |     12 KB |
|         RemoveWithString | 139.29 μs |    382 KB |
| ReplaceWithStringBuilder | 571.77 μs |     12 KB |
|        ReplaceWithString | 106.71 μs |    137 KB |
```

时间上，StringBuilder方法快于String方法，**除了Replace()方法**。

空间上，StringBuilder方法比String占用少得多的空间。

##### 9.使用StringBuilder地方

- We expect a lot of operations on a string
- We need to perform a lot of search operations (StringBuilder doesn’t have the `Contains()`, `IndexOf()`, or `StartsWith()` methods)
- There’s an indefinite number of operations (e.g., using a while loop)

On the other hand, if we have to perform a few operations or a fixed number of operations on a string literal, we’ll be better off using the plain old `String` class.

##### 10.操作字符串的方法

1. ToCharArray()

   因为String的不可变性，故String可看作char的==只读==数组。

   ```C#
   string str = "abcd";
   char c = str[0];
   // using cycle
   char[] ch = new char[10];
   int n = 0;
   foreach (char c in str)
   {
       ch[n] = c;
       n++;
   }
   for	(int i = 0; i < str.Length, i++)
   {
       ch[i] = str[i];
   }
   ```

   改变单个字符，需将字符串转换为char数组。

   ```C#
   char[] ch = str.ToCharArray();
   // Equal to
   char[] ch1 = str.ToArray<char>();
   // Equal to
   char[] ch1 = str.ToArray();
   ch[0] = "b";
   // char数组转换为字符串
   str = new String(ch);
   ```

2. Equals()

   **Equals()和==的区别**

   [C#中equal与==的区别 - 陈胜威 - 博客园 (cnblogs.com)](https://www.cnblogs.com/dearbeans/p/5351695.html)

   1. ==判断的是堆栈中的值，Equals判断的是堆中的值。

   2. 对于值类型，==与Equals作用相同，都是判断值是否相等。

   3. 对于引用类型，==比较两个堆地址是否相等，Equals比较两个对象在堆中的值是否相等。

   4. ~~String类型虽然是引用类型，但对String对象的赋值是按值类型的操作~~

      ```C#
      String s1 = "hello";
      String s2 = "hello";
      Console.Write(s1 == s2); // true
      Console.write(s1.Equals(s2)); // true
      ```

      因为赋值给s2的对象的值与s1相等，在对s2初始化时，没有在堆中开辟内存地址，而是在栈中存储指向s1内容的堆地址，故相等。

      ~~两个String类型做“==”，先判断栈中存储的内存地址是否相等，不等则再比较值是否相等。~~
      
   5. 重写Equals()方法
      使用Equals()比较两个对象时，字段、属性等存储在堆上，方法存储在方法表里，只有在比较同一个对象才能返回true。因此只需要比较两个对象内的字段或属性时，需要重写

   6. 在做比较时，要考虑将比较方转为统一格式时，需要忽略大小写。

      ```C#
      s1.ToUpper() == s2.ToUpper();
      s1.ToLower() == s2.ToLower();
      // Or
      s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
      ```

   
   Equals()方法内参数有的是object类型，需要进行转换，专门的字符串比较函数有CompareTo()\string.Equals()\string.Compare()\string.CompareOrdinal()等等。
   
3. Split()

   ```c#
   string str = " a b ,  -- , cd";
   string[] s3 = str.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
   // s3: a,b,cd
   ```

4. String.Join(char, object[])
   在数组元素中插入字符。

   eg.将字符串"  hello      world,你  好 世界   !    "两端空格去掉，并且将其中的所有其他空格都替换成一个空格，输出结果为："hello world,你 好 世界 !"。
   
   ```C#
   string str = "  hello      world,你  好 世界   !    ";
   string[] strings = str.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
   str = String.Join(" ", strings);
   Console.WriteLine(str);
   ```
   
4. Replace()

5. Substring(int startIndex, int length)

6. Contains()
   ctrl+j : 显示提示
   ctrl+shift+space : 显示方法重载

7. StartsWith()/EndsWith()
   字符串以什么开头/结尾。

8. IndexOf(char index, int startIndex)/LastIndexOf()
   
   <details>
       <summary>返回第一个/最后一个出现字符的索引</summary>
       <pre><code>
       // Finding all char in a string
       // Circular method
       string a = "abcdabcda";
       int temp = 0;
       int num = 0;
       for (int i = 0; i < a.Length; i++)
       {
           temp = a.IndexOf('a', temp);
           if (temp != -1)
           {
               temp++;
               num++;
           }
           else
           {
               break;
           }
       }
       // Or
       do
       {
           num++;
           temp = a.IndexOf('a', temp + 1);
       }
       while (temp != -1);
       num--;
       Console.WriteLine("There has {0} pieces of 'a'", num);
       // Recursion method
       int temp = 0;
       int num = 0;
       CountChar(temp, ref num);
       Console.WriteLine("There has {0} pieces of 'a'", num);
       static void Addd(int temp, ref int num)
       {
           string a = "abcdabcda";
           temp = a.IndexOf('a', temp);
           if (temp != -1)
           {
               num++;
               CountChar(++temp, ref num);
           }    
       }
       string path = @"c:\windds\saf\dfadfd\3oitj\yjq.cs";
       int index = path.LastIndexOf('\\');
       string name = path.SubString(index + 1);
       </code></pre>
   </details>
   
9. Trim()/TrimStart()/TrimEnd()
   去掉字符串左右两边/左边/右边的空格。
   
11. ToArray<T>()
    转换为一个数组。
    
12. string.IsNullOrEmpty()

    ```C#
    string str = "123";
    if (string.IsNullOrEmpty(str)) {}
    // Equal to
    if (str == null || str == "") {}
    ```
    
13. Select<>
    根据条件返回新的序列。

14. Single<>
    根据返回符合条件的一个值。

### 第十天

##### 1.封装

将重复代码封装成一个方法；将私有字段封装到属性；将事物的行为和特征封装到类中；将能实现一套流程的数个类封装到一个程序集里；以上都是封装的体现。

##### 2.继承

1. 继承是为了解决多个类中相同属性和方法的冗余。 
2. ==子类继承父类除私有成员和构造函数外的其它实例成员==。
3. 由于子类继承父类的成员，因此需要初始化父类成员。故在默认情况下，子类在执行构造函数前，会生成一个父类对象，并调用父类的无参构造函数。
   当父类存在带参构造函数替换了无参构造函数时，以下解决办法：
   1. 在父类中创建一个无参构造函数。
   2. 在子类构造函数后使用`base()`显示调用父类构造函数；
      基类的构造函数会首先执行，然后才是派生类的构造函数。
4. ==在子类中，通过`base`只能调用父类的公有和保护的实例成员==。
5. 继承的特性
   1. 单根性
   2. 传递性：可以继承父类的父类

##### 3.`new`关键字

1. 创建对象
2. 在子类中，隐藏从父类继承来的同名函数。（不用new效果一样）

##### 4.`this`关键字

1. 代表当前类对象

2. 显式调用自己的构造函数

   ```C#
   public Student(string name, int age, char gender, int id)
   {
       this.Name = name;
       this.Age = age;
       this.Gender = gender;
       this.ID = id;
   }
   public Student(string name, int age, char gender):this(name,age,gender,0)
   {}
   public Student(int age, char gender, int id):this(null,age,gender,id)
   {}
   ```

##### 5.里氏转换

1. 子类对象可以赋值给父类引用。

   ```C#
   Person s = new Student();
   	   引用     对象
   // Equal to
   Student s = new Student();
   Person p = s;
   
   //For example
   string s = string.Join("|", 1, 3.14, true, 'c', "param_obj");
   ```

2. 如果父类引用指向子类对象，那么可以将这个父类强制转换为子类对象。（**意味着强制转换要求是继承关系）**

   ```C#
   Person p = new Student();
   Student s = (Student)p;
   ```

##### 6.`as is` 关键字

1. `is`：能否类型转换，转换成功返回true，否则返回false。

   ```C#
   if (p is Student)
   {
       Student t = (Student)p;
   }
   ```

2. `as`：进行类型转换，转换成功返回转换后的对象，否则返回null。
   object = 类型；          

   类型 = (类型)object;    ==>    类型 = object as 类型；

3. Example
   因为子类对象赋值给父类引用时，表现的是父类类型，无法调用子类方法，所以要转换为子类对象。

   ```C#
   if (p is Student)
   {
       ((Student)p).Hello();
   }
   else
   {
       p.Hello();
   }
   ```

##### 7.`var`

在C#中，使用 `var` 关键字进行隐式类型声明有几个原因和好处：

1. **代码简洁性**：使用 `var` 可以使代码更加简洁。当变量类型明显时，使用 `var` 可以避免重复类型名称，使代码更加易读。

2. **易于重构**：当更改变量的类型时，使用 `var` 可以减少需要修改的代码量。因为类型是由编译器推断的，所以只需更改赋值部分即可。

3. **提高可读性**：在某些情况下，使用 `var` 可以使代码更易于理解。特别是在使用复杂类型（如LINQ查询或匿名类型）时，`var` 可以避免冗长的类型声明。

4. **匿名类型支持**：在处理匿名类型时必须使用 `var`，因为匿名类型的名称无法在代码中显式地写出。

5. **与动态类型区分**：在C#中，`var` 是静态类型的，这意味着类型在编译时就已确定。这与 `dynamic` 类型相对，后者在运行时才确定类型。使用 `var` 可以明确表达这种静态类型的意图。

然而，也有一些情况下不推荐使用 `var`，例如当类型不明显时，过度使用 `var` 可能会降低代码的可读性。因此，是否使用 `var` 应根据具体情况和团队的编码标准来决定。

### 30.匿名类型

匿名类型在C#中是一种特殊的数据类型，它允许你创建一个没有显式定义类的对象。这个特性在快速构建数据结构时非常有用，尤其是在不需要或不想为数据创建完整类定义的情况下。

使用匿名类型，你可以即时定义一个对象及其属性，而不需要事先定义一个类。它通常与 `var` 关键字一起使用，因为匿名类型的实际类型名称是由编译器生成的，对于程序员来说是未知的。

匿名类型的常见用途包括：

- **LINQ 查询的结果**：在使用LINQ进行数据查询时，你经常需要创建包含不同数据源或部分数据字段的结果集。匿名类型可以快速创建这样的结果集。

- **临时数据结构**：当你需要一个简单的数据结构来存储几个相关的数据，但这个结构在其他地方不会再次使用时，匿名类型是一个好选择。

一个匿名类型的例子如下：

```csharp
var person = new { Name = "John Doe", Age = 30 };
```

在这个例子中，我们创建了一个拥有 `Name` 和 `Age` 属性的新对象。这个对象的类型是由编译器自动生成的，因此我们使用 `var` 来进行声明。

匿名类型是只读的，这意味着一旦你创建了一个匿名类型的实例，就不能修改其属性的值。这些特性使得匿名类型在某些特定场景中非常有用。

### 31.`dynamic`动态类型

在C#中，`dynamic` 关键字是用于声明一个动态类型的变量。使用 `dynamic` 关键字的变量在编译时不具有静态类型检查，而是在运行时解析类型。这为一些特定的场景提供了灵活性，但也引入了一些潜在的运行时错误。

以下是 `dynamic` 关键字的主要作用：

1. **运行时类型解析：** 使用 `dynamic` 声明的变量允许在运行时确定其类型。这使得你可以绕过编译时的类型检查，将类型检查推迟到运行时。

    ```csharp
    dynamic dynamicVar = 10;
    dynamicVar = "Hello, dynamic!";
    ```

2. **与COM对象交互：** `dynamic` 关键字在组件化编程中与COM（Component Object Model）对象交互时很有用，因为COM对象的类型信息可能不在编译时可用，而是在运行时动态获取。

    ```csharp
    dynamic comObject = GetCOMObject();
    comObject.MethodName();
    ```

3. **简化反射代码：** 在一些需要使用反射的情境下，`dynamic` 关键字可以减少代码的复杂性，因为不再需要显式地使用 `Type` 和 `MethodInfo` 等反射类。

    ```csharp
    dynamic obj = GetObjectUsingReflection();
    obj.SomeMethod();
    ```

4. **匿名类型：** `dynamic` 关键字还可以用于处理匿名类型，使得在运行时创建的匿名类型的实例更容易操作。

    ```csharp
    var person = new { Name = "John", Age = 30 };
    dynamic dynamicPerson = person;
    Console.WriteLine($"Name: {dynamicPerson.Name}, Age: {dynamicPerson.Age}");
    ```

需要注意的是，尽管 `dynamic` 提供了一些灵活性，但由于缺乏静态类型检查，可能会导致运行时错误。在大多数情况下，推荐使用静态类型，只有在特定的情况下才使用 `dynamic`。使用 `dynamic` 时应当谨慎，以免引入难以调试和理解的错误。

在C#中，`dynamic` 关键字和 `object` 类型有一些相似之处，但它们之间存在关键的区别。

1. **`dynamic` 类型：** 变量声明为 `dynamic` 类型时，它将被编译器视为动态类型，其类型信息在运行时确定。`dynamic` 类型的变量可以调用任何成员，而不进行编译时类型检查，而是在运行时解析类型。这使得 `dynamic` 类型更灵活，但也可能导致运行时错误。

    ```csharp
    dynamic dynamicVar = 10;
    dynamicVar = "Hello, dynamic!";
    ```

2. **`object` 类型：** `object` 是一个静态类型，它是所有其他类型的基类。当变量声明为 `object` 类型时，它可以包含任何类型的值，但在使用这些值时需要进行显式的类型转换。`object` 类型的变量在编译时具有类型检查。

    ```csharp
    object obj = 10;
    obj = "Hello, object!";
    ```

总的来说，`dynamic` 和 `object` 都允许在一个变量中存储不同类型的值，但它们的使用场景和行为不同。`dynamic` 更注重于运行时的灵活性，而 `object` 提供了一个通用的静态类型，需要显式转换来使用其中的值。

### 第十一天

##### 1.ArrayList

1. Array、ArrayList和泛型list
   [C#中数组、ArrayList和List三者的区别 - 君莫笑·秋 - 博客园 (cnblogs.com)](https://www.cnblogs.com/vaevvaev/p/7126568.html)

2. 当ArrayList集合元素是引用类型时，输出元素显示的是命名空间+类型名。原因是元素类型是object类型。

   ```C#
   Person p = new Person();
   list.Add(p);
   list.Add(new int[] { 1, 2, 3, 4, 5 });
   list.Add(list);
   // Output
   _02ArrayList集合.Person
   System.Int32[]
   System.Collections.ArrayList
       
   // Converting Solution
   for (int i = 0; i < list.Count; i++)
   {
       if (list[i] is Person)
       {
           ((Person)list[i]).SayHello();
       }
       else if (list[i] is int[])
       {
           for (int j = 0; j < ((int[])list[i]).Length; j++)
           {
               Console.WriteLine(((int[])list[i])[j]);
           }
       }
       else if (list[i] is ArrayList)
       { }
       else
       {
           Console.WriteLine(list[i]);
       }
   }
   ```

3. `ArrayList`的方法

   `arrayList.Add()`给集合添加单个元素。

   `arrayList.AddRange()`给集合添加集合，以类似单个元素添加进去。

   ```C#
   list.AddRange(new int[] { 1, 2, 3, 4, 5 });
   list.AddRange(new string[] { "张三", "李四", "王五", "赵六", "田七" });
   Console.WriteLine(list.Count);
   // Output
   10
   ```

   `arrayList.Remove(obj)`删除某个元素。

   `arrayList.RemoveAt(int)`删除该索引的元素。

   `arrayList.RemoveRange(int,int)`删除从该索引开始的数个元素。

   `arrayList.Insert(int,obj)`在索引处插入单个值。

   `arrayList.InsertRange(int,collection)`在索引处插入集合。

   `arrayList.Sort()`集合内元素排序，必须所有元素同类型。

   `arrayList.Clear()`清空所有元素。

4. Example

   ```C#
   // Add 10 non repeating random number to arraylist.
   ArrayList arrayList = new ArrayList();
   Random r = new Random();
   for	(int i = 0; i < 10; i++)
   {
       int num = r.Next(0, 10);
       arrayList.Contains(num) ? i-- : arrayList.Add(num);
   }
   ```

5. `ArrayList`长度可变的原因

   `arrayList.Count`实际包含的元素个数。

   `arrayList.Capacity`允许包含的元素个数，2的次方增长。

   数组集合创建时(0,0)，(Count,Capacity)

   存在1个元素时(1,4)，存在4个元素时(4,4)，

   存在5个元素时(5,8)，存在8个元素时(8,8)，

   存在9个元素时(9,16)，减少到8个元素时(8,8)。

##### 2.Hashtable

1. `Hashtable`是字典，键值对集合。

2. 字典的查询，键必须唯一。

   ```C#
   Hashtable ht = new Hashtable();
   ht.Add(1, "张三");
   ht.Add('c', true);
   ht.Add(3.14, 100);
   // Using for
   for (int i = 0; i < ht.Count; i++)
   {
       Console.WriteLine(ht[i]); // ht[0] ht[1] ht[2]
   }
   // Output
   
   张三
   
   // Cause [key], only 1 in the keys of the collection.
       
   // Using foreach
   foreach (var item in ht)
   {
       Console.WriteLine(item);
   }
   // Output
   System.Collection.DictionaryEntry
   System.Collection.DictionaryEntry    
   System.Collection.DictionaryEntry
   
   foreach (var item in ht.Keys)
   {
       Console.WriteLine(item + "  " + ht[item]);
   }
   // Output
   3.14  100
   c  True
   1  张三
   ```

3. 值的赋值

   ```C#
   ht[1] = "李四"; // Cause key 1 is not exist, making the value of key is 1 modified to 李四.
   ht[5] = "王五"; // Cause key 5 is not exist, add a new parter, key is 5, value is 王五.
   ```

4. 方法

   `ht.Contains(key) == ht.ContainsKey(key)`字典中是否包含键。

   `ht.ContainsValue(value)`字典中是否包含值。

   `ht.Remove(key)`根据键删除键值对。

##### 3.var推断类型

C#是一门强类型语言，对变量类型必须有明确定义。

`var`弱化了类型的定义，根据上下文推断该变量的类型。

但是必须使用`var`必须初始化隐式类型的变量。

```C#
var money = 5000m;
Console.WriteLine(money.GetType());
// Output
System.Decimal
```

##### 3.File类（静态工具类）

File类一次性将数据加载至内存，故其适合操作小文件。

1. 创建：File.Create();
2. 删除：File.Delete();
3. 复制：File.Copy();
   `File.Copy(@"C:\Users\27652\Desktop\2.doc", @"C:\Users\27652\Desktop\3.txt", true);`
4. 剪切：File.Move();
5. 是否存在：File.Exits();

##### 4.File类读取txt文本

File.ReadAllLines();返回字符串数组。

File.ReadAllText();返回一整个字符串。

File.ReadAllBytes();以二进制的形式读取一个文件，返回二进制数组。
`string text = Encoding.Default.GetString(ArrayBytes);`将二进制转换为字符。

以上三个读文件方法有对应的WriteAllLines()\WriteAllText()\WriteAllBytes()三个写方法，但是这三个写方法会覆盖原有文件。

##### 5.File类读取所有文件

计算机存储都是以二进制的形式存储，出现乱码的原因是文件保存格式和打开格式不兼容。

1个二进制占1个bit位
1Byte = 8bit
1KB = 1024B
1MB = 1024KB
1GB = 1024MB
1TB = 1024GB
1PB = 1024TB
1EB = 1024PB
1ZB = 1024EB
1YB = 1024ZB

File.ReadAllBytes();可以读取所有文件，并返回字节数组。
`System.Text.Encoding.Default.GetString();`字节数组转字符串。
打开和保存文件尽量用统一编码格式，如`Encoding.Default`或`Encoding.UTF8`。
最终方式：`System.Text.Encoding.GetEncoding("GBK").GetString();`

##### 6.File类写入文件

1. 替换存在文件的形式写入数据，不存在即自动创建。

   1. `File.WriteAllLine();`向自定义文件（txt、csv、doc）换行写入字符串数组。

   2. `File.WriteAllText();`向自定义文件（txt、csv、doc）写入一整个字符串。

   3. `File.WriteAllBytes();`以字节的形式写入文件。

      ```C#
      // Realize file copy in byte form
      string str = "The weather is nice today";
      byte[] buffer = System.Text.Encoding.GetBytes(str);
      
      byte[] fileBuffer = File.ReadAllBytes(@"C:\Users\27652\Desktop\2.doc");
      File.WriteAllBytes(@"C:\Users\27652\Desktop\2.txt", fileBuffer);
      // Equal to
      File.Copy(@"C:\Users\27652\Desktop\2.doc", @"C:\Users\27652\Desktop\2.txt", true);
      ```

2. 追加到文件的形式写入数据，不存在即自动创建。

   1. `File.AppendAllText();`向目标文件追加一整个字符串。

   2. `File.AppendText();`返回一个写入流StreamWriter对象。

      ```C#
      using (StreamWriter s = File.AppendText(@"C:\Users\27652\Desktop\2.doc"))
      {
          s.WriteLine("abcd");
      };
      ```

##### 7.Directory类

1. Directory.CreateDirectory();创建文件夹

2. Directory.Delete();删除文件夹
   `Directory.Delete(@"D:\A");`删除空文件夹A
   `Directory.Delete(@"D:\A", ture);`删除整个文件夹A

3. Directory.Move();剪切文件夹

4. Directory.GetFiles();返回该文件夹下所有文件

   `Directory.GetFiles(@"D:\A", "*.txt", SearchOption.AllDirectories);`返回该文件夹下包含子文件夹下的文本文件

5. Directory。GetDirectories();返回该文件夹下所有文件夹
   `Directory.GetDirectories(@"D:\A", "*", SearchOption.AllDirectories);`返回该文件夹下包含子文件夹下的文本文件

##### 8.Path类

1. Path.GetFileName();获取文件名和扩展名，是文件夹则获取文件夹名
2. Path.GetExtension();获取文件的扩展名
3. Path.GetFileNameWithoutExtension();获取文件名或者文件夹名
4. Path.GetDirectoryName();获取文件夹的路径
5. Path.GetFullPath();获取绝对路径
6. Path.Combine();拼接路径

Path类只能操作路径的字符串，并不能造成实际影响。
`Path.ChangExtensionName(@"D:\A\1.txt", "jpg");`实际文件扩展名并未改变。

以上路径使用相对路径的话，是程序的Debug目录。

### 第十二天

##### 1. `TextWriter`

`TextWriter` 是 `System.IO` 命名空间中的一个抽象类，用于将字符或字符串数据写入输出流。它提供了用于写入格式化文本、行和其他类型数据的方法。一些常见的实现包括：

- **`StreamWriter`：**
  `StreamWriter` 是 `TextWriter` 的一个具体实现，允许你将文本写入指定的流，比如文件流。它支持各种构造函数，用于指定输出流和编码。

    ```csharp
    using (TextWriter writer = new StreamWriter("example.txt"))
    {
        writer.WriteLine("Hello, TextWriter!");
    }
    ```

##### 2. `TextReader`

`TextReader` 是 `System.IO` 命名空间中的一个抽象类，用于从输入流中读取字符或字符串数据。它提供了用于读取行、字符和其他类型数据的方法。一些常见的实现包括：

- **`StreamReader`：**
  `StreamReader` 是 `TextReader` 的一个具体实现，允许你从指定的流中读取文本，比如文件流。它支持各种构造函数，用于指定输入流和编码。

    ```csharp
    using (TextReader reader = new StreamReader("example.txt"))
    {
        string line = reader.ReadLine();
        Console.WriteLine(line);
    }
    ```

在 C# 中，`StringWriter` 和 `StringReader` 是用于在内存中进行字符串操作的类，它们都继承自 `TextWriter` 和 `TextReader`。

##### 3.StringWriter

这两个类对于处理字符串而不涉及文件或网络流的场景非常有用。它们允许你在内存中操作字符串，是在构建和处理文本数据时的有用工具。

`StringWriter` 是一个实现了 `TextWriter` 抽象类的具体类，它允许你在内存中创建一个字符串缓冲区，并向该缓冲区写入文本。主要用途包括构建文本输出的字符串，而不必实际写入到文件或网络流。以下是一个简单的示例：

```csharp
static void Main()
{
    // 使用StringWriter创建一个字符串缓冲区
    using (StringWriter stringWriter = new StringWriter())
    {
        // 向字符串缓冲区写入文本
        stringWriter.WriteLine("Hello, StringWriter!");
        stringWriter.WriteLine("This is another line.");

        // 获取整个字符串内容
        string result = stringWriter.ToString();

        // 输出字符串内容
        Console.WriteLine(result);
    }
}
```

在这个例子中，我们使用 `StringWriter` 来创建一个字符串缓冲区，然后通过 `WriteLine` 方法向缓冲区写入文本。最后，我们使用 `ToString` 方法获取整个字符串内容并输出。

##### 4.StringReader

`StringReader` 是一个实现了 `TextReader` 抽象类的具体类，它允许你从字符串中读取文本。主要用途包括从字符串中读取数据而不必从文件或网络流中读取。以下是一个简单的示例：

```csharp
static void Main()
{
    // 使用StringReader从字符串读取文本
    string text = "Hello, StringReader!\nThis is another line.";
    using (StringReader stringReader = new StringReader(text))
    {
        // 逐行读取并显示文本
        //string line = stringReader.ReadToEnd();
        string line;
        while ((line = stringReader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
```

在这个例子中，我们使用 `StringReader` 来从一个字符串中读取文本，然后使用 `ReadLine` 方法逐行读取并输出文本内容。

##### 3. Stream

`Stream` 是一个抽象类，同样位于 `System.IO` 命名空间中，用于处理字节流。它定义了基本的读取和写入字节的操作，适用于处理二进制数据。以下是 `Stream` 的一些常见实现类：

- **`FileStream`：** `FileStream` 是 `Stream` 的具体实现之一，通常用于文件读写操作。它支持指定文件路径、文件模式等参数。

  ```C#
  using (Stream stream = new FileStream("example.dat", FileMode.Create))
  {
      byte[] data = Encoding.UTF8.GetBytes("Hello, Stream!");
      stream.Write(data, 0, data.Length);
  }
  ```

- **`MemoryStream`：** `MemoryStream` 是 `Stream` 的具体实现之一，用于在内存中进行读写操作。它提供了一个可变大小的内存缓冲区，适用于临时存储数据。

  ```C#
  using (MemoryStream memoryStream = new MemoryStream())
  {
      byte[] data = Encoding.UTF8.GetBytes("Hello, MemoryStream!");
      memoryStream.Write(data, 0, data.Length);
  }
  ```

##### 1.FileStream文件流

FileStream是操作字节的,因此可以操作所有类型的文件，适合操作大文件。

```C#
FileStream fs = new FileStream(@"D:\A\1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
byte[] bufferRead = new byte[fs.Length];
// Read data to array buffer, from 0 to the max buffer's length; return valid quantity.
int r = fs.Read(bufferRead, 0 , bufferRead.Length);
// Put valid bytes of array convert to string
string str = System.Text.Encoding.Default.GetString(buffer, 0 , r);

string str = "Today is nice";
byte[] bufferWrite = Encoding.Default.GetBytes(str);
fs.Write(bufferWrite, 0 , bufferWrite.Length);
```

流对象不能被垃圾回收器处理，故要及时关闭和释放

```C#
fs.Close();		// Turn off stream
fs.Dispose();	// Dispose the object
// Equal to
using (Create the stream object)
{
    //Reading or writing.
}
```

读取一个20MB的文件：

```C#
string sourceFile = @"C:\1.wmv";
string targetFile = @"D:\1.wmv";
using (FileStream fsRead = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
{
    using (FileStream fsWrite = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
    {
        // Read 5MB data each time
        byte[] buffer = new byte[1024 * 1024 * 5];
        while (true)
        {
            int r = fsRead.Read(buffer, 0, buffer.Length);
            // --------First type---------
            if (r == 0) // Break when no data
            {
                break;
            }
            fsWrite.Write(buffer, 0, r);
            // --------Second type--------
            fsWrite.Write(buffer, 0, r);
            if (r < buffer.Length)
            {
                break;
            }
        }
    }
}
```

##### 2.StreamWriter\StreamReader

是操作字符的，适合操作小文件

```c#
using (StreamReader sr = new StreamReader(@"C:\抽象类特点.txt", Encoding.Default))
{
    //string s = sr.ReadToEnd();
    //while(sr.Read() != -1)
    while (!sr.EndOfStream)
    {
        string str = sr.ReadLine();
        Console.WriteLine(str);
    }
}

using (StreamWriter sw = new StreamWriter(@"C:\Users\SpringRain\Desktop\ooo.txt",true))
{
    // 'true' means append
    sw.Write("lalalaala");
    sw.WriteLine("hhahaha");
}
```

==读文件结束时，FileStream.Read()返回0，StreamReader.Read()/ReadLine()返回-1。==

##### 3.拆箱和装箱

装箱：将值类型转换为引用类型
拆箱：将引用类型转换为值类型

发生拆装箱的两个类型必须存在继承关系，如：

```C#
int a = 0;
object obj = a;
int b = (int)obj;
// The following does not match. Inheritance relationship is not exist.
string  s = "11";
int n = Convert.ToInt32(s);
```

拆装箱建立在里氏转换上，拆装箱后要用对应类型接收。

##### 4.泛型集合

**`List<T> list = new List<T>();`**

字符串数组转集合：

```c#
List<string> list = new List<string>(strings);
// Equal to
List<string> list = strings.ToList<string>();
```

1. list.Add();添加单个元素

2. list.AddRange(list);添加集合

3. list.ToArray();返回一个数组

4. list.ForEach(Action<T>);

   ```C#
   list.ForEach(item =>
   {
      if (item = 1)
   	{
       	return;
   	}
   });
   // Equal to
   foreach(int item in list)
   {
       test(item)
   }
   void test(int item)
   {
       if (item == 1)
       {
           return;
       }
   }
   
   // e.g. count if the first char is '王' in the list of string type
   for (int i = 0; i < list.Count; i++)
   {
       Console.WriteLine(list[i]);
       if (list[i][0] == '王')
       {
           count++;
       }
   }
   ```

5. list.Remove();删除第一个该元素,返回是否成功的bool值

6. list.RemoveAt();删除该索引的元素

7. list.RemoveRange();删除从指定索引开始的数个元素

8. list.RemoveAll(Predicate<T>);lamda表达式，删除匹配的结果，返回删除元素的个数

   ```C#
   // Remove the same elements of list1 from list
   list.RemoveAll(item => list1.Contains(item));
   ```
   
9. `List<List<int>> list = new List<List<int>>;`

10. list.Select<>/SelectMany<>;根据表达式获取一个新集合/将子集合成一个集合

    ```C#
    public void SecteTest()
    {
        var initList = new List<Select>();
        initList.Add(new Select("s1", "s2"));
        initList.Add(new Select("s11", "s22"));
        initList.Add(new Select("s111", "s222"));
    
        var firstList = initList.Select(x => x.Attrs).ToList();
        var secondList = initList.SelectMany(x => x.Attrs).ToList();
    }
    public class Select
    {
        public Select(params string[] str)
        {
            str?.ToList()?.ForEach(x => Attrs.Add(x));
        }
        public List<string> Attrs { get; set; } = new List<string>();
    }
    // Output
    Select 						firstList		secondList
    [0] Attr:[0] s1 [1] s2		[0]{s1, s2}		[0]s1
    [1] Attr:[0] s11 [1] s22	[1]{s11, s22}	[1]s2
    [2] Attr:[0] s111 [1] s222	[2]{s111, s222}	[2]s11
    											[3]s22    
    											[4]s111
    											[5]s222
    ```

**`Dictionary<T, T> dic = new Dictionary<T, T>();`**

1. dic.Add();添加一个键值对

2. dic[key] = value;修改指定键的值，不存在则添加该键值对

3. ```C#
   // ergodic
   // foreach(int i in dic.Keys)
   // foreach(string s in dic.Values)
   foreach (KeyValuePair<int, string> item in dic)
   {
       Console.WriteLine(item.Key, item.Value);
   }
   ```

4. 返回字符出现的次数

   ```C#
   string str = "Welcome to China";
   Dictionary<char, int> dic = new Dictionary<char, int>();
   for (int i = 0; i < str.Length; i++)
   {
       if (dic.ContainsKey(str[i]))
       {
           dic[str[i]]++;
       }
       else
       {
           dic.Add(str[i], 1);
       }
       if (str[i] == " ")
       {
           continue;
       }
   }
   ```

##### 5.多态

多态允许不同类的对象对同一消息做出响应，但具体的行为则取决于对象的实际类型。

实现多态有虚方法、抽象类和接口等方法。

==当父类的成员有实际意义，方法有默认的实现，且父类对象需要被实例化，使用虚方法实现多态。反之，用抽象类。==

**虚方法**

1. 将父类的方法用virtual修饰为虚方法，意味着该方法可以被子类覆盖。

```C#
Chinese cn = new Chinese("yjq");
American us = new American("foreigner");
Person[] per = { cn, us };
for (int i = 0; i < per.Length; i++)
{
    per[i].SayHello();
}
// The old method
for (int i = 0; i < per.Length; i++)
{
    if (per[i] is Chinese)
    {
        ((Chinese)per[i]).SayHello();
    }
    if (per[i] is American)
    {
        ((American)per[i]).SayHello();
    }
}
```

2. 当子类方法没有被覆盖时，父类引用调用的是父类方法。

<details>
    <summary>虽然指向的子类对象，但是仍表现为父类类型</summary>
    <pre><code>
    public class RealDuck
    {
        public virtual void Bark()
        {
            Console.WriteLine("gg");
        }
    }
    public class WoodDuck : RealDuck
    {
        public override void Bark()
        {
            Console.WriteLine("zz");
        }
    }
    public class RubberDuck : RealDuck
    {
        public (new) void Bark()
        {
            Console.WriteLine("jj");
        }
    }
    static void Main(string[] args)
    {
        RealDuck rd = new WoodDuck();
        rd.Bark();
        RealDuck rd2 = new RubberDuck();
        rd2.Bark();
        Console.Read();
    }
    // Output
    zz
    gg
    </code></pre>
</details>

**抽象类**

抽象类有构造函数但是不能实例化，因此抽象类中的实例成员对父类没有意义，但其子类依旧可以继承，==抽象类的意义就是给子类重写==。抽象方法必须声明在抽象类中，且抽象类的子类必须覆盖(override)抽象方法，相同的参数和返回类型。

| 虚方法             | 抽象方法           |
| ------------------ | ------------------ |
| 用virtual修饰      | 用abstract修饰     |
| 有方法体           | 没有方法体         |
| 可以被子类override | 必须被子类override |
| 除了密封类内不能有 | 只存在于抽象类     |

### 第十三天

##### 1.5种访问修饰符

1、public : 公开的， 公共的

2、private : 私有的 （只能在当前类的内部访问，类中的成员们，如果不加上访问修饰符的话，默认的就是 private）

3、protected : 受保护的，可以在当前类的内部访问，也可以该类的子类中访问

4、internal : 只能在当前项目中可以访问，如果一个类不手动加上访问修饰符的话，那默认的就是internal。 在同一个项目中 internal 和 public 的访问权限是一样的

5、protected internal : 既可以在继承链上的其子类里面被访问，也可以在同一个项目中使用。与internal的区别在于，其修饰的成员可以跨程序集被访问，只要在另一个程序集中声明一个属于继承链上的类并且使用protected internal修饰。

（1）能修饰类的访问修饰符只有 public 和 internal
（2）可访问性不一致：子类的访问权限不能高于父类的访问权限，会暴漏父类的成员。
（3）在同一个项目中，internal的权限要大于protected, 而如果出了此项目那 protected的权限要大于internal。
（4）子类的访问权限不能高于父类，因为子类可能暴露父类的成员。

##### 2.序列化与反序列化

序列化是将对象状态转换为可保持或传输的形式的过程。 序列化的补集是反序列化，后者将流转换为对象。 这两个过程一起保证能够存储和传输数据。

.NET 具有以下序列化技术：

- [二进制序列化](https://learn.microsoft.com/zh-cn/dotnet/standard/serialization/binary-serialization)保持类型保真，这对于多次调用应用程序时保持对象状态非常有用。 例如，通过将对象序列化到剪贴板，可在不同的应用程序之间共享对象。 您可以将对象序列化到流、磁盘、内存和网络等。 远程处理使用序列化，“按值”在计算机或应用程序域之间传递对象。
- [XML 和 SOAP 序列化](https://learn.microsoft.com/zh-cn/dotnet/standard/serialization/xml-and-soap-serialization)只序列化公共属性和字段，并且不保持类型保真。 当您希望提供或使用数据而不限制使用该数据的应用程序时，这一点非常有用。 由于 XML 是开放式的标准，因此它对于通过 Web 共享数据来说是一个理想选择。 SOAP 同样是开放式的标准，这使它也成为一个理想选择。
- [JSON 序列化](https://learn.microsoft.com/zh-cn/dotnet/standard/serialization/system-text-json-overview)只序列化公共属性，并且不保持类型保真。 JSON 是开放式的标准，对于通过 Web 共享数据来说是一个理想选择。

1. **XML 序列化：**
   
   - 使用 `XmlSerializer` 类可以将对象序列化为XML格式。需要标记类和属性以指示序列化的方式，通常使用 `XmlRootAttribute` 和 `XmlElementAttribute` 进行控制。
   - 优点：人类可读，广泛支持。
   - 缺点：相对冗长，可能不适合大型数据。
   
   ```csharp
   XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
   serializer.Serialize(stream, obj);
   ```
   
   <details>
       <summary>XML序列化的例子</summary>
       <pre><code>
       public static void MethXmlSerializer()
       {
           // 创建一个Person对象
           var person = new PersonXml { Name = "John", Age = 30, Both = new() };
           // 序列化
           var serializer = new XmlSerializer(typeof(PersonXml));
           // xml字符串
           string xml = string.Empty;
           /* If the XML document has been altered with unknown
               nodes or attributes, handle them with the
               UnknownNode and UnknownAttribute events.*/
           serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
           serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
           using (var stream = new MemoryStream())
           {
               serializer.Serialize(stream, person);
               Console.WriteLine("Serialized Data:");
               // 输出序列化后的XML
               Console.WriteLine(Encoding.UTF8.GetString(stream.ToArray()));
               // 使用streamReader输出序列化后的XML
               stream.Position = 0;
               using (var reader = new StreamReader(stream))
               {
                   Console.WriteLine(xml = reader.ReadToEnd());
               }
           }
           // xml字符串反序列化为对象
           using (TextReader reader = new StringReader(xml))
           {
               var deperson = (PersonXml)serializer.Deserialize(reader);
               Console.WriteLine("\nDeserialized Person:");
               Console.WriteLine($"Name: {deperson.Name}, Age: {deperson.Age}");
           }
           void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
           {
               Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
           }
           void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
           {
               System.Xml.XmlAttribute attr = e.Attr;
               Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
           }
       }
       </code></pre>
   </details>
   
2. **JSON 序列化：**
   - 使用 `JsonSerializer` 类可以将对象序列化为JSON格式。无需显式标记类和属性，但可以使用 `JsonProperty` 特性进行更多的控制。
   - 优点：轻量，易于阅读，广泛支持。
   - 缺点：不支持所有数据类型，可能需要处理循环引用。

   ```csharp
   JsonSerializer serializer = new JsonSerializer();
   serializer.Serialize(stream, obj);
   ```

3. **二进制序列化：**
   
   - 使用 `BinaryFormatter` 类可以将对象序列化为二进制格式。通常需要标记类为 `[Serializable]`。
   - 优点：紧凑，性能较好。
   - 缺点：二进制格式对人类不可读，不适用于跨平台或跨语言。
   
   ```csharp
   BinaryFormatter formatter = new BinaryFormatter();
   formatter.Serialize(stream, obj);
   ```
   
   <details>
       <summary>二进制序列化的例子</summary>
       <pre><code>
       [Serialize]
       Class Person
       {
           public string Name{ get; set; }
           public int Age{ get; set; }
           public Person(string name, int age)
           {
               Name = name;
               Age = age;
           }
       }
       // Serialize
       Person p = new Person("yjq", 22);
       using (FileStream fs = new FileStream(@"D:\1.txt", FileMode.OpenOrCreate, FileAccess.Write))
       {
           BinaryFormatter bf = new BinaryFormatter();
           bf.Serialize(fs, p);
       }
       Person per;
       using (FileStream fs = new FileStream(@"D\1.txt", FileMode.OpenOrCreate, FileAccess.Read))
       {
           BinaryFormatter bf = new BinaryFormatter();
           per = (Person)bf.Deserialize(fs);
       }
       </code></pre>
   </details>
   
4. **DataContract 序列化：**
   
   - 使用 `DataContractSerializer` 类可以将对象序列化为XML或JSON格式，类和属性需要标记为 `[DataContract]` 和 `[DataMember]`。
   - 优点：支持多种格式，可以通过设置来控制序列化行为。
   - 缺点：需要明确标记类和属性。
   
   ```csharp
   DataContractSerializer serializer = new DataContractSerializer(typeof(MyClass));
   serializer.WriteObject(stream, obj);
   ```
   
   <details>
       <summary>使用 DataContractSerializer类将对象序列化为XML和JSON的例子</summary>
       <pre><code>
       // 定义一个Person类用于序列化和反序列化
       [DataContract]
       public class Person
       {
           [DataMember]
           public string Name { get; set; }
           [DataMember]
           public int Age { get; set; }
       }
       class Serialization
       {
           #region DataContract 序列化为XML格式
           public static void MethXml()
           {
               // 创建一个Person对象
               Person person = new Person { Name = "John", Age = 30 };
               // 序列化
               string serializedData = SerializeObject(person);
               Console.WriteLine("Serialized Data:");
               Console.WriteLine(serializedData);
               // 反序列化
               Person deserializedPerson = DeserializeObject<Person>(serializedData);
               // 输出反序列化后的对象
               Console.WriteLine("\nDeserialized Person:");
               Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
           }
           // 将对象序列化为字符串
           static string SerializeObject<T>(T obj)
           {
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                   serializer.WriteObject(memoryStream, obj);
                   memoryStream.Position = 0;
                   using (StreamReader reader = new StreamReader(memoryStream))
                   {
                       return reader.ReadToEnd();
                   }
               }
           }
           // 将字符串反序列化为对象
           static T DeserializeObject<T>(string serializedData)
           {
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   using (StreamWriter writer = new StreamWriter(memoryStream))
                   {
                       writer.Write(serializedData);
                       writer.Flush();
                       memoryStream.Position = 0;
                       DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                       return (T)serializer.ReadObject(memoryStream);
                   }
               }
           }
           #endregion
           #region DataContractJsonSerializer 序列化为Json格式
           public static void MethJson()
           {
               // 创建一个Person对象
               Person person = new Person { Name = "John", Age = 30 };
               // 序列化为JSON
               string json = SerializeToJson(person);
               Console.WriteLine("Serialized JSON:");
               Console.WriteLine(json);
               // 反序列化JSON
               Person deserializedPerson = DeserializeFromJson<Person>(json);
               // 输出反序列化后的对象
               Console.WriteLine("\nDeserialized Person:");
               Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
           }
           // 将对象序列化为JSON字符串
           static string SerializeToJson<T>(T obj)
           {
               using (MemoryStream memoryStream = new MemoryStream())
               {
                   DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                   serializer.WriteObject(memoryStream, obj);
                   memoryStream.Position = 0;
                   using (StreamReader reader = new StreamReader(memoryStream))
                   {
                       return reader.ReadToEnd();
                   }
               }
           }
           // 将JSON字符串反序列化为对象
           static T DeserializeFromJson<T>(string json)
           {
               using (MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
               {
                   DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                   return (T)serializer.ReadObject(memoryStream);
               }
           }
           #endregion
       }
       </pre></code>
   </details>

##### 3.简单工厂模式

货物数量不断变化
`List<Product> listProduct = new List<Product>();`

考虑到货物分类
`List<List<Product>> list = new List<List<Product>>();`

3个产品即3个货架,放入仓库
`list.Add(new List<Product>);`
`list.Add(new List<Product>);`
`list.Add(new List<Product>);`

将产品放入货架

```C#
PutInStorage(string type, int count)
{
    for (int i = 0; i < count; i++)
    {
        Switch(type)
        {
            case "Apple":
            list[n].Add(new Apple("红富士", Guid.NewGuid().ToString(), "5"));
            break;
            //...
        }
    }
}
// Guid.NewGuid().ToString()
// Produce a unique identification used to indicate the product
```

从货架取货，取货数量已知情况下用数组

```C#
PutOutStorage(string type, int count)
{
    // Create an array of parent type 
	Product[] pros = new Product[count];
    for (int i = 0; i < count; i++)
    {
        Switch(type)
        {
            // Take the first each time
            case "Apple":
            pro[i] = list[0][0];
            list[0].RemoveAt(0);
            break;
            //...
        }
	}
}
```

### 第十四天

##### 1.接口

因为类的继承具有单根性，类不能多继承，但是可以继承多个接口。

接口内的成员不能有字段和构造函数，不能有访问修饰符，都默认是public，且不能有定义，即不能有方法体。

继承接口的类必须实现接口成员，实现不是override。

接口实现多态，接口不能被实例化**（接口、抽象类、静态类不能创建对象）**

```C#
// Subclass objects are assigned to interface references
CBAPlayer cba = new Student();
// Call the method implemented by the subclass
cba.Dunk();
```

接口命名以I开头，以able结尾：实现了我的接口，即具备了我的==能力==。故，可以将某种能力封装成接口。
例如，飞的能力。并非所有鸟都能飞，则将能飞声明成接口，所有鸟的共同特征和行为封装成鸟这个父类，具体种类的鸟的子类继承鸟这个父类并根据是否具有飞行能力来是否继承能飞的接口。

接口与接口之间可以继承，也可以多继承，并且具有传递性；类可以继承接口，接口不能继承类。
类同时继承类和接口时，语法上类在前，接口在后。

##### 2.显式实现接口

解决子类方法和接口方法重名问题

```C#
public interface IEatable
{
    void Eat();
}
public class Student
{
    public void Eat()
    {
        // Student eat
    }
    void IEatable.Eat()
    {
        // Interface eat
    }
    string Eat(string name)
    { 
        // Function overload
    }
}

static void Main(string[] args)
{
    IEatable eat = new Student();
    eat.Eat();
}
```

Student类中的接口方法在类内方法默认是private，子类对象赋值给接口引用后，可以调用子类实现的方法，是因为接口对象实际调用的是接口内的方法（默认public），而该方法被赋予对象的子类实现了。

接口功能要单一，能吃就不要写能飞、能爬。

##### 3.抽象类继承接口

需要抽象类的子类实现接口

```C#
public interface IFlyable
{
    void Fly();
}
public abstract class Person : M
{
    public void Fly()
    {
        // 
    }
}
public class Student : Person
{
    
}
static void Main(string[] args)
{
    // Polymorphism is not implemented
    // Cause the subclass inherits the public method of the parent class
    Student student = new Student();
    student.Fly();
    
    // Polymorphism is implemented
    M m = new Student();
    m.Fly();
}
```

注意：谁有能力，谁继承接口。如果Person不一定具有Fly能力，而Student具有该能力，就让Student继承Fly接口，而Student的子类自然而然继承了Student的能力。

##### 4.值传递和引用传递

值类型：int\double\decimal\char\bool\struct\enum 继承于Object

引用类型：string\数组\集合\自定义类\object\接口 继承于object

值类型在赋值的时候，传递的是值本身。

引用类型在赋值的时候，传递的是引用，即地址。

```C#
Person p1 = new Person("yjq");
Person p2 = p1;
p2.Name = "yjqqqq";
Console.WriteLine(p1.Name);
// Output
yjqqqq
```

##### 5.重写父类的方法

```C#
public class Person()
{
    public override string ToString()
    {
        return "Hello World";
    }
}
```

所有类都继承于Object类，ToString()方法在Object类中是虚方法。

##### 6.MD5加密（不可逆）

| 加密的字符串 | 123                              |
| ------------ | -------------------------------- |
| 16位 小写    | ac59075b964b0715                 |
| 16位 大写    | AC59075B964B0715                 |
| 32位 小写    | 202cb962ac59075b964b07152d234b70 |
| 32位 大写    | 202CB962AC59075B964B07152D234B70 |

```C#
string GetMD5(string str)
{
    // Encrypted string
    MD5 md5 = MD5.Create();
    byte[] buffer = Encoding.Default.GetBytes(str);
    byte[] md5Buffer = md5.ComputeHash(buffer);
    // Print string after encryted
    string md5Str = string.Empty;
    for (int i = 0; i < md5Buffer.Length; i++)
    {
        md5Str += md5Buffer[i].ToString("X2");
    }
    return md5Str;
}
```

因为MD5格式是十六位或者三十二位，所以将每个字符转换为十六进制打印显示。
X2 指将十六进制数以两位数显示。如：0x0A

| 标志 | 转换对象 | 代码                  | 结果          |
| ---- | -------- | --------------------- | ------------- |
| C    | 货币     | 2.5.ToString("C")     | ￥2.50        |
| D    | 十进制数 | 25.ToString("D5")     | 00025         |
| E    | 科学型   | 25000.ToString("E")   | 2.500000E+005 |
| F    | 固定点   | 25.ToString("F2")     | 25.00         |
| G    | 常规     | 2.5.ToString("G")     | 2.5           |
| N    | 数字     | 2500000.ToString("N") | 2,500,000.00  |
| X    | 十六进制 | 255.ToString("X")     | FF            |

##### 7.密封类和部分类

sealed：修饰密封类，表示该类不能被继承（可以实例化）。

partial：修饰部分类，同名部分类组成一个完整的类。
		 适合多人协同所有同一个类。

##### 8.控件的简单属性

1. BackgroundImage: 控件背景图片，保存在.resx文件下
2. BackgroundImageLayout: 背景图片的布局方式
3. Cursor: 鼠标样式
4. Enable: 控件能否使用
5. Dock: 控件在窗体的位置
6. FlatStyle: 使用控件时不同的表现
7. StartPosition: 窗体出现的位置
8. Opacity: 控件的不透明度
9. WordWarp: 自动换行
10. ScrollBars: 滚动条
11. PasswordChar: 密码
12. AllowDrop: 拖拽文件至控件
13. Controls: 获取改控件内的控件集合
13. HideSelection: 控件内项目失去焦点后是否高亮
13. Tag: 用户自定义数据关联该控件
13. ContextMenuStrip: 右键快捷菜单，需添加该组件

**窗体间的控件移动**

```C#
// label controler move between form1 and form2
Form2 form2 = new Form2();
private void label_Click(object sender, EventArgs e)
{
    if (this.label.Parent == this)
    {
        form2.Controls.Add(this.label);
    }
    else
    {
        this.Controls.Add(this.label);
    }
}
```

##### 9.控件的事件

`Point p = MousePosition;`屏幕坐标

`Point p1 = this.PointToClient(MousePosition);`窗体坐标

控件在窗体内活动的范围
`int maxWidth = this.ClientSize.Width - button.Width;`
`int maxHeight = this.ClientSize.Height - button.Height;`
`button.Location = new Point(x, y);`

RadioButton: 通过容器实现多选

MenuStrip: 菜单栏
`frm2.MdiParent = this;`form2的父窗体是当前窗体，form2窗体只能在父窗体内。
`LayoutMdi(MdiLayout.TileVertical);`在多文档界面父窗体内垂直排列子窗体。
`LayoutMdi(MdiLayout.TileHorizontal);`在多文档界面父窗体内水平排列子窗体。

PictureBox: 图片窗体
`pictureBox1.Image = Image.FromFile("C:\1.jpg");`加载一张图片

ComboBox: 下拉框
`comboBox1.Items.Add("0");`添加一个下拉项
`comboBox1.SelectedIndex = 0;`设置第一项显示
DropDownStyle: 下拉样式
	simple:全部显示
	DropDown:正常下拉样式
	DropDownList:类表形式，框内无法编辑

```C#
// Show the number days of each month
switch(month)
{
    case 1:
    case 3:
    case 5:
    case 7:
    case 8:
    case 10:
    case 12:
        days = 31;
        break;
    case 2:
        if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
        {
            days = 29;
        }
        else
        {
            days = 28;
        }
        break;
    default:
        days = 30;
        break;
}
```

WebBrowser: 浏览器控件使用Uri

```C#
// Go to a web address
string str = "http://" + textBox1.Text;
Uri uri = new Uri(str);
webBrowser1.Uri = uri;
```

listBox: 列表框播放wav

```C#
// Play .wav type musics
private void listBox1_DoubleClick(object sender, EventArgs e)
{
    SoundPlayer sp = new SoundPlayer();
    sp.SoundLocation = list[listBox1.SelectedIndex];
    sp.Play();
}
```

OpenFileDialog: 打开文件对话框

1. 通过代码添加

   ```C#
   OpenFileDialog ofd = new OpenFileDialog();
   ofd.Title = "Please select files";
   ofd.Multiselect = true;
   ofd.InitialDirectory = @"D:\";
   ofd.Filter = "All files|*.*|Text files|*.txt";
   ofd.ShowDialog();// or (this);
   // Get file's path which selected
   string path = ofd.FileName;
   ```

2. 通过工具箱OpenFileDialog控件添加

   只需要调用ShowDialog()方法将它显示出来。

   参数可以通过代码添加，也可以通过属性进行修改。

   ```C#
   private void button1_Click(object sender, EventArgs e)
   {
   	openFileDialog1.ShowDialog();
   }
   private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
   {
   
   }
   ```

3. ShowHelp属性

   默认为false，当置为true时，弹窗样式将改变并且增加帮助按钮，此时可以触发HelpRequest事件，即点击帮助按钮后的事件。

MenuStrip: 菜单栏控件

Validating和Validated: 在控件失去焦点后触发的事件。

ItemCheck和ItemChecked: 在选中一项前/后，根据事件内方法体检查值，前者可通过e.Cancel()撤销改值的						传入。

ComboBox: 下拉框，添加数据源。

```C#
comboBox.DataBindings.Clear();
// Add array
comboBox.DataSource = (Array)T[];
// Add enum
comboBox.DataSource = Enum.GetNames(typeof(EMethod));
// Clear
comboBox.DataSource = null;
comboBox.SelectedIndex = -1;
comboBox.Items.Clear();
comboBox.Items.Add("");
comboBox.Text = "";
comboBox.Items.Clear();

comboBox.Items.Add(object);//赋值
comboBox.SelectedIndex = 0;//设置选中项的下标
```

### 第十七天

##### 1.GDI

CLR: 公共语言运行时
当我们运行程序时，CLR加载所有类文件到内存，找到主函数，从上到下一行一行执行。

<details>
    <summary>画线</summary>
    <code>
    void DrawStraightLine()<br>
    {<br>
&emsp;        Graphics g = this.CreateGraphics();<br>
&emsp;        Point p1 = new Point(50, 50);<br>
&emsp;        Point p2 = new Point(250, 250);<br>
&emsp;        Pen pen = new Pen(Brushes.Black);<br>
&emsp;        g.DrawLine(pen, p1, p2);<br>
    }<br>
    // Repaint event follow OS<br>
    private void Form1_Paint(object sender, PaintEventArgs e)<br>
    {<br>
&emsp;        DrawStraightLine();<br>
    }<br>
    </code>
</details>
<details>
  <summary>展开查看</summary>
  <pre><code> 
     void DrawStraightLine()
    {
        Graphics g = this.CreateGraphics();
        Point p1 = new Point(50, 50);
        Point p2 = new Point(250, 250);
        Pen pen = new Pen(Brushes.Black);
        g.DrawLine(pen, p1, p2);
    }
    // Repaint event follow OS
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        DrawStraightLine();
    }
  </code></pre>
</details>

<details>
  <summary>画验证码</summary>
  <pre><code> 
    private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string str = "";
            for (int i = 0; i < 5; i++)
            {
                int rNumber = r.Next(0, 10);
                str += rNumber;
            }
            <!--创建一个图片对象-->
            Bitmap bmp=new Bitmap(120,25);
            //创建GDI对象
            Graphics g = Graphics.FromImage(bmp);
            string[] fonts = { "黑体", "楷体", "微软雅黑", "宋体", "隶书" };
            Color[] colors = { Color.Red, Color.Yellow, Color.Blue, Color.Black, Color.Green };
            {
                Point p1=new Point(r.Next(0,bmp.Width),r.Next(0,bmp.Height));
                Point p2=new Point(r.Next(0,bmp.Width),r.Next(0,bmp.Height));
                g.DrawLine(new Pen(Color.Green), p1, p2);
            }
            //画像素颗粒
            for (int i = 0; i < 100; i++)
            {
                 Point p=new Point(r.Next(0,bmp.Width),r.Next(0,bmp.Height));
                 bmp.SetPixel(p.X, p.Y, Color.Black);
            }
            <!--把画好的图片放到PictureBox上-->
            pictureBox1.Image = bmp;           
        }
  </code></pre>
</details>

##### 2.多线程

1. 进程

   ```C#
   // Get all processes
   Process[] pros = Process.GetProcesses();
   // Get current process
   Console.WtiteLine(Process.GetCurrentProcess().ToString());
   ```

2. 代码的形式启动进程或者打开文件

   ```C#
   Process.Start("calc");// calculater
   Process.Start("mspaint");// calculater
   Process.Start("iexplore", "http://www.baidu.com");
   Process.Start("devenv");// VS
   // Anther way abort open file
   ProcessStartInfo psi = new ProcessStartInfo(@"D:\1.txt");
   Process.Start(psi);
   // Equal to
   ProcessStartInfo psi = new ProcessStartInfo(@"D:\1.txt");
   Process p = new Process();
   p.StartInfo = psi;
   p.Start();
   ```

3. 前台线程：只有所有前台线程都关闭才能关闭应用程序。

   后台线程：只要所有前台线程结束，后台线程自动结束。

   线程一旦中止，就不能再被开启。

##### 3.跨线程访问控件

1. 调用控件的invoke()方法

   ```C#
   // Include parameter
   Action<string> actionDelegate = delegate(string str)
   {
       textBox1.Text = str;
   };
   textBox1.Invoke(actionDelegate, txt);
   // Simplify
   Action<string> actionDelegate = (x) =>
   {
       textBox1.Text = x.ToString();
   };
   Invoke(actionDelegate, txt);
   // Or
   textBox1.Invoke(new Action<string>((x) =>
   {
   	textBox1.Text = x;
   }));
   
   // No parameter
   Action actionDelegate = delegate()
   {
       textBox1.Text = str;
   };
   Action action = () =>
   {
       textBox1.Text = "kxc";
   };
   Invoke(actionDelegate);
   textBox1.Invoke(new Action(() =>
   {
       textBox1.Text = "kxc";
   }));
   ```

2. 最简化

   ```C#
   Invoke((EventHandler)delegate
   {
       textBox1.Text = str;
   });
   ```

3. 取消检查

   ```C#
   Control.CheckForIllegalCrossThreadCalls = false;
   ```

4. BackgroundWorker组件

   ```C#
   private void button1_Click(object sender, EventArgs e)
   {
       using(BackgroundWorker bw = new BackgroundWorker())
       {
           bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
           bw.RunWorkerAsync("tank");
           bw.DoWork += Bw_DoWork;//new DoWorkEventHandler(Bw_DoWork);
       }    
   }
   private void Bw_DoWork(object sender, DoWorkEventArgs e)
   {
       Thread.Sleep(2000);
       e.Result = e.Argument + " work ";
   }
   private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
   {
       textBox1.Text = e.Result + "kxc";
   }
   // Output
   tank work kxc
   ```
   

### 第二十天

##### 1.窗体Show()和ShowDialog()

* Show():可打开多个窗体，且主窗体可以访问。
* ShowDialog():只能打开一个窗体，且主窗体不能访问。

##### 2.单例模式

实现只打开一个窗体，且同时主窗体可以访问。

```C#
// Form1
private void button1_Click(object sender, EventArgs e)
{
    Form2 frm2 = Form2.GetSingle();
    frm2.Show();
}

// Form2
private static Form2 _frmSingle = null;
public static Form2 GetSingle()
{
    if (_frmSingle == null)
    {
        _frmSingle = new Form2();
    }
    return _frmSingle;
}
```

##### 3.索引器

作用：方便使用类内的集合。

```C#
public class ID
{
    int[] nums = new int[10];
    public int this[int index]
    {
        get { return nums[index]; }
        set { nums[index] = value; }
    }
}
static void Main(string[] args)
{
    Person p = new Person();
    p[0] = 0;
    p[1] = 1;
    Console.WriteLine(p[0] + " " + p[1]);
    Console.Read();
}
// Output
0 1
// If use properties, only operate entire array.
public int[] Nums { get => nums; set => nums = value; }
```

##### 4.格式化数值结果表(不区分大小写)

| **字符** | **说明**         | **示例**                               | **输出**   |
| -------- | ---------------- | -------------------------------------- | ---------- |
| C        | 货币             | **string.Format**("{0:C3}", 2)         | ￥2.000    |
| D        | 十进制           | **string.Format**("{0:D3}", 2)         | 002        |
| E        | 科学计数法       | 1.20E+001                              | 1.20E+001  |
| F        | 定点数           | **string.Format**("{0:F3}", 2)         | 2.000      |
| G        | 常规             | **string.Format**("{0:G}", 2)          | 2          |
| N        | 用分号隔开的数字 | **string.Format**("{0:N}", 250000)     | 250,000.00 |
| X        | 十六进制         | **string.Format**("{0:X}", 12)         | C          |
|          |                  | **string.Format**("{0:000.000}", 12.2) | 012.200    |

```C#
System.Globalization.CultureInfo myCulture = new System.Globalization.CultureInfo("en-GB");
System.Globalization.CultureInfo myCulture1 = new System.Globalization.CultureInfo("en-US");
System.Globalization.CultureInfo myCulture2 = new System.Globalization.CultureInfo("zh-CN");

Console.WriteLine(string.Format(myCulture, "{0:C}", 100));
// Output
￡100.00
$100.00
￥100.00
```

##### 5.进制转换

1. 二进制、八进制和十六进制的表示

   ```C#
   int binary = 0b10;
   int oct = 010;
   int hex = 0x10;
   ```

2. 十进制转其它

   ```C#
   string strhex = Convert.ToString(hex, 16);
   string strhex2 = Convert.ToString(hex, 10);
   string strhex3 = Convert.ToString(hex, 8);
   string strhex4 = Convert.ToString(hex, 2);
   // Output
   10 16 20 10000
   ```

3. 其它转十进制

   ```C#
   // 16进制转10进制
   int digital = Convert.ToInt32(strhex, 16);
   int _digital = Int32.Parse(strhex, System.Globalization.NumberStyles.HexNumber);
   
   int digital2 = Convert.ToInt32(strhex2, 10);
   int digital3 = Convert.ToInt32(strhex3, 8);
   int digital4 = Convert.ToInt32(strhex4, 2);
   // Output
   16
   ```

### 第二十一天

##### 1.对象初始化器

[c#对象初始化器_Maybe_ch的博客-CSDN博客_c#对象初始化器](https://blog.csdn.net/Maybe_ch/article/details/81332662)
类似`List<int> list = new List<int>() { 1, 2, 3, 4, 5 };`

##### 2.创建XML文档

```C#
using System.Xml;
// Create a object of a xml document.
XmlDocument doc = new XmlDocument();
// Create the first line of the xml for declaration.
XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
// Add the declaration to doc.
doc.AppendChild(dec);
// Create the root node.
XmlElement books = doc.CreateElements("Books");
// Add the root node to doc.
doc.AppendChild(books);
// Create a child node.
XmlElement book = doc.CreateElements("Book");
// Add the child node to the root node.
books.AppendChild(book);
XmlElement name = doc.CreateElement("Name");
// Add a element to name node.
name.InnerXml = "Iron Man";
book.AppendChild(name);
XmlElement price = doc.CreateElement("Price");
name.InnerXml = 99;
book.AppendChild(price);
// Save the xml to a address.
doc.Save("new.xml");
```

`InnerXml`效果上等于`InnerText`，但是元素内出现`<>`时，只有`InnerXml`才能编译，`name.InnerXml = "<p>Iron Man</p>";`结果如下：

```xml
<name>
    <p>Iron Man</p>
<name>
```

给标签设置属性，并赋值：

```C#
XmlElement item = doc.CreateElement("Order");
item.SetAttribute("Name", "toy");
item.SetAttribute("Count", "5");
price.AppendChild(item);
```

输出结果：

```xml
<Price>
	<Order Name="toy" Count="5"/>
</Price>
```

##### 3.读取XML文档

[C#读取XML的三种实现方式_C#教程_脚本之家 (jb51.net)](https://www.jb51.net/article/105265.htm)

### 第二十二天

##### 1.委托\匿名函数\lamba表达式 语法

声明的委托必须跟指向方法具有同样的签名。

```c#
public delegate string DelTest(string name);
public static void Main(string[] args)
{
    //Demo for delegate
    DelTest del = Test;// new DelTest(Test);
    Console.WriteLine(del("YJQ"));    
    //Demo for anonymous
    DelTest ano = delegate(string name) { return name; };
    Console.WriteLine(ano("YJQ11"));
    //Demo for lamda
    DelTest lam = (name) => { return name; };
    Console.WriteLine(lam("YJQ22"));

    Console.Read();
}

static string Test(string name)
{
    return name;
}

//输出
//YJQ
//YJQ11
//YJQ22
```

##### 2.lamda表达式应用

```c#
List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
list.RemoveAll(n => n > 2);
foreach (var item in list)
{
    Console.WriteLine(item);
}
//输出
//1
//2
```

##### 3.多播委托

```c++
delegate void Del();
public class Program
{
    public static void Main(string[] args)
    {
        Del del = fun1;
        del += fun2;
        del += fun3;
        del -= fun2;
        del();
        Console.Read();
    }
    static void fun1()
    {
        Console.WriteLine("fun1");
    }
    static void fun2()
    {
        Console.WriteLine("fun2");
    }
    static void fun3()
    {
        Console.WriteLine("fun3");
    }
}
//输出
//fun1
//fun3
```

##### 4.泛型委托

<details>
    <summary>泛型委托</summary>
    <pre><code>
    public delegate int DelCompare<T>(T t1, T t2);
    public class Person
    {
        public int Age
        {
            get;
            set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person[] pers = { new Person() { Age = 18 }, new Person() { Age = 29 } };
            Person p = GetMax<Person>(pers, Compare3);
            Console.WriteLine(p.Age);
            Console.ReadKey();
        }
        public static T GetMax<T>(T[] nums, DelCompare<T> del)
        {
            T max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (del(max, nums[i]) < 0)
                {
                    max = nums[i];
                }
            }
            return max;
        }
        public static int Compare1(int n1, int n2)
        {
            return n1 - n2;
        }
        public static int Compare2(string s1, string s2)
        {
            return s1.Length - s2.Length;
        }
        public static int Compare3(Person p1, Person p2)
        {
            return p1.Age - p2.Age;
        }
    }
    //输出
    //29
    </code></pre>
</details>
##### 5.播放器

1. Windows Media Player 组件可播放音频。

```C#
// Turn off auto play
axWindowsMediaPlayer1.settings.autoStart = false;
axWindowsMediaPlayer1.URL = @"F:\music\1.mp3";
// Play
axWindowsMediaPlayer1.Ctlcontrols.play();
// Pause
axWindowsMediaPlayer1.Ctlcontrols.pause();
// Stop
axWindowsMediaPlayer1.Ctlcontrols.stop();
// Volume up
axWindowsMediaPlayer1.setting.volume += 5;
// Mute
axWindowsMediaPlayer1.setting.mute = true;
// Audio duration, total / minutes and seconds
axWindowsMediaPlayer1.currentMedia.duration / durationString;
// Current play time, total / minutes and seconds
axWindowsMediaPlayer1.Ctlcontrol.currentPosition / currentPositionString;
```

2. 根据播放器状态实现自动播放

```C#
private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        { 
if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
    {
        int index = listBox1.SelectedIndex;
        listBox1.SelectedIndices.Clear();
        if (++index == listBox1.Items.Count)
        {
            index = 0;
        }
        listBox1.SelectedIndex = index;
        axWindowsMediaPlayer1.URL = list[index];
    }
    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady)
    {
        try
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        catch { }
    }
}
```

3. 根据属性实现显示歌词

<details>
    <summary>显示歌词</summary>
    <pre><code>
    void IsExistLrc(string songPath)
    {
        songPath += ".lrc";
        //如果歌词存在
        if (File.Exists(songPath))
        {
            string[] lrcText = File.ReadAllLines(songPath, Encoding.Default);
            FormatLrc(lrcText);
        }
        else//歌词不存在
        {
            lblLrc.Text = "-------歌词未找到---------";
        }
    }
    List<double> listTime = new List<double>();//存储时间
    List<string> listLrc = new List<string>();//存储歌词
    //[00:15.57]当我和世界不一样  15.57
    void FormatLrc(string[] lrcText)  
    {
    	//清除上一个音频的歌词
    	listTime.Clear();
    	listLrc.Clear();
        for (int i = 0; i < lrcText.Length; i++)
        {
            string[] temp = lrcText[i].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            string[] newTemp = temp[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            //01
            double time = double.Parse(newTemp[0]) * 60 + double.Parse(newTemp[1]);
            listTime.Add(time);
            listLrc.Add(temp[1]);
        }
    }
    //播放歌词
    private void timer2_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < listTime.Count; i++)
        {
            if (musicPlayer.Ctlcontrols.currentPosition >= listTime[i] && musicPlayer.Ctlcontrols.currentPosition <= listTime[i + 1])
            {
                lblLrc.Text = listLrc[i];
            }
        }
    }
    </code></pre>
</details>

### 第N天

##### 1.读取txt文件行数和内容

1. FileStream.Read()

   ```C#
   FileStream fs = new FileStream(@"C:\Users\27652\Desktop\新建文本文档.txt", FileMode.Open, File.Access.Read );
   int length = (int)fs.Length;
   byte[] bytes = new byte[length];
   int reads = fs.Read(bytes, 0, n);
   string str = Encoding.UTF8.GetString(bytes, 0, reads);
   ```

2. FileStream.ReadByte()

   ```C#
   FileStream fs = new FileStream(@"C:\Users\27652\Desktop\新建文本文档.txt", FileMode.Open, File.Access.Read );
   long length = fs.Length;
   byte[] bytes = new byte[length];
   int index = 0;
   int data = fs.ReadByte();
   while(data != -1)
   {
       bytes[index++] = Convert.ToByte(data);
       data = fs.ReadByte();
   }
   string str = Encoding.UTF8.GetString(bytes);
   ```

3. StreamReader.ReadLine()

   ```C#
   StreamReader sr = new StreamReader(@"C:\Users\27652\Desktop\新建文本文档.txt", Encoding.UTF8);
   string line = sr.ReadLine();
   string content;
   while(line != null)
   {
       content += line;
       line = sr.ReadLine();
       if (line != null)
           content += "\r\n";
   }
   //-----------Or-------------
   StreamReader sr = new StreamReader(@"C:\Users\27652\Desktop\新建文本文档.txt", Encoding.UTF8);
   string content;
   while(!sr.EndOfStream)
   {
       content += sr.ReadLine();
       if (!sr.EndOfStream)
           content += "\r\n";
   }
   ```

4. StreamReader.ReadToEnd()

   ```C#
   StreamReader sr = new StreamReader(@"C:\Users\27652\Desktop\新建文本文档.txt", Encoding.UTF8);
   string str = sr.ReadToEnd();
   ```

5. StreamReader(FileStream)

   ```C#
   FileStream fs = new FileStream(@"C:\Users\27652\Desktop\新建文本文档.txt", FileMode.Open, File.Access.Read );
   StreamReader sr = new StreamReader(fs, Encoding.UTF8);
   string str = sr.ReadToEnd();
   ```

6. File

   ```C#
   string str = File.ReadAllText(@"C:\Users\27652\Desktop\新建文本文档.txt", Encoding.UTF8);
   ```

   

```C#
//Method one
string[] str = File.ReadAllLines(@"C:\Users\27652\Desktop\新建文本文档.txt");
Console.WriteLine(str.Length + " lines ," + str[str.Length - 1]);

//Method two
StreamReader sr = File.OpenText(@"C:\Users\27652\Desktop\新建文本文档.txt");
//as same as
//StreamReader sr = new StreamReader(@"C:\Users\27652\Desktop\新建文本文档.txt");
string content = sr.ReadToEnd();
int num = 0;
string temp = cxnull;
while ((temp = sr.ReadLine()) != null)
{
    str[num++] =  temp;
}
Console.WriteLine(num);
sr.Close();

//Method three
int num = 0;
string temp = null;
string[] str = new string[40];
FileStream fs = new FileStream(@"C:\Users\27652\Desktop\新建文本文档.txt", FileMode.Open);
StreamReader sr = new StreamReader(fs);
while ((temp = sr.ReadLine()) != null)
{
    str[num++] = temp;
}
fs.Close();
sr.Close();
Console.WriteLine(num);

Console.Read();
```

##### 2.拷贝整个文件夹

[C#中复制文件夹及文件的两种方法 - 狼者为王 - 博客园 (cnblogs.com)](https://www.cnblogs.com/wangjianhui008/p/3234519.html)

```c#
/// <summary>
/// 复制文件夹及文件
/// </summary>
/// <param name="sourceFolder">原文件路径</param>
/// <param name="destFolder">目标文件路径</param>
/// <returns></returns>
public int CopyFolder(string sourceFolder, string destFolder)
{
    try
    {
        //如果目标路径不存在,则创建目标路径
        if (!System.IO.Directory.Exists(destFolder))
        {
            System.IO.Directory.CreateDirectory(destFolder);
        }
        //得到原文件根目录下的所有文件
        string[] files = System.IO.Directory.GetFiles(sourceFolder);
        foreach (string file in files)
        {
            string name = System.IO.Path.GetFileName(file);
            string dest = System.IO.Path.Combine(destFolder, name);
            System.IO.File.Copy(file, dest);//复制文件
        }
        //得到原文件根目录下的所有文件夹
        string[] folders = System.IO.Directory.GetDirectories(sourceFolder);
        foreach (string folder in folders)
        {
            string name = System.IO.Path.GetFileName(folder);
            string dest = System.IO.Path.Combine(destFolder, name);
            CopyFolder(folder, dest);//构建目标路径,递归复制文件
        }
        return 1;
    }
    catch (Exception e)
    {
        MessageBox.Show(e.Message);
        return 0;
    }

}
```



##### 3.对日期时间的操作

[C#中DateTime的时间加减法操作总结 【转载】 - 工控Probie也有梦 - 博客园 (cnblogs.com)](https://www.cnblogs.com/pengyuanliang/p/15375281.html)

##### 4.重载和重写的区别

1. 重载在同一个类里面；重写在父类和子类中。
2. 重载的方法名相同，参数不同；重写方法名和参数都相同。
3. 重载的方法用相同对象调用；重写方法是不同对象调用。
4. 重载的编译时的多态；重写是运行时的多态。

##### 5.与空相关的运算符

1. 可空运算符（?）
   引用类型可以有空值（null），而值类型通常不能为空。

   ```C#
   int i = null；// Compilation Error
   int? i = null; // Allowed
   ```

2. 三元运算符（? :）

3. 空合并运算符（??, ??=）
   如果左操作数不为空则返回左操作数，否则返回右运算符。

   ```C#
   string s1 = null;
   string s2 = "";
   s1 = s1 ?? s2; // s1 = "";
   // Equal to 
   s1 ??= s2;
   
   // The null-coalescing operators are right-associative.
   a ?? b ?? c;
   d ??= e ?? f;
   // Equal to
   a ?? (b ?? c);
   d ??= (e ??= f);
   ```
   
4. 空检查运算符（?.）
   检查?.左侧成员是否为空，为空直接返回null，否则获取右侧成员运算结果。

   ```C#
   // Get the X position of the first point from Point sequence.
   int? first = points?.FirstOrDefault()?.X;
   // FirstOrDefault(): Return the first element which meet the conditions.
   // Equal to
   int? first = null;
   if (points != null)
   {
       var first = points.FirstOrDefault();
       if (first != null)
       {
           firstX = first.X;
       }
   }
   ```

5. 命名空间别名运算符（::）
   使用::访问一个别名命名空间的成员。

   ::左侧修饰符可以是下面三种：
   ①using 别名指令

   ```C#
   using forwinforms = System.Drawing;
   using forwpf = System.Windows;
   
   public class Converters
   {
       public static forwpf::Point Convert(forwinforms::Point point);
   }
   ```

   ②外部别名

   ③全局别名

6. nameof
   主要作用是方便获取类型、成员的简单字符串名称（也称非完全限定名）
   当使用nameof的参数发生变化时，在引用的地方也同步变化，避免硬代码。
   nameof()里面可以是类名，成员名（字段、属性、方法）。

   ```C#
   public string Name
   {
       get => name;
       set => name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
   }
   ```

7. typeof
   typeof运算符用于获取某个类型的System.Type实例。typeof运算符的实参必须是类型或者类型形参的名称。

   ```C#
   Console.WriteLine(typeof(List<string>));
   PrintType<int>();
   PrintType<System.Int32>();
   PrintType<Dictionary<int, char>>();
   // Output:
   // System.Collections.Generic.List`1[System.String]
   // System.Int32
   // System.Int32
   // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
   Console.WriteLine(typeof(Dictionary<,>));
   // Output:
   // System.Collections.Generic.Dictionary`2[TKey,TValue]
   ```

   使用 `typeof` 运算符来检查表达式结果的运行时类型是否与给定的类型完全匹配。 以下示例演示了使用 `typeof` 运算符和 is 运算符执行的类型检查之间的差异。

   ```C#
   public class Animal { }
   
   public class Giraffe : Animal { }
   
   public static class TypeOfExample
   {
       public static void Main()
       {
           object b = new Giraffe();
           Console.WriteLine(b is Animal);  // output: True
           Console.WriteLine(b.GetType() == typeof(Animal));  // output: False
   
           Console.WriteLine(b is Giraffe);  // output: True
           Console.WriteLine(b.GetType() == typeof(Giraffe));  // output: True
       }
   }
   ```

##### 6.关键字

1. var
   弱化类型定义，var可替代任何类型，编译器根据程序上下判断该变量类型。类似于object，但效率更高。

   1. 必须在定义时初始化。
   2. 一旦初始化完成，就不能给该变量赋值其它类型的值。
   3. var要求局部变量。
   4. var定义变量和object不同，在效率上和使用强类型关键字定义变量一样。

2. checked, unchecked
   在编译器运行时，checked检查整数类型操作或转换出现的溢出。

   <details>
       <summary>在编译器运行时，checked检查整数类型操作或转换出现的溢出。</summary>
       <pre><code>
       class OverFlowTest
       {
           // Set maxIntValue to the maximum value for integers.
           static int maxIntValue = 2147483647;
           // Using a checked expression.
           static int CheckedMethod()
           {
               int z = 0;
               try
               {
                   // The following line raises an exception because it is checked.
                   z = checked(maxIntValue + 10);
                   // Equal to
                   checked
                   {
                       z = maxIntValue + 10;
                   }
               }
               catch (System.OverflowException e)
               {
                   // The following line displays information about the error.
                   Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
               }
               // The value of z is still 0.
               return z;
           }
           // Using an unchecked expression.
           static int UncheckedMethod()
           {
               int z = 0;
               try
               {
                   // The following calculation is unchecked and will not
                   // raise an exception.
                   z = maxIntValue + 10;
               }
               catch (System.OverflowException e)
               {
                   // The following line will not be executed.
                   Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
               }
               // Equal to
               unchecked
               {
                   z = maxIntValue + 10;
               }
               // Equal to
               z = unchecked(maxIntValue + 10);
               // Because of the undetected overflow, the sum of 2147483647 + 10 is
               // returned as -2147483639.
               return z;
           }
           static void Main()
           {
               Console.WriteLine("\nCHECKED output value is: {0}",
                                 CheckedMethod());
               Console.WriteLine("UNCHECKED output value is: {0}",
                                 UncheckedMethod());
           }
           /*
          Output:
          CHECKED and CAUGHT:  System.OverflowException: Arithmetic operation resulted
          in an overflow.
             at ConsoleApplication1.OverFlowTest.CheckedMethod()
          CHECKED output value is: 0
          UNCHECKED output value is: -2147483639
           */
       }
       </code></pre>
   </details>
   
3. lock
   当不同线程需要访问某个资源时，需要用到同步机制，即对同一个资源进行读写操作时，保证同一时刻只能被一个线程操作。

   lock(objectA){codeB}:
   ①objectA被锁了吗，没有则由我来锁，否则等待objectA释放。

   ②lock后执行codeB期间其它线程不能调用codeB，也不能使用objectA。

   ③执行完codeB后释放objectA，codeB和objectA可以被其它线程访问。

   lock(this)会使得用到this对象地方无法被其它线程访问。

4. undefined

   ①未声明的变量

   ②已声明但未赋值的变量

   ③不存在的对象的属性

   ④函数没有返回值时，默认返回undefined

5. throw
   发出程序执行期间出现的信号。
   语法：throw [e];
   e 是派生自System.Exception类的实例。

   ```C#
   public class NumberGenerator
   {
      int[] numbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
   
      public int GetNumber(int index)
      {
         if (index < 0 || index >= numbers.Length)
         {
            throw new IndexOutOfRangeException();
         }
         return numbers[index];
      }
   }
   ```

   使用try-catch 或 try-catch-finally处理抛出的异常。

   ```C#
   public class Example
   {
      public static void Main()
      {
         var gen = new NumberGenerator();
         int index = 10;
         try
         {
             int value = gen.GetNumber(index);
             Console.WriteLine($"Retrieved {value}");
         }
         catch (IndexOutOfRangeException e)
         {
            Console.WriteLine($"{e.GetType().Name}: {index} is outside the bounds of the array");
         }
      }
   }
   // The example displays the following output:
   //        IndexOutOfRangeException: 10 is outside the bounds of the array
   ```

   `throw`也可以用于 `catch` 块，以重新引发在 `catch` 块中处理的异常。

   ```C#
   catch (IndexOutOfRangeException e)
   {
       throw;
   }
   ```

##### 7.调用cmd.exe写入cmd命令

[C# 执行CMD命令的方法 - 代码描绘人生 - 博客园 (cnblogs.com)](https://www.cnblogs.com/testsec/p/6095667.html)

##### 8.C#常用快捷键

[C# 常用快捷键 - Lee597 - 博客园 (cnblogs.com)](https://www.cnblogs.com/Lee597/p/14975587.html)

##### 10.跨线程访问控件

[C#多线程 - 跨线程访问控件_道可盗经常盗-CSDN博客_c跨线程访问控件](https://blog.csdn.net/sy95122/article/details/110071147)

```C#
// First
richTextBox.Invoke(
    new Action(() =>
               {
                   richTextBox.SelectionColor = Color.Black;
                   richTextBox.AppendText(DateTime.Now.ToString("MM-dd HH:mm:ss") + value);
               }));

// Second
ManualBtn.Invoke(
    new MethodInvoker(
        delegate
        {
            if (ManualBtn.BackColor == Color.Green)
            {
                ManualBtn.PerformClick();
            }
            ManualBtn.Enabled = false;
        }));

// Third
richTextBox.Invoke(
    (EventHandler)delegate
    {
        richTextBox.SelectionColor = Color.Black;
        richTextBox.AppendText(DateTime.Now.ToString("MM-dd HH:mm:ss") + value);
    });
```



##### 11.C# 中的delegate、event、Action、Func

[C# 中的delegate、event、Action、Func_|刘钊|的博客-CSDN博客](https://blog.csdn.net/weixin_40200876/article/details/89335598)

==可以通过`action()`或者`action.Invoke()`两种方式调用方法。==

在 C# 中，委托（Delegates）和事件（Events）是两个密切相关但用途不同的概念。

委托（Delegates）

1. **定义**：委托是一种类型，它安全地封装了一个方法的引用。在 C# 中，委托是一种引用类型，用于表示对具有特定参数列表和返回类型的方法的引用。

2. **用途**：委托允许将方法作为参数传递给其他方法，用于回调方法的场景。它们可以用于实现事件处理、回调机制等。

3. **灵活性**：委托可以直接被赋值、改变和调用。你可以将任何符合委托签名的方法赋予给委托变量。

4. **多播**：委托可以是多播的，意味着它们可以引用多个方法。一个委托实例可以调用委托链中的所有方法。

事件（Events）

1. **定义**：事件是一种成员，它在类或对象中封装了委托的引用。你可以将事件视为委托的一个包装器，提供了一种发布/订阅模型。

2. **用途**：事件主要用于实现观察者模式，允许一个对象通知其他对象发生了某些事情。常见于 UI 交互、通知系统等场景。

3. **封装**：事件提供了一种封装委托实例的方式，限制了外部对委托的直接操作。只有定义事件的类可以触发事件，而其他类只能添加或移除事件处理方法。

   ```C#
   public class Publisher
   {
       // 定义事件
       public event EventHandler MyEvent;
   
       public void RaiseEvent()
       {
           // 触发事件
           MyEvent?.Invoke(this, EventArgs.Empty);
       }
   }
   
   public class Subscriber
   {
       public void Subscribe(Publisher publisher)
       {
           // 订阅事件
           publisher.MyEvent += HandleEvent;
       }
   
       private void HandleEvent(object sender, EventArgs e)
       {
           // 处理事件
           Console.WriteLine("事件被触发");
       }
   }
   ```

   

4. **安全性**：事件比直接使用委托更安全。通过事件，你可以防止外部代码随意更改事件的订阅者列表或直接调用事件。

区别总结

- **封装与安全性**：事件是一种特殊的委托，提供了更好的封装和安全性。事件隐藏了其委托实例的实现，只暴露了添加（`+=`）和移除（`-=`）事件处理器的能力。

- **用途**：委托是一种更为通用的引用方法类型，而事件是在委托的基础上提供了一种特定的发布/订阅机制。

- **控制权**：通过事件，类可以更好地控制对其委托成员的访问。这是遵守良好的封装和设计原则的一种方式。

理解并正确使用委托和事件，对于编写高质量的 C# 代码来说非常关键。

##### 11.EventHandler

在C#中，EventHandler 是一个预定义的委托类型，专门用于处理事件。在 .NET 框架中，事件通常与委托一起使用，以提供对事件的订阅和发布机制。`EventHandler` 委托是这一机制中的核心部分，用于定义事件处理方法的签名。其定义如下：

```c#
public delegate void EventHandler(object sender, EventArgs e);
```

**返回类型**：`void`。这意味着事件处理方法不返回值。
**参数**：
sender：调用事件处理程序的对象。
EventArgs e：包含事件数据的对象。对于没有事件数据的事件，你通常会使用 EventArgs.Empty。

要定义一个 EventHandler 类型的事件，你可以这样操作：

```c#
public event EventHandler MyEvent;
```

然后当满足特定条件时触发这个事件：

```c#
if (MyEvent != null)
{
    MyEvent(this, EventArgs.Empty);
}
```

如果你的事件有特定类型的数据需要传递，那就需要创建 EventArgs 的子类，将数据封装在里面。然后使用`EventHandler<TEventArgs>`来定义和触发事件。例如：

```c#
public class MyEventArgs : EventArgs
{
    public string Message { get; set; }
}

public event EventHandler<MyEventArgs> MyEvent;

// 事件的订阅者可以这样处理这个事件
foo.MyEvent += OnMyEvent;
public void OnMyEvent(object sender, MyEventArgs e)
{
    Console.WriteLine(e.Message);
}
// 触发事件
if (MyEvent != null)
{
    MyEvent(this, new MyEventArgs() { Message = "Hello" });
}
```

在上面的代码中，OnMyEvent 方法被注册为 foo 对象的 MyEvent 事件的回调方法，当 MyEvent 事件被触发时，OnMyEvent 方法将会执行。


在事件处理模型中，事件处理程序通常包含两个参数：

1. `object sender`：这个参数代表了触发事件的对象，也就是事件源。多数情况下，我们会使用 `this` 关键字将当前对象作为事件源传递给事件处理器。
2. `EventArgs e`：这个参数包含了事件相关的数据。如果没有额外的数据需要传递，我们通常使用 `EventArgs.Empty` 或直接使用 `EventArgs` 类代表没有传递任何额外数据。

在 .NET 中，我们通常会通过创建 `EventArgs` 的子类来传递事件相关的数据。例如，你可能会创建一个叫做 `MyEventArgs` 的参数类来传递特定的数据：

##### 11.线程同步

[C# EventWaitHandle类解析 - 冬音 - 博客园 (cnblogs.com)](https://www.cnblogs.com/wintertone/p/11657334.html)

[ManualResetEvent、AutoResetEvent和Mutex - 走看看 (zoukankan.com)](http://t.zoukankan.com/newton-p-2793928.html)

##### 12.DataGridView导出EXCEL

[C# DataGridView直接导出EXCEL 的两种方法_爱家的技术博客_51CTO博客

##### 13.多线程

1. Thread.ThreadState:显示线程状态。
2. Thread.Join():当前线程等待新加入的线程执行完成后再继续往下运行。
3. Thread.Abort():引发ThreadAborting异常，中止线程
4. Thread.Suspend()：该方法并不终止未完成的线程，它仅仅挂起线程，以后还可恢复； 
   Thread.Resume()：恢复被Suspend()方法挂起的线程的执行；

##### 14.常用字符

char(9)水平制表符 "\t"

char(10)换行键 "\n"

char(13)回车键 "\r"

##### 15.深浅拷贝

[C#基础：C#中的深拷贝和浅拷贝 - .NET开发菜鸟 - 博客园 (cnblogs.com)](https://www.cnblogs.com/dotnet261010/p/12329220.html)

[(1条消息) C#四种深拷贝方法_xyx_0300的博客-CSDN博客_c# 深拷贝](https://blog.csdn.net/xyx_0300/article/details/118179940)

Type对象可通过IsValueType\IsGenericType等等判断对象类型。

##### 16.序列化

[C# 序列化和反序列化 详解 - Ryan_zheng - 博客园 (cnblogs.com)](https://www.cnblogs.com/ryanzheng/p/11075105.html)

##### 17.客户端和服务器问题

1. 要接收多个客户端信息，服务器接收函数必须将监听到套接字用新套接字接收
   `Socket server = listen.Accept();`
2. 检查客户端有没有退出用Poll()
   `bool b = server.Poll(5000, SelectMode.SelectRead)`
3. System.Windows.Forms.Timer触发Tick()
   ①通过窗体添加事件，timer_Tick()
   ②通过代码添加，timer.Tick += Timer_Tick()

##### 18.定时器

[C#里面的三种定时计时器：Timer - .NET开发菜鸟 - 博客园 (cnblogs.com)](https://www.cnblogs.com/dotnet261010/p/7113523.html)

##### 19.弃元，元组，switch语法糖

![](https://gitee.com/mrbm868/graphic-bed/raw/master/img/CSharp_元组.png)

[C#中的弃元_xinyue_htx的博客-CSDN博客_c# 弃元](https://blog.csdn.net/htxhtx123/article/details/104306675)

[c#语法糖模式匹配【switch 表达式】_dotNET跨平台的博客-CSDN博客](https://blog.csdn.net/sd7o95o/article/details/124287006)

```C#
public static string RockPaperScissors(string first, string second)
    => (first, second) switch
    {
        ("rock", "paper") => "rock is covered by paper. Paper wins.",
        ("rock", "scissors") => "rock breaks scissors. Rock wins.",
        ("paper", "rock") => "paper covers rock. Paper wins.",
        ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
        ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
        ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
        (_, _) => "tie"
    };
```

##### 20.整洁式写法

```C#
string str = "";
// Equal to
string str = string.Empty;

List<string> list = new List<string>();
string str1 = list[0];
// Equal to
string str1 = list.First();
// Addition, the two statements above will throw exceptions cause they have not been initialized.
string str1 = list.FirstOrDefault();
// The following one is used only in arrays.
string str1 = array?.First();
```

##### 21.字符串的比较

[c#中字符串的比较方法-详解_玉珂鸣响的博客-CSDN博客_c#字符串比较](https://blog.csdn.net/m0_52390420/article/details/111233489)

##### 22.反射(reflection)

[C#-反射-根据传入的类名，方法名，执行此方法，或者反射赋值给委托_HOLD ON!的博客-CSDN博客](https://blog.csdn.net/cxu123321/article/details/107711209)

C#中的反射可以恢复数据，是因为反射可以访问对象的元数据。元数据是指关于对象的描述信息，包括对象的类型、属性、方法、构造函数等。反射可以通过这些元数据来访问对象的内部数据。反射允许你在运行时实例化对象。这意味着你可以动态地创建对象，而不需要在编译时知道确切的类型。

例如，以下代码使用反射来获取对象的类型信息，假设有一个类 `Person`，它有两个属性 `name` 和 `age`：

```C#
object obj = new Person();
Type type = obj.GetType();

Console.WriteLine(type.Name); // 输出：Person
```

以下代码使用反射来获取对象的属性信息：

```C#
object obj = new Person();
Type type = obj.GetType();

PropertyInfo property = type.GetProperty("Name");

Console.WriteLine(property.GetValue(obj)); // 输出：John Doe
```

以下代码使用反射来调用对象的方法：

```C#
object obj = new Person();
Type type = obj.GetType();

MethodInfo method = type.GetMethod("SayHello");

method.Invoke(obj, null); // 输出：Hello, John Doe!
```

以下代码使用反射来多态生成对象的方法：

```c#
Type type = typeof(Person);
dynamic? obj = Activator.CreateInstance(type);

Type? type1 = Type.GetType("Person");
// 获取当前程序集
Assembly assembly = Assembly.GetExecutingAssembly();
// 动态创建当前类型的对象
if (type1 != null)
{
    dynamic? obj1 = assembly.CreateInstance(type1.FullName);
}
```

<details>
    <summary>传递类</summary>
    <pre><code>
    public delegate bool shuchu(string addr, int port, string format);//定义的委托
    void Test()
    {
        // 传入的类全名称
        string className = "MyProgram.OmronFinsTcpClass";
        // 得到此类的类型
        Type type = Type.GetType(className);
        // 获取当前程序集
        Assembly assembly = Assembly.GetExecutingAssembly();
        // 动态创建当前类型的对象
        dynamic obj = assembly.CreateInstance(type.FullName);
        // 根据传入的方法名获取当前类型的方法
        MethodInfo mthof = type.GetMethod("Connect", new Type[] { typeof(string), typeof(int), typeof(string) });
        // 执行此方法，如果此方法有参数，则传入参数
        bool b1 = mthof.Invoke(obj, new object[] { "1", 2, "3" });//输出“hello”
        // 两种方法动态赋值给委托。
        Delegate myshuchu1 = mthof.CreateDelegate(typeof(shuchu), obj);
        Delegate myshuchu2 = Delegate.CreateDelegate(typeof(shuchu), obj, mthof);
        bool b2 = (bool)myshuchu1.DynamicInvoke(new object[] { "1", 2, "3" });
        bool b3 = (bool)myshuchu2.DynamicInvoke(new object[] { "1", 2, "3" });
    }
    namespace MyProgram
    {
        class OmronFinsTcpClass
        {
            public bool Connect(string ip, int port, string format)
            {
                omronFinsNet = new OmronFinsNet();
                omronFinsNet.IpAddress = ip;
                omronFinsNet.Port = port;
                omronFinsNet.ByteTransform.DataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), format);
                connected = omronFinsNet.ConnectServer().IsSuccess;
                return connected;
            }
        }
    }
    </code></pre>
</details>

##### 23.根据类获取其命名空间、方法等属性

[C#获取类的名字、属性名字、方法名字的方式_C#气氛组队员的博客-CSDN博客_c# 获取类名](https://blog.csdn.net/ni996570734/article/details/123028203)

```C#
// Get the full name of all classes from the namespace of "MyProgram" in current assembly.
Assembly assembly = Assembly.GetExecutingAssembly();
Type[] typeArray = assembly.GetTypes().Where(t => String.Equals(t.Namespace, "MyProgram")).ToArray();
String[] strClassName = typeArray.Select(t => t.FullName).ToArray();
// Get the full name of assigned class
Type typeName = typeof(OmronFinsTcpClass);
string strName = typeName.FullName;// or Name(Exclude namespace)

// Get the name of current class
System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;//or FullName(Include namespace)
// Get the name of current method
System.Reflection.MethodBase.GetCurrentMethod().Name;
```

根据对象名称获取类名

```C#
public PLCParams plc = new PLCParams();
string name = plc.GetType().Name;
```

##### 24.类中访问控件

[C# winform中一个类中如何调用另一个窗体的控件或方法_ichenqingyun的博客-CSDN博客_winform调用其他窗口控件](https://blog.csdn.net/ichenqingyun/article/details/52622340?spm=1001.2014.3001.5502)

##### 25.将泛型解析为数组

```C#
public bool Write<T>(string address, T value)
{
    // Convert to a array.
    if (value is Boolean)
    {
        bool b = Convert.ToBoolean(value);
    }
    else if (value is Boolean[])
    {
        var array = value as Array;
        bool[] bools = new bool[array.Length];
        int i = 0;
        foreach (var item in array)
            bools[i++] = Convert.ToBoolean(item);
    }
    // Convert to a object.
    if (value is Int16)
    {
        short num = Convert.ToInt16(value);
    }
    else if (value is Int16[])
    {
        Int16[] int16s = (Int16[])(object)value;
    }
}
```

##### 26.防止应用重复开启的方法（单例）

[(C#)Application.Exit()、Environment.Exit（0）区别 - 跟着阿笨一起玩.NET - 博客园 (cnblogs.com)](https://www.cnblogs.com/51net/p/10984923.html)

[C# Mutex类_zls365365的博客-CSDN博客](https://blog.csdn.net/zls365365/article/details/124207303)

```c#
System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRun_上位机");
// Determining whether a mutual exclusion is in use
if (mutex.WaitOne(0, false))
{
    try
    {
        Application.Run(new MainForm());
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
    try { Application.Exit(); } catch { }
    try 
    { 
        System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
        process.Kill();
    } catch { }
    try { Environment.Exit(0); } catch { }
}
else
{
    MessageBox.Show("上位机 已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    Application.Exit();
}
```

```c#
new Mutex(true, Application.ProductName, out bool create);
if(create)
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form2());
}
else
{
    MessageBox.Show("程序已打开");
    System.Environment.Exit(0);
}
```

##### 27.控件大小随窗口大小改变等比例变化

[02--C#Winform--控件大小随窗口大小改变等比例变化_奔跑的花儿的博客-CSDN博客_c#控件随窗体大小变化](https://blog.csdn.net/TheBeauty_/article/details/121994376)

##### 28.字符串转字节

[C#中如何将字符串的“32”装换成字节0x32-CSDN社区](https://bbs.csdn.net/topics/391955315)

##### 29.二维数组和交错数组

[c#中的二维数组和交错数组的区别_牛掰是怎么形成的的博客-CSDN博客_交错数组和二维数组的区别](https://blog.csdn.net/qq_33060405/article/details/78463896)

[C# 二维数组行列遍历_十五啊十五的博客-CSDN博客_c#遍历二维数组](https://blog.csdn.net/zhangl15/article/details/104159941)

##### 30.在方法调用时显示形参

```c#
StreamWrite write = new StreamWriter(basepath, append: true);
```

##### 31.变量、数组、结构体、类

当一个程序需要很多类型一样的变量的时候，
用数组，反之用单个变量；
当数据是定长的时候，
用数组，反之用链表或有序集合；
当元素比较简单且无需多层分割时，
用数组，反之用集合或结构体；
当数据功能非常单一且执行次序非常严格时才会用栈。

[C#中类与结构体的区别_我是谁_谁是我的博客-CSDN博客_c# 结构体和类有什么区别](https://blog.csdn.net/wcx1293296315/article/details/112940875)

##### 32.计算时间间隔

[C#中如何使用TimeSpan_未来无限的博客-CSDN博客_c# timespan](https://blog.csdn.net/qq_30725967/article/details/86502877)

##### 33.获取文件夹下的文件

```C#
// Get string names of files
string[] s1 = Directory.GetFiles("D:\\DATA");
// Get all information of files
DirectoryInfo directoryInfo = new DirectoryInfo("D:\\DATA");
FileInfo[] fileInfos = directoryInfo.GetFiles();
```

##### 34.volatile关键字

`volatile`是C#用于控制同步的关键字，其意义是针对程序中一些敏感数据，不允许多线程同时访问，保证数据的完整性，是修饰**变量的修饰符**。多线程访问一个变量时，CLR为了效率允许每个线程进行本地缓存，导致了变量的不一致性。而`volatile`解决了这个问题，其修饰的变量不允许本地缓存，每个线程的都是直接操作在共享内存上，保证了变量始终一致。

`synchronized`则作用于一段代码或方法，获得并释放监视器，保证其修饰的内容只允许一个线程访问。

```C#
int i1;              int geti1() {return i1;}
volatile int i2;     int geti2() {return i2;}
int i3;              synchronized int geti3() {return i3;}
```

##### 35.C#define条件编译

[C#---#define条件编译 - 我喜欢大白 - 博客园 (cnblogs.com)](https://www.cnblogs.com/woxihuadabai/p/8005892.html)

##### 37.获取程序当前路径

[C#获取当前程序所在路径的各种方法 - 一年变大牛 - 博客园 (cnblogs.com)](https://www.cnblogs.com/adamgq/p/16580480.html)

##### 38.文件的BuildAction属性

[ VS2010文件的BuildAction属性介绍_三五月儿的博客-CSDN博客_build action](https://blog.csdn.net/yl2isoft/article/details/16918299)

##### 39.读取CSV文件时跳过标题栏

```C#
bool IsFirst = true;//标示是否是读取的第一行
string strLine = "";//记录每次读取的一行记录
string[] aryLine = null;//记录每行记录中的各字段内容
//逐行读取CSV中的数据
while ((strLine = sr.ReadLine()) != null)
{
    if (IsFirst == true)
    {
        IsFirst = false;
    }
    else
    {
        aryLine = strLine.Split(',');
        dic.Add(aryLine[1], aryLine[0]);
    }
}

int iReadNum = 0;
String line;
if (strFilePath.Contains(".csv"))
{
    sr.ReadLine();//去掉表头
}
while ((line = sr.ReadLine()) != null)
{
    strPramData[iReadNum] = line;
    iReadNum++;
}
```

##### 40.保持对象单例

错误写法1

```C#
//错误 => 本质是 get set会一直创建新对象
public static  SqlSugarScope  Db=> new  ...(); 

//错误  不能get set
public static  SqlSugarScope  Db{get{ retun new xxx}}  

//错误 不能是方法，调一次方法会创建一次
public static  SqlSugarScope  Db(){ return new xxx}

//错误  SqlSugarClient不能单例只能用 SqlSugarScope  
public static  SqlSugarClient Db=new  ...(); 

//正确写法
public static  SqlSugarScope  =  new  ...();
```

错误写法2：不能在泛型类中new

```C#
public class DbContext<T>  //错误原因:DbContext<T>.Db 随着T不同他的实例也会不同
{ 
   public static SqlSugarScope  Db=new  ...(); //应该提取到非泛型类或者IOC单例注入
}
 
//正确用法
public class DbContext<T> 
{ 
   public static  SqlSugarScope Db  =  SqlSugarHelper.Db; //在建一个类
}
```

错误写法3:不能在构造函数内部new

```C#
public class DbContext
{
   public DbContext()
   {
       Db=new SqlSugarScope..(); //new一次DbContext会创建一个实例
    }
    public static  SqlSugarScope  Db ;
}

//正确用法 
public static  SqlSugarScope  Db= new xxxx();
```

例示1：继承方式单例

```C#
public class TestManager : DbContext
{
    public List<Order> Add()
    {
        return Db.Queryable<Order>().ToList();
    }
}
public class DbContext  //如果是泛型类 Db要扔到外面 ,DbContext<T>.Db会导致产生多个实例
{
    protected  static SqlSugarScope Db = new SqlSugarScope(
        new ConnectionConfig()
        {
            DbType = SqlSugar.DbType.SqlServer,
            ConnectionString = Config.ConnectionString,
            IsAutoCloseConnection = true
        },
        db => {
            //单例参数配置，所有上下文生效
            db.Aop.OnLogExecuting = (s, p) =>
            {
                Console.WriteLine(s);
            };
        });
}
```

示例2 类调用方式

```C#
public class TestManager 
{
    public List<Order> Add()
    {
        return DbContext.Db.Queryable<Order>().ToList();
    }
}
public class DbContext //如果是泛型类 Db要扔到外面 ,DbContext<T>.Db会导致产生多个实例
{ 
    //这里要public 
    public static SqlSugarScope Db = new SqlSugarScope(
        new ConnectionConfig()
        {
            DbType = SqlSugar.DbType.SqlServer,
            ConnectionString = Config.ConnectionString,
            IsAutoCloseConnection = true
        },
        db => {
            //单例参数配置，所有上下文生效
            db.Aop.OnLogExecuting = (s, p) =>
            {
                Console.WriteLine(s);
            };
        });
}
```

### 41.删除过期文件

```C#
public static void DeleteOldFiles(string dirPath, int days)
{
    try
    {
        if (!Directory.Exists(str))
        {
            return;
        }

        DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        // 按照修改时间排序
        Array.Sort(directories, (x, y) => x.CreationTime.CompareTo(y.LastWriteTime));
        DateTime now = DateTime.Now;
        foreach (DirectoryInfo directoryInfo in directories)
        {
            if (now.Subtract(directoryInfo.LastWriteTime).TotalDays > (double)days)
            {
                FileInfo[] files = directoryInfo2.GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    fileInfo.Delete();
                }
                // 该方法只有文件夹为空时才可删除文件夹
                directoryInfo2.Delete();
            }
            else
            {
                // 排过序，后面文件均在时间范围内
                break;
            }
        }
    }
    catch { }
}
```

### 42.图片控件显示图片

```C#
Bitmap bmp = ReadImageFile(Program.StrBaseDic.Replace("\\DataBaseData\\CowainConfig\\ParamFile",@"\Cowain_AutoDispenser\bin\x64\Debug\FlatnessBackground.jpg"));
PictureBox.Image = bmp;

private Bitmap ReadImageFile(string path)
{
    FileStream fs = File.OpenRead(path);
    int fileLength = (int)fs.Length;
    byte[] image = new byte[fileLength];
    fs.Read(image, 0, fileLength);
    Image result = Image.FromStream(fs);
    fs.Close();
    Bitmap bit = new Bitmap(result);
    return bit;
}
//-----------------------------------------------------------------------
ViewImage(pictureBox1, path + "CCD1.bmp");
public static void ViewImage(PictureBox picture, string path)
{
    Image image = Image.FromFile(path);
    Bitmap bitmap = new Bitmap(picture.Width, picture.Height);
    Graphics graphics = Graphics.FromImage(bitmap);
    graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
    picture.Image = bitmap;
}
```



### 11.异常处理

##### 1. 捕捉错误

* try块后必须跟着一个或多个catch块或/和一个finally块
* catch块必须从最具体到最不具体排列，`System.Exception`最不具体，所以它放在最后
* 无论try块是否抛出异常，只要控制离开try块，finally块就会执行。finally块的作用是提供一个最终位置，放入一定会执行的代码。finally块最适合用来执行资源清理。

| 异常类型                         | 描述                                         |
| -------------------------------- | -------------------------------------------- |
| System.Exception                 | 最基本的异常，其它所有异常类型都由它派生     |
| System.ArgumentException         | 传给方法的参数无效                           |
| System.ArgumentNullException     | 不应该为null的参数为null                     |
| System.ApplicationException      | 避免使用。区分系统异常和应用程序异常。       |
| System.FormatException           | 实参类型不符合形参规范                       |
| System.IndexOutOfRangeExcetion   | 试图服务不存在的数组或其他集合元素           |
| System.InvalidCastException      | 无效类型转换                                 |
| System.InvalidOperationException | 发生非预期情况，应用程序不再处于有效工作状态 |
| System.NotImplementedException   | 该方法未实现                                 |

| 异常类型                          | 描述                           |
| --------------------------------- | ------------------------------ |
| System.NullReferenceException     | 引用为空，未指向实例           |
| System.ArithmeticException        | 无效数学运算                   |
| System.ArrayTypeMismatchException | 试图将类型有误的元素加入到数组 |
| System.StackOverflowException     | 发生非预期的深递归             |

### 12.泛型

##### 1.可空类型是作为泛型类型Nullable\<T>实现的

##### 2.泛型的优点

* 促进了类型安全。只要成员明确的数据类型才能使用，减小了在运行时发生InvalidCastException异常几率
* 为泛型类成员使用值类型，不再造成到object的装箱转换，减少了内存消耗
* 增加了代码的可读性
* 允许使用代码来实现模式，为反复出现模式提供了单一的实现。

##### 3.泛型接口和结构

声明泛型接口

```C#
internal interface IPair<Test>
{
    Test First { get; set; }
    Test Second { get; set; }
}

internal class Class1<T> : IPair<T>
{
    public T First { get; set; }
    public T Second { get; set; }
}
```

避免在类型中实现同一泛型接口的多个构造，如下

```C#
internal class Class1<T> : IPair<int>, IPair<float>
{
    int IPair<int>.First { get; set; }
    float IPair<float>.First { get; set; }
    int IPair<int>.Second { get; set; }
    float IPair<float>.Second { get; set; }
}
```

##### 4.指定默认值

使用`default`操作符初始化部分字段。因为不知道T的数据类型。引用类型能初始化成null。但如果T是不允许为空的值类型，null就不合适。为应对这样的局面，C#提供了default操作符。只要能推断出数据类型，使用default时就可不指定参数。

```C#
struct Pair<T> : IPair<T>
{
    public T First { get; set; }
    public T Second { get; set; }
    public Pair(T first)
    {
        First = first;
        Second = default(T);
    }
}
```

##### 5.元组

实现元组的底层类型实际是泛型，System.ValueTuple。可在TRest中存储另一个ValueTuple。这样元数实际就是无限的。![元组](E:\Gitee\Backup\元组.png)

##### 6.约束

1. 接口约束

   为了使T类型参数有`CompareTo()`方法，必须实现`IComparable<T>`接口

   ```C#
   class BinaryTree<T> where T: System.Comparable<T> {}
   ```

2. 类类型约束

   如果同时指定多个约束，类类型约束必须第一个出现。
   语法和接口约束基本相同，但是不允许多个类类型约束，因为不可能从多个不相关的类派生。
   类类型约束不能指定密封类，不允许是`string`或`System.Nullable<T>`。

   ```C#
   class Entity<TKey, TValue> : 
   	System.Collections.Generic.Dictionary<Tkey, TValue>
       where TValue : EntityBase
   {}
   ```

3. struct/class约束

   将类型参数限制为任何非可空类型或任何引用类型
   `struct`约束：可空值类型不符合条件

   `class`约束：类型参数限制为引用类型，类、接口、委托、数组符合条件

   ```C#
   struct Nullable<T> : IFormattablem, IComparable<Nullable<T>>
       where T : struct
   {}
   ```

4. 多个约束

   可以为任意类型参数指定任意数量的接口约束，但类类型约束只能指定一个（即同类可实现任意数量的接口，但只能从一个类派生）。如果有多个3类型参数，每个类型参数前都要使用`where`关键字。一个类型参数的多个约束默认存在AND关系。

   ```c#
   class Entity<TKey, TValue> : 
   	System.Collections.Generic.Dictionary<Tkey, TValue>
       where TKey : IComparable<TKey>, IFormattable
       where TValue : EntityBase
   {}
   ```

   

### 13.定义值相等性

- 对于 `class` 类型，如果两个对象引用内存中的同一对象，则这两个对象相等。
- 对于 `struct` 类型，如果两个对象是相同的类型并且存储相同的值，则这两个对象相等。
- 对于具有 `record` 修饰符（`record class`、`record struct` 和 `readonly record struct`）的类型，如果两个对象是相同的类型并且存储相同的值，则这两个对象相等。

`record struct` 的相等性定义与 `struct` 的相等性定义相同。 不同之处在于，对于 `struct`，实现处于` [ValueType.Equals(Object)`] 中并且依赖反射。 对于记录，实现由编译器合成，并且使用声明的数据成员。

### 14.`record`类修饰符

C# 9.0中引入了一个全新的类型——`record`。它是一种引用类型，可以定义为类（class）或者结构（struct）。`record`类型首先是不可变的，通过值比较进行相等性判断。而普通的类是可变的，通过引用比较进行相等性判断。
这是一段简单的对比代码，先看一下普通类的行为:

```c#
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
Person person1 = new Person { FirstName = "John", LastName = "Doe" };
Person person2 = new Person { FirstName = "John", LastName = "Doe" };

Console.WriteLine(person1 == person2); // Output: False
Console.WriteLine(Object.ReferenceEquals(person1, person2)); // Output: False
```

尽管person1和person2的属性值是一样的，但他们是两个不同的对象，所以判定为不相等。
而record就不同了，看一下例子:

```c#
public record Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
Person person1 = new Person { FirstName = "John", LastName = "Doe" };
Person person2 = new Person { FirstName = "John", LastName = "Doe" };

Console.WriteLine(person1 == person2); // Output: True
```

这次person1和person2**虽然还是两个不同的对象，但他们的属性值是一样的，所以record就把他们判定为了相等**。另外，我们可以看到，`record`采用`init`访问器，只允许在对象初始化时设置属性值，不允许在初始化后修改，所以它们是不可变的。

总结一下，record类型的特性：

1. 提供值相等性比较
2. 是不可变的。
3. 自动生成一些方法，例如 ToString(), Equals(), GetHashCode() 等。
4. 支持非破坏性的修改（non-destructive mutation），通过with关键字可以创建一个与现有对象属性值大部分相同的新对象。

需要注意的是，并非所有场景都适合使用。比如在需要更改对象状态的场景下，还是应该选择使用普通的类。

`readonly`修饰符修饰的字段只能在声明时或所属类的构造函数中赋值。
`init`访问器用于初始化属性的值，该属性的值只能在`init`访问器中、构造函数中或对象初始值设定项中设置。设置后其值就不能再改变，其效果类似于`readonly`字段。
`required`修饰符表示它所应用的字段或属性==必须==由对象初始值设定项进行初始化。

```c#
record class Record
{
    public readonly int a = -1;
    public int aa { get; init; } = -1;
    public required int aaa { get; set; };

    public Record()
    {
        this.a = 0;
    }

    public void M()
    {
        a = 1;//Error
        aa = 1;//Error
        var o1 = new Record
        {
        	a = 1;//Error
            aa = 1,
            //aaa = 2, //Error
        };
    }
}

class Class2
{
    public void M2()
    {
        var o1 = new Record
        {
            a = 1;//Error
            aa = 11,
            aaa = 111
        };
        o1.a = 2;//Error
        o1.aa = 2;//Error
        o1.aaa = 2;        
    }
}
```

### 15.add和remove关键字

在C#中，add和remove关键字被用来创建自定义的事件访问器。事件是发布-订阅模型的一种实现，表示一类特殊的多路广播委托。一个事件可以有多个订阅者，对于订阅者而言可以自由地添加或者移除自己。
当我们用标准的方式定义一个事件时，编译器会自动生成add和remove访问器（你并不能直接看到），用于实现对该事件的订阅和取消订阅。
如果你希望改变事件的订阅和取消订阅的行为的话，可以自定义add和remove访问器。代码如下：

```c#
public sealed class MyClass
{
    private EventHandler myList;
    public event EventHandler MyEvent
    {
        add
        {
            myList += value;
            Console.WriteLine("Added event.");
        }
        remove
        {
            myList -= value;
            Console.WriteLine("Removed event.");
        }
    }
}
```

在上面的代码中，你可以看到add和remove访问器用于处理订阅事件和取消订阅事件的逻辑。当你对MyEvent事件做+=操作的时候，会调用add访问器；做-=操作的时候，会调用remove访问器。所以你可以在add和remove访问器里添加自定义的逻辑。
需要注意add和remove关键字只能在事件(event)中使用，不能在常规的字段或者属性中使用。

### 16.`IAsyncEnumerable<T>`类型

`IAsyncEnumerable<T> `是 .NET 中的一种接口类型，用于表示支持异步迭代的枚举式数据序列。
异步迭代是异步编程和迭代器的结合。你可以利用 it 异步等待序列中的每个元素，而不用一次性获取整个集合。这在处理可能花费很长时间计算或检索每个元素的大型集合时非常有用，例如读取大文件或处理复杂的计算任务。

```c#
private static void Main(string[] args)
{
    Task.Run(DateTimeStyles).Wait();
    System.Console.WriteLine("Main!");
    Task.Run(ClearAwaitAsync).Wait();
}

private static Task ClearAwaitAsync()
{
    DoWorkAsync();  //  此调用不会等待
    Console.WriteLine("After work");
    return Task.CompletedTask;
}

public static async Task DoWorkAsync()
{
    await Task.Delay(2000);  // 模拟耗时操作
    Console.WriteLine("Work finished");
}

private static async Task DateTimeStyles()
{
    await foreach (var item in GetItemsAsync())
    {
        Console.WriteLine(item);
    }
    System.Console.WriteLine("DateTimeStyles!");//await foreach 语句体后面的代码在整个循环执行完毕以后将会被执行
}

private static async IAsyncEnumerable<string> GetItemsAsync()
{
    for (int i = 0; i < 3; i++)
    {
        await Task.Delay(500);
        yield return $"The number is {i}";
    }
}

//OUTPUT
The number is 0
The number is 1
The number is 2
DateTimeStyles!
Main!
After work
```

这种机制允许我们在数据准备好时立即处理，而不用等待所有数据都准备好。这在处理大型数据或需要长时间准备的数据时，可以提高应用的响应性和效率。

Task 在运行时通常会使用线程池技术。
在 .NET 中，Task 是一种表示异步操作的对象，而执行这些异步操作的线程通常来自线程池。线程池是一个线程管理的机制，它在程序启动时创建一些线程，并将这些线程保持在池中供需要的时候使用。使用线程池可以减少线程创建和销毁的开销，提升资源利用率。
当你使用 Task.Run 或 Task.Factory.StartNew 等方法启动一个新的 Task 时，.NET 运行时会从线程池中获取一个线程来执行这个 Task。当该 Task 完成（或暂时阻塞）后，该线程会被归还给线程池，供后续的 Task 或其他并行操作使用。
需要注意的是，async/await 异步操作可能并不会新开线程。例如，在 I/O 密集型操作（如文件读写、网络请求等）中，await 通常会利用操作系统的 I/O 完成端口（IOCP，即异步 I/O）机制进行异步操作，这些操作实际上并不需要额外的线程。在这种场景下，Task 更像是一种状态机，用于表示异步操作的完成情况，而实际的工作可能并不在另一个线程上执行。

如果你的` DateTimeStyles`方法是一个 void 类型，这意味着这个方法不返回任何值，包括不返回 Task，那么你将无法在其上使用 await 关键字等待异步操作的完成，同时也无法在 Task.Run 中使用它。
使用返回类型为 void 的异步方法（也称为 async void 方法）通常是不建议的，除非在特殊情况下（比如事件处理器）。这是因为 async void 方法会在它执行到第一个 await 表达式时立即返回，且你无法获取与其关联的 Task，这使得你无法追踪其生命周期，无法等待其完成，也无法处理由异步操作抛出的异常。这可能会导致程序的不确定行为和难以捕获的错误。
所以，当你编写异步方法时，应尽量避免使用 async void，而应使用 async Task 或 async Task<T>。这样，其他代码就可以通过 await 关键字等待异步操作的完成，并通过 try-catch 语句处理可能的异常。

### 17.async void 类型

在C#中，async void 是专门为事件处理器设计的，因为事件处理器的签名通常没有返回类型（即，返回 void）。也就是说，你执行一个事件处理器，调用它时并不期待它有任何返回值。
async void 方法允许你在事件处理器中使用 await 导致异步行为，这在面向用户的UI应用程序中非常有用。例如，当用户点击一个按钮时，你可能需要执行一项耗时的网络请求或数据库操作，通过 await，UI线程会被释放出来并保持响应。

```C#
public async void Button_Click(object sender, RoutedEventArgs e)
{
    var result = await LongRunningOperationAsync();
    // 继续执行其他操作，比如更新UI
}
```

然而，需要注意的是 async void 方法存在一些挑战：

如果 async void 方法内部有未处理的异常，应用程序可能会崩溃。因为 async void 方法无法返回 Task，调用者不能捕获并处理异步操作中可能抛出的异常。
无法追踪 async void 方法的生命周期。因为它们没有返回 Task，调用者不能等待这个异步操作的完成。

因此在非事件处理的场合，尽量避免使用 async void，而是使用 async Task 或 async Task<T>，这样你可以持有一个 Task，通过它来追踪异步操作的完成，处理可能的异常，以及等待其完成。

### 18.async  await  执行详解

 这里依旧先打印Work finished，是什么原因？

```C#
public async Task DoWorkAsync()
{
    await Task.Delay(2000); // 模拟耗时操作
    Console.WriteLine("Work finished");
}
// 调用异步方法
await DoWorkAsync();
Console.WriteLine("After work");
```

在这个代码样例中，由于 `await` 关键字的存在，`DoWorkAsync` 方法内部的 `Console.WriteLine("Work finished");` 导致会先于 `Console.WriteLine("After work");` 执行。

简单来说，当执行到 `await DoWorkAsync();` 这行代码时：

1. `DoWorkAsync` 方法被调用，开始执行。
2. 执行到 `await Task.Delay(2000);`，`DoWorkAsync` 方法会暂停执行，控制权回到调用它的方法（也就是 `Main` 方法）。但由于 `await` 关键字的存在，`Main` 方法在 `DoWorkAsync` 完成前也会暂停。
3. 等待的 `Task.Delay(2000);` 完成之后，`DoWorkAsync` 恢复执行，打印出 "Work finished"。
4. `DoWorkAsync` 方法执行完成，控制权归还给 `Main` 方法，继续执行剩下的部分，打印 "After work"。

因此，尽管 `DoWorkAsync` 方法是异步的，但由于 `await` 关键字的使用，代码依然会保持 "Work finished" 先于 "After work" 打印出来的顺序。这就是 `await` 的一个主要优点 - 它能帮助我们在保持代码的读性（貌似同步的顺序性）同时进行异步操作。

### 18.Timer

在C#中，`System.Threading.Timer`和`System.Timers.Timer`是两种常用的计时器，但它们接口不同，各具用途。

`System.Threading.Timer`是用户提供一个`TimerCallback`委托给定时器，在特定的时间间隔调用此委托。此定时器则有更精简的接口，并且只适用于基于多线程的情况。

```C#
System.Threading.Timer t = new System.Threading.Timer(TimerCallback, null, 0, 2000);

public void TimerCallback(Object o) {
  // TODO: Handle timer event
}
```

`System.Timers.Timer`侧重于组件模型支持，允许在多个线程间同步事件，并且可以配置为跨越应用程序的域。它还具有更多的功能，例如可以通过设置`AutoReset`属性来选择定时器触发一次或多次。

```C#
System.Timers.Timer t = new System.Timers.Timer(2000);
t.Elapsed += new ElapsedEventHandler(OnElapsed);
t.AutoReset = true;
t.Enabled = true;

public void OnElapsed(Object source, ElapsedEventArgs e)
{
    // TODO: Handle timer event
}
```

如果你的程序是基于多线程的情况，那么`System.Threading.Timer`更合适你，如果你需要的是一个特性丰富并且可配置的定时器，那么`System.Timers.Timer`应当更适合你。

`System.Threading.Timer` 类在 .NET 中会开启新的线程来执行与定时器关联的回调函数。你可以将其看作一种机制，能够在特定时间（只发生一次）或者特定的间隔（多次发生）触发一个操作。
然而，你应该注意的是，此定时器使用的线程并不是你自己创建的，而是从线程池中获取的。当定时器到达指定的时间间隔，线程池会提供一个线程来执行回调方法。这种方式在开销管理和性能方面都更有效。
针对这一点，以下是一个简单的示例：

```C#
public static void Main()
{
    Timer t = new Timer(TimerCallback, null, 0, 2000);
    // 主线程休眠一段时间进行观察
    Thread.Sleep(11000);
    t.Dispose();
}

private static void TimerCallback(Object o) 
{
	Console.WriteLine("Timer callback executed on thread: {0}", 
          				Thread.CurrentThread.ManagedThreadId);
}
```

}

在这个例子中，你可以看到回调函数是在不同的线程中被执行的，线程的 ID 由 `Thread.CurrentThread.ManagedThreadId`提供，你会发现，这并不是主线程的 ID，这是因为回调函数是由线程池中的线程执行的。

`System.Timers.Timer`作为一种服务器基础计时器，它会在每次到达指定的间隔时产生一个事件。这个类的对象实际上使用一个`System.Threading.Timer`来实现定时功能，这意味着计时回调并不在创建计时器的线程（主线程）上执行。
当一个时间间隔到达，Elapsed事件会被触发，而事件处理函数则默认在一个线程池线程中执行。
不过，需要注意的是，如果你希望Elapsed事件在创建计时器的那个线程（例如 UI 线程）上执行，你可以给`System.Timers.Timer`对象的`SynchronizingObject`属性赋上一个与UI线程关联的对象（例如在Windows Forms中，这个对象通常是指一个Form，或者是某个UI控件）。
这样，无论Elapsed事件何时被触发，都会在指定的线程，也就是SynchronizingObject所在的线程中运行。这在需要更新UI的情况下特别有用，因为UI元素通常只能在UI线程上被访问。

在Windows Forms（WinForms）应用程序中，主线程也被视为用户界面（UI）线程。
WinForms应用程序以单线程方式运行，所有UI操作（例如创建窗体、改变控件属性或响应用户操作等）都在这个线程上执行，因此在这种上下文中，主线程即为UI线程。
但是，请注意，可以创建新的线程来执行耗时的运算或I/O操作，以避免阻塞UI线程，导致用户界面无响应。然后，在这些后台线程中，你不能直接访问或修改UI控件。如果你需要在这些线程中更新UI，你应当使用`Control.Invoke`或`Control.BeginInvoke`方法，将这些更新UI的操作交回给UI线程执行。这是因为在WinForms和许多其他UI框架中，UI控件（例如窗体、按钮等等）都不是线程安全的。

`System.Timers.Timer`类的 `SynchronizingObject `属性默认是 null。
如果你没有对 `SynchronizingObject `属性进行设置，定时器会在线程池线程中引发 `Elapsed `事件。这意味着如果你在 `Elapsed `事件处理函数中访问 UI（如 WinForm 或 WPF 的元素），可能会引发线程冲突。
为了解决这个问题，你可以将主窗体（或者任何 Windows Form 控件）赋值给 `SynchronizingObject`。这样，定时器就会在 UI 线程上引发 Elapsed事件。
以下是一个示例：

```c#
// 假设 this 是你的主窗体
System.Timers.Timer myTimer = new System.Timers.Timer();
myTimer.SynchronizingObject = this;
```

这样设置后，`myTimer `在引发 Elapsed 事件时，就会在 UI 线程而非线程池线程上执行回调方法。这就顺利避免了潜在的线程冲突问题。

### 18.`Invoke`和`BeginInvoke `

`Control.Invoke `和 `Control.BeginInvoke `都是用来在 UI 线程上执行指定的委托（delegate）。这在有多线程操作，并且需要在非 UI 线程上更新 UI 控件时是极其重要的，因为直接在非 UI 线程上操作 UI 控件是不安全的。
两者的主要区别在于，它们对线程执行的控制方式不同：

`Control.Invoke`: 调用该函数会导致调用线程阻塞，直到 UI 线程执行完该操作后调用线程才能继续执行。它是同步的，即调用线程会等待控制返回。

```c#
this.Invoke((MethodInvoker)delegate {
   // 更新UI的代码
});
```

`Control.BeginInvoke`: 调用该函数时，调用线程会立即返回，而 UI 线程会在空闲时执行该操作。它是异步的，即调用线程不会等待控制返回。

```c#
this.BeginInvoke((MethodInvoker)delegate {
   // 更新UI的代码
});
```

选择使用哪个函数主要取决于你的需求。如果你不需要等待 UI 操作完成，或者由于某种原因你需要避免阻塞你的线程（例如那可能会导致死锁），那么可以使用`BeginInvoke`。如果你需要等待 UI 操作完成才能进行下一步，那么你应该使用 Invoke。
`Control.Invoke` 和 `Control.BeginInvoke` 方法可以在指定的 `Control` 控件所在的线程上执行特定的方法。而这个 `Control` 控件，无论是一个按钮、标签，还是整个的 Form 窗体，只要是在 UI 线程上创建的，就都可以被用来安全地在其他线程上更新 UI。

### 19.依赖注入

依赖注入（Dependency Injection，简称DI）是一种设计模式，用于管理类之间的依赖关系。在依赖注入中，类的依赖关系不是在类内部直接创建或者硬编码，而是通过外部的机制来注入（传递）给类。这种方式有助于解耦类之间的依赖，提高代码的可维护性、可测试性和可扩展性。控制反转通过将控制权从调用者转移到框架或容器，从而降低了类之间的直接依赖性，通过依赖注入实现。

在C#中，依赖注入通常包括以下几个主要概念：

1. **依赖（Dependency）：** 一个类需要使用其他类或服务，这个被使用的类或服务就是所谓的依赖。

2. **服务（Service）：** 在依赖注入中，依赖通常是通过服务来提供的。服务可以是具体的类、接口、或者其他可被注入的对象。

3. **注入（Injection）：** 将依赖通过构造函数、属性或方法参数等方式注入到类中的过程。

4. **容器（Container）：** 依赖注入容器是一个管理和解析依赖关系的工具。它负责创建和维护依赖对象的实例，并在需要的时候将它们注入到需要的地方。

在C#中，依赖注入通常使用第三方库（如.NET Core中的内置依赖注入容器）或者DI容器框架（如Autofac、Ninject、Unity等）来实现。这些工具提供了简化依赖注入的方式，开发者只需在代码中声明依赖，容器就会负责解析和注入。

下面是一个简单的依赖注入的例子，使用.NET Core中内置的依赖注入容器：

```csharp
using Microsoft.Extensions.DependencyInjection;

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class ConsoleLogger1 : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message + "11111111111");
    }
}

public class MyClass
{
    private readonly ILogger _logger;

    public MyClass(ILogger logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.Log("Doing something...");
    }
}

class DependencyInjection
{
    public static void Main11()
    {
        // 创建服务容器
        var serviceProvider = new ServiceCollection()
            .AddTransient<ILogger, ConsoleLogger>()
            .AddTransient<ILogger, ConsoleLogger1>() // 会覆盖上面的注册
            .AddTransient<MyClass>()
            .BuildServiceProvider();

        // 从容器中获取MyClass实例
        var myClassInstance = serviceProvider.GetRequiredService<MyClass>();

        // 调用MyClass中的方法，会自动注入ConsoleLogger
        myClassInstance.DoSomething();
    }
}
```

在上述例子中，`MyClass`通过构造函数接收`ILogger`接口的实例。在`Main`方法中，我们使用.NET Core提供的`ServiceCollection`和`BuildServiceProvider`来设置依赖注入容器，并通过`.AddTransient`方法注册服务和使用服务的类。`.AddTransient`表示每次请求都会创建一个新的实例。

这样，当我们从容器中获取`MyClass`的实例时，容器会自动解析并注入`ILogger`的实例（在此例中是`ConsoleLogger`），从而实现了依赖注入。

以下是一些使用依赖注入的典型场景：

1. **测试驱动开发（TDD）：** 依赖注入有助于实现更容易进行单元测试的代码。通过将依赖注入到类中，你可以更轻松地使用模拟对象（Mock objects）替代实际的依赖，从而使单元测试更加简单和可靠。
2. **可维护性和可读性：** 依赖注入使得代码更易于理解和维护，因为它明确了类的依赖关系。通过查看构造函数或其他注入点，开发人员可以清晰地看到一个类所依赖的所有组件。
3. **松耦合设计：** 依赖注入可以降低类之间的耦合度，使得代码更加灵活和易于扩展。类不再负责创建自己的依赖，而是通过外部注入，从而减少了类与具体实现之间的紧密关系。
4. **配置灵活性：** 通过依赖注入容器，你可以在不修改代码的情况下更改组件的实现。这对于在不同环境中使用不同的实现（例如开发、测试和生产环境）非常有用。
5. **插件和模块化开发：** 依赖注入促进了模块化开发，允许你更容易地替换、添加或删除系统的各个部分。这对于构建可插拔的架构和应用程序模块非常有帮助。
6. **ASP.NET Core中的Web开发：** 在ASP.NET Core中，依赖注入是内置的，并被广泛用于控制器、服务以及其他应用程序组件的管理。这使得在Web应用程序中使用依赖注入变得非常方便。

### 20.特性

在 C# 中，Attributes（特性）是一种用于向程序中添加元数据（metadata）（描述程序实体的特性、行为、用途等信息）的机制。它们提供了一种将附加信息和元数据与程序实体（类、方法、属性等）关联起来的方式。这些元数据可以被反射读取，并在运行时或设计时提供一些额外的信息。特性是通过在代码中使用方括号 `[]` 来声明的。

以下是一些常见的C#特性：

1. **[Obsolete] 特性：** 用于标记已经过时的代码。编译器会在使用过时的成员时发出警告。

    ```csharp
    [Obsolete("This method is obsolete. Use NewMethod instead.")]
    public void OldMethod()
    {
        // 方法实现
    }
    ```

2. **[Serializable] 特性：** 用于指示一个类可以序列化，即可以在网络上传输或保存到文件中。

    ```csharp
    [Serializable]
    public class SerializableClass
    {
        // 类的成员
    }
    ```

3. **[AttributeUsage] 特性：** 用于指定特性的使用方式，例如可以应用于类、方法、属性等。

    ```csharp
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyCustomAttribute : Attribute
    {
        // 特性的实现
    }
    ```

4. **[Conditional] 特性：** 用于指定条件编译，只有在满足指定条件时，特性中的代码才会被编译进程序。这表示只有在定义了 `DEBUG` 符号（例如通过在 Visual Studio 的项目属性中选择 "Debug" 配置）时，这个方法的调用才会被编译进程序。

    在发布（Release）配置中，`DEBUG` 符号通常不会定义，因此 `DebugMethod` 中的代码在 Release 模式下不会被编译进程序。

    这种方法对于包含仅在调试时使用的代码非常有用，因为它允许在发布时轻松地排除这些代码，从而减小程序的大小。

    需要注意的是，`Conditional` 特性只能用于方法、属性、索引器和事件。并且，它仅影响编译，而不是运行时行为。在运行时，即使在 Release 模式下，你仍然可以调用 `DebugMethod`，但调用会被忽略，因为相应的代码块在编译时已被排除。

    ```csharp
    [Conditional("DEBUG")]
    public void DebugMethod()
    {
        // 只在 DEBUG 模式下编译
    }
    ```

    你也可以自定义条件符号，并在编译时定义或取消定义这些符号。

    例如，你可以使用 `#define` 指令在代码中定义符号：

    ```csharp
    #define MY_CONDITION
    
    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
            DebugMethod();
        }
    
        [Conditional("MY_CONDITION")]
        public static void DebugMethod()
        {
            Console.WriteLine("This code is included only if MY_CONDITION is defined.");
        }
    }
    ```

    在这个例子中，只有在使用 `#define MY_CONDITION` 指令定义了 `MY_CONDITION` 符号时，`DebugMethod` 中的代码才会被编译进程序。

5. **[Required] 特性（ASP.NET Core）：** 用于标记模型属性为必需的，通常在模型验证中使用。

    ```csharp
    public class MyModel
    {
        [Required]
        public string Name { get; set; }
    }
    ```

这只是一小部分C#中可用的特性，C#提供了许多内置的特性，并且你也可以创建自定义特性以满足特定需求。在实际开发中，特性通常用于提供元数据、配置和注释，以及在运行时进行自定义操作。

当你在C#中使用特性时，你可以通过反射机制来获取特性的信息。以下是一个简单的例子，演示如何在运行时获取类的特性信息：

```csharp
[MyCustom123("SampleClass", Version = 0)]
[MyCustom456Attribute(name: "SampleClass123", Version1 = 1)]// 没有找到SampleClass123，会报错
class SampleClass
{
    // 类的成员
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.All)] // 限定该特性的使用范围：类
public class MyCustom123Attribute(string name) : Attribute
{
    public string Name { get; set; } = name;
    public double Version { get; set; }
    public double ABC { get; set; }
}

public class MyCustom456Attribute(string name) : MyCustom123Attribute(name)
{
    public string Name1 { get; set; } = name + "111";
    public double Version1 { get; set; }
}

public class AttributeTest
{
    public static void Main11()
    {
        // 检测某个特性是否应用到某个类上
        SampleClass myClass = new SampleClass();
        Type type = myClass.GetType();
        // false表示不搜索SampleClass继承链上的特性
        bool isDefined = type.IsDefined(typeof(MyCustom123Attribute), false);
        if (isDefined)
            Console.WriteLine(type.Name + "上使用了特性MyCustom123Attribute");

        // 获取SampleClass上的所有特性
        object[] attributes = typeof(SampleClass).GetCustomAttributes(true);
        foreach (var attribute in attributes)
        {
            if (attribute is MyCustom123Attribute myCustomAttribute)
            {
                Console.WriteLine($"Class Name: {myCustomAttribute.Name}");
                Console.WriteLine($"Version: {myCustomAttribute.Version}");
            }
            if (attribute is MyCustom456Attribute myCustomAttribute1)
            {
                Console.WriteLine($"Class Name1: {myCustomAttribute1.Name1}");
                Console.WriteLine($"Version1: {myCustomAttribute1.Version1}");
            }
        }
    }
}
//OUTPUT
SampleClass上使用了特性MyCustom123Attribute
Class Name: SampleClass
Version: 0
Class Name: SampleClass1
Version: 0
Class Name1: SampleClass1111
Version1: 1
```

在这个例子中，我们定义了一个名为`MyCustomAttribute`的自定义特性，并在`SampleClass`上应用了这个特性。然后，通过反射的方式获取`SampleClass`上的特性，并输出特性的信息。

在实际应用中，特性可以用于各种场景，例如在ASP.NET MVC中用于标记控制器和动作方法，在Entity Framework中用于配置数据库映射，以及在测试框架中用于标记测试方法等等。

### 21.条件编译指令

在 C# 中，`#if` 和 `#endif` 是条件编译指令，用于在编译时根据条件选择性地包含或排除代码块。这些指令使得你能够根据在编译时定义的条件来控制代码的编译。

基本语法如下：

```csharp
#if condition
    // 如果条件为真，则编译此部分代码
#else
    // 如果条件为假，则编译此部分代码
#endif
```

- `#if`：用于开始一个条件编译块，后面跟着一个编译时的条件。
- `#else`：用于指定在条件为假时要编译的代码块。
- `#endif`：用于结束条件编译块。

常见的使用情景包括根据不同的平台、调试模式或其他条件来控制代码的编译。

例如，以下是一个简单的示例，演示如何使用条件编译来区分调试和发布模式：

```csharp
#define DEBUG

using System;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.WriteLine("Debug mode");
#else
        Console.WriteLine("Release mode");
#endif
    }
}
```

在这个示例中，`#define DEBUG` 表示定义了一个名为 `DEBUG` 的编译时符号。在 `#if DEBUG` 中的代码块只有在定义了 `DEBUG` 符号时才会被编译，否则将编译到 `#else` 中的代码块。在实际的项目中，这种技术经常用于在调试和发布版本之间切换一些代码行为或日志记录。

### 22.`yield`关键字

在C#中，`yield` 关键字通常与迭代器（iterator）一起使用，用于创建一个可枚举集合（enumerable collection）。`yield` 允许你在循环中逐个返回元素，而不需要在内存中保存整个集合。

具体来说，通过在方法中使用 `yield return` 语句，你可以按需生成集合的元素。当调用方通过迭代器请求下一个元素时，方法会在 `yield return` 处暂停执行，返回一个值给调用方，并保留当前的状态。下次调用方请求下一个元素时，方法会从暂停的地方继续执行，直到再次遇到 `yield return` 或者执行完毕。

下面是一个简单的示例，展示了 `yield` 的基本用法：

```csharp
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        foreach (var number in GenerateNumbers())
        {
            Console.WriteLine(number);
        }
    }

    static IEnumerable<int> GenerateNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            // 使用 yield return 逐个返回元素
            yield return i;
        }
    }
}
```

在上述示例中，`GenerateNumbers` 方法使用 `yield return` 逐个返回数字 1 到 5。在 `Main` 方法中，我们使用 `foreach` 循环遍历生成的集合，而不必将所有元素存储在内存中。

`yield` 的使用使得代码更加简洁，同时允许按需生成元素，从而提高性能和资源利用率。需要注意的是，`yield` 只能在返回类型为 `IEnumerable<T>`、`IEnumerator<T>`、`IEnumerable` 或 `IEnumerator` 的方法中使用。

23.`IEnumerable` 和 `IEnumerator` 

`IEnumerable` 和 `IEnumerator` 是 C# 中用于实现枚举（enumeration）的接口。它们是 .NET 中集合类的基础，提供了一种迭代集合元素的标准方法。

1. **IEnumerable 接口：**
   - `IEnumerable` 接口定义了一个方法 `GetEnumerator()`，该方法返回一个实现了 `IEnumerator` 接口的对象。
   - 该接口是集合类（如数组、列表、集合等）实现的基础接口，使得这些集合类可以被 `foreach` 循环遍历。

   ```csharp
   public interface IEnumerable
   {
       IEnumerator GetEnumerator();
   }
   ```

2. **IEnumerator 接口：**
   - `IEnumerator` 接口定义了在集合上进行迭代的标准方法。它包含两个主要成员：`MoveNext()` 和 `Current`。
     - `MoveNext()`：将指针移动到集合的下一个元素，如果存在下一个元素，则返回 `true`，否则返回 `false`。
     - `Current`：获取当前指针所在位置的元素。

   ```csharp
   public interface IEnumerator
   {
       bool MoveNext();
       object Current { get; }
       void Reset();
   }
   ```

   注意：在实际的代码中，通常会使用泛型版本的 `IEnumerable<T>` 和 `IEnumerator<T>`，其中 `T` 是集合中元素的类型，这样可以避免在使用时进行类型转换。

   ```csharp
   public interface IEnumerable<out T>
   {
       IEnumerator<T> GetEnumerator();
   }
   
   public interface IEnumerator<out T>
   {
       bool MoveNext();
       T Current { get; }
       void Reset();
   }
   ```

通过实现 `IEnumerable` 和 `IEnumerator` 接口，可以使集合类具备可枚举的特性，使得它们可以被 `foreach` 循环遍历，也可以使用 LINQ 查询语句等对其进行操作。这种模式在 C# 中广泛应用于集合的迭代和操作。

此外，为了更好地理解 `IEnumerator` 的工作原理，我们可以进一步说明其在 `foreach` 循环中的使用。`foreach` 循环实际上通过 `IEnumerator` 接口的实现来进行迭代。上述代码中的 `foreach` 循环可以被展开为以下伪代码：

```csharp
IEnumerable<int> numbers = GenerateNumbers();
IEnumerator<int> enumerator = numbers.GetEnumerator();

while (enumerator.MoveNext())
{
    int number = enumerator.Current;
    Console.WriteLine(number);
}
```

在这个伪代码中，首先通过 `GetEnumerator` 方法获取了一个 `IEnumerator<int>` 对象，然后通过 `MoveNext` 和 `Current` 属性来迭代集合中的元素。这展示了 `IEnumerator` 在背后的工作方式，以及为什么实现这个接口对于支持 `foreach` 循环是如此重要。

总体而言，`IEnumerable` 和 `IEnumerator` 接口是 C# 中实现集合迭代的核心机制，它们使得集合可以被统一地遍历和操作。

<details>
    <summary>实现IEnumerable和IEnumerator接口的例子</summary>
    <pre><code>
    class CustomCollection<T> : IEnumerable<T>
    {
        private T[] items;    
        public CustomCollection(T[] collection)
        {
            items = collection;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator(items);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class CustomEnumerator : IEnumerator<T>
        {
            private T[] items;
            private int currentIndex = -1;
            public CustomEnumerator(T[] collection)
            {
                items = collection;
            }
            public T Current
            {
                get { return items[currentIndex]; }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < items.Length;
            }
            public void Reset()
            {
                currentIndex = -1;
            }
            public void Dispose()
            {
                // 如果有需要，在这里进行资源的释放
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            var customCollection = new CustomCollection<int>(numbers);
            foreach (var number in customCollection)
            {
                Console.WriteLine(number);
            }
        }
    }
    </code></pre>
</details>

### 23.闭包

在C#中，闭包（closure）是指一个函数（或者方法）以及其相关的引用环境（外部变量）的组合。闭包允许函数访问其定义时所在的词法作用域中的变量，即使函数在其他地方执行也能访问这些变量。这使得在函数内部可以引用外部的变量，而不必把这些变量作为参数传递给函数。

在C#中，闭包通常涉及到匿名方法、Lambda 表达式或者委托。以下是一个简单的闭包的例子：

```csharp
class Program
{
    static void Main()
    {
        // 外部变量
        int externalVariable = 10;

        // 使用 Lambda 表达式创建闭包
        Action closure = () => 
        {
            // 在闭包中引用外部变量
            Console.WriteLine(externalVariable);
        };

        // 调用闭包
        closure(); // 输出：10

        // 修改外部变量
        externalVariable = 20;

        // 再次调用闭包
        closure(); // 输出：20
    }
}
```

在这个例子中，Lambda 表达式创建了一个闭包，其中引用了外部变量 `externalVariable`。即使在 Lambda 表达式被创建后，外部变量的值发生变化，闭包仍然能够访问并使用新的值。

闭包在异步编程、LINQ 查询、事件处理等场景中经常被使用，它能够简化代码并使得逻辑更加清晰。在使用闭包时，需要注意引用的外部变量的生命周期，以避免潜在的问题，比如在异步操作中，确保引用的外部变量是可预测的。

### 24.泛型约束

在C#中，泛型约束（Generic Constraints）是指在定义泛型类型或泛型方法时，对泛型参数施加的条件，以限制允许传递给泛型参数的类型。泛型约束可以分为主要约束（Primary Constraints）和次要约束（Secondary Constraints）。

1. **主要约束（Primary Constraints）：**
   主要约束指定了泛型参数必须满足的基本条件，其中包括：
   - **class约束：** 指定泛型参数必须是引用类型（类、接口、委托或数组），不能是值类型。使用 `where T : class` 来指定该约束。
   - **struct约束：** 指定泛型参数必须是值类型。使用 `where T : struct` 来指定该约束。
   - **new()约束：** 指定泛型参数必须具有无参的公共构造函数。使用 `where T : new()` 来指定该约束。

2. **次要约束（Secondary Constraints）：**
   次要约束是在主要约束的基础上，进一步对泛型参数施加的条件，以增加灵活性。次要约束包括：
   - **接口约束：** 指定泛型参数必须实现指定的接口。使用 `where T : 接口名` 来指定该约束。
   - **基类约束：** 指定泛型参数必须派生自指定的基类。使用 `where T : 基类名` 来指定该约束。
   - **其他类型约束：** 指定泛型参数必须是指定类型或其派生类。使用 `where T : 类型名` 来指定该约束。

下面是一个泛型方法的示例，展示了主要约束和次要约束的用法：
```csharp
public class Example
{
    public void GenericMethod<T>(T obj) where T : class, IComparable, new()
    {
        // 泛型参数必须满足class、IComparable和new()约束
        T newObj = new T(); // 调用泛型参数类型的无参构造函数
        // 对象必须实现IComparable接口
        int result = newObj.CompareTo(obj);
        // 其他逻辑...
    }
}
```
在这个示例中，`GenericMethod` 是一个泛型方法，它的泛型参数 `T` 必须满足class、IComparable和new()约束。这意味着 `T` 必须是引用类型、必须实现 `IComparable` 接口，而且必须具有无参的公共构造函数。

### 25.协变和逆变

在 C# 中，协变（Covariance）和逆变（Contravariance）是与泛型相关的概念，用于描述类型参数在继承关系中的行为。这两个概念主要与接口和委托相关，用于提高泛型的灵活性和可用性。

1. **协变（Covariance）：**
   - 协变指的是类型参数的子类型可以替代父类型，即可以向上转型。
   - 在 C# 中，协变通常发生在返回类型或接口的泛型参数中。
   - 用于标识协变的关键字是 `out`。

   例如：
   ```csharp
   interface IMyInterface<out T>
   {
       T GetItem();
   }
   ```
   在这个示例中，`IMyInterface` 接口中的泛型参数 `T` 声明为协变，表示可以将返回类型 `T` 替换为 `T` 的派生类型。

2. **逆变（Contravariance）：**
   - 逆变指的是类型参数的父类型可以替代子类型，即可以向下转型。
   - 在 C# 中，逆变通常发生在参数的泛型类型中。
   - 用于标识逆变的关键字是 `in`。

   例如：
   ```csharp
   interface IMyInterface<in T>
   {
       void AddItem(T item);
   }
   ```
   在这个示例中，`IMyInterface` 接口中的泛型参数 `T` 声明为逆变，表示可以将参数 `T` 替换为 `T` 的基类型。

协变和逆变提高了泛型类型的灵活性，允许派生类型和基类型在泛型类型参数中进行替换，从而使代码更具通用性和可复用性。然而，需要注意的是，协变和逆变只能应用于接口和委托，而不能应用于类。

16.`IEnumerable`和`IEnumerator`

在C#中，`IEnumerable` 和 `IEnumerator` 是用于遍历集合的接口，它们提供了一种统一的方式来访问集合中的元素，从而使得集合的实现可以被迭代器访问。

1. **`IEnumerable` 接口：**
   - `IEnumerable` 接口定义了一个单独的方法 `GetEnumerator()`，该方法返回一个实现了 `IEnumerator` 接口的迭代器对象。
   - 实现了 `IEnumerable` 接口的对象可以被 `foreach` 循环或 LINQ 查询等迭代器访问。
   - `IEnumerable` 接口只包含一个方法：
     ```csharp
     public interface IEnumerable
     {
         IEnumerator GetEnumerator();
     }
     ```

2. **`IEnumerator` 接口：**
   - `IEnumerator` 接口定义了用于在集合中移动的方法和属性，它允许逐个访问集合中的元素。
   - `IEnumerator` 接口包含以下成员：
     - `Current` 属性：获取集合中当前位置的元素。
     - `MoveNext()` 方法：将迭代器移到集合中的下一个元素。
     - `Reset()` 方法：将迭代器重置到集合的起始位置。
     - `Dispose()` 方法：释放迭代器占用的资源。
   - `IEnumerator` 接口通常用于实现迭代器模式，允许逐个访问集合中的元素。

通常情况下，使用 `foreach` 循环遍历集合时，编译器会自动调用 `IEnumerable` 接口中的 `GetEnumerator()` 方法获取一个迭代器，然后使用 `IEnumerator` 接口中的方法和属性来逐个访问集合中的元素。

例如：
```csharp
IEnumerable collection = GetCollection(); // 返回一个实现了 IEnumerable 接口的集合
IEnumerator enumerator = collection.GetEnumerator(); // 获取迭代器
while (enumerator.MoveNext()) // 遍历集合中的元素
{
    object element = enumerator.Current; // 获取当前元素
    // 处理当前元素...
}
```

总的来说，`IEnumerable` 接口表示一个可以枚举的集合，而 `IEnumerator` 接口表示在集合中进行迭代的迭代器。这两个接口结合在一起，提供了一种统一的方式来访问集合中的元素。

### 26.内存存储区

在计算机内存管理中，通常将内存分为以下几个区域：

1. **栈（Stack）**：
   - 栈是一种自动分配和释放内存的区域，用于存储函数的局部变量、函数参数、返回地址等。
   - 栈内存的分配和释放由编译器自动生成的代码来管理，栈内存的分配和释放操作非常高效。
   - 栈内存的生命周期与函数调用的生命周期相同，函数返回时栈上的局部变量会被自动释放。

2. **堆（Heap）**：
   - 堆是一种动态分配和释放内存的区域，通常用于存储动态分配的对象和数据结构。
   - 堆内存的分配和释放由程序员手动管理，需要通过特定的内存分配函数（如 `malloc`、`new` 等）来申请堆内存，并通过相应的释放函数（如 `free`、`delete` 等）来释放已分配的堆内存。
   - 堆内存的分配和释放效率较低，因为需要考虑内存分配的连续性和内存泄漏的问题。

3. **全局/静态区（Global/Static Area）**：
   - 全局/静态区是用于存储全局变量、静态变量和常量的区域，这些变量在程序的整个生命周期内存在。
   - 全局/静态区的内存分配在程序启动时完成，内存释放在程序结束时完成。

4. **常量区（Constant Area）**：
   - 常量区是用于存储字符串常量和其他不可变常量的区域。
   - 常量区的内存分配在程序编译时完成，这些常量的值在程序运行期间不可修改。

5. **代码区（Code Area）**：
   - 代码区是用于存储程序的执行代码的区域，也称为文本区或代码段。
   - 代码区的内存分配在程序加载到内存时完成，其中包含了程序的机器指令。

### 27.设计模式的使用场景

设计模式是针对软件设计中常见问题的解决方案，可以帮助开发人员更有效地设计和实现软件系统。设计模式通常分为三类：创建型模式（Creational Patterns）、结构型模式（Structural Patterns）和行为型模式（Behavioral Patterns）。不同的设计模式适用于不同的场景和问题，以下是它们的使用时机：

1. **创建型模式（Creational Patterns）：**
   
   - 创建型模式用于处理对象的创建过程，目标是尽可能地灵活、可扩展和解耦对象的创建和初始化过程。
   - 适用于在创建对象时需要灵活选择创建方式、隐藏对象的创建逻辑、减少耦合度等场景。
   - 典型的创建型模式包括工厂方法模式、抽象工厂模式、建造者模式、原型模式和单例模式。
   
   **使用时机：** 
   - 当需要灵活地实例化对象，并且希望将对象的创建逻辑与使用者解耦时。
   - 当需要控制对象的创建过程、隐藏创建细节或者实现对象的复用时。
   - 当需要确保系统中某个类只有一个实例时，可以考虑使用单例模式。
   
2. **结构型模式（Structural Patterns）：**
   - 结构型模式用于描述如何将类或对象组合成更大的结构，以解决系统中的子系统之间的关系和依赖问题。
   - 适用于改善现有系统的结构，提高系统的灵活性和可扩展性，减少系统的耦合度。
   - 典型的结构型模式包括适配器模式、桥接模式、组合模式、装饰器模式、外观模式、享元模式和代理模式。

   **使用时机：**
   - 当需要将一个系统中的类或对象组织成更大的结构，并且希望结构中的各个部分能够独立地变化时。
   - 当需要将接口与实现分离、减少类之间的耦合度或者实现系统的复用时。
   - 当需要对现有对象的行为进行扩展或修改时，可以考虑使用装饰器模式。

3. **行为型模式（Behavioral Patterns）：**
   - 行为型模式用于描述对象之间的通信模式，以及如何分配职责和行为。
   - 适用于解决对象之间的通信和协作问题，提高系统的灵活性和可维护性，降低系统的耦合度。
   - 典型的行为型模式包括责任链模式、命令模式、解释器模式、迭代器模式、中介者模式、备忘录模式、观察者模式、状态模式、策略模式、模板方法模式和访问者模式。

   **使用时机：**
   - 当需要在对象之间建立灵活的通信机制，并且希望对象之间的耦合度较低时。
   - 当需要实现对象之间的复杂协作、分配职责和行为、或者对系统的状态和行为进行封装时。
   - 当需要在不同的对象之间实现相同的行为，但又希望行为能够根据对象的状态和类型而变化时，可以考虑使用策略模式或状态模式。

总的来说，设计模式是一种通用的解决方案，可以帮助开发人员更好地组织和管理软件系统，提高系统的可维护性、可扩展性和可重用性。选择合适的设计模式需要根据具体的需求和问题场景来决定，以便最大程度地发挥设计模式的优势。

### 28.Socket编程

C#中的Socket编程是指使用Socket类来实现网络通信。Socket类提供了一种在应用程序之间进行通信的方法，它允许在网络上发送和接收数据。下面是一个简单的示例，演示了如何使用C#进行Socket编程：

```csharp
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        // 设置服务器的IP地址和端口号
        string serverIP = "127.0.0.1";
        int port = 8888;

        try
        {
            // 创建Socket对象
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 连接到服务器
            clientSocket.Connect(serverIP, port);
            Console.WriteLine("连接到服务器成功！");

            // 发送数据到服务器
            string messageToSend = "Hello from client!";
            byte[] dataToSend = Encoding.ASCII.GetBytes(messageToSend);
            clientSocket.Send(dataToSend);

            // 接收来自服务器的数据
            byte[] dataReceived = new byte[1024];
            int bytesReceived = clientSocket.Receive(dataReceived);
            string messageReceived = Encoding.ASCII.GetString(dataReceived, 0, bytesReceived);
            Console.WriteLine("服务器返回消息: " + messageReceived);

            // 关闭Socket连接
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("发生异常: " + ex.Message);
        }
    }
}
```

在这个示例中，我们创建了一个客户端Socket，并连接到指定的服务器IP地址和端口号。然后，我们发送一个字符串消息到服务器，并等待服务器的响应。一旦收到服务器的响应，我们将其打印出来，并关闭Socket连接。

在实际应用中，服务器端代码类似，但会监听指定端口并接受来自客户端的连接请求。然后，服务器会处理客户端发送的数据，并返回相应的结果。

需要注意的是，在实际应用中，Socket编程可能会涉及到更多的异常处理、数据格式化和网络安全等方面的考虑。此外，还可以考虑使用异步操作（如`BeginConnect`、`BeginSend`、`BeginReceive`等方法）来提高性能和响应能力。

### 29.网络通信

在 C# 中，`HttpClient`、`HttpListener` 和 `Socket` 都是用于进行网络通信的类，但它们在功能和使用方式上有所不同，适用于不同的场景：

1. **HttpClient**：
   - `HttpClient` 是一个用于发送 HTTP 请求和接收 HTTP 响应的高级类。它是基于 HTTP 协议的高级抽象，适用于与 Web 服务器进行通信。
   - `HttpClient` 提供了异步的方法来发送请求，并自动处理了一些与 HTTP 相关的细节，如连接管理、请求头的处理、响应解析等。
   - 适用于通过 HTTP 协议与远程 Web 服务进行通信，如调用 RESTful API、下载文件等。

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://example.com");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
```

2. **HttpListener**：
   - `HttpListener` 是一个用于创建 HTTP 服务器的类。它可以监听指定的端口，并接受来自客户端的 HTTP 请求。
   - `HttpListener` 允许你编写自定义的 HTTP 服务器，处理来自客户端的请求，并返回相应的响应。
   - 适用于创建自定义的 HTTP 服务器，如 Web API、Webhook 等。

```csharp
using System;
using System.Net;

class Program
{
    static void Main()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Listening...");
        
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string responseString = "<html><body>Hello World!</body></html>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
        
        listener.Stop();
    }
}
```

3. **Socket**：
   - `Socket` 是一个底层的通用网络通信类，支持多种网络协议（如 TCP、UDP）。它可以用于创建各种类型的网络连接，包括 HTTP 连接。
   - `Socket` 提供了更底层、更灵活的 API，可以完全控制数据的发送和接收过程，适用于实现自定义的网络通信协议。
   - 适用于实现更复杂的网络通信需求，如实时数据传输、自定义协议的实现等。

```csharp
using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        byte[] bytes = new byte[1024];

        IPHostEntry host = Dns.GetHostEntry("www.example.com");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, 80);

        Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes("GET / HTTP/1.1\r\nHost: www.example.com\r\n\r\n");
            sender.Send(requestBytes);

            int bytesReceived = sender.Receive(bytes);
            Console.WriteLine("Response from server: ");
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(bytes, 0, bytesReceived));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred: " + ex.Message);
        }
    }
}
```

总结：
- `HttpClient` 适用于向远程 Web 服务发送 HTTP 请求。
- `HttpListener` 适用于创建自定义的 HTTP 服务器，处理客户端的请求。
- `Socket` 提供了更底层、更灵活的 API，适用于实现自定义的网络通信协议。
