/**
* @file:\NsFirstapp\NsFirstapp\Interfaces\InterfaceConfig.cs 1.0.0
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Interop;

namespace NSTheframework.Interfaces
{
    public interface InterfaceConfig
    {
        string get_db_folder { get; }
        ISQLitePlatform get_platform { get; }

    }//InterfaceConfig

}//NSTheframework.Interfaces
