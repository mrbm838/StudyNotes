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

out的执行方式与ref一样，区别在于：out让方法返回多个值，且可以使用未赋值的变量，但必须在方法内赋值，执行失败时，使用其修饰的变量的值会丢失，重新赋值为0。

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
3. 调用对象的构造函数（意味着构造函数的访问修饰符必须为public）

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

String对象在声明之后在内存中的大小是不可修改的，每次操作字符串对象时，都会在堆中开辟新空间，故重复多次操作字符串时会产生很大的系统开销。System.Text.StringBuilder类对象则只在一个内存空间上操作，且可自由扩展大小，因此提升性能。

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
   1. 在父类中创建一个无参构造函数
   2. 在子类构造函数后使用`base()`显示调用父类构造函数
4. ==在子类中，通过`base`只能调用父类的公有和保护的实例成员==。
5. 继承的特性
   1. 单根性
   2. 传递性：可以继承父类的父类

##### 3.`new`关键字

1. 创建对象
2. 在子类中，隐藏从父类继承来的同名函数。（不用new效果一样）

##### 4.`this`键字

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

##### 2.StreamWriter\StreamReader是操作字符的，适合操作小文件

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

多态指一个对象能够表现出多种的状态。

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

序列化：将对象转换为二进制

反序列化：将二进制转换为对象

作用：用于传输数据

```C#
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
```

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

1. 二进制和十六进制的表示

   ```C#
   int binary = 0b10;
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
   int digital = Convert.ToInt32(strhex, 16);
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
string temp = null;
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

##### 11.C# 中的delegate、event、Action、Func

[C# 中的delegate、event、Action、Func_|刘钊|的博客-CSDN博客](https://blog.csdn.net/weixin_40200876/article/details/89335598)

==可以通过`action()`或者`action.Invoke()`两种方式调用方法。==

##### 11.线程同步

[C# EventWaitHandle类解析 - 冬音 - 博客园 (cnblogs.com)](https://www.cnblogs.com/wintertone/p/11657334.html)

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

##### 22.根据类名获取类和方法

[C#-反射-根据传入的类名，方法名，执行此方法，或者反射赋值给委托_HOLD ON!的博客-CSDN博客](https://blog.csdn.net/cxu123321/article/details/107711209)

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

