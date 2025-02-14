using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_1
{
    internal static class Extensions
    {

        // conditions for  extension method 
        /* 
         1- it must be public static  function
         2- it must be in static class [means in this class all members in it is static]
         3- what is the data type u want the extension method to appear for ? here Method (string st,delegate) => this mean any string varaible can call the extension method str.Methood
               EX : public static void Filter(this list<int> list , predicate<int> ) here only lists of intgers can call filter functino
                and  this mean only this functino appear only for the list of intgers 
         */

        // V-01
        public static void Filter(this List<int> list, Predicate<int> prdecate)
        {
            foreach(int i in list) { 
                if (prdecate(i))
                {
                    Console.WriteLine(i+" ");
                }
            }
        }

        // V-02   [ generic typed function ]
        public static void Filter02<T>(this IEnumerable<T> list, Predicate<T> prdecate)
        {
            // any thing implement ienum can use this method 
            foreach (T i in list)
            {
                if (prdecate(i))
                {
                    Console.WriteLine(i + " ");
                }
            }
        }


        // V-03 with yield statment and try it 
        public static IEnumerable<T> Filter03<T>(this IEnumerable<T> list,Predicate<T> predicate)
        {
            foreach(T i in list)
            {
                if (predicate(i))
                {
                    yield return i;
                }
            }
        }



        // here if we dont put in parameter "this" we should call it with this   Console.WriteLine (Extensions.RemoveCapitalLetters(str));
        //  instead str.remover.....();
        public static string RemoveCapitalLetters01(string str)
        {
            StringBuilder str01 = new StringBuilder();
            foreach(char c in str)
            {
                if (!char.IsUpper(c))
                {
                    str01.Append(c);
                }
            }
            return str01.ToString();
        }


        public static string RemoveCapitalLetters02(this string str)
        {
            StringBuilder str01 = new StringBuilder();
            foreach (char c in str)
            {
                if (!char.IsUpper(c))
                {
                    str01.Append(c);
                }
            }
            return str01.ToString();
        }

        public static void print(this string str)
        {
            Console.WriteLine(str);
        }







    }
}
