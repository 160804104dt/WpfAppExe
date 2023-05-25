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

            if ("之前听泡泡老师说伍泽凯小朋友上课表现非常好，上完后发现伍泽凯小朋友上课表现确实挺不错的，遵守课堂纪律，而且组装机器人的速度也非常快，继续保持就好".Equals("#"))
            {
                if(list.Count > 0)
                {
                    Console.WriteLine("这样的话就是很好了");
                }
            }

            return list;
        }
    }
}
