using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Models
{
    public class Person:BindableBase
    {
        private string name;

        private int age;

        private string address;

        private string contact;     
        
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public int Age { get => age; set=>SetProperty(ref age, value); }
        public string Address { get => address; set => SetProperty(ref address, value); }
        public string Contact { get => contact; set=>SetProperty(ref contact, value); }
    }
}
