using LINQtoObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_2
{
    internal static class Extensions
    {
        // [Generic filter function such , Where in LINQ]
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            foreach(var course in source)
            {
                if (predicate(course))
                {
                    yield return course;
                }
            }
        }
        
        
        // = = = = =  = = = = = = = = = = = 
        // Give it the courses and return an list of courses name [ this function will work on 2 data types]
        // The Ienumrable that call this function will be an Ienumrable of the source , when i call this fnction i decide the Tsource data type
        //? We can say that => public static Ienummrable<string> Filter<Course,string>(thos Ienum<course> , Func<Course,string>)
        public static IEnumerable<TResult> Choose<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource,TResult> chooser)
        {
            foreach (var item in source)
            {
                yield return chooser(item);
            }
        }





        // when i want to select 2 coulmns or more than one 
        public static IEnumerable<TResult> Choose2<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> chooser)
        {
            foreach (var item in source)
            {
                yield return chooser(item);
            }
        }



    }
}
