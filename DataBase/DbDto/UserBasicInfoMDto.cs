using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbDto
{
    public class UserBasicInfoMDto
    {
        public int user_seq;
        public string login_id;
        public string password;
        public string user_name;
        public string user_kana_name;
        public string user_display_name;
        public string email_address;
        public string mayaku_license_no;
        public string memo;
        public string user_image_file;
        public string valid_period_start_date;
        public string valid_period_end_date;
        public string renzoku_ninshou_failure_kaisuu;
        public string login_kaisuu;
        public string zenkai_login_date_time;
        public string zenkai_password_change_date_time;
        public string is_deleted;
        public string created_by;
        public DateTime created_at;
        public string updated_by;
        public DateTime updated_at;
    }
}
