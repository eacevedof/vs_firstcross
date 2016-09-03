
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
namespace NSTheframework.Core
{
    public class TheFramework
    {
        public TheFramework()
        {
        }//TheFramework()

        public void pr(string s)
        {
            Debug.WriteLine(s);
        }
    }//TheFramework

    public static class StTheFramework
    {
        public static void pr(string s)
        {
            Debug.WriteLine(s);
        }

        public static void pr(string s, string t)
        {
            Debug.WriteLine(t);
            Debug.WriteLine(s);
        }

    }//StTheFramework

}//NSTheframework.Core
