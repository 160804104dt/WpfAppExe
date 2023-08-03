using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppExe.Views.UserControls
{
    /// <summary>
    /// ListBoxUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxUserControl : UserControl
    {
        public ListBoxUserControl()
        {
            InitializeComponent();
            MyListBox.AddHandler(MouseRightButtonUpEvent,new RoutedEventHandler(MouseRightButtonUp),true);

        }

        private void MouseRightButtonUp(object e, RoutedEventArgs arg)
        {
            MessageBox.Show("方法1");
        }

        private void MyListBox_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("方法2");
        }
    }
}
