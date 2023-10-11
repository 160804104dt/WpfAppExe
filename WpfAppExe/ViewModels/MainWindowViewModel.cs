using DataBase.DbDto;
using Newtonsoft.Json;
using Npgsql;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Unity;
using WpfAppExe.ActionBase;
using WpfAppExe.Core;
using WpfAppExe.Enum;
using WpfAppExe.Views;
using static WpfAppExe.Enum.EnumConstant;

namespace WpfAppExe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Command
        public ReactiveCommand ClickCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand Row4Command { get; set; } = new ReactiveCommand();
        public ReactiveCommand SortCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand LayoutCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand SocketCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand IOCCommand { get; set; } = new ReactiveCommand();
        
        public ReactiveCommand PreviewKeyDownCommand { get; set; } = new ReactiveCommand();
        #endregion

        #region Property
        int[] array = new int[11] { 5, 3, 7, 6, 4, 1, 0, 2, 9, 10, 8 };

        public List<HokenshaNoMDto> LinqTestList = new List<HokenshaNoMDto>();
        public List<HokenshaMatomeConfig> LinqTestList1 = new List<HokenshaMatomeConfig>();


        public BindableClass bindableClass { get; set; } = new BindableClass();

        public NpClass Title { get; set; } = new NpClass() { Name = "李四" };

        public ICommand MyCommand => new MyCommand(MyAction, MyCanExec);
        /// <summary>
        /// 冒泡排序
        /// </summary>
        public int[] BubbleSortArrays = new int[10000];
        /// <summary>
        /// 插入排序
        /// </summary>
        public int[] InsertSortArrays = new int[10000];
        /// <summary>
        /// 选择排序
        /// </summary>
        public int[] SelectionSortArrays = new int[10000];
        /// <summary>
        /// 快速排序
        /// </summary>
        public int[] QuickSortArrays = new int[1000];
        /// <summary>
        /// 希尔排序
        /// </summary>
        public int[] ShellSortArrays = new int[10000];
        /// <summary>
        /// 堆排序
        /// </summary>
        public int[] HeapSortArrays = new int[10000];
        /// <summary>
        /// 归并排序
        /// </summary>
        public int[] MergeSortArrays = new int[10000];
        /// <summary>
        /// 基数排序
        /// </summary>
        public int[] RadixSortArrays = new int[10000];
        /// <summary>
        /// 计数排序
        /// </summary>
        public int[] CountSortArrays = new int[10000];
        /// <summary>
        /// 桶排序
        /// </summary>
        public int[] BucketSortArrays = new int[10000];

        public ReactivePropertySlim<int?> Row1Select { get; set; } = new ReactivePropertySlim<int?>();

        public ReactivePropertySlim<string> Row1SelectedItem { get; set; } = new ReactivePropertySlim<string>();
        #endregion

        #region override
        protected override void InitData()
        {
            base.InitData();
            Init();
            Title.Name = "张三";
            bindableClass.Name = "3333";
            Thread thread1 = new Thread(ThreadMethod1);
            Thread thread2 = new Thread(ThreadMethod2);
            Thread thread3 = new Thread(ThreadMethod1,2);
            Thread thread4 = new Thread(ThreadMethod2,3);
            thread1.Start();
            //thread2.Start();
            thread2.Start(2);
            thread3.Start();
            thread4.Start();

            string filePath = "..\\..\\data\\1.jpg";
            string dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                dirPath = dirInfo.FullName;
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                FileInfo fileInfo = new FileInfo(filePath);
                string s = fileInfo.FullName;
            }
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            ClickCommand.Subscribe(o =>
            {
                ComponentWindow componentWindow = new ComponentWindow();
                if (componentWindow.DataContext is ComponentWindowViewModel vm)
                {
                    vm.SelectedTabIndex.Value = Convert.ToInt32((o as string));
                }
                componentWindow.ShowDialog();
            });

            Row4Command.Subscribe(o =>
            {
                if (o is string selectedIndex)
                {
                    if (selectedIndex == "1")
                    {
                        int value = 1234;
                        long commonSecond = 0;
                        long objectSecond = 0;
                        long genericSecond = 0;

                        Stopwatch stopwatch1 = new Stopwatch();
                        Stopwatch stopwatch2 = new Stopwatch();
                        Stopwatch stopwatch3 = new Stopwatch();
                        stopwatch1.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            Test(value);
                        }
                        stopwatch1.Stop();
                        commonSecond = stopwatch1.ElapsedMilliseconds;

                        stopwatch2.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            TestObject(value);
                        }
                        stopwatch2.Stop();
                        objectSecond = stopwatch2.ElapsedMilliseconds;

                        stopwatch3.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            Test<int>(value);
                        }
                        stopwatch3.Stop();
                        genericSecond = stopwatch3.ElapsedMilliseconds;

                        MessageBox.Show(commonSecond.ToString() + "\n" + objectSecond.ToString() + "\n" + genericSecond.ToString());

                        Test1<Stopwatch>(new Stopwatch());

                        Class1 class1 = new Class1(3);

                        Test2<Class1>(class1);
                    }
                    else if (selectedIndex == "2")
                    {
                        //升序
                        List<HokenshaNoMDto> list1 = LinqTestList.OrderBy(x => x.HokenshaNo).ToList();
                        //降序
                        List<HokenshaNoMDto> list2 = LinqTestList.OrderByDescending(x => x.HokenshaNo).ToList();
                        //分组
                        var grp = LinqTestList.OrderBy(x => x.HokenshaNo).GroupBy(x => x.HokenshaKanjiName).ToList();//list类型
                        Dictionary<string, List<HokenshaNoMDto>> grp1 = LinqTestList.OrderBy(x => x.HokenshaNo).GroupBy(x => x.HokenshaKanjiName).ToDictionary(x => x.Key, x => x.ToList());//字典类型
                                                                                                                                                                                            //查找
                        HokenshaNoMDto? f1 = LinqTestList.Find(x => x.PostalNo.Contains("22"));//符合条件的第一个元素
                        HokenshaNoMDto? f2 = LinqTestList.FindLast(x => x.PostalNo.Contains("22"));//符合条件的最后一个元素
                        List<HokenshaNoMDto> f3 = LinqTestList.FindAll(x => x.PostalNo.Contains("444")).OrderByDescending(x => x.HokenshaNo).ToList();//符合条件的所有元素

                        int f4 = LinqTestList.FindIndex(x => x.PostalNo.Contains("22"));//符合条件的第一个下标
                        int f5 = LinqTestList.FindLastIndex(x => x.PostalNo.Contains("22"));//符合条件的最后一个下标
                        var list3 = LinqTestList.Select(x => x.HokenshaNo).ToList();    //投影
                        var list4 = LinqTestList.SelectMany(x => x.HokenshaNo).ToList();//先找到HokenshaNo，再把HokenshaNo拆分下来
                        var list5 = LinqTestList.Join(LinqTestList1, t1 => t1.prefectureCode, t2 => t2.prefecture_code, (t1, t2) =>
                        {
                            if (t1.prefectureCode == t2.prefecture_code)
                            {
                                return new { t1, t2.hokensha_matome_kbn };
                            }
                            return null;
                        }).ToList();//join连接查询

                        var list6 = LinqTestList.Select(x => x.address1).Aggregate(new List<string>(), (a, p) =>
                        {
                            a.Add(p);
                            return a;
                        });

                        var list7 = LinqTestList.Select(x => x.HokenshaKanjiShortName).Aggregate(new List<string>(), (l, m) =>
                        {
                            l.Add(m);
                            return l;
                        });
                    }
                    else if (selectedIndex == "3")
                    {
                        delegate1 d1 = new delegate1(d1Func);
                        d1.Invoke(3, 2); //显式委托

                        d1NoName.Invoke(5, 5);//匿名委托

                        d1Lambda.Invoke(3, 3);//lambda表达式

                        delegate2 d2 = new delegate2(d2Func);
                        d2.Invoke();

                        Func<int, int> func4 = new Func<int, int>(usefunc4);
                        func4.Invoke(8);
                    }
                    else if (selectedIndex == "4")
                    {
                        //这个方法不再支持，会抛出异常
                        //Func<string, int, string> func = Dosomething;
                        //var asyncResult = func.BeginInvoke("JOY",0,null,null);
                        //string result = func.EndInvoke(asyncResult);
                        long time1 = DateTime.Now.Ticks;
                        long time2 = DateTime.Now.Ticks;
                        Thread thread5 = new Thread(Thread1);
                        Thread thread6 = new Thread(Thread2);
                        thread5.Start();
                        thread6.Start();



                    }
                    else if (selectedIndex == "5")
                    {
                        Task task = new Task(new Action(() =>
                        {
                            System.Diagnostics.Debug.WriteLine("");
                        }));
                        task.Start();

                        Task<HokenshaNoMDto> task1 = new Task<HokenshaNoMDto>(new Func<HokenshaNoMDto>(() =>
                        {
                            return new HokenshaNoMDto();
                        }));
                    }
                    else if (selectedIndex == "6")
                    {

                    }
                    else if (selectedIndex == "7")
                    {
                        var code = YouhouZaikeiCode.Naiteki.GetCode();
                        var name = YouhouZaikeiCode.Naiteki.GetDescription();

                        var code1 = YTSize.MiddleTZ.GetCode();
                        var name1 = YTSize.MiddleTZ.GetDescription();
                    }
                    else if (selectedIndex == "8")
                    {
                    }
                }
            });

            SortCommand.Subscribe(o =>
            {
                Random random = new Random();
                if (o is string index)
                {
                    switch (index)
                    {
                        //冒泡排序
                        case "1":
                            for (int i = 0; i < 10000; i++)
                            {
                                BubbleSortArrays[i] = random.Next(1, 10000);
                            }
                            BubbleSort(BubbleSortArrays);
                            break;
                        //插入排序
                        case "2":
                            for (int i = 0; i < 10000; i++)
                            {
                                InsertSortArrays[i] = random.Next(1, 10000);
                            }
                            InsertSort(InsertSortArrays);
                            break;
                        //选择排序
                        case "3":
                            for (int i = 0; i < 10000; i++)
                            {
                                SelectionSortArrays[i] = random.Next(1, 10000);
                            }
                            SelectionSort(SelectionSortArrays);
                            break;
                        //快速排序
                        case "4":
                            for (int i = 0; i < 1000; i++)
                            {
                                QuickSortArrays[i] = random.Next(1, 10000);
                            }
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            QuickSort(QuickSortArrays, 0, QuickSortArrays.Length - 1);
                            stopwatch.Stop();
                            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
                            Print(QuickSortArrays);
                            break;
                        //希尔排序
                        case "5":
                            for (int i = 0; i < 10000; i++)
                            {
                                ShellSortArrays[i] = random.Next(1, 10000);
                            }
                            ShellSort(ShellSortArrays);
                            break;
                        //堆排序
                        case "6":
                            for (int i = 0; i < 10000; i++)
                            {
                                HeapSortArrays[i] = random.Next(1, 10000);
                            }
                            HeapSort(HeapSortArrays);
                            break;
                        //归并排序
                        case "7":
                            for (int i = 0; i < 10000; i++)
                            {
                                MergeSortArrays[i] = random.Next(1, 10000);
                            }
                            MergeSort(MergeSortArrays);
                            break;
                        //基数排序
                        case "8":
                            for (int i = 0; i < 10000; i++)
                            {
                                RadixSortArrays[i] = random.Next(1, 10000);
                            }
                            RadixSort(RadixSortArrays);
                            break;
                        //计数排序
                        case "9":
                            for (int i = 0; i < 10000; i++)
                            {
                                CountSortArrays[i] = random.Next(1, 10000);
                            }
                            CountingSort(CountSortArrays);
                            break;
                        //桶排序
                        case "10":
                            for (int i = 0; i < 10000; i++)
                            {
                                BucketSortArrays[i] = random.Next(1, 10000);
                            }
                            BucketSort(BucketSortArrays);
                            break;
                    }
                }
            });

            LayoutCommand.Subscribe(o =>
            {
                if (o is string selectedIndex)
                {
                    switch (selectedIndex)
                    {
                        case "1":
                            LayoutWindow layoutWindow = new LayoutWindow();
                            layoutWindow.ShowDialog();
                            break;
                    }
                }
            });

            SocketCommand.Subscribe(o =>
            {
                System.Diagnostics.Debug.WriteLine("Client Running...");
                string msg = "这个是客户端的消息";
                string fileName = Path.Combine(Environment.CurrentDirectory, "test.jpg");
                string str1 = SendPictures(fileName, msg);
                str1 = str1 + "#" + str1 + "#" + str1 + "#" + str1 + "#" + str1;
                Send(str1);
            });

            IOCCommand.Subscribe(o =>
            {
                DIP();
            });

            PreviewKeyDownCommand.Subscribe(o =>
            {
                if(o is KeyEventArgs e)
                {
                    if (e.Key == Key.Right)
                    {
                        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                        request.Wrapped = true;
                        if(e.OriginalSource is Button button)
                        {
                            button.MoveFocus(request);
                        }
                    }
                }
            });

            Row1Select.Subscribe(o =>
            {
                if (Row1Select != null)
                {

                }
            });

            Row1SelectedItem.Subscribe(o =>
            {
                if (Row1SelectedItem != null && Row1SelectedItem.Value != null)
                {

                }
            });
        }
        #endregion

        #region 泛型
        private void Test(int a)
        {

        }

        private void TestObject(object a)
        {

        }

        private void Test<T>(T a)
        {

        }

        //限制了参数的类型，必须是class
        private void Test1<T>(T a) where T : class
        {

        }

        //new表示参数必须有无参构造函数
        private void Test2<T>(T a) where T : new()
        {

        }
        #endregion

        #region 排序算法

        ///<summary>
        /// 稳定排序：如果 a 原本在 b 的前面，且 a == b，排序之后 a 仍然在 b 的前面，则为稳定排序。
        /// 非稳定排序：如果 a 原本在 b 的前面，且 a == b，排序之后 a 可能不在 b 的前面，则为非稳定排序。
        /// 原地排序：原地排序就是指在排序过程中不申请多余的存储空间，只利用原来存储待排数据的存储空间进行比较和交换的数据排序。
        /// 非原地排序：需要利用额外的数组来辅助排序。
        /// 时间复杂度：一个算法执行所消耗的时间。
        /// 空间复杂度：运行完一个算法所需的内存大小。
        ///</summary>

        /// <summary>
        /// 冒泡排序
        /// 冒泡排序是每次将相邻的两个数进行排序，第一轮过后，最大(小)的数会排到最后一个；
        /// 剩下的数重复上述排序过程，直到最后有序；
        /// 稳定排序，
        /// 时间复杂度：最好O(n)，最坏O(n2)
        /// 空间复杂度：O(1)
        /// </summary>
        private void BubbleSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ShowBusyIndicator();
            for (int i = 0; i < arrays.Length; i++)
            {
                bool flag = true;
                for (int j = 1; j < arrays.Length - i; j++)
                {
                    if (arrays[j - 1] > arrays[j])
                    {
                        flag = false;
                        int temp = arrays[j - 1];
                        arrays[j - 1] = arrays[j];
                        arrays[j] = temp;
                    }
                }
                if (flag)
                    break;
            }
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            Print(arrays);
            HideBusyIndicator();
        }
        /// <summary>
        /// 插入排序
        /// 将前i个数据（初始为1）假定为有序序列，依次遍历数据，将当前数据插入到前述有序序列的适当位置，形成前i+1个有序序列，依次遍历完所有数据，直到所有数据有序，适合部分有序的数列
        /// 数据反序，时间耗时O(n2)，正序时，时间耗时O(n)
        /// 平均时间复杂度O(n2)，空间复杂度O(1)
        /// 稳定排序
        /// </summary>
        /// <param name="arrays"></param>
        private void InsertSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 选择排序
        /// 遍历所有数据，选出最大或者最小的数放在第一个，再从剩下的数组中进行重复的操作；用一个游标标记每次排序排到的下标
        /// 不稳定排序
        /// 时间复杂度：O(n2)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="arrays"></param>
        private void SelectionSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < arrays.Length - 1; i++)
            {
                int k = i;
                for (int j = i + 1; j < arrays.Length; j++)
                {
                    if (arrays[j] < arrays[k])
                        k = j;
                }
                if (k != i)
                {
                    int temp = arrays[k];
                    arrays[k] = arrays[i];
                    arrays[i] = temp;
                }
            }
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            Print(arrays);
        }
        /// <summary>
        /// 快速排序
        /// 快速排序是对冒泡排序的一种改进
        /// 快速排序采用分治算法，从数列中挑选一个数作为中间值，依次遍历数据，所以所有比中间值小的放在左边，比中间值小的放在右边；
        /// 按照此方法对左右两个子序列分别进行递归操作，直到所有数据有序
        /// 最理想情况下，每次选择的中间数恰好能把序列等分，时间复杂度为O(NlogN)；
        /// 最坏情况下，每次选择的中间数是当前序列的最大或者最小的数，时间复杂度为O(n2)
        /// 平均时间复杂度为O(nlogN)，空间复杂度为O(logN)
        /// 不稳定排序
        /// </summary>
        /// <param name="arrays"></param>
        private void QuickSort(int[] arrays, int left, int right)
        {
            if (left > right)
                return;
            int middle = Quick_Sort(arrays, left, right);
            QuickSort(arrays, left, middle - 1);
            QuickSort(arrays, middle + 1, right);
        }

        private int Quick_Sort(int[] data, int left, int right)
        {
            int key = data[left];
            while (left < right)
            {
                //从后向前遍历，大于基准值的放在右边
                while (data[right] > key && right > left)
                    right--;
                data[left] = data[right];
                //从前向后遍历，小于基准值的放在左边
                while (data[left] < key && right > left)
                    left++;
                data[right] = data[left];
            }
            data[left] = key;
            return left;
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="arrays"></param>
        private void ShellSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arrays"></param>
        private void HeapSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arrays"></param>
        private void MergeSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 基数排序
        /// </summary>
        /// <param name="arrays"></param>
        private void RadixSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="arrays"></param>
        private void CountingSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }
        /// <summary>
        /// 桶排序
        /// </summary>
        /// <param name="arrays"></param>
        private void BucketSort(int[] arrays)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
            //Print(arrays);
        }

        /// <summary>
        /// 打印数组
        /// </summary>
        /// <param name="arrays"></param>
        private void Print(int[] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                System.Diagnostics.Debug.Write(arrays[i]);
                System.Diagnostics.Debug.Write("  ");
                if ((i + 1) % 10 == 0)
                    System.Diagnostics.Debug.WriteLine("");
            }
        }



        #region Linq
        public void Init()
        {
            string connStr = "server=192.168.0.169;username=postgres;password=postgres;database=APPLICATION";
            NpgsqlConnection connection = new NpgsqlConnection(connStr);
            try
            {
                connection.Open();
                string commandStr = "select * from common.hokensha_no_m";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(commandStr, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable == null || dataTable.Rows.Count == 0)
                    return;
                var res = JsonConvert.SerializeObject(dataTable);
                var mt = JsonConvert.DeserializeObject<List<HokenshaNoMDto>>(res);
                mt.ForEach(o =>
                {
                    LinqTestList.Add(o);
                });

                string commandStr1 = "select * from common.hokensha_matome_config";
                NpgsqlDataAdapter adapter1 = new NpgsqlDataAdapter(commandStr1, connection);
                DataTable dataTable1 = new DataTable();
                adapter1.Fill(dataTable1);
                if(dataTable1 == null || dataTable1.Rows.Count == 0)
                    return;
                var res1 = JsonConvert.SerializeObject(dataTable1);
                var mt1 = JsonConvert.DeserializeObject<List<HokenshaMatomeConfig>>(res1);
                mt1.ForEach(o =>
                {
                    LinqTestList1.Add(o);
                });
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion


        #endregion

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
        private static string d1Func(int a, int b)
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

        delegate1 d1 = new delegate1((x, y) =>
        {
            return (x + y).ToString();
        });

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
        Func<int> func1 = new Func<int>(() =>
        {
            return 1;
        });

        Func<int,string> func2 = new Func<int,string>(a =>
        {
            return "r";
        });

        Func<int, int, string> func3 = (a, b) =>
        {
            return (a + b).ToString();
        };

        private int usefunc4(int a)
        {
            return a;
        }

        Func<int, int,string> action6 = new Func<int, int,string>(d1Func);
        #endregion

        #endregion

        #region 多线程
        private void ThreadMethod1()
        {
            System.Diagnostics.Debug.WriteLine("this is new thread without paramater");
        }
        private void ThreadMethod2(object? a)
        {
            System.Diagnostics.Debug.WriteLine("this is new thread with paramater");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="millisecondTimeout"></param>
        /// <returns></returns>
        private string Dosomething(string name,int millisecondTimeout)
        {
            System.Diagnostics.Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00}执行");
            return name;
        }

        #region thread demo
        private void dosth()
        {
            for(int j = 0; j < 1000; j++)
            {
                int a = 15;
                a = a * a ;
            }
        }

        private void Thread1()
        {
            for(int i = 0; i < 1000; i++)
            {
                dosth();
                System.Diagnostics.Debug.WriteLine("1");
            }
        }

        private void Thread2()
        {
            for (int i = 0; i < 1000; i++)
            {
                dosth();
                System.Diagnostics.Debug.WriteLine("2");
                MyStruct myStruct = new MyStruct();
                myStruct.age = 5;
            }
        }
        #endregion

        /// <summary>
        /// 回调函数
        /// </summary>
        private void Callback() { System.Diagnostics.Debug.WriteLine("执行回调"); }
        #endregion

        #region Task
        #endregion

        #region 事件
        //event delegate1 myEvent;
        #endregion

        #region 命令
        public void MyAction(object parameter)
        {
            Debug.WriteLine("这是自定义的命令");
        }

        public bool MyCanExec(object parameter)
        {
            return true;
        }
        #endregion

        #region Socket

        private static string SendPictures(string fileName,string str)
        {
            string str1;
            if (File.Exists(fileName))
            {
                FileInfo file = new FileInfo(fileName);
                var stream = file.OpenRead();
                byte[] buffer = new byte[file.Length];
                //
                stream.Read(buffer,0,Convert.ToInt32(file.Length));
                str1 = Convert.ToBase64String(buffer);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("文件不存在");
                str1 = "";
            }
            str1 = str + ")" + str1;
            return str1;
        }

        private static void Send(string str)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect("localhost",8500);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("发送消息");
            NetworkStream streamToServer = client.GetStream();
            byte[] buffer1 = Encoding.UTF8.GetBytes(str);
            streamToServer.Write(buffer1,0,buffer1.Length);
            client.Close();
        }
        #endregion

        #region 依赖注入原则
        private void DIP()
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterSingleton<DataAccess, AccessDal>();
            //DataAccess dataAccess = container.Resolve<DataAccess>();
            //dataAccess.Add();
            DataAccess dataAccess = new AccessDal();
            dataAccess.Add();
            DataAccess dataAccess1 = new SqlServerDal();
            dataAccess1.Add();
        }
        #endregion

    }

    public class Class1
    {
        public Class1(){}
        public Class1(int a){}
    }

    #region 依赖属性和INotifyPropertyChanged
    public class DpClass : DependencyObject
    {
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("NameProperty",typeof(string),typeof(DpClass),new PropertyMetadata("张三"));
    }

    public class NpClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }
    }

    public class BindableClass : BindableBase
    {
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value);}
    }
    #endregion

    public struct MyStruct:MyInterface
    {
        public int age;
        public string name;

        public void GetName(int na)
        {
            Console.WriteLine(na);
        }

        public void SayHello()
        {
            throw new NotImplementedException();
        }
    }

    public interface MyInterface
    {
       void SayHello();
    }

    #region 依赖注入
    public class A
    {   
        //A依赖于B
        public B b;
        //public A() 这样写的话，如果B的new方法发生了改变，就需要重写*1的方法，耦合性很高
        //{
        //    b = new B(); *1
        //}

        //public A(B b) 这种方式是构造方法注入
        //{
        //    this.b = b;
        //}
    }

    public class B
    {

    }

    public interface People
    {

    }

    public interface DataAccess
    {
        void Add();
    }

    public class SqlServerDal:DataAccess
    {
        public void Add()
        {
            Console.WriteLine("添加一条新订单");
        }
    }

    //3.需求发生变更，需要将数据库改成Access，就要重新定义Access类
    public class AccessDal: DataAccess
    {
        public void Add()
        {
            Console.WriteLine("添加一条新订单");
        }
    }

    public interface DependenceInterface
    {
        void SetDependence(DataAccess dataAccess);
    }

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
    #endregion

}
