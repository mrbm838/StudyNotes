---
created: 2023-02-12T21:32:34 (UTC +08:00)
tags: [c# 内部类]
source: https://blog.csdn.net/GuiCiTianXie/article/details/81018074
author: 
---

# (3条消息) 【转载】C# 内部类_GuiCiTianXie的博客-CSDN博客_c# 内部类

> ## Excerpt
> C#语言有很多值得学习的地方，这里我们主要介绍C#内部类，包括介绍instance方法和private方法等方面。C#内部类能够使用外部类定义的类型和静态方法，但是不能直接使用外部类的实例方法，直接看来，外部类对于内部类的作用更像是一个命名空间，在C#中，始终可以用（只要访问控制允许）Sys.Model.Key key = new Model.Key()；来创建一个内部类的实例，这个实例与外部类的...

---
### C#语言有很多值得学习的地方，这里我们主要介绍C#内部类，包括介绍instance方法和private方法等方面。

C#内部类能够使用外部类定义的类型和静态方法，但是不能直接使用外部类的实例方法，直接看来，外部类对于内部类的作用更像是一个命名空间，在C#中，始终可以用（只要访问控制允许）

Sys.Model.Key key = new Model.Key()；

来创建一个内部类的实例，这个实例与外部类的任何实例没有任何直接的关系。类似于Java中的静态内部类。

在C#中，类区分为Nested Class和Not-Nested Class，前者是声明在其他数据类型内部的类。后者是直接定义在某一个命名空间的类。

非内嵌类只允许使用public和internal的访问控制，而内置类则允许使用所有的五种访问控制符

(1)private; (2) protected; (3) internal; (4)protected; (5)public

内部类也可以访问外部类的所有方法，包括instance方法和private方法，但是需要显式的传递一个外部类的实例。

创建内部类的一个目的是为了抽象外部类的某一状态下的行为，或者C#内部类仅在外部类的某一特定上下文存在。或是隐藏实现，通过将内部类设为private，可以设置仅有外部类可以访问该类。内部类的另外一个重要的用途是当外部类需要作为某个特定的类工作，而外部类已经继承与另外一个类的时候，因为C#不支持多继承，所以创建一个对应的内部类作为外部类的一个facecade来使用。

二：

使用内部类有这样几个好处：  
（1）抽象外部类的某一状态下的行为，隐藏实现，通过修改该内的访问修饰符，可以设置仅有外部类可以访问该类。  
（2）扩展了命名空间，可以将外部类的类名作为内部类的一个命名空间(这里只是相当于，但不是真正的命名空间)。  
（3）内部类可以当作外部类的一个扩展，可以活的更好的封装。  
上面的这些特点胡乱的总结了一下，可能有些词不达意，下面有些具体例子：  
1.内部类的定义:  
嵌套类：在一个类中定义另外一个类，主要分为静态嵌套类和非静态嵌套类(又称之为"内部类")。内部类的定义结构：  
(1)在一个类中直接定义类。  
(2)在一个方法中定义类。  
(3)匿名内部类。

2.外部类访问内部类  
外部类访问内部类 例子    
 namespace GameStatistical.Test.InnerClass    
 {    
     public class Person    
     {    
         public class Student    
         {    
             public static int age;    
             internal static int height;    
             private static string sex;  

               public virtual void Show()    
            {    
                 Console.WriteLine("年龄:"+age);    
                 Console.WriteLine("身高:"+height);    
             }  

                 internal void Display()    
            {    
                 Console.WriteLine("internal");    
                Console.WriteLine("年龄:" + age);    
                 Console.WriteLine("身高:" + height);    
             }    
         }  

             public void Show()    
         {    
             Student.age = 21;    
             Student.height = 75;    
             Student student = new Student();    
             student.Show();    
         }    
     }    
 }   
该段代码定义了一个外部类Person 和一个内部类Student， 其中内部类Student中使用了各种修饰符修饰的变量和方法，从上面的例子可以看出外部类只能够访问嵌套类中修饰符为public、internal的字段、方法、属性。调用外部类的 Show（）方法运行得到如下结果：

3.内部类访问外部类

内部类访问外部类 例子    
 namespace GameStatistical.Test.InnerClass    
 {    
     public class Person1    
     {    
         private string name;  

             public string Name    
         {    
             get { return name; }    
             set { name = value; }    
         }    
         private string sex;  

             public string Sex    
         {    
             get { return sex; }    
             set { sex = value; }    
         }  

             public void Show1()    
         {    
             Console.WriteLine(this.name + "==>" + this.sex);    
         }  

             private static void Show2()    
         {    
             Console.WriteLine("===================>");    
         }  

            internal void Show3()    
         {    
             Console.WriteLine(this.name + "==>" + this.sex);    
         }  

                     public class Student    
         {    
             public void SetPer(string name, string sex)    
             {    
                 Person1 p = new Person1();    
                 p.name = name;    
                 p.sex = sex;  

                     p.Show3();    
                 p.Show1();    
             }  

             }    
     }    
 }   
这段代码同样定义了一个外部类Person1 和一个内部类Student,内部类中的SetPer（）调用了外部类中的方法，写这段代码我们可以发现 嵌套类可以访问外部类的方法、属性、字段而不受访问修饰符的限制

4.内部类的继承

内部类继承例子1  

 namespace GameStatistical.Test.InnerClass    
 {    
     public class Person    
     {    
         public class Student    
         {    
             public static int age;    
             internal static int height;    
             private static string sex;  

                 public virtual void Show()    
             {    
                 Console.WriteLine("年龄:"+age);    
                 Console.WriteLine("身高:"+height);    
             }  

                 internal void Display()    
             {    
                 Console.WriteLine("internal");    
                 Console.WriteLine("年龄:" + age);    
                 Console.WriteLine("身高:" + height);    
             }    
         }  

                 public void Show()    
         {    
             Student.age = 21;    
             Student.height = 75;    
             Student student = new Student();    
             student.Show();    
             student.Display();    
         }    
     }    
 }   
内部类继承，上面的内部类定义了父类，其中public virtual void Show() 使用virtual 修饰，可以用于子类重写这个方法，看内部类继承子类是否能够重写这个方法。

内部类继承例子2    
 namespace GameStatistical.Test.InnerClass    
 {    
     public class SubPerson:Person    
     {    
         public class SubStudent : Student    
         {    
             public override void Show()    
             {    
                 base.Show();    
             }    
         }    
     }    
 }   
上面的代码重写了Show() 这个方法，说明内部类的继承可以通过

5.反射内部类

对于这段代码，是从其他网站看到的，反射内部类我们不能直接通过 "." 操作符直接来操作，而是通过 "+" 操作符。前面也提到过内部类也是一种有效的管理命名空间的方法，这里也是普通类和内部类的一点区别：

反射内部类

Activator.CreateInstance("GameStatistical.Test.InnerClass","GameStatistical.Test.InnerClass.ReflectionPerson+Student");

反射普通类

Activator.CreateInstance("GameStatistical.Test.InnerClass", "GameStatistical.Test.InnerClass.ReflectionPerson.Student");

   在实际操作中，内部类好像使用的比较少，这里也只是非常简单的介绍，作为一个知识点总结起来。
