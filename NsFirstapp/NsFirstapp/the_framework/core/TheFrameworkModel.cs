using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using NSTheframework.Components;

namespace NSTheframework.Core 
{
    public class TheFrameworkModel:TheFramework,IDisposable
    {
        protected SQLiteConnection oSQLiteConn;

        public TheFrameworkModel():base()
        {

        }//TheFrameworkModel()



        public void Dispose()
        {
            this.oSQLiteConn.Dispose();
        }//Dispose

    }//TheFrameworkModel
}//NSTheframework.Core
