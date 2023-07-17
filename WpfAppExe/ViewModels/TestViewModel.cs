using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Core;

namespace WpfAppExe.ViewModels
{
    public class TestViewModel:ViewModelBase
    {
        public ReactiveCommand c1 { get; set; } = new ReactiveCommand();

        public ReactiveProperty<string> c2 { get; set; } = new ReactiveProperty<string>();

        public ReactivePropertySlim<string> c3 { get; set; } = new ReactivePropertySlim<string>();

        public ReactiveCollection<TestClass> c4 { get; set; } = new ReactiveCollection<TestClass>();

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            c1.Subscribe(o =>
            {

            });

            c4.ObserveElementProperty(p => p.a).Subscribe(o =>
            {

            });

        }
    }

    public class TestClass: INotifyPropertyChanged
    {
        public int a;
        public string b;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
