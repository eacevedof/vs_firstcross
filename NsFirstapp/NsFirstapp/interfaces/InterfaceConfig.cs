/**
* @file:\NsFirstapp\NsFirstapp\interfaces\InterfaceConfig.cs 1.0.0
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Interop;

namespace NsFirstapp.interfaces
{
    public interface InterfaceConfig
    {
        string sPathDbFolder { get; }
        ISQLitePlatform oSQLPlatform { get; }

    }//InterfaceConfig

}//NsFirstapp.interfaces
