using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoObject;

namespace Aggregrate_LINQ_3
{
    internal class CourseComparer : IComparer<Course>
    {
        public int Compare(Course? crs1, Course? crs2)
        {
            // "2017-FI-1577" we want to take 2017 and 1577 of each Course
            int Year1 = Convert.ToInt32(crs1.CourseNo.Split('-')[0]);
            int Year2 = Convert.ToInt32(crs2.CourseNo.Split('-')[0]);
            int Seq1 = Convert.ToInt32(crs1.CourseNo.Split('-')[2]);
            int Seq2 = Convert.ToInt32(crs2.CourseNo.Split('-')[2]);

            if (Year1 == Year2)
            {
                   return Seq1.CompareTo(Seq2);
            }
            else
            {
                return Year1.CompareTo(Year2);
            }
            
            
        }
    }
}
