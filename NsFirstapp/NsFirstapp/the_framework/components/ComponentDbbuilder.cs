/*
 *@file: \NsFirstapp\components\ComponentDbBuilder.cs 1.0.0
 */
using Xamarin.Forms;
using System.IO; //para Path.Combine
using SQLite.Net;

using NSTheframework.Config;
using NSTheframework.Interfaces;
using NSTheapplication.Models;

namespace NSTheframework.Components
{
    public class ComponentDbBuilder 
    {
        SQLiteConnection oSQLiteConn;

        public ComponentDbBuilder()
        {
            Bug.pr("ComponentDbBuilder()");
            var oCompConfig = DependencyService.Get<InterfaceConfig>();
            Bug.pr(oCompConfig, "oCompConfig");
            string sPathDb = Path.Combine(oCompConfig.get_db_folder, ConfDatabase.NAME);
            Bug.pr(sPathDb,"sPathDb");

            this.oSQLiteConn = new SQLiteConnection(oCompConfig.get_platform,sPathDb);
            Bug.pr("End constructor");
        }//ComponentDbBuilder

        public void build_db()
        {
            this.base_user();
        }//build_db

        public void build_db(bool useDrop)
        {
            if (useDrop)
            {
                string sSQL = "DROP TABLE IF EXISTS base_user";
                this.execute(sSQL);
                sSQL = "DROP TABLE IF EXISTS app_employee";
                this.execute(sSQL);
            }
        }//build_db(2)

        private void execute(string sSQL)
        {
            Bug.pr(sSQL);
            SQLiteCommand oSQLCmd = this.oSQLiteConn.CreateCommand(sSQL);
            int iResult = oSQLCmd.ExecuteNonQuery();
            Bug.pr("result: "+iResult.ToString());
        }//execute

        private void base_user()
        {
            Bug.pr("ComponentDbBuilder.base_user", "START CREATION");
            this.oSQLiteConn.CreateTable<ModelUser>();
            Bug.pr("ComponentDbBuilder.base_user", "END CREATION");
        }//create_user()



    }//ComponentDbBuilder

}//NSTheframework.Components
