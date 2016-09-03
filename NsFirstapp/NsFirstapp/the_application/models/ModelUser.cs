/**
* @file:\NsFirstapp\NsFirstapp\models\ModelUser.cs 1.0.1
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using NsFirstapp.Interfaces;
using System.IO;

namespace NSTheapplication.Models
{
    [Table("base_user")]
    public class ModelUser:TheApplicationModel
    {
        [MaxLength(5)]
        public string processflag { get; set; }
        [MaxLength(3),Default(true,"2")]
        public string insert_platform { get; set; }
        [MaxLength(15)]
        public string insert_user { get; set; }
        [MaxLength(14)]
        public string insert_date { get; set; }
        [MaxLength(3)]
        public string update_platform { get; set; }
        [MaxLength(15)]
        public string update_user { get; set; }
        [MaxLength(14)]
        public string update_date { get; set; }
        [MaxLength(3)]
        public string delete_platform { get; set; }
        [MaxLength(15)]
        public string delete_user { get; set; }
        [MaxLength(14)]
        public string delete_date { get; set; }
        [MaxLength(500)]
        public string cru_csvnote { get; set; }
        [MaxLength(3),Default(true,"0")]
        public string is_erpsent { get; set; }
        [MaxLength(3),Default(true,"1")]
        public string is_enabled { get; set; }
        public int i { get; set; }

        [PrimaryKey, AutoIncrement] 
        public int id { get; set; }
        [MaxLength(25)]
        public string code_erp { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
        [MaxLength(100)]
        public string first_name { get; set; }
        [MaxLength(100)]
        public string last_name { get; set; }
        [MaxLength(15)]
        public string bo_login { get; set; }
        [MaxLength(250)]
        public string bo_password { get; set; }
        [MaxLength(15)]
        public string md_login { get; set; }
        [MaxLength(250)]
        public string md_password { get; set; }
        [MaxLength(50)]
        public string language { get; set; }
        public int id_language { get; set; }
        public int id_start_module { get; set; }
        [MaxLength(100)]
        public string path_picture { get; set; }
        public int id_profile { get; set; }
        [MaxLength(25)]
        public string code_type { get; set; }
        [MaxLength(15)]
        public string login_ip { get; set; }
        [MaxLength(6)]
        public string login_hour { get; set; }
        [MaxLength(100)]
        public string login_session { get; set; }
        [MaxLength(50)]
        public string login_latitude { get; set; }
        [MaxLength(50)]
        public string login_length { get; set; }

        public ModelUser() : base()
        {
            this.pr("ModelUser.constructor");
            this.sTableName = "base_user";
            //this.drop_table();
            //Esto esta dando problemas circulares de recursividad ya que se llama a si mismo.
            //this.create_table();
        }//ModelUser

        private void drop_table()
        {
            this.pr("ModelUser.droptable 1");
            string sSQL = "DROP TABLE IF EXISTS " + this.sTableName+";";
            this.execute(sSQL);
        }//drop_table

        public new void create_table()
        {
            //MAL!!!
            this.pr("ModelUser.create_table 1");
            try
            {
                this.oSQLiteConn.CreateTable<ModelUser>();
            }
            catch (Exception oEx)
            {
                this.pr("ModelUser->create_table EXEPTION!!!: "+oEx.GetBaseException().ToString());
            }
        }//create_table

        public static void createtable()
        {
            var oCompConfig = Xamarin.Forms.DependencyService.Get<InterfaceConfig>();
            SQLite.Net.SQLiteConnection oSQLiteConn = new SQLite.Net.SQLiteConnection(oCompConfig.get_platform
                , Path.Combine(oCompConfig.get_db_folder, NSTheframework.Config.ConfDatabase.NAME));
            oSQLiteConn.CreateTable<ModelUser>();
        }//createtable()

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}"
                ,this.id,this.code_erp, this.description, this.insert_user, this.insert_date, this.update_date);
        }//ToString

    }//ModelUser
}//NSTheapplication.Models
