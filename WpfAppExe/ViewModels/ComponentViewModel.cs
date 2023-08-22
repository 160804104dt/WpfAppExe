using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExe.Core;
using WpfAppExe.ViewModels.UserControls;
using WpfAppExe.Views.UserControls;

namespace WpfAppExe.ViewModels
{
    public class ComponentWindowViewModel: ViewModelBase
    {
        public ReactiveProperty<int> SelectedTabIndex { get; set; } = new ReactiveProperty<int>();
        public ListBoxUserControl listBoxUserControl { get; set; } = new ListBoxUserControl();
        public ReactiveProperty<ListBoxUserControlViewModel> ListBoxUserControl { get; set; } = new ReactiveProperty<ListBoxUserControlViewModel>(new ListBoxUserControlViewModel());
        public ReactiveProperty<DataGridUserControlViewModel> DataGridUserControl { get; set; } = new ReactiveProperty<DataGridUserControlViewModel>(new DataGridUserControlViewModel());
        
        public ReactivePropertySlim<string> ButtonContext { get; set; } = new ReactivePropertySlim<string>("dddddddd");
        /// <summary>
        /// 
        /// </summary>
        public ReactiveCommand AncestorCommand { get; set; } = new ReactiveCommand();

        protected override void InitData()
        {
            base.InitData();
            //Init();
            Console.WriteLine("画面数据初始化成功");
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            SelectedTabIndex.Subscribe(o =>
            {
                Console.WriteLine(SelectedTabIndex.Value);
            });

            AncestorCommand.Subscribe(o =>
            {
                MessageBox.Show("这是FindAncestor，向上找的内容");
                var Buttonlist = GetControlList<System.Windows.Controls.Button>();
            });

        }
    }
}
