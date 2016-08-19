/**
 * @file: \NsFirstapp\NsFirstapp.iOS\components\ComponentConfig.cs 1.0.0
 **/

using System;

using NsFirstapp.interfaces;
using SQLite.Net.Interop;

namespace NsFirstapp.iOS.components
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
                    this.oSQLPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
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
                    var sPersonalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    this.sPathDbFolder = System.IO.Path.Combine(sPersonalFolder, "..", "Library");
                }
                return this.sPathDbFolder;
                //throw new NotImplementedException();
            }
        }//get_db_folder
    }
}