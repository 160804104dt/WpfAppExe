using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExe.Core;
using WpfAppExe.Views;

namespace WpfAppExe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand ClickCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand GenericCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand SortCommand { get; set; } = new ReactiveCommand();

        int[] array = new int[11] {5,3,7,6,4,1,0,2,9,10,8};

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

        protected override void RegisterCommands()
        {
            base.RegisterCommands();

            ClickCommand.Subscribe(o =>
            {
                ComponentWindow componentWindow = new ComponentWindow();
                if(componentWindow.DataContext is ComponentWindowViewModel vm)
                {
                    vm.SelectedTabIndex.Value = Convert.ToInt32((o as string));
                }
                componentWindow.ShowDialog();
            });

            GenericCommand.Subscribe(o =>
            {
                int value = 1234;
                long commonSecond = 0;
                long objectSecond = 0;
                long genericSecond = 0;

                Stopwatch stopwatch1 = new Stopwatch();
                Stopwatch stopwatch2 = new Stopwatch();
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch1.Start();
                for(int i = 0; i < 100000000; i++)
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

                MessageBox.Show(commonSecond.ToString()+"\n"+ objectSecond.ToString() + "\n" + genericSecond.ToString());

                Test1<Stopwatch>(new Stopwatch());

                Class1 class1 = new Class1(3);

                Test2<Class1>(class1);
            });

            SortCommand.Subscribe(o =>
            {
                Random random = new Random();
                if(o is string index)
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
                            QuickSort(QuickSortArrays,0,QuickSortArrays.Length-1);
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
        }

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
        private void Test2<T>(T a)where T : new()
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
            for(int i = 0; i < arrays.Length; i++)
            {
                bool flag = true;
                for(int j = 1;j< arrays.Length - i; j++)
                {
                    if(arrays[j-1] > arrays[j])
                    {
                        flag = false;
                        int temp = arrays[j-1];
                        arrays[j-1] = arrays[j];
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
        /// 将前i个数据（初始为1）假定为有序序列，依次遍历数据，将当前数据插入到前述有序序列的适当位置，形成前i+1个有序序列，依次遍历完所有数据，直到所有数据有序
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
            for(int i = 0; i < arrays.Length - 1; i++)
            {
                int k = i;
                for(int j = i+1; j < arrays.Length; j++)
                {
                    if(arrays[j] < arrays[k])
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
        private void QuickSort(int[] arrays,int left,int right)
        {
            if (left > right)
                return;
            int middle = Quick_Sort(arrays,left,right);
            QuickSort(arrays, left, middle-1);
            QuickSort(arrays, middle + 1, right);
        }

        private int Quick_Sort(int[] data,int left,int right)
        {
            int key = data[left];
            while(left < right)
            {
                //从后向前遍历，大于基准值的放在右边
                while (data[right] > key && right>left)
                    right--;
                data[left] = data[right];
                //从前向后遍历，小于基准值的放在左边
                while(data[left] < key && right>left)
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

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(DpClass),new PropertyMetadata(""));
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
}
