using System.Linq;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using LINQtoObject;
using LINQ_2;

namespace LINQ_2
{
    

    // for extension methods 
    internal class Program
    {
        public struct CourseData
        {
            public string Name;
            public int Hours;
        }


        public static CourseData GetData(Course crs)
        {
            return new CourseData{  Name = crs.Name, Hours = crs.Hours };
        }


        static void Main(string[] args)
        {

            #region [To know how to implment filter function , display names for the accepted condition]
            IEnumerable<Course> source = SampleData.Courses.Filter(c => c.Hours > 30);
            foreach (Course s in source)
            {
                Console.WriteLine(s.Name);
            } 
            #endregion

            Console.WriteLine("------------------------");

            #region [How To select specific coulmn on the data source (dont return all the whole object)]
            // for return only one coulmn
            IEnumerable<string> source2 = SampleData.Courses.Choose(c => c.Name);
            foreach (var s in source2)
            {
                Console.WriteLine(s);
            }

            #endregion
            Console.WriteLine("------------------------");

            #region [If we want to select more than one coulmn but there is a problem explained in the next comment line]
            // هنا المشكله ان مش كل ما هحب اعمل سيليلكت لحاجات معينه هروح اعمل داتا تايب جديده ف حلها كان اني ابعت انينوموس اوبجيكت
            // for return more than one coulmn
            // but here we must make for each retrevial data make a new datatype ! so we retrun an anynomys object see the next lines for the soultion
            IEnumerable<CourseData> source3 = SampleData.Courses.Choose(GetData);
            foreach (var s in source3)
            {
                Console.WriteLine($"{s.Name}  {s.Hours}");
            } 
            #endregion

            Console.WriteLine("------------------------");

            #region [Soultion for the previious problem]
            // if we return an anynomos object from the function we must spicify the return type as object and it hard to the compiler to detect what is the type 
            // So we decide to pass the object in the function call not in the function
            var source4 = SampleData.Courses.Choose(c => new { c.Name, c.Hours });
            // ienumrable<anynomous> كتبت فار لاني مش عارف الداتا تايب الي  راجعه نوعها ايه انا مباصي انينوموس اوبيجكت معرفش اي الي راجعلي 
            foreach (var s in source4)
            {
                Console.WriteLine($"{s.Name}  {s.Hours}");
            }
            #endregion


            #region [PipeLine]
            // Question : What is the first called the Choose or the Filter function first 
            var query = SampleData.Courses
                .Where(c => c.Hours > 30)
                .Select(c => new { c.Name, c.Hours });
            // عشان تعرف اجابه السؤال بص ف الكشكول بتاعك لكن كمعلومه هتلاقي ان ال تشوز فانكشن بتتنده الاول 
            var query2 = SampleData.Courses
                .Select(c => new { c.Name, c.Hours })
                .Where(c => c.Hours > 30);
            //ألفرق ف الي راجع والي اقدر اكسيسه من التو كويريز 


            #endregion


           #region [Query expression]

            // (the best is operator query)وفي اصلا فانكشنز ف الطريقه الاوبيريتور مش هينفع اعملها ف الاكسبريشن  query operator عشان اصلا الاساس هو ال

            var query3 = 
                    from crs in SampleData.Courses
                    where crs.Hours>30
                    select new { crs.Name , crs.Hours};

            // must end with select or group by .
            #endregion

            Console.WriteLine("------------------------");

            var q = SampleData.Courses.Max(c => c.Hours);
            Console.WriteLine(q);


        }


    }
}