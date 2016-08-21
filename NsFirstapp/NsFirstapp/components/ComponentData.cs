/*
 *@file: \NsFirstapp\NsFirstapp\components\ComponentData.cs 1.0.0
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using Xamarin.Forms;
using System.IO;

using NsFirstapp.interfaces;
using NsFirstapp.models;

namespace NsFirstapp.components
{
    public class ComponentData : IDisposable
    {
        private SQLiteConnection oSQLiteConx;
        private string sDbName;

        public ComponentData()
        {
            this.oSQLiteConx = null;
            this.sDbName = "db_empleados.db3";
        }

        public void db_connect()
        {
            //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
            var oCompConfig = DependencyService.Get<InterfaceConfig>();
            this.oSQLiteConx = new SQLiteConnection(oCompConfig.get_platform
                ,Path.Combine(oCompConfig.get_db_folder,this.sDbName));

            this.oSQLiteConx.CreateTable<ModelEmpleado>();

        }//db_connect

        public void insert_empleado(ModelEmpleado oEmpleado)
        {
            this.oSQLiteConx.Insert(oEmpleado);
        }//insert_empleado

        public void update_empleado(ModelEmpleado oEmpleado)
        {
            this.oSQLiteConx.Update(oEmpleado);
        }//update_empleado

        public void delete_empleado(ModelEmpleado oEmpleado)
        {
            this.oSQLiteConx.Delete(oEmpleado);
        }//delete_empleado

        public ModelEmpleado get_empleado(int idEmpleado)
        {
            return this.oSQLiteConx.Table<ModelEmpleado>().FirstOrDefault(c=>c.id == idEmpleado);
        }//get_empleado

        public List<ModelEmpleado> get_empleados()
        {
            return this.oSQLiteConx.Table<ModelEmpleado>().ToList();
        }//get_empleados

        public List<ModelEmpleado> get_empleados(bool isOrderApellidos)
        {
            return this.oSQLiteConx.Table<ModelEmpleado>().ToList();
            if(isOrderApellidos)
                return this.oSQLiteConx.Table<ModelEmpleado>().OrderBy(c=>c.last_name).ToList();
        }//get_empleados

        public void Dispose()
        {
            this.oSQLiteConx.Dispose();
        }//Dispose
    }//ComponentData

}//NsFirstapp.components
