using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Models
{
    public class Subject:BindableBase
    {
        private readonly List<Observer> _observers = new List<Observer>();

        private int _state;

        public int State
        {
            get => _state;
            set { SetProperty(ref _state, value); NotifyAllObservers(); }
        }

        public void AddObserver(Observer observer)
        {
            observer.Subject = this;
            _observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            _observers.ForEach(o => o.Update());
        }
    }
}
