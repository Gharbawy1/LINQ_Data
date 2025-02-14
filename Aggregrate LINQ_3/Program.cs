using System.Linq;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using LINQ_3;
using LINQ_2;
using LINQtoObject;
using System.Collections;
using Aggregrate_LINQ_3;

namespace LINQ_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            RunMethod01();

        }


        

        #region [Aggregration || Aggregrate ,Max , min ,maxby , minby , Count,long count,]
        #region [Aggrgrate function the first overload]
        public static void RunMethod01()
        {
            //   بترجع هناك aهنعرف هنا ان القيمه الاكيوميليت بتتخزن ف ال 
            var names = new[] { "ali", "ahmed", "mohamed", "sayed", "marwan" };
            var new_name = names.Aggregate((a, b) => { Console.WriteLine($"a = {a} ,, b = {b}  "); return $"{a},{b}"; });
            // هتبقي التراكميه لعمليه ضم الاسترنجات a  هنا كل مره قيمه ال 
            Console.WriteLine(new_name);

        }
        #endregion

        #region [Aggrgrate function the second overload => take seed (deafult value to start acuumlate on it)]
        public static void RunMethod02()
        {

            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var new_num = nums.Aggregate(0, (a, b) => a + b);
            // with seed 0 : add on the value 0 
            // with seed 20 : add on the values 20
            // هتبقي التراكميه لعمليه ضم الاسترنجات a  هنا كل مره قيمه ال 
            Console.WriteLine(new_num);

        }
        #endregion

        #region [Count , Longcount]
        public static void Runcount()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Count(a => a > 4));
            Console.WriteLine(nums.Where(a => a > 4).Count());
            Console.WriteLine(nums.LongCount()); // for long retriveing count [if the retirved count is very large]
        }
        #endregion

        #region [Max , MaxBy]
        public static void RunMax()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(nums.Max());

            // to indicate the MaxBy function we use the Sample dataclass from linq2
            var Course = SampleData.Courses;
            // We want the course data that has the max  hours 
            var CrsWithMaxHourse = Course.MaxBy(x => x.Hours);
            Console.WriteLine(CrsWithMaxHourse.Name); //  return Course object 


        }
        #endregion 
        #endregion

        #region [Groupping]
        #region [Group By]
        public static void RunGroupBy()
        {
            var coursesGrouped = SampleData.Courses.GroupBy(x => x.Hours);
            // is an enumerable of groups. Each group consists of a key (the Hours value) and a collection of courses that have the same Hours value.

            /*
                 GroupBy : creates groups where each group has the same value for the Hours property. [30,[list of courses that has the same 30 hour]]
             */

            // IEnumerable<IGrouping<TKey, TSource>>     TSource is "course" , Key is Keyselector (type of the attribyute i grouped by)
            // key : Hours    value: collection of courses  
            foreach (var item in coursesGrouped)
            {
                // iterate on the ienumrable of groups i iterat on the first group it has 2 items [ key and collection of courses] 
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {
                    // iterate of the collectiion of courses
                    Console.WriteLine(item2.Name);
                }
            }
        }


        #endregion

        #region [ToLookup]
        public static void RunToLookup()
        {
            // the same in group by replace group by with tolookup

            var coursesGrouped = SampleData.Courses.ToLookup(x => x.Hours);

            foreach (var item in coursesGrouped)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.Name);
                }
            }

        }
        #endregion

        #region [Difference Between GroupBy , ToLookup]
        /*
            -> Group By :
            -> Uses Deffered Excution 
            -> each iteratie Group again [each iteration excute group by function]
            -> return Ienumrable<IGroupping<Tkey,TSource>>


            -> ToLookup : 
            -> Uses Eager Excution 
            -> store result in memory immediatly 
            -> return ILookup<Tkey,TSource>
            -> Good At Multiple process لو انا عاوز اعمل علي الليست اكتر من عمليه والداتا كلها موجوده  


         */
        #endregion 
        #endregion

        #region [Sorting]
        // We have OrderBy it deafult sort in ascending order 
        // and OrderByDescindeing 
            public static void RunOrderBy()
            {
                // ascednig order 
                var SortedList1 = SampleData.Courses.OrderBy(x=>x.Name); // order by the alphbatic order [deafult]
                var SortedList2 = SampleData.Courses.OrderBy(x => x.Name.Length); // order by the string order 


                // ascednig order 
                var SortedList3 = SampleData.Courses.OrderByDescending(x => x.Name); // order by the alphbatic order [deafult]
                var SortedList4 = SampleData.Courses.OrderByDescending(x => x.Name.Length); // order by the string order 

                foreach(var item in SortedList4)
                {
                    Console.WriteLine(item.Name);
                }

            }


        #endregion

        #region [Primary , secondary sorting]
            // افرض وانا برتب حسب المرتبات جه 2 موظفين ليهم نفس المرتب ارتبهم بناءا علي ايه ؟
            public static void RunPrim_sec_sorting()
            {
                var crs1 = SampleData.Courses.OrderBy(cr => cr.Hours).ThenBy(cr => cr.Name);// in case 2 course has the same hours then orderby the name 
                var crs2 = SampleData.Courses.OrderBy(cr => cr.Hours).ThenByDescending(cr => cr.Name);// in case 2 course has the same hours then orderby the name 
            }
        #endregion

        #region [Coustm sorting]
            // if i have 2 courses in its Course number 
            // C1.No = "2017-FI-1377"
            //C2.No =  "2018-FI-1577" 
            //1577 هنا لو عاوز ارتبهم ف العادي هيعتبرهم سترينج ويرتبهم علي اساس الاسترينج  انما لو حابب مثلا ارتب الاول علي السنه ولو تشابهوا ارتب علي اول حرف ف ال 
            public static void RunCoustmSort()
            {
                IEnumerable <Course> crs = SampleData.Courses;
                IOrderedEnumerable<Course> SortedCourses = crs.OrderBy(cr => cr.Name);
                // here sort all course based on the name string


            // if i want to sort based on the third character !!
            // we find an overload for order by take an Icomparor 
            // IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer);
            // So,What is Icomparor ?? this is an interface compare between two " objects " 
            //  SEE THE META DATA AND KNOW THE IS THE RETEUR TYPE

            // We Have This CourseNo format "2017-FI-1577" and we want to use order by operator to order based on the 2017 and 1577 ignore the FI
            // here we create a class called "CourseComparer" to compare 2 course objects

            //? IOrderedEnumerable<Course> SortedCourses2 = crs.OrderBy(cr => cr.Name,new CourseComparer()); //EEROR 
            // Cause Icomaprer compare object with object but here i give string 
            
            IOrderedEnumerable<Course> SortedCourses2 = crs.OrderBy(cr => cr,new CourseComparer()); 

                foreach(var course in SortedCourses2) {
                     Console.WriteLine($"{course.Name}\t\t\t\t\t\t{course.Department.Name}\t\t{course.CourseNo}");
                }
            }



        #endregion

        
        // [Reverse is value typed dont change in the original list]
    }

}