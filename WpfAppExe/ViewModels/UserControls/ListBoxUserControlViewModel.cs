using DataBase.DbDto;
using Newtonsoft.Json;
using Npgsql;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfAppExe.Core;
using WpfAppExe.Models;

namespace WpfAppExe.ViewModels.UserControls
{
    public class ListBoxUserControlViewModel:ViewModelBase
    {
        public List<HokenshaNoMDto> DataSource = new List<HokenshaNoMDto>();
        public ReactiveCollection<HokenshaNoMDto> DataList { get; set; } = new ReactiveCollection<HokenshaNoMDto>();

        public ReactiveCommand SortAscCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand SortDescCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand GroupCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand FindCommand { get; set; } = new ReactiveCommand();
        public ReactiveProperty<string> SearchName { get; set; } = new ReactiveProperty<string>("");

        protected override void InitData()
        {
            base.InitData();
            Init();
            DataList.AddRangeOnScheduler(DataSource);
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            SortAscCommand.Subscribe(o =>
            {
                var list = DataSource.OrderBy(x => x.HokenshaNo).ToList();
                DataList.Clear();
                DataList.AddRangeOnScheduler(list);
            });

            SortDescCommand.Subscribe(o =>
            {
                var list = DataSource.OrderByDescending(x => x.HokenshaNo).ToList();
                DataList.Clear();
                DataList.AddRangeOnScheduler(list);
            });

            GroupCommand.Subscribe(o =>
            {
                var grp = DataSource.OrderBy(x=>x.HokenshaNo).GroupBy(x => x.HokenshaKanjiName).ToList();
                var grp1 = DataSource.OrderBy(x => x.HokenshaNo).GroupBy(x => x.HokenshaKanjiName).ToDictionary(x=>x.Key,x=>x.ToList());
                DataList.Clear();
                var list = grp.SelectMany(x => x.ToList()).ToList();
                DataList.AddRangeOnScheduler(list);
            });


            FindCommand.Subscribe(o =>
            {
                var list = DataSource.FindAll(x => x.PostalNo.Contains(SearchName.Value)).OrderByDescending(x=>x.HokenshaNo).ToList();
                var item = DataSource.Find(x => x.PostalNo.Contains(SearchName.Value));
                DataList.Clear();
                DataList.AddRangeOnScheduler(list);
            });
        }

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
                    return ;
                var res = JsonConvert.SerializeObject(dataTable);
                var mt = JsonConvert.DeserializeObject<List<HokenshaNoMDto>>(res);
                DataSource.AddRange(mt);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
