/**
 * @file: \NsFirstapp\NsFirstapp.WinPhone\components\ComponentConfig.cs 1.0.0
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;
using NsFirstapp.Interfaces;

//necesito este NS para que esta interface se pueda usar en toda la app
using Xamarin.Forms;
//para que pueda usar la interface en la capa de aplicacion debemos utilizar esta etiqueta
//Dependency nos permite tener compatibilidad con las 3 plataformas
[assembly: Dependency(typeof(NsFirstapp.WinPhone.components.ComponentConfig))]

namespace NsFirstapp.WinPhone.components
{
    public class ComponentConfig : InterfaceConfig
    {
        private string sPathDbFolder;
        private ISQLitePlatform oSQLPlatform;

        ISQLitePlatform InterfaceConfig.get_platform
        {
            get
            {
                if (this.oSQLPlatform == null)
                {
                    this.oSQLPlatform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }
                return this.oSQLPlatform;
                //throw new NotImplementedException();
            }
        }//get_platform

        string InterfaceConfig.get_db_folder
        {
            get
            {
                if (string.IsNullOrEmpty(this.sPathDbFolder))
                {
                    //Error:var sPersonalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    var sPersonalFolder = "c:/firstapp/";
                    this.sPathDbFolder = sPersonalFolder;
                    //                    this.sPathDbFolder = System.IO.Path.Combine(sPersonalFolder, "..", "Library");
                }
                return this.sPathDbFolder;
                //throw new NotImplementedException();
            }
        }//get_db_folder
    }//ComponentConfig
}//NsFirstapp.WinPhone.components