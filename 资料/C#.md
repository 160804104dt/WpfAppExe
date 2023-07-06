# C#

## 一、数组

数组的声明：

```c#
int[] a1 = new int[10];//一维数组
int[,] a2 = new int[10, 5];//二维
int[,,] a3 = new int[10, 5, 2];//三维
```

多维数组中可以声明不同长度的数组

```c#
int[][] a = new int[3][];
a[0] = new int[10];//第一行10列
a[1] = new int[5];//第二行5列
a[2] = new int[20];//第三行2列
```

## 二、字符串内插

可以自己定义字符串的表达格式：

```c#
Console.WriteLine($"The low and high temperature on {weatherData.Date:MM-DD-YYYY}");
Console.WriteLine($"    was {weatherData.LowTemp} and {weatherData.HighTemp}.");
// Output (similar to):
// The low and high temperature on 08-11-2020
//     was 5 and 30.
```

 内插字符串通过 `$` 标记来声明。 字符串插内插计算 `{` 和 `}` 之间的表达式，然后将结果转换为 `string`，并将括号内的文本替换为表达式的字符串结果。 第一个表达式 (`{weatherData.Date:MM-DD-YYYY}`) 中的 `:` 指定格式字符串。 在前一个示例中，这指定日期应以“MM-DD-YYYY”格式显示。 

## 三、委托

```c#
#region 委托,使用委托时可以直接用，也可以用invoke方法
        /// <summary>
        /// 显式委托的定义: delegate 返回类型 委托名称(参数1,参数2......)
        /// 具体使用时，需要传入一个函数(或者委托)作为参数
        /// 匿名委托不用定义委托的名称
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        //委托定义
        delegate string delegate1(int a, int b);
        //具体调用函数
        private string d1Func(int a, int b)
        {
            return (a + b).ToString();
        }
        //Func委托
        Func<int, int, string> f1 = new Func<int, int, string>((int a, int b) =>
        {
            return (a + b).ToString();
        });

        /// <summary>
        /// 匿名委托，没有传入具体的函数或者委托
        /// </summary>
        delegate1 d1NoName = delegate (int a, int b) { return (a + b).ToString(); };
        /// <summary>
        /// lambda表达式创建委托变量
        /// </summary>
        delegate1 d1Lambda = (a, b) => { return (a + b).ToString(); };

        /// <summary>
        /// 无参数，无返回值的委托
        /// </summary>
        delegate void delegate2();
        private void d2Func()
        {
            Console.WriteLine("12345");
        }

        Action a1 = () =>
        {
            Console.WriteLine("12345");
        };

        #region Action委托 Action委托没有返回类型
        //几种定义方式
        /// <summary>
        /// 显式定义
        /// </summary>
        Action action1 = new Action(() =>
        {
            Console.WriteLine(3);
        });

        //lambda表达式定义（只有一行时，括号可以省略）
        Action action2 = () =>
        {
            Console.WriteLine(3);
        };
        Action action3 = () => Console.WriteLine(3);

        /// <summary>
        /// 有参数的定义
        /// </summary>
        Action<int, int> action4 = new Action<int, int>((a, b) =>
        {
            Console.WriteLine(a+b);
        });

        Action<int, int> action5 = (a, b) => Console.WriteLine(a + b);
        #endregion

        #region Func委托 Func委托有返回类型
        #endregion

 #endregion
```



### 2、协变，逆变

子类向父类转变是协变，父类向子类转化是逆变

协变对应修饰符是out，逆变对应修饰符是in

用in和ref修饰参数时，使用前必须要赋值，使用out修饰，可以不用赋值



## 四、lambda表达式

### 形式

lambda表达式用来创建匿名函数，有两种形式：

- 表达式lambda，表达式为主体

```C#
(input-parameters) => expression
```

- 语句lambda，语句块为主体

```c#
(input-parameters) => { <sequence-of-statements> }
```

### lambda表达式的输入参数

1.使用空括号指定没有参数

2.一个参数时，括号可以省略

3.多个参数之间用逗号分开

4.可以显示参数类型

5.当多个参数不在表达式中用到时，可以使用弃元方法，使用_代替

6.如果只有一个参数时，且命名为_，那么在表达式中会视为该参数的名称



## 五、LINQ（语言集成查询）

类似于数据库查询语句

**所有LINQ查询操作都由以下三个不同的操作组成：**

1.获取数据源

2.创建查询

3.执行查询

查询的执行不同于查询本身，换句话说，仅通过创建查询变量不会检索到任何数据

**延迟执行：**

查询变量本身只存储查询命令，查询的实际执行将推迟到在foreach语句中循环访问查询变量后进行，此概念称为延迟执行

**强制执行：**

执行聚合函数的查询必须访问这些元素，比如Count，Max，Average，First等，由于本身必须使用foreach以便返回结果，这类查询不需要使用显示foreach语句。

```c#
public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

			IEnumerable<Student> EnumStudents =
                              from student in students
                              select student;
            foreach (var student in EnumStudents)
                Console.WriteLine(student.First);

            //排序
            IEnumerable<Student> OrderStudents =
                              from student in students
                              orderby student.First
                              select student;
            foreach (var student in OrderStudents)
                Console.WriteLine(student.First);

            //分组，这里是将Last的第一个字母作为分组条件
            var studentQuery2 =
                        from student in students
                        group student by student.Last[0];

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }
			//使用let，可以提高性能
			var studentQuery6 =
                            from student in students
                            let totalScore = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                            select totalScore;
            foreach (var TotalScore in studentQuery6)
                Console.WriteLine(TotalScore);
                /*
                330
                289
                338
                353
                268
                369
                352
                343
                327
                341
                332
                368
                */
            //平均分
            Console.WriteLine(studentQuery6.Average());

			//当查询生成的元素与源序列不一致时，需要注意以下，比如现在需要First数据，但是源序列中元素是student，所以下面的遍历的元素就不是student
			IEnumerable<string> studentQuery7 =
                                        from student in students
                                        where student.Last == "Garcia"
                                        select student.First;

            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            // Output:
            // The Garcias in the class are:
            // Cesar
            // Debra
            // Hugo

顺序：from in
     where,orderby...
     select
```

![1644043055349](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1644043055349.png)最后一个分组的结果左图



```c#
var list1 = data.FindAll(x=>x.Age>46);
var list2 = data.Where(x => x.Age > 46).ToList();
var list3 = data.Select(x => x.Age).ToList();//选择对象中的某个属性
var bool1 = data.All(x => x.Age > 46);//返回bool值
var bool2 = data.Any(x => x.Age > 46);
var list6 = data.GroupBy(x => x.Age).ToDictionary(x => x.Key, x => x.ToList());
var item = data.Find(x => x.Age > 46);//找到第一个符合条件的
var list8 = data.Union(data).ToList();//取交集
var list9 = data.OrderBy(x => x.Age).ToList();//根据年龄排序
```





## 六、Async 和 Await 的异步编程

```c#
	#region 普通线程池
    /*for(int i = 1; i <= 10; i++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
                    {
                        Console.WriteLine($"第{obj}个执行任务");
                    }),i);
                }
                */
    #endregion

    #region 无返回值的Task不会阻塞主线程
    //1.new方式实例化一个Task，需要通过Start方法启动
    /*Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello,task1的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });
            task.Start();
            //2.Task.Factory.StartNew(Action action)创建和启动一个Task
            Task task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello,task2的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });
            //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
            Task task3 = Task.Run(() => 
            {
                Thread.Sleep(100);
                Console.WriteLine($"hello,task3的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("执行主线程！");*/
    #endregion

    #region 有result的Task会阻塞主线程
    //task.result会阻塞线程，会等待获取到result，再执行后边的代码

    //Task<string> task4 = new Task<string>(() =>
    //{
    //    return $"hello,task4的线程ID为{Thread.CurrentThread.ManagedThreadId}";
    //});
    //task4.Start();
    //Task<string> task5 = new Task<string>(() =>
    //{
    //    return $"hello,task5的线程ID为{Thread.CurrentThread.ManagedThreadId}";
    //});
    //task5.Start();
    //Task<string> task6 = new Task<string>(() =>
    //{
    //    return $"hello,task6的线程ID为{Thread.CurrentThread.ManagedThreadId}";
    //});
    //task6.Start();
    //Console.WriteLine("执行主线程");
    //Console.WriteLine(task4.Result);
    //Console.WriteLine(task5.Result);
    //Console.WriteLine(task6.Result);
    //Task.WaitAll(new Task[] { task4, task5,task6 });
    #endregion

    #region wait方法会阻塞主线程 WaitAll，WaitAny
    /* Task task7 = new Task(() =>
            {
                Console.WriteLine("執行Task7結束");
            });
            Task task8 = new Task(() =>
            {
                Console.WriteLine("執行Task8結束");
            });
            Task task9 = new Task(() =>
            {
                Console.WriteLine("執行Task9結束");
            });
            Task task10 = new Task(() =>
            {
                Console.WriteLine("執行Task10結束");
            });
            Task task11 = new Task(() =>
            {
                Console.WriteLine("執行Task11結束");
            });
            Task task12 = new Task(() =>
            {
                Console.WriteLine("執行Task12結束");
            });
            Task task13 = new Task(() =>
            {
                Console.WriteLine("執行Task13結束");
            });
            Task task14 = new Task(() =>
            {
                Console.WriteLine("執行Task14結束");
            });
            task7.Start();
            task8.Start();
            task9.Start();
            task10.Start();
            task11.Start();
            task12.Start();
            task13.Start();
            task14.Start();
            Task.WaitAny(new Task[] { task7, task8, task9, task10, task11, task12, task13, task14 });
            Console.WriteLine("執行主綫程結束！");*/
    #endregion

    #region When方法不会阻塞主线程 WhenAll，WhenAny
    /*Task task15 = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("执行Task15结束");
            });

            Task task16 = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("执行Task16结束");
            });
            Task task17 = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("执行Task17结束");
            });

            Task task18 = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("执行Task18结束");
            });
            task15.Start();
            task16.Start();
            task17.Start();
            task18.Start();
            Task.WhenAny(task15, task16, task17, task18).ContinueWith(x =>
            {
                Console.WriteLine("执行后续操作完毕");
            });
            Console.WriteLine("执行主线程完毕！");*/
    #endregion

    #region Task取消任务执行:CancellationTokenSource 
        /*CancellationTokenSource source1 = new CancellationTokenSource();
            int index = 0;
            Task task19 = new Task(() => 
            {
                while (!source1.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"第{++index}次执行，线程运行中。。。");
                }
            });
            task19.Start();
            Thread.Sleep(5000);
            source1.Cancel();
            Console.WriteLine(source1.IsCancellationRequested);*/
        #endregion

        #region Task取消执行后的操作,搭配CancelAfter方法使用
        /*CancellationTokenSource source2 = new CancellationTokenSource();
            source2.Token.Register(() => {
                Console.WriteLine("任务被取消后执行的操作！");
            });
            int index2 = 0;
            Task task20 = new Task(() => {
                while (!source2.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"第{++index2}次执行，线程运行中。。。");
                }
            });
            task20.Start();
            source2.CancelAfter(5000);*/
        #endregion

        Console.ReadKey();
```





## 七、虚函数

## 八、new关键字

new关键字的三种用法：

1、创建新的对象和调用构造函数

2、显式隐藏父类的对象或者方法，就是在子类中定义一个和父类变量名称相同的变量；

3、

## 九、正则表达式

### 1、语法

**+**：前面的字符至少出现一次

eg： rb+c 可以匹配rbc，rbbc,rbbbbc等

*****：前面字符可以出现0,1，n次

eg： rb*c 可以匹配rc，rbc，rbbc等

**？**：前面字符最多出现一次（0或1次）

eg：rb?c 可以匹配rc，rbc

**^** ：两种应用方式：

在条件里是不包含的意思，比如 [ ^abc ]会匹配所有除了abc的字符串

在表达式开头意思是从被匹配的字符串开头开始匹配

**-** ：表示一个区间，比如[ a-z ]，[ A-Z ]，[0-9]

**\w**：匹配字母数字下划线，相当于[ A-Za-Z0-9 ]

**\W**：相当于^\w



## 十、面向对象六大原则

### 1.单一职责原则

一个类只负责一个功能领域中的相应职责，或者可以定义为：就一个类而言，应该只有一个引起它变化的原因

单一职责原则是实现高内聚，低耦合的指导方针。



### 2.开闭原则

一个软件实体应该对扩展开放，对修改关闭；一个软件实体尽量在不修改源代码的情况下进行对外扩展；

需要对系统进行抽象化设计，抽象化是开闭原则的关键；可以为系统定义一个相对稳定的抽象层，将不同的实现行为移至具体的实现层中完成

开闭原则是面向对象设计的目标

### 3.里氏替换原则

所有引用基类的地方必须能够透明的使用其子类的对象；

如果把基类对象替换成它的子类对象，程序将不会产生任何错误和异常，反过来责不成立：如果使用的是一个子类对象的话，不一定能够使用基类对象；

里氏替换原则是实现开闭原则的重要方式之一，使用基类对象的地方都可以使用子类对象，因此在程序中尽量使用基类类型来对对象进行定义，在运行时再确定其子类类型，用子类对象来替换父类对象

在使用里氏替换原则时需注意如下几个问题：

（1）子类的所有方法必须在父类中声明(子类必须实现父类中声明的所有方法)

（2）尽量把父类设计成抽象类或者接口

### 4.依赖倒置原则

抽象不应该依赖于细节，细节应该依赖于抽象，换言之，要面向接口编程，而不是针对实现编程

高层模块不应该依赖于低层模块，二者都应该依赖其抽象

依赖导致原则基于这样的设计理念：相对于细节的多变性，抽象的东西要稳定的多，以抽象为基础搭建的架构比以细节为基础的架构要稳定的多；

举例：

依赖倒置的三种注入方法：

（1）构造函数注入，在实现类的构造函数中声明依赖对象

（2）Setter方式注入，通过Setter方法声明依赖对象

（3）接口注入，在接口方法中声明依赖对象

### 5.接口隔离原则

使用多个专门的接口，而不应该使用单一的总接口，即客户端不应该依赖那些不需要的接口;

在使用接口隔离原则时，我们需要注意控制接口的粒度，接口不能太小，如果太小会导致接口泛滥，不利于维护，接口也不能太大，太大会违背接口隔离原则，使用起来不方便。

### 6.迪米特法则

一个软件实体应当尽可能的少与其他实体发生相互作用

迪米特法则又称最少知识原则



## 十一、设计模式（Design Pattern）

设计模式是一套被反复使用的，多数人知晓的，经过分类编目的，代码设计经验的总结。

三大类:

创建性模式：对象实例化的模式，创建型模式用于解耦对象的实例化过程。

结构型模式：把类或对象结合在一起形成一个更大的结构。

行为型模式：类和对象如何交互，及划分责任和算法。



## 十二、多线程

c#中的线程类是Thread，有4个重载的构造函数

```c#
public Thread(ParameterizedThreadStart start);
public Thread(ThreadStart start);
public Thread(ParameterizedThreadStart start, int maxStackSize);
public Thread(ThreadStart start, int maxStackSize);
```

| 名称                                                     | 说明                                                         |
| -------------------------------------------------------- | ------------------------------------------------------------ |
| Thread(ParameterizedThreadStart start)                   | 初始化 Thread 类的新实例，指定允许对象在线程启动时传递给线程的委托。要执行的方法是有参的 |
| Thread(ThreadStart start)                                | 初始化 Thread 类的新实例。要执行的方法是无参的。             |
| Thread(ParameterizedThreadStart start, int maxStackSize) | 初始化 Thread 类的新实例，指定允许对象在线程启动时传递给线程的委托，并指定线程的最大堆栈大小 |
| Thread(ThreadStart start, int maxStackSize)              | 初始化 Thread 类的新实例，指定线程的最大堆栈大小。           |

前台线程和后台线程：

前台线程：所有的前台线程都结束，应用程序才能结束。是默认情况下创建的线程都是前台线程

后台线程：只要所有的前台线程结束，后台线程自动结束；通过Thread.IsBackground设置后台线程；必须在调用Start方法之前设置线程的类型，否则一旦线程运行，将无法改变其类型

通过BeginXXX方法运行的线程都是后台线程

## 十三、泛型

泛型是为了解决代码重用的问题而提出的

泛型和object的区别是：

泛型避免了拆箱装箱，在性能上提高了不少

在处理引用类型时，避免了强制类型转换

## 十四、排序算法

1、冒泡排序

2、选择排序

3、快速排序

4、
