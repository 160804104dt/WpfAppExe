### C#

#### 一、数组

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

#### 二、字符串内插

可以自己定义字符串的表达格式：

```c#
Console.WriteLine($"The low and high temperature on {weatherData.Date:MM-DD-YYYY}");
Console.WriteLine($"    was {weatherData.LowTemp} and {weatherData.HighTemp}.");
// Output (similar to):
// The low and high temperature on 08-11-2020
//     was 5 and 30.
```

 内插字符串通过 `$` 标记来声明。 字符串插内插计算 `{` 和 `}` 之间的表达式，然后将结果转换为 `string`，并将括号内的文本替换为表达式的字符串结果。 第一个表达式 (`{weatherData.Date:MM-DD-YYYY}`) 中的 `:` 指定格式字符串。 在前一个示例中，这指定日期应以“MM-DD-YYYY”格式显示。 

#### 三、委托

委托本质上是一个类，是一个引用类型，是对方法的引用

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



#### 四、lambda表达式

##### 形式

lambda表达式用来创建匿名函数，有两种形式：

- 表达式lambda，表达式为主体

```C#
(input-parameters) => expression
```

- 语句lambda，语句块为主体

```c#
(input-parameters) => { <sequence-of-statements> }
```

##### lambda表达式的输入参数

1.使用空括号指定没有参数

2.一个参数时，括号可以省略

3.多个参数之间用逗号分开

4.可以显示参数类型

5.当多个参数不在表达式中用到时，可以使用弃元方法，使用_代替

6.如果只有一个参数时，且命名为_，那么在表达式中会视为该参数的名称



#### 五、LINQ（语言集成查询）

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
var list6 = LinqTestList.Select(x => x.address1).Aggregate(new List<string>(), (a, p) =>
{
	a.Add(p);
	return a;
});//聚集，可以选择其中的属性聚齐起来
```





#### 六、Async 和 Await 的异步编程

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





#### 七、虚函数

虚函数的关键词virtual，实现多态性

不能有static，abstract，override修饰符

虚函数不能私有，不能用private修饰符

虚函数和一般函数的区别：

一般函数在编译时就静态编译到了执行文件中，相对地址在运行期间不会发生变化

虚函数在编译期间不会被静态编译，会根据运行期间对象实例来动态判断调用哪个函数

声明时定义的类叫声明类，执行时实例化的类叫实例类

调用过程：

1.调用一个对象的函数时，系统会直接去检查这个对象声明定义的类，即声明类，看调用的函数是否为虚函数

2.如果不是虚函数，就直接执行，如果是虚函数，就不执行，去实例类中找

3.如果在实例类中找到了重写的虚函数，就执行，如果没有，就往上找实例类的父类，重复上面的检查，直到找到重写虚函数的父类，然后执行

#### 八、new关键字

new关键字的三种用法：

1、创建新的对象和调用构造函数

2、显式隐藏父类的对象或者方法，就是在子类中定义一个和父类变量名称相同的变量；

3、在泛型约束中用于约束有无参构造函数的类型

#### 九、正则表达式

##### 1、语法

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



#### 十、面向对象六大原则（六大设计模式）

##### 1.单一职责原则（Single Responsibility principle）

一个类只负责一个功能领域中的相应职责，或者可以定义为：就一个类而言，应该只有一个引起它变化的原因

单一职责原则是实现高内聚，低耦合的指导方针。

##### 2.开闭原则（Open Closed principle）

一个软件实体应该对扩展开放，对修改关闭；一个软件实体尽量在不修改源代码的情况下进行对外扩展；

需要对系统进行抽象化设计，抽象化是开闭原则的关键；可以为系统定义一个相对稳定的抽象层，将不同的实现行为移至具体的实现层中完成

对扩展开放：系统中的模块，类，方法对于它们的提供者是开放的，可以对系统进行扩展新的功能

对修改关闭：系统中的模块，类，方法对于它们的使用者是关闭的，使用者不会因为提供者新增了功能而做出相应的修改

开闭原则是面向对象设计的目标

##### 3.里氏替换原则（Liskov Substitution principle）

所有引用基类的地方必须能够透明的使用其子类的对象；

如果把基类对象替换成它的子类对象，程序将不会产生任何错误和异常，反过来责不成立：如果使用的是一个子类对象的话，不一定能够使用基类对象；

里氏替换原则是实现开闭原则的重要方式之一，使用基类对象的地方都可以使用子类对象，因此在程序中尽量使用基类类型来对对象进行定义，在运行时再确定其子类类型，用子类对象来替换父类对象

在使用里氏替换原则时需注意如下几个问题：

（1）子类的所有方法必须在父类中声明(子类必须实现父类中声明的所有方法)

（2）尽量把父类设计成抽象类或者接口

##### 4.依赖倒置原则（Dependence Inversion principle）

抽象不应该依赖于细节，细节应该依赖于抽象，换言之，要面向接口编程，而不是针对实现编程

高层模块不应该依赖于低层模块，二者都应该依赖其抽象

依赖导致原则基于这样的设计理念：相对于细节的多变性，抽象的东西要稳定的多，以抽象为基础搭建的架构比以细节为基础的架构要稳定的多；

高层模块就是封装了其他许多的模块，低层模块就是不可分割的模块

依赖倒置原则是指的模块间的依赖是通过抽象来发生的,实现类之间不发生直接的依赖关系,其依赖关系是通过接口时来实现的,这就是俗称的 

面向接口编程

举例：

在类中需要用到其他类的时候，就需要依赖注入

依赖倒置的三种注入方法：

（1）构造函数注入，在实现类的构造函数中声明依赖对象

（2）Setter方式注入，通过Setter方法声明依赖对象

（3）接口注入，在接口方法中声明依赖对象

例子：

```c#
//1.数据库的读写，往数据中添加一条订单
public class SqlServerDal
{
    public void Add()
    {
        Console.WriteLine("添加一条新订单");
    }
}

//2.定义一个order类，用于逻辑处理
public class Order
{
    private SqlServerDal sqlServerDal = new SqlServerDal();

    public void Add()
    {
        sqlServerDal.Add();
    }
}

//3.需求发生变更，需要将数据库改成Access，就要重新定义Access类
public class AccessDal
{
    public void Add()
    {
        Console.WriteLine("添加一条新订单");
    }
}

//Order类中也需要发生变化
public class Order
{
    private AccessDal sqlServerDal = new AccessDal();

    public void Add()
    {
        sqlServerDal.Add();
    }
}
//这样耦合度就很高，因为高层模块Order类依赖于了低层模块SqlServerDal和AccessDal，两者都应该依赖于抽象

//改进
//定义一个接口DataAccess
public class SqlServerDal:DataAccess
{
    public void Add()
    {
        Console.WriteLine("添加一条新订单");
    }
}

public class AccessDal: DataAccess
{
    public void Add()
    {
        Console.WriteLine("添加一条新订单");
    }
}
//修改Order类
//➀构造函数注入
public class Order
{
    private DataAccess dataAccess;

    public Order(DataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }
    
    public void Add()
    {
        dataAccess.Add();
    }
}
//set方法注入（属性注入）
public class Order
{
    private DataAccess _dataAccess;

    public DataAccess DataAccess
    {
        get => _dataAccess;
        set => _dataAccess = value;
    }

    public void Add()
    {
        DataAccess.Add();
    }
}
//接口方法注入
public class Order: DependenceInterface
{
    private DataAccess _dataAccess;

    public void SetDependence(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public void Add()
    {
        _dataAccess.Add();
    }
}

//c#中常用的IOC容器是UnityContainer
IUnityContainer container = new UnityContainer();
container.RegisterSingleton<DataAccess, AccessDal>();//单例模式
DataAccess dataAccess = container.Resolve<DataAccess>();
dataAccess.Add();
```

##### 5.接口隔离原则（Interface Segregation principle）

使用多个专门的接口，而不应该使用单一的总接口，即客户端不应该依赖那些不需要的接口;

另一个定义：一个类对另一个类的依赖应该建立在最小的接口上

在使用接口隔离原则时，我们需要注意控制接口的粒度，接口不能太小，如果太小会导致接口泛滥，不利于维护，接口也不能太大，太大会违背接口隔离原则，使用起来不方便。

##### 6.迪米特法则

一个软件实体应当尽可能的少与其他实体发生相互作用

当一个软件实体发生变化时就会尽量减少对其他软件实体的影响

迪米特法则又称最少知识原则

例如：关闭电脑的例子，要关闭电脑正在执行的任务，关闭其他运行程序，关闭显示器，关闭电源

对于人而言只有关闭电脑这一个动作，把其他方法封装在关闭电脑的方法里



#### 十一、设计模式（Design Pattern）

设计模式是一套被反复使用的，多数人知晓的，经过分类编目的，代码设计经验的总结。

三大类:

创建性模式：对象实例化的模式，创建型模式用于解耦对象的实例化过程。

结构型模式：把类或对象结合在一起形成一个更大的结构。

行为型模式：类和对象如何交互，及划分责任和算法。

创建型模式：单例模式，原型模式，工厂方法模式，抽象工厂模式，建造者模式

##### **1.单例模式**

```c#
#region 单例模式 在进程中只有一个实例 饿汉式、懒汉式

    /// <summary>
    /// 饿汉式
    /// 缺点：类加载的时候就完成了实例化，如果没用，就会浪费，占用内存
    /// </summary>
    //public class Singleton
    //{
    //    private static Singleton INSTANCE = new Singleton();
    //    private Singleton() { }

    //    public static Singleton GetSingleton()
    //    {
    //        return INSTANCE;
    //    }
    //    public void Test()
    //    {
    //        Console.WriteLine("Hello,Singleton!");
    //    }
    //}

    /// <summary>
    /// 懒汉式，用的时候再创建;
    /// 普通的懒汉式，线程不安全;
    /// 假设对象还没有被实例化，但是又两个线程同时访问，就会可能出现多次实例化的结果，所以不可用
    /// </summary>
    //public class Singleton
    //{
    //    private static Singleton instance = null;
    //    private Singleton() { }
    //    public static Singleton GetSingleton()
    //    {
    //        if (instance == null)//单if判null
    //        {
    //            instance = new Singleton();
    //        }
    //        return instance;
    //    }

    //    public void Test()
    //    {
    //        Console.WriteLine("Hello,Singleton!");
    //    }
    //}


    /// <summary>
    /// if判null，外层加lock
    /// lock作用，保证进入lock的代码块是单线程的
    /// 不推荐：多线程通过lock变成单线程，无法利用多线程的优势，意义不大
    /// </summary>
    //public class Singleton
    //{
    //    private static Singleton singleton;
    //    private Singleton() { }

    //    private static readonly object _instanceLock = new object();//声明静态lock对象
    //    public static Singleton GetSingleton()
    //    {
    //        lock (_instanceLock)
    //        {
    //            if (singleton == null)
    //            {
    //                singleton = new Singleton();
    //            }
    //        }
    //        return singleton;
    //    }
    //    public void Test()
    //    {
    //        Console.WriteLine("Hello,Singleton!");
    //    }
    //}

    /// <summary>
    /// lock内外均加if判null
    /// 保证单例，而且多线程
    /// </summary>
    //public class Singleton
    //{
    //    private static Singleton singleton;
    //    private Singleton() { }

    //    private static readonly object _instanceLock = new object();

    //    public static Singleton GetSingleton()
    //    {
    //        if (singleton == null)
    //        {
    //            lock (_instanceLock)
    //            {
    //                if (singleton == null)
    //                {
    //                    singleton = new Singleton();
    //                }
    //            }
    //        }
    //        return singleton;
    //    }
    //    public void Test()
    //    {
    //        Console.WriteLine("Hello,Singleton!");
    //    }
    //}
    #endregion
```

##### 2.工厂方法模式，抽象工厂模式

```c#
#region 工厂方法模式
    ///<summary>
    /// 案例：想要造华为手机，小米手机
    /// </summary>

    #region 简单工厂模式
    //public interface IPhone
    //{
    //    void TurnOn();
    //}

    //public class HuaWeiPhone : IPhone
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("华为开机");
    //    }
    //}

    //public class XiaoMiPhone : IPhone
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("小米开机");
    //    }
    //}
    #endregion

    #region 工厂方法模式
    //考虑到制造手机的厂商有很多，所以提出来工厂方法模式
    //public interface IPhone
    //{
    //    void TurnOn();
    //}

    //public class HuaWeiPhone : IPhone
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("华为开机");
    //    }
    //}

    //public class XiaoMiPhone : IPhone
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("小米开机");
    //    }
    //}

    //public interface IFactory
    //{
    //    IPhone CreatePhone();
    //}

    ////制造华为的工厂
    //public class HuaWeiFactory : IFactory
    //{
    //    public IPhone CreatePhone()
    //    {
    //        return new HuaWeiPhone();
    //    }
    //}

    ////制造小米的工厂
    //public class XiaomiFactory : IFactory
    //{
    //    public IPhone CreatePhone()
    //    {
    //        return new HuaWeiPhone();
    //    }
    //}
    #endregion

    //下面需求变了，需要这个工厂不仅可以制造手机，也可以制造其他产品
    ///<summary>
    /// 抽象工厂模式允许客户端创建一组相关的产品
    /// 四个组成部分：抽象工厂，具体工厂，抽象产品，具体产品
    /// </summary>
    public interface IFactory
    {
        IPhone CreatePhone();
        ITV CreateTV();
    }

    public class HuaWeiFactory : IFactory
    {
        public IPhone CreatePhone()
        {
            return new HuaWeiPhone();
        }

        public ITV CreateTV()
        {
            return new HuaWeiTV();
        }
    }

    public interface IPhone
    {
        void TurnOn();
    }
    public interface ITV
    {
        void TurnOn();
    }

    public class HuaWeiPhone : IPhone
    {
        public void TurnOn()
        {
            Console.WriteLine("华为手机");
        }
    }

    public class HuaWeiTV : ITV
    {
        public void TurnOn()
        {
            Console.WriteLine("华为电视");
        }
    }
    #endregion
```

抽象工厂模式和工厂方法模式的比较：

1.抽象工厂适合创建一组依赖的情况，工厂方法模式适合创建单个对象的情况

2.抽象工厂包含抽象工厂，具体工厂，抽象产品，具体产品；工厂方法包含工厂接口，具体工厂，产品接口

优点：促进程序的松散耦合，因为是和抽象工厂接口进行交互，而不是和具体工厂具体产品进行交互

缺点：当添加新的产品时，抽象工厂具体工厂都要修改，导致代码难以维护

##### 3.原型模式

模式中的角色

2.1 Prototype（抽象原型类）：它是声明克隆方法的接口，是所有具体原型类的公共父类，可以是抽象类也可以是接口，甚至还可以是具体实现类。

2.2 ConcretePrototype（具体原型类）：它实现在抽象原型类中声明的克隆方法，在克隆方法中返回自己的一个克隆对象。

2.3 Client（客户类）：让一个原型对象克隆自身从而创建一个新的对象

```c#
public class Resume : ICloneable
{
    public string name;
    public string birthday;
    public string sex;
    public string school;
    public string timeArea;
    public string company;

    public Resume()
    {

    }

    public Resume(string name, string birthday, string sex, string school, string timeArea, string company)
    {
        this.name = name;
        this.birthday = birthday;
        this.sex = sex;
        this.school = school;
        this.timeArea = timeArea;
        this.company = company;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

Resume resume = new Resume("1","2","3","4","5","6");
Resume resume1 = resume.Clone() as Resume;
```

优点：简化了对象的创建

可以使用深克隆保存对象的状态，使用原型模式复制一份并且保存下来

缺点：需要给每一个类准备一个克隆方法，需要改造类时，就要修改源代码，违背了开闭原则

##### 4.建造者模式

将复杂的对象构造和它的表示进行分离，使得同样的构建过程可以创建不同的表示。创建者模式返回一个完整的复杂产品。

模式中的角色：

建造者Builder：为创建产品的各个部分提供接口，控制建造的细节

具体建造者ConcreteBuilder

指挥者Director：控制建造的过程

产品Product

**案例：**创建一个人，这个人可以是高个子，胖子等等

Builder：定义接口，控制细节，比如造胳膊，造头，造身体，造腿

ConcreteBuilder：造瘦子，胖子等等

Director：控制建造过程，选择实现哪些细节

Product：具体产品，如高个子，瘦子。。。

优点：过程由指挥者控制，细节由抽象控制，对于实现来说，不会错过一个步骤

缺点：如果要增加一个细节，需要修改所有地方，对修改也开放了，违背开闭原则

#### 十二、多线程和异步

进程和线程：

进程包含着一个运行程序所需要的资源，一个正在运行的应用程序可以看做一个进程，一个进程可以包含一个或者多个线程

线程是CPU调度和分派的基本单位

进程和线程的区别和联系：

1.进程是资源分配的基本单位，线程是操作系统调度和分派的基本单位

2.进程拥有独立的内存空间，资源，共享复杂，但是同步简单，线程共享所属进程的资源，共享简单，但是同步复杂，需要加锁。

3.进程之间不会相互影响，线程会影响进程，如果挂掉，程序也会挂掉

4.进程是独立的，不包含在其他进程中，线程的所有逻辑是包含在进程中的

5.一个线程可以创建和撤销另一个线程，同一个进程中的多个线程之间可以并发执行

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

```c#
Thread thread1 = new Thread(ThreadMethod1);
Thread thread2 = new Thread(ThreadMethod2);
Thread thread3 = new Thread(ThreadMethod1,2);
Thread thread4 = new Thread(ThreadMethod2,3);
thread1.Start();
thread2.Start();
thread2.Start(2);
thread3.Start();
thread4.Start();

private void ThreadMethod1()
{
    System.Diagnostics.Debug.WriteLine("this is new thread without paramater");
}

private void ThreadMethod2(object? a)
{
    System.Diagnostics.Debug.WriteLine("this is new thread with paramater");
}

```

Thread.Sleep();

Thread.Wait();

**多线程和异步:**

异步相对于同步来说是一个目的，多线程是实现异步的一种方法

Task和Thread的比较：

task相当于应用层，thread更底层一些，但二者没有隶属关系

task是在线程池上创建，是后台线程，thread是单个线程，默认是前台线程

task可以直接获得返回值，thread不能从方法中返回结果(可以通过变量)

task可以通过CancellationTokenSource类来取消任务，thread运行时，无法取消

task能够方便捕捉到异常，thread在父方法中无法捕捉到异常

Task.Delay()不会阻塞主线程，一般和ContinueWith联合使用，等待一段时间后执行ContinueWith里面的事情



Thread.Sleep()会阻塞主线程



竞态条件：多个线程在访问共享资源时，由于执行顺序的不确定性，会导致程序结果和预计的不一样

线程的状态：就绪，运行，等待，阻塞，终止

```c#
thread.Start();线程开启
thread.Suspend(); //表示线程暂停，现在已弃用，NetCore平台已经不支持
thread.Resume();  //线程恢复执行，弃用，NetCore平台已经不支持
thread.Abort();   //线程停止，子线程对外抛出了一个异常，线程是无法从外部去终止的
Thread.ResetAbort();//停止的线程继续去执行
thread.Join();//主线程等待，直到当前线程执行完毕
thread.Join(500);//主线程等待500毫秒，不管当前线程执行是否完毕，都继续往后执行

//在主线程中给ThreadStatic特性标注的变量赋值，则只有主线程能访问该变量

Task task1 = new Task(()=> 
{
    for (int i = 0; i < 10000; i++)
        count++;
});
task1.Start();

Task.Run(()=>
{
	cw("");    
})

TaskFactory factory = Task.Factory;
factory.StartNew(() =>
{                 
	Console.WriteLine("张三");
});
Task<int> task3 = factory.StartNew<int>(() =>
{
	return DateTime.Now.Year;
});

task1.RunSynchronously();//同步方法

//线程阻塞
task.Wait()//会阻塞其他线程，直到它完成
Task.WaitAll();
Task.WaitAny();
//When不会阻塞线程
Task.WhenAll(tasks.ToArray()).ContinueWith((o) => { Console.WriteLine("运行结束"); });
Task.WhenAny(tasks.ToArray()).ContinueWith((o) => { Console.WriteLine("运行结束"); });

//多线程异常处理
多线程内部发生异常后，try-catch无法捕捉到异常
如何捕捉到异常：需要做线程的等待
//1.Task.WaitAll()
//用try-catch包裹
在try外面用Task.WaitAll()等待线程，例如
 List<Task> taskList = new List<Task>();
try
{
    for(int i = 0; i < 20; i++)
    {
        Task task = Task.Run(() => 
                             {
                                 if(i == 2)
                                 {
                                     throw new Exception("第二个异常了");
                                 }
                                 else if (i == 8)
                                 {
                                     throw new Exception("第8个异常了");
                                 }
                                 else if (i == 12)
                                 {
                                     throw new Exception("第12个异常了");
                                 }
                             });
        taskList.Add(task);
    }
    Task.WaitAll(taskList.ToArray());
}
catch(AggregateException ex)
{
    foreach(var item in ex.InnerExceptions)
    {
        System.Diagnostics.Debug.WriteLine(item.Message);
    }
}
//捕捉到的异常是一个AggregateException类型的异常，包含有多线程内部异常的集合

//线程取消
//线程不能从外部取消，只能自己取消自己
//CancellationTokenSource，提供了IsCancellationRequested布尔型的属性，默认为false，true表示线程取消
CancellationTokenSource cts = new CancellationTokenSource();
cts.Cancel();
```



#### 十三、泛型

泛型是为了解决代码重用的问题而提出的

泛型和object的区别是：

泛型避免了拆箱装箱，在性能上提高了不少

在处理引用类型时，避免了强制类型转换

泛型可用的地方：自定义类，方法，接口，委托，约束

泛型约束：

在泛型方法后面写where T:

new()约束：where T :new ()表示T一定是要有一个无参的构造函数

struct值类型约束：struct,int,double,float等等

例如：where T:struct

class引用类型约束：数字，类，接口，委托，object

where T:class，where T:class,new()

自定义类型约束：自己定义的类型

```c#
class MyGeneric<T,K,C> 
where T:struct 
where K:class,new() 
where C:Student,new()
{
   
}
```

<font color="blue">注意：new()约束一定要写在最后面</font>

#### 十四、排序算法

![1700306878068](C:\Users\丁涛\AppData\Roaming\Typora\typora-user-images\1700306878068.png)

1、冒泡排序

第一轮从一个数开始，相邻的两个数进行比较交换，第一轮过后最大的数到了最后一个；第二轮从第二个数继续比较

2、选择排序

- 数组的初始状态：有序区为空，无序区为[0,…,n]
- 每次找到无序区里的最小元素，添加到有序区的最后
- 重复前面步骤，直到整个数组排序完成

3、插入排序

整个数组分为**左边部分有序元素集合**和**右边部分无序元素集合**

一开始从索引为一的元素开始逐渐递增与有序集合进行比较

将未排序的元素一个一个地插入到有序的集合中，插入时把所有有序集合从后向前扫一遍，找到合适的位置插入

4、希尔排序

希尔排序简单的来说就是一种改进的插入排序算法，它通过将待排序的元素分成若干个子序列，然后对每个子序列进行插入排序，最终逐步缩小子序列的间隔，直到整个序列变得有序。希尔排序的主要思想是通过插入排序的优势，减小逆序对的距离，从而提高排序效率。

1. 首先要确定一个增量序列（初始间隔），将待排序序列分成多个子序列。
2. 对每个子序列分别进行插入排序，即在子序列内部进行排序。
3. 逐步减小增量，重复步骤2，直到增量为1，即完成最后一次插入排序，排序完成。

5、快速排序

- 开始设定一个基准值pivot
- 将数组重新排列，所有比**pivot小的放在其前面**，**比pivot大的放后面**，这种操作称为分区(partition)操作
- 对两边的数组重复前两个步骤; （分而治之算法思想）

### 具体实现步骤如下：

1. 首先选择一个基准元素，通常为数组的第一个或最后一个元素。

2. 设置两个指针，一个指向数组的起始位置（低位），一个指向数组的结束位置（高位）。

3. 使用两个指针从两个方向同时遍历数组，直到两个指针相遇。

4. 从低位开始，比较当前元素与基准元素的大小关系：

5. - 如果当前元素小于等于基准元素，则向右移动低位指针。
   - 如果当前元素大于基准元素，则向左移动高位指针。
   - 如果低位指针仍然在高位指针的左侧，则交换低位指针和高位指针所指向的元素。

6. 重复步骤4，直到低位指针与高位指针相遇。

7. 将基准元素与相遇位置的元素进行交换，确保基准元素位于其最终的排序位置。

8. 根据基准元素的位置，将数组分为两个子数组，并递归地对这两个子数组进行快速排序。

p=21

left = 0,right=6

21，5，11，44，17，22，28

​                               r

17，5，11，44，17，22，28

​                       l        r

17，5，11，21，44，22，28



6、归并排序

- 归并排序算法是采用分治法的一个非常典型的应用
- 不断将数组一分为二，一直分到子数组的长度小于等于一（无法再分）
- 通过递归的方法逐个比较大小自底向上有序地合并数组

1. 将待排序序列分割成两个子序列，直到每个子序列中只有一个元素。
2. 将相邻的两个子序列合并，并按照大小顺序合并为一个新的有序序列。
3. 不断重复第2步，直到所有子序列都合并为一个有序序列。

7、计数排序

计数排序是一种非比较性的排序算法，适用于排序一定范围内的整数。它的基本思想是通过统计每个元素的出现次数，然后根据元素的大小依次输出排序结果。 

1. 首先找出待排序数组中的最大值max和最小值min。
2. 创建一个长度为max-min+1的数组count，用于统计每个元素出现的次数。
3. 遍历待排序数组，将每个元素的出现次数记录在count数组中。
4. 根据count数组和min值，得到每个元素在排序结果中的起始位置。
5. 创建一个与待排序数组长度相同的临时数组temp，用于存储排序结果。
6. 再次遍历待排序数组，根据count数组和min值确定每个元素在temp数组中的位置，并将其放入。
7. 将temp数组中的元素复制回待排序数组，排序完成。

8、堆排序

堆排序是一种高效的排序算法，基于二叉堆数据结构实现。它具有稳定性、时间复杂度为O(nlogn)和空间复杂度为O(1)的特点。 

1. 构建最大堆：将待排序数组构建成一个最大堆，即满足父节点大于等于子节点的特性。
2. 将堆顶元素与最后一个元素交换：将最大堆的堆顶元素与堆中的最后一个元素交换位置，将最大元素放到了数组的末尾。
3. 重新调整堆：对剩余的n-1个元素进行堆调整，即将堆顶元素下沉，重新形成最大堆。
4. 重复步骤2和3，直到堆中的所有元素都被排列好。

9、桶排序

桶排序是一种线性时间复杂度的排序算法，它将待排序的数据分到有限数量的桶中，每个桶再进行单独排序，最后将所有桶中的数据按顺序依次取出，即可得到排序结果。 

1. 首先根据待排序数据，确定需要的桶的数量。（最大值-最小值）/元素个数+1
2. 遍历待排序数据，将每个数据放入对应的桶中。
3. 对每个非空的桶进行排序，可以使用快速排序、插入排序等常用的排序算法。
4. 将每个桶中的数据依次取出，即可得到排序结果。

10、基数排序

 基数排序是一种非比较性排序算法，它通过将待排序的数据拆分成多个数字位进行排序。 

1. 首先找出待排序数组中的最大值，并确定排序的位数。
2. 从最低位（个位）开始，按照个位数的大小进行桶排序，将元素放入对应的桶中。
3. 将各个桶中的元素按照存放顺序依次取出，组成新的数组。
4. 接着按照十位数进行桶排序，再次将元素放入对应的桶中。
5. 再次将各个桶中的元素按照存放顺序依次取出，组成新的数组。
6. 重复上述操作，以百位、千位、万位等位数为基准进行排序，直至所有位数都被排序。

#### 十五、文件读写

```c#
using System.IO;

string filePath;//文件路径
string directoryPath;//文件夹路径
//读取文件
StreamReader sr = new StreamReader(filePath,Encoding.UTF8);
string line = sr.ReadLine();//一行一行读
string allLine = sr.ReadToEnd();//一次性读完
while(line != null)
{
	//具体处理
	line = sr.ReadLine();
}
sr.Close();

//写入文件
FileStream fs = new FileStream(filePath,FileMode.Open...)
StreamWriter sw = new StreamWriter();
sw.WriteLine(content);
sw.Close();

File.Exists(filePath);//判断文件是否存在
File.Create(filePath);//创建文件
FileInfo fileInfo = new FileInfo(filePath);//生成文件的详细信息

string dirPath = Path.GetDirectoryName(filePath);//通过文件名获得文件夹
Directory.Exists(dirPath);//判断文件夹是否存在
Directory.CreateDirectory(dirPath);//创建文件夹
DirectoryInfo dirInfo = new DirectoryInfo(dirPath);//生成文件夹的具体信息
AppDomain.CurrentDomain.BaseDirectory//获得当前程序运行的目录

```

#### 十六、修饰符

访问修饰符用于控制类，字段，属性，方法等的访问权限

public：在任何地方都可以访问

作用域：字段，方法，属性，类，接口，结构

private：只能在类中或者结构体中被访问

作用域：字段，方法，属性，嵌套类型

protected：只能在类（结构体）中或者继承类（结构体）中访问

作用域：字段，方法，属性，嵌套类型

internal：只能在同一个程序集中访问

作用域：类，接口，接口，枚举，嵌套类型

protected internal：只能在同一个程序集中访问，或者在类以及子类中访问

作用域：字段，方法，属性，嵌套类型

#### 十八、接口和抽象类

接口：

接口中只能包含方法（属性，事件，索引）

不能有实现

接口不能实例化，抽象类，静态函数也不可以

接口的成员不能有访问修饰符（C#8.0以后可以，但也不能是private）

接口的所有成员函数都要被子类实现，不需要加关键词，直接实现就好

抽象类：

抽象方法只能在抽象类中，抽象类中可以包含普通方法

在父类定义中的抽象方法不能实现

抽象类不能实例化

如果抽象类的子类不是抽象类，必须重写父类抽象类的所有方法



- 在 8.0 以前的 C# 版本中，接口类似于只有抽象成员的抽象基类。 实现接口的类或结构必须实现其所有成员。
- 从 C# 8.0 开始，接口可以定义其部分或全部成员的默认实现。 实现接口的类或结构不一定要实现具有默认实现的成员。 
- 接口无法直接进行实例化。 其成员由实现接口的任何类或结构来实现。
- 一个类或结构可以实现多个接口。 一个类可以继承一个基类，还可实现一个或多个接口。

#### 十九、反射

<img src="C:\Users\丁涛\AppData\Roaming\Typora\typora-user-images\1698567419964.png" alt="1698567419964"  />

C#编译运行过程：

编译的时候会将源代码编译成程序集，程序集以exe或者dll的形式呈现，程序集包含了中间语言（IL）和元数据

在执行的时候，实时编译器（JIT）会将中间语言转化成机器码（本机代码）

运行时，CLR会提供要发生的托管执行的基础结构和执行期间可使用的服务

exe文件有程序入口，dll是动态，没有程序入口

metadata：元数据，描述exe/dll的一个数据清单，有什么内容

元数据包含了：类，方法，特性，属性，字段

反射的优点：提高了程序的扩展性和灵活性，降低了耦合度

反射的缺点：性能有所损耗



使用场景

【1】更新程序时（更新自己的dll）

【2】使用别人的dll文件（私有的也能读取）

反射就是操作metadata的一个类库，动态读取或者操作元数据

反射是指程序可以访问检测和修改本身的状态或者行为的一种能力

程序集包含模块，而模块包含类型，类型又包含成员。反射则提供了封装程序集、模块和类型的对象。 

1.通过反射加载dll文件

//Assembly assembly = Assembly.Load("Ant.DB.MySql");//加载方式一：dll文件名（当前程序运行目录下）
//Assembly assembly = Assembly.LoadFile(@"E:\CsharpProjects\Ant.DB.MySql\bin\Debug\net5.0\Ant.DB.MySql.dll");//加载方式二：完整路径
//Assembly assembly = Assembly.LoadFrom("Ant.DB.MySql.dll");//完全限定名
Assembly assembly = Assembly.LoadFrom(@"E:\CsharpProjects\Ant.DB.MySql\bin\Debug\net5.0\Ant.DB.MySql.dll");//文件完整路径

foreach (var type in assembly.GetTypes())//找到所有类型
{
	Console.WriteLine(type.Name);
	foreach(var method in type.GetMethods())//找到所有方法
	{
		Console.WriteLine("这是{0}方法",method.Name);
	}
}

2.通过反射创建对象

```c#
#region 使用反射创建对象
//Assembly assembly = Assembly.LoadFrom ("Ant.DB.MySql.dll");//加载dll文件
//Type type = assembly.GetType("Ant.DB.MySql.MysqlHelper");//获取类型，需要完整名称，命名空间加上类名
//object oDBHelper = Activator.CreateInstance(type);//创建对象
//IDBHelper dBHelper = oDBHelper as IDBHelper;
//dBHelper.Query();
#endregion

#region 使用反射创建对象（带参数的构造函数）
Assembly assembly = Assembly.LoadFrom("Ant.DB.MySql.dll");//加载dll文件
Type type = assembly.GetType("Ant.DB.MySql.ReflectionTest");
foreach(ConstructorInfo ctor in type.GetConstructors())//获取所有构造方法
{
    Console.WriteLine(ctor.Name);
    foreach(var paramater in ctor.GetParameters())
    {
        Console.WriteLine(paramater.ParameterType);
    }
}

object obj1 = Activator.CreateInstance(type);
object obj2 = Activator.CreateInstance(type, new object[]{ "1234" });
object obj3 = Activator.CreateInstance(type, new object[] {1111 });
#endregion
    

```

```c#
测试类：
class ReflectionTest
{
    private int _num = 0;

    public string Phone = "1311111111";

    public string Name { get; set; }

    public string Address { get; set; }
    
    public ReflectionTest()
    {
        Console.WriteLine($"这是{this.GetType()}无参构造函数");
    }

    private ReflectionTest(string name)
    {
        Console.WriteLine($"这是{this.GetType()}有参构造函数，类型为{name.GetType()}");
    }

    public ReflectionTest(int id)
    {
        Console.WriteLine($"这是{this.GetType()}有参构造函数，类型为{id.GetType()}");
    }
    
    public int PublicMethod()
    {
        Console.WriteLine($"Name is :{Name}");
        return int.MinValue;
    }

    internal void InternalMethod()
    {

    }
    private void PrivateMethod()
    {

    }
}
```



Type类的使用：

```c#
获取Type实例的三种办法：
ReflectionTest reflectionTest = new ReflectionTest();
Type type1 = typeof(ReflectionTest);//用实例化对象
Type type2 = reflectionTest.GetType();//用类型
Type type3 = Type.GetType("Ant.DB.MySql.ReflectionTest,Ant.DB.MySql");//用Type静态方法，如果是同一个程序集下，就直接写命名空间.类型就可以简写为
Type type3 = Type.GetType("Ant.DB.MySql.ReflectionTest");

Console.WriteLine(type1);
Console.WriteLine(type2);
Console.WriteLine(type3);

输出结果如下：
Ant.DB.MySql.ReflectionTest
Ant.DB.MySql.ReflectionTest
Ant.DB.MySql.ReflectionTest
*************************************************************************************
Type的一些方法
type1.Name
type1.FullName
type1.Namespace
type1.Assembly
type1.AssemblyQualifiedName
输出结果如下：
ReflectionTest
Ant.DB.MySql.ReflectionTest
Ant.DB.MySql
Ant.DB.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Ant.DB.MySql.ReflectionTest, Ant.DB.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

1.
ConstructorInfo[] constructorInfos = type1.GetConstructors();//获得所有的公共构造函数
foreach(var item in constructorInfos)
{
    Console.WriteLine(item.Name);
    ParameterInfo[] parameterInfos = item.GetParameters();//获得函数的参数信息
    foreach(var para in parameterInfos)
    {
        Console.WriteLine($"para.Name:{para.Name}, para.ParameterType:{para.ParameterType}");
    }
}
输出结果如下：
.ctor
.ctor
para.Name:id, para.ParameterType:System.Int32

2.
//获取当前Type 实例的所有Public方法
MethodInfo[] methodInfos = type1.GetMethods();
foreach (var item in methodInfos)
{
    Console.WriteLine($"{type1.Name}类型中有：{item.Name}方法，返回类型为{item.ReturnType}");
}
输出结果如下：  
ReflectionTest类型中有：get_Name方法，返回类型为System.String
ReflectionTest类型中有：set_Name方法，返回类型为System.Void
ReflectionTest类型中有：get_Address方法，返回类型为System.String
ReflectionTest类型中有：set_Address方法，返回类型为System.Void
ReflectionTest类型中有：PublicMethod方法，返回类型为System.Int32
ReflectionTest类型中有：GetType方法，返回类型为System.Type
ReflectionTest类型中有：ToString方法，返回类型为System.String
ReflectionTest类型中有：Equals方法，返回类型为System.Boolean
ReflectionTest类型中有：GetHashCode方法，返回类型为System.Int32

3.
//获取当前Type 实例的所有Public属性
PropertyInfo[] propertyInfos = type1.GetProperties();
foreach (var item in propertyInfos)
{
    Console.WriteLine($"{type1.Name}类中有 属性-{item.Name} 类型为-{item.PropertyType}");
}
输出结果如下：
ReflectionTest类中有 属性-Name 类型为-System.String
ReflectionTest类中有 属性-Address 类型为-System.String

4.
//获取当前Type 实例的所有Public字段
FieldInfo[] fieldInfos = type1.GetFields();
foreach (var item in fieldInfos)
{
    Console.WriteLine($"{type1.Name}类中有 字段-{item.Name} 类型为-{item.FieldType}");
}
输出结果如下：
ReflectionTest类中有 字段-Phone 类型为-System.String

5.
//获取当前Type 实例的所有公共成员，包括构造函数，属性，字段，方法
MemberInfo[] memberInfos = type1.GetMembers();
foreach (var item in memberInfos)
{
    Console.WriteLine($"{type1.Name}类中有 成员名称-{item.Name} 类型为-{item.MemberType}");
}
输出结果如下：
ReflectionTest类中有 成员名称-get_Name 类型为-Method
ReflectionTest类中有 成员名称-set_Name 类型为-Method
ReflectionTest类中有 成员名称-get_Address 类型为-Method
ReflectionTest类中有 成员名称-set_Address 类型为-Method
ReflectionTest类中有 成员名称-PublicMethod 类型为-Method
ReflectionTest类中有 成员名称-GetType 类型为-Method
ReflectionTest类中有 成员名称-ToString 类型为-Method
ReflectionTest类中有 成员名称-Equals 类型为-Method
ReflectionTest类中有 成员名称-GetHashCode 类型为-Method
ReflectionTest类中有 成员名称-.ctor 类型为-Constructor
ReflectionTest类中有 成员名称-.ctor 类型为-Constructor
ReflectionTest类中有 成员名称-Name 类型为-Property
ReflectionTest类中有 成员名称-Address 类型为-Property
ReflectionTest类中有 成员名称-Phone 类型为-Field
```



System.Activator类的应用

```c#
//Activator类主要用于创建对象的实例
Type type = typeof(ReflectionTest);
ReflectionTest reflectionTest=(ReflectionTest)Activator.CreateInstance(type);//无参构造
//分别对于三个public构造方法，非公有的会报错
object obj1 = Activator.CreateInstance(type);
object obj2 = Activator.CreateInstance(type, new object[]{ "1234" });
object obj3 = Activator.CreateInstance(type, new object[] {1111 });

```

System.Reflection.Assembly类的应用

```c#
1.通过反射加载dll文件
Assembly assembly1 = Assembly.Load("Ant.DB.MySql");//dll文件名
Assembly assembly2 = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory+"Ant.DB.MySql.dll");//完整路径
Assembly assembly3 = Assembly.LoadFrom("Ant.DB.MySql.dll");//完全限定名
Assembly assembly4 = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory+"Ant.DB.MySql.dll");//完整路径
```

反射创建对象的三种方法：

```c#
Type type = typeof(ReflectionTest);
//第一种，用构造方法，得到对应的构造函数，再传入相应的参数
ConstructorInfo constructorInfo1 = type.GetConstructor(new Type[] { });
ConstructorInfo constructorInfo2 = type.GetConstructor(new Type[] {typeof(string)});
ConstructorInfo constructorInfo3 = type.GetConstructor(new Type[] { typeof(int) });
constructorInfo1.Invoke(new object[] { });
constructorInfo2.Invoke(new object[] { "1111" });
constructorInfo3.Invoke(new object[] { 22222 });
//第二种，Activator方法
Activator.CreateInstance(type);
Activator.CreateInstance(type, new object[] {"123" });
Activator.CreateInstance(type, new object[] {12345 });
//第三种 通过Assembly创建对象，true表示忽略大小写
Assembly assembly = Assembly.LoadFrom("Ant.DB.MySql.dll");//加载dll文件
ReflectionTest obj = assembly.CreateInstance("Ant.DB.MySql.ReflectionTest", true) as ReflectionTest;
```

其他方法

```c#
PropertyInfo propertyInfo = type.GetProperty("Name");
propertyInfo.SetValue(obj,"张三");
MethodInfo methodInfo = type.GetMethod("PublicMethod");
methodInfo.Invoke(obj,new object[] { });
```

#### 二十、索引器

索引器（indexer）使得对象能够用与数组相同的方式（即使用下标）进行索引

索引器声明：例如

```c#
class Student
{
    private Dictionary<string, int> scroeDictionary = new Dictionary<string, int>();

    string[] weekarray = new string[daysCount];
    static int daysCount = 7;

    public int? this[string subject]
    {
        get 
        {
            if (this.scroeDictionary.ContainsKey(subject))
            {
                return this.scroeDictionary[subject];
            }
            return null;
        }
        set 
        {
            if (value.HasValue == false)
            {
                throw new Exception("Score cannot be null");
            }

            if (scroeDictionary.ContainsKey(subject))
            {
                scroeDictionary[subject] = value.Value;
            }
            else
            {
                this.scroeDictionary.Add(subject, value.Value);
            }
        }

    }

    public string this[int index]
    {
        get
        {
            string week;

            if (index >= 0 && index <= daysCount - 1)
                week = weekarray[index];
            else
                week = "";

            return week;
        }
        set
        {
            if (index >= 0 && index <= daysCount - 1)
                weekarray[index] = value;
        }
    }
}
```

定义了两个索引器

#### 二十一、数据类型

C#数据类型大致分为三类，值类型，引用类型和指针类型

**1.值类型**

C# 中的值类型是从 System.ValueType 类中派生出来的，对于值类型的变量我们可以直接为其分配一个具体的值。当声明一个值类型的变量时，系统会自动分配一块儿内存区域用来存储这个变量的值，需要注意的是，变量所占内存的大小会根据系统的不同而有所变化。 

![1700123591815](C:\Users\丁涛\AppData\Roaming\Typora\typora-user-images\1700123591815.png)

 如果想要获取类型或变量的确切大小，可以使用 sizeof 方法，示例：sizeof(int)

**2.引用类型**

引用类型的变量中并不存储实际的数据值，而是存储的对数据（对象）的引用，换句话说就是，引用类型的变量中存储的是数据在内存中的位置。当多个变量都引用同一个内存地址时，如果其中一个变量改变了内存中数据的值，那么所有引用这个内存地址的变量的值都会改变。C# 中内置的引用类型包括 Object（对象）、Dynamic（动态）和 string（字符串）。



#### 二十二、ref，out，in

- ref 修饰符，指定参数由引用传递，可以由调用方法读取或写入。
- out 修饰符，指定参数由引用传递，必须由调用方法写入。必须在调用方法中赋值
- in 修饰符，指定参数由引用传递，可以由调用方法读取，但不可以写入。不能在调用方法中赋值

三个在使用前必须赋值

```c#
Get1(ref a);
Get2(out a);
Get3(in a);

public static void Get1(ref int a)
{

}

public static void Get2(out int a)
{
    a = 5;//必须赋值
}

public static void Get3(in int a)
{
    a = 5;//错误，不能赋值
}
```

#### 二十三、IOC（Inversion of control）

IOC：降低程序的耦合性，使得程序更加容易维护

IOC的思想就是把对象之间的依赖关系交给容器来处理，上层不再依赖于下层，而是依赖于抽象，IOC 容器来实例化下层。
所以IOC它就是一种目标，让程序解耦，让第三方的IOC容器来创建对象，DI是实现IOC的手段。
IOC也可以理解为一个实例化对象的工厂，它的这种思想也符合设计模式中的依赖倒置原则。

#### 二十四、特性

特性（Attribute）是用于在运行时传递程序中各种元素（比如类、方法、结构、枚举、组件等）的行为信息的声明性标签。 

```c#
public enum AttributeTargets
    {
        //
        // 摘要:
        //     Attribute can be applied to an assembly.
        Assembly = 1,
        //
        // 摘要:
        //     Attribute can be applied to a module. Module refers to a portable executable
        //     file (.dll or.exe) and not a Visual Basic standard module.
        Module = 2,
        //
        // 摘要:
        //     Attribute can be applied to a class.
        Class = 4,
        //
        // 摘要:
        //     Attribute can be applied to a structure; that is, a value type.
        Struct = 8,
        //
        // 摘要:
        //     Attribute can be applied to an enumeration.
        Enum = 16,
        //
        // 摘要:
        //     Attribute can be applied to a constructor.
        Constructor = 32,
        //
        // 摘要:
        //     Attribute can be applied to a method.
        Method = 64,
        //
        // 摘要:
        //     Attribute can be applied to a property.
        Property = 128,
        //
        // 摘要:
        //     Attribute can be applied to a field.
        Field = 256,
        //
        // 摘要:
        //     Attribute can be applied to an event.
        Event = 512,
        //
        // 摘要:
        //     Attribute can be applied to an interface.
        Interface = 1024,
        //
        // 摘要:
        //     Attribute can be applied to a parameter.
        Parameter = 2048,
        //
        // 摘要:
        //     Attribute can be applied to a delegate.
        Delegate = 4096,
        //
        // 摘要:
        //     Attribute can be applied to a return value.
        ReturnValue = 8192,
        //
        // 摘要:
        //     Attribute can be applied to a generic parameter. Currently, this attribute can
        //     be applied only in C#, Microsoft intermediate language (MSIL), and emitted code.
        GenericParameter = 16384,
        //
        // 摘要:
        //     Attribute can be applied to any application element.
        All = 32767
    }


特性的定义
[AttributeUsage(AttributeTargets.Field)]
public sealed class CodeAttribute : Attribute
{
    public CodeAttribute(string code)
    {
        Code = code;
    }

    public string Code = "";
}

使用
public enum MyAttributeEnum
{
    [Code("Monday")]
    Monday,

    [Code("Tuesday")]
    Tuesday,

    [Code("Wendesday")]
    Wendesday,

    [Code("Turthday")]
    Turthday,

    [Code("Friday")]
    Friday,

    [Code("Saturday")]
    Saturday,

    [Code("Sunday")]
    Sunday,
}

如何获得特性的内容
定义一个GetCode方法
public static string GetCode(this Enum value)
{
    // NULL判定
    if (value == null)
    {
        return string.Empty;
    }

    return value.GetAttribute<CodeAttribute>()?.Code
        ?? value.ToString();
}

private static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
{
    //通过反射
    var fieldInfo = value.GetType().GetField(value.ToString());
    if (fieldInfo == null)
    {
        return null;
    }
    //通过GetCustomAttributes方法得到特性的相关信息，.Cast方法是投射
    var attributes
        = fieldInfo.GetCustomAttributes(typeof(TAttribute), false)
        .Cast<TAttribute>();

    if ((attributes?.Count() ?? 0) <= 0)
        return null;

    return attributes.First();
}
```

#### 二十五、面向对象的三大特征

封装：将事物的属性和方法封装在一个类中，属性描述事物的特征，方法描述事物的行为

将信息隐藏在类中，私有化，提供方法对这些隐藏信息进行读取和操作get，set

隐藏了实现细节，还要对外提供可以访问的方式。便于调用者的使用。这是核心之一，也可
以理解为就是封装的概念。

提高了安全性

继承：

就是子类继承父类的特征和行为，使得子类对象（实例）具有父类的实例域和方法，或子类从父类继承方法，使得子类具有父类相同的行为。 

提高了代码的复用性

类与类之间有了联系，为多态创造基础

多态： 父类引用指向子类实例 

**多态的实现的必要条件:**

1. 存在继承关系
2. 存在方法重写
3. 父类引用指向子类对象

**多态的优点**

1. 简化了代码
2. 提高了维护性和扩展性



C#
多线程√

异步√
委托√
数据类型√
泛型√
异常 try catch finally√

反射√
特性√
索引器√
集合√

ArrayList

HashTable

List<T>

Dictionary<K,V>

HashSet<T>

Stack

Queue



？的使用√

（1）三元运算符 a = 3?3:2

（2）可空值类型 int? a = 4; 是Nullable<T>类型

（3） null 条件运算符(?.和?[]) , 是一种成员访问符的拓展 

?.表示成员访问运算符，主要用于对象属性、方法等成员访问，?[]表示元素访问运算符，主要用于集合中元素访问

 （4）null 合并运算符（??和??=） 

expr1??expr2

如果expr1结果为null，返回expr2的计算结果，如果expr1不为null，返回expr1的结果

??=是合并赋值运算符

a ??= b
//等价于

a = a ?? b

//等价于

if (a is null)
{
    a = b;
}



static，const，readonly√

静态变量属于类型，可以在声明或者静态构造函数中赋值，赋值后不可修改

const常量属于类型，不属于对象，声明就要初始化，且不可修改，效率高一点，只能用于基本数据类型和string

readonly属于对象，初始化后不可修改，可以在声明或者构造函数中初始化

const在编译时就已经确定，static和readonly在运行时确定

各种只读的场景：

为了提高程序的可读性和执行效率------常量

为了防止对象的值被改变------只读字段

向外暴露不允许被修改的数据------只读属性（静态或非静态）只有get，功能和常量有一些重叠

当希望成为常量的值不能被const时（类/自定义结构体）------静态只读字段

public readonly TestClass testClass = new TestClass();



控制反转IOC√

协变逆变ref out in√

原码反码补码√

解决有符号正数的加减运算，原码是二进制本身，正数的反码是原码，负数的反码是每位都取反，正数的补码就是原码，负数的补码是反码+1





wpf
绑定√
数据驱动√
路由事件√
style√
模板√
控件
自定义控件
常用方法

程序设计
六大原则
设计模式
排序算法



工作中的难点：
多个函数，参数列表，返回类型一样，条件不一样，用不同的函数
用委托


遇到这么解决：
技术知识：
在其他业务中去寻找答案
百度搜索
请教其他人

业务知识：

性能调查：
listview化
从控件入手

患者保険登录：
速度变慢
从log中查看耗时
先是得到所以处方签，然后得到这个患者的处方签
，然后得到这个患者的保険
其实在受付一览中就已经

核心业务：
来局设定的过去処方
想法：设置不同的模板

分割処方:
难点：排序+style
点击事件得到那个label



分割処方：

检索区域

数据展示区域

功能键区域



难点：

点击排序

DataGrid_LabelPresenterSortStyle 排序style

添加点击事件

判断是否点的表头，

给每个表头都加了Name，Name就是数据源的属性名，

还有定义了需要的排序项（有一个default，默认排序），

先判断点击的那一项是否是需要排序的

然后就是还需要一个变量来记录一下升序降序默认排序

还需要判断下次排序项目是否和上一次排序项目一致，如果一致，就在上次排序基础上进行排序

例如上次是升序，这次就是降序，如果不一致，就从升序开始排序

排序逻辑处理完后，需要在画面上能显现出按照上面排序的，对于排序的项目，文字下面标上下划线以示区分

然后制作一个排序图标箭头Path，在上面的逻辑处理中和Path的tag属性做关联，1表示升序，0表示降序，""表示默认排序



来局設定：

保険选择列表

模板选择器：

根据不同的保険类型





文件相关：
OpenFileDialog
FolderBrowserDialog
Path
File
Directory
FileInfo
DirectoryInfo
FileStream
StreamReader
StreamWriter


https://developer.aliyun.com/article/715728