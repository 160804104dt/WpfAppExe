using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppExe.Converter
{
    public class PrefectureCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "未知";
            else
            {
                if(value is string prefectureCode)
                {
                    string connStr = "server=192.168.0.169;username=postgres;password=postgres;database=APPLICATION";
                    NpgsqlConnection connection = new NpgsqlConnection(connStr);
                    try
                    {
                        connection.Open();
                        string commandStr = string.Format("select * from common.prefecture_m where prefecture_code = '{0}'", prefectureCode);
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(commandStr, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        if (dataTable == null || dataTable.Rows.Count == 0)
                            return string.Empty;
                        else if(dataTable.Rows.Count == 1)
                        {
                            string prefectureName = dataTable.Rows[0].ItemArray[2].ToString();
                            return prefectureName;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
