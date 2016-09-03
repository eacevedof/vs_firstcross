/*
 *@file: \NsFirstapp\NsFirstapp\components\ComponentData.cs 1.0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using Xamarin.Forms;
using System.IO; //para Path.Combine

using NSTheframework.Config;
using NSTheapplication.Models;
using NSTheframework.Interfaces;

namespace NSTheframework.Components
{
    public class ComponentData : IDisposable
    {
        private SQLiteConnection oSQLiteConn;
        private string sDbName;

        public ComponentData()
        {
            this.oSQLiteConn = null;
            this.sDbName = ConfDatabase.NAME;
            this.db_connect();
        }//ComponentData

        public void db_connect()
        {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            var oCompConfig = DependencyService.Get<InterfaceConfig>();
            this.oSQLiteConn = new SQLiteConnection(oCompConfig.get_platform
                ,Path.Combine(oCompConfig.get_db_folder,this.sDbName));

            this.oSQLiteConn.CreateTable<ModelEmployee>();

        }//db_connect

        public void table_baseuser()
        {
            this.oSQLiteConn.CreateTable<ModelUser>();
        }

        public void insert_empleado(ModelEmployee oEmpleado)
        {
            this.oSQLiteConn.Insert(oEmpleado);
        }//insert_empleado

        public void update_empleado(ModelEmployee oEmpleado)
        {
            int iResult = this.oSQLiteConn.Update(oEmpleado);
        }//update_empleado

        public void delete_empleado(ModelEmployee oEmpleado)
        {
            int iResult = this.oSQLiteConn.Delete(oEmpleado);
        }//delete_empleado

        public ModelEmployee get_empleado(int idEmpleado)
        {
            return this.oSQLiteConn.Table<ModelEmployee>().FirstOrDefault(c=>c.id == idEmpleado);
        }//get_empleado

        public List<ModelEmployee> get_empleados()
        {
            return this.oSQLiteConn.Table<ModelEmployee>().ToList();
        }//get_empleados

        public List<ModelEmployee> get_empleados(bool isOrderApellidos)
        {
            if(isOrderApellidos)
                return this.oSQLiteConn.Table<ModelEmployee>().OrderBy(c=>c.last_name).ToList();
            else
                return this.oSQLiteConn.Table<ModelEmployee>().ToList();
        }//get_empleados

        public void Dispose()
        {
            this.oSQLiteConn.Dispose();
        }//Dispose

  
    }//ComponentData

}//NsFirstapp.components
