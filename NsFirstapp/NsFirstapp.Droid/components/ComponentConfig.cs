using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NsFirstapp.interfaces;
using SQLite.Net.Interop;

//necesito este NS para que esta interface se pueda usar en toda la app
using Xamarin.Forms;
//para que pueda usar la interface en la capa de aplicacion debemos utilizar esta etiqueta
//Dependency nos permite tener compatibilidad con las 3 plataformas
[assembly: Dependency(typeof(NsFirstapp.Droid.components.ComponentConfig))]

namespace NsFirstapp.Droid.components
{
    class ComponentConfig : InterfaceConfig
    {
        private string sPathDbFolder;
        private ISQLitePlatform oSQLPlatform;

        string InterfaceConfig.get_db_folder
        {
            get
            {
                if (string.IsNullOrEmpty(this.sPathDbFolder))
                {
                    var sPersonalFolder = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    this.sPathDbFolder = sPersonalFolder;
                }
                return this.sPathDbFolder;
                //throw new NotImplementedException();
            }
        }//get_db_folder

        ISQLitePlatform InterfaceConfig.get_platform
        {
            get
            {
                if (this.oSQLPlatform == null)
                {
                    this.oSQLPlatform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return this.oSQLPlatform;
                //throw new NotImplementedException();
            }
        }//get_platform

    }//ComponentConfig

}//NsFirstapp.Droid.components