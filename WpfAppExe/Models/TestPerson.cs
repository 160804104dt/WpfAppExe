using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppExe.Models
{
    public class TestPerson:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }

        private int age { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }
    }

    public class TestPerson1:DependencyObject
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(TestPerson1),new PropertyMetadata("张三"));

        public int Age 
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public static readonly DependencyProperty AgeProperty = DependencyProperty.Register("Age",typeof(int), typeof(TestPerson1));
    }
}
