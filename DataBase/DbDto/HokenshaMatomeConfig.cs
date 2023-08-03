using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbDto
{
    public class HokenshaMatomeConfig: BindableBase
    {
        public string hokensha_matome_kbn;
        public string prefecture_code;
        public string kokuho_hoken_kbn;
        public string hokensha_no;
        public DateTime tekiyou_start_date;
        public string matome_hokensha_no;
        public string matome_hokensha_name;
        public string rezept_kbn;
        public int created_by;
        public DateTime created_at;
        public int updated_by;
        public DateTime updated_at;
    }
}
