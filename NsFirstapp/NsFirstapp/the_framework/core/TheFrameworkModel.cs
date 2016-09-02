/*
 *@file: NsFirstapp\the_framework\core\TheFrameworkModel.cs 1.0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;//para Path.Combine
using Xamarin.Forms;
using SQLite.Net;

using NSTheframework.Config;
using NsFirstapp.Interfaces;
//using NSTheframework.Components;

namespace NSTheframework.Core 
{
    public class TheFrameworkModel:TheFramework,IDisposable
    {
        protected string sTableName;

        protected SQLiteConnection oSQLiteConn;

        public TheFrameworkModel(string sTableName):base()
        {
            this.sTableName = sTableName;
            this.db_connect();

        }//TheFrameworkModel()

        public void db_connect()
        {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            var oCompConfig = DependencyService.Get<InterfaceConfig>();
            this.oSQLiteConn = new SQLiteConnection(oCompConfig.get_platform
                , Path.Combine(oCompConfig.get_db_folder, ConfDatabase.NAME));
        }//db_connect

        public List<string> query(string sSQL)
        {
            List<string> lstString = new List<string>();
            SQLiteCommand oSQLCmd = this.oSQLiteConn.CreateCommand(sSQL);
            lstString = oSQLCmd.ExecuteQuery<string>();
            return lstString;
        }//query

        public int execute(string sSQL)
        {
            int iResult = 0;
            SQLiteCommand oSQLCmd = this.oSQLiteConn.CreateCommand(sSQL);
            iResult = oSQLCmd.ExecuteNonQuery();
            return iResult;
        }//execute

        protected void create_table()
        {
            //http://www.bricelam.net/2015/04/29/sqlite-on-corefx.html
            //https://msdn.microsoft.com/en-us/magazine/mt736454.aspx?f=255&MSPPError=-2147217396
            //this.oSQLiteConn.CreateTable<this>();
        }//create_table

        
        public void Dispose()
        {
            this.oSQLiteConn.Dispose();
        }//Dispose

    }//TheFrameworkModel
}//NSTheframework.Core
