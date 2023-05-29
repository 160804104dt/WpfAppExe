using DataBase.DbDto;
using DataBase.Service;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfAppExe.Manager.Interface;
using BCrypt;
using System.Security.Cryptography;

namespace WpfAppExe.Manager.Entity
{
    public class UserBasicInfoMDataManager : BaseDataManager<UserBasicInfoMDto>, IUserBasicInfoMDataManager
    {
        public UserBasicInfoMDto GetUserBasicInfoMDto(string loginId, string password)
        {
            UserBasicInfoMDto user = this.Find(o => o.login_id.Equals(loginId) && o.password.Equals(password));
            return user;
        }

        public int SellectAll()
        {
            if (!IsLoaded)
            {
                List<UserBasicInfoMDto> list = new List<UserBasicInfoMDto>();

                string connStr = "server=192.168.0.169;username=postgres;password=postgres;database=APPLICATION";
                NpgsqlConnection connection = new NpgsqlConnection(connStr);
                try
                {
                    connection.Open();
                    string commandStr = "select * from g200010.user_basic_info_m";
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(commandStr, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable == null || dataTable.Rows.Count == 0)
                        return 0;
                    var res = JsonConvert.SerializeObject(dataTable);
                    var mt = JsonConvert.DeserializeObject<List<UserBasicInfoMDto>>(res);
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
