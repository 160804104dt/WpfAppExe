using DataBase.DbDto;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Service
{
    public class BaseService<T>
    {
        public static List<T> GetAllData()
        {
            List<T> list = new List<T>();

            PropertyInfo[] infos = typeof(T).GetProperties();

            string connStr = "server=192.168.0.169;username=postgres;password=postgres;database=APPLICATION";
            NpgsqlConnection connection = new NpgsqlConnection(connStr);
            try
            {
                connection.Open();
                string commandStr = "select * from g200010.user_basic_info_m";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(commandStr, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}
