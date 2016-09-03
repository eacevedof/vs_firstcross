/*
 *@file: \NsFirstapp\components\ComponentDbBuilder.cs 1.0.0
 */
using System.Diagnostics;

namespace NSTheframework.Components
{
    public static class Bug
    {
        public static void pr(string s)
        {
            Debug.WriteLine(s);
        }//pr

        public static void pr(string s, string t)
        {
            Debug.WriteLine(t);
            Debug.WriteLine(s);
        }//pr(2)

        public static void pr(object o)
        {
            Debug.WriteLine(o.ToString());
        }//pr(3)

        public static void pr(object o, string t)
        {
            Debug.WriteLine(t);
            Debug.WriteLine(o.ToString());
        }//pr(4)

    }//Bug

}//NSTheframework.Components
