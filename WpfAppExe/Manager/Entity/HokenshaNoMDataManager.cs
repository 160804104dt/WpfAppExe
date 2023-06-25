using DataBase.DbDto;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Manager.Interface;

namespace WpfAppExe.Manager.Entity
{
    public class HokenshaNoMDataManager : BaseDataManager<HokenshaNoMDto>, IHokenshaNoMDataManager
    {
        public int SellectAll()
        {
            if (!IsLoaded)
            {
                List<HokenshaNoMDto> list = new List<HokenshaNoMDto>();

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
                        return 0;
                    var res = JsonConvert.SerializeObject(dataTable);
                    var mt = JsonConvert.DeserializeObject<List<HokenshaNoMDto>>(res);
                    if (mt.Count > 0)
                    {
                        this.AddRange(mt);
                        return mt.Count;
                    }
                }
                finally
                {
                    connection.Close();
                }

                if (list != null && list.Count > 0)
                {
                    this.AddRange(list);
                    IsLoaded = true;
                    return list.Count;
                }
                return 0;
            }
            else
            {
                return this.Count;
            }
        }
    }
}
