using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppExe.Core;
using WpfAppExe.Models;

namespace WpfAppExe.ViewModels
{
    public class Window2ViewModel:ViewModelBase
    {
        public ReactiveCollection<Person> List { get; set; } = new ReactiveCollection<Person>();

        protected override void InitData()
        {
            base.InitData();
            PrepareData().ForEach(o =>
            {
                List.Add(o);
            });

            Action action = () => {
                System.Diagnostics.Debug.WriteLine("action");
                Run();
            };
            Action action1 = new Action(() => {
                System.Diagnostics.Debug.WriteLine("action1");
                Run();
            });
            action.Invoke();
            action1.Invoke();

            Action action2 = Run;
            action2.Invoke();

            Action<int> action3 = (x) => {
                System.Diagnostics.Debug.WriteLine(x);
            };
            action3.Invoke(9);

            Func<int> func = () =>
            {
                return 2;
            };
            System.Diagnostics.Debug.WriteLine("func");
            System.Diagnostics.Debug.WriteLine(func.Invoke());

            Func<int, int> func1 = new Func<int, int>(x =>
            {
                return x * 5;
            });
            System.Diagnostics.Debug.WriteLine("func1");
            System.Diagnostics.Debug.WriteLine(func1.Invoke(4));

            Func<int,int,int> func2 = (x,y) => x*y+5;
            System.Diagnostics.Debug.WriteLine("func2");
            System.Diagnostics.Debug.WriteLine(func2.Invoke(4,6));

            System.Diagnostics.Debug.WriteLine("================================");

            IEnumerable<Person> stringQuery =
                from item in List
                where item.Age > 35 
                orderby item.Age
                select item;

            List<Person> list = stringQuery.ToList();
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            FinishInteractionCommand.Execute();
        }

        private List<Person> PrepareData()
        {
            List<Person> data = new List<Person>();
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                data.Add(new Person()
                {
                    Name = i.ToString() + "号",
                    Age = random.Next(15, 48),
                    Address = i.ToString() + "街区",
                    Contact = (10000 + i).ToString()
                });
            }

            var list = data.Where(x => x.Age > 30).ToList();

            return list;
        }

        private void Run()
        {
            System.Diagnostics.Debug.WriteLine("Run 方法");
        }
    }
}
