/*
 *@file: \NsFirstapp\NsFirstapp\the_framework\core\TheFrameworkModel.cs 1.0.0
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
using NSTheframework.Components;

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

        protected void create_table()
        {
            if(!String.IsNullOrEmpty(this.sTableName))
            {
                //this.oSQLiteConn.CreateTable<ModelEmpleado>();
            }
        }

        public void Dispose()
        {
            this.oSQLiteConn.Dispose();
        }//Dispose

    }//TheFrameworkModel
}//NSTheframework.Core
