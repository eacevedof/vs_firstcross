/**
* @file:\NsFirstapp\NsFirstapp\models\ModelUser.cs 1.0.1
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace NSTheapplication.Models
{
    [Table("base_user")]
    public class ModelUser:TheApplicationModel
    {

        public string processflag { get; set; }
        public string insert_platform { get; set; }
        public string insert_user { get; set; }
        public string insert_date { get; set; }
        public string update_platform { get; set; }
        public string update_user { get; set; }
        public string update_date { get; set; }
        public string delete_platform { get; set; }
        public string delete_user { get; set; }
        public string delete_date { get; set; }
        public string cru_csvnote { get; set; }
        public string is_erpsent { get; set; }
        public string is_enabled { get; set; }
        public int i { get; set; }

        [PrimaryKey, AutoIncrement] 
        public int id { get; set; }
        public string code_erp { get; set; }
        public string description { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bo_login { get; set; }
        public string bo_password { get; set; }
        public string md_login { get; set; }
        public string md_password { get; set; }
        public string language { get; set; }
        public int id_language { get; set; }
        public int id_start_module { get; set; }
        public string path_picture { get; set; }
        public int id_profile { get; set; }
        public string code_type { get; set; }
        public string login_ip { get; set; }
        public string login_hour { get; set; }
        public string login_session { get; set; }
        public string login_latitude { get; set; }
        public string login_length { get; set; }

        public ModelUser(string sTableName) : base(sTableName)
        {
            this.create_table();
            if (string.IsNullOrEmpty(sTableName))
                sTableName = "base_user";
            this.sTableName = sTableName;
        }

        private void drop_table()
        {
            string sSQL = "DROP TABLE "+this.sTableName+";";
            this.execute(sSQL);
        }//drop_table

        private void create_table()
        {
            this.oSQLiteConn.CreateTable<ModelUser>();
        }//create_table

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}"
                ,this.id,this.code_erp, this.description, this.insert_user, this.insert_date, this.update_date);
        }//ToString

    }//ModelUser
}//NSTheapplication.Models
