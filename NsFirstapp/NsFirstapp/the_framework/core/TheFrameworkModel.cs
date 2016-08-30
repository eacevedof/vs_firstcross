using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using NSTheframework.Components;

namespace NSTheframework.Core
{
    public class TheFrameworkModel:TheFramework
    {
        protected SQLiteConnection oConn;

        public TheFrameworkModel():base()
        {

        }//TheFrameworkModel()
    }//TheFrameworkModel
}//NSTheframework.Core
