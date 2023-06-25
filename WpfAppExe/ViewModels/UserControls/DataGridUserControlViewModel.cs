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
using WpfAppExe.Core;
using WpfAppExe.Manager;

namespace WpfAppExe.ViewModels.UserControls
{
    public class DataGridUserControlViewModel:ViewModelBase
    {

        public ReactiveCollection<HokenshaNoMDto> DataList { get; set; } = new ReactiveCollection<HokenshaNoMDto>();
        protected override void InitData()
        {
            base.InitData();
            Init();
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
                    return;
                var res = JsonConvert.SerializeObject(dataTable);
                var mt = JsonConvert.DeserializeObject<List<HokenshaNoMDto>>(res);
                mt.ForEach(o =>
                {
                    DataList.Add(o);
                });
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
