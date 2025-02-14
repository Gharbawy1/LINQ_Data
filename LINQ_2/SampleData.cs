using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LINQtoObject
{
    public static class SampleData
    {
        public static Department[] Departments =
        {
            new Department{Name="SD",Address="Assiut"},
            new Department{Name="Unix",Address="Alex"},
            new Department{Name="Java",Address="Cairo"},
            new Department{Name="E-Learning",Address="Alex"}
        };

        public static Subject[] Subjects =
        {
            new Subject{Name="Programming",Description="Development Courses"},
            new Subject{Name="Soft Skills",Description="HR Courses"},
            new Subject{Name="Language",Description="Language Courses"}
        };

        public static Course[] Courses =
        {
            new Course{Name="C#",Hours=60,Subject=Subjects[0],Department=Departments[0],CourseNo = "2017-FI-1577"},
            new Course{Name="LINQ",Hours=18,Subject=Subjects[0],Department=Departments[0],CourseNo = "2018-NT-1573"},
            new Course{Name="Agile",Hours=30,Subject=Subjects[0],Department=Departments[2],CourseNo = "2017-FA-1875"},
            new Course{Name="Interview",Hours=18,Subject=Subjects[1],Department=Departments[1],CourseNo = "2019-FC-1972"},
            new Course{Name="Flash MX",Hours=45,Subject=Subjects[0],Department=Departments[3],CourseNo = "2018-MN-1274"},
            new Course{Name="Communication Skills",Hours=18,Subject=Subjects[1],Department=Departments[1], CourseNo = "2015-FI-1877"},
            new Course{Name="English",Hours=45,Subject=Subjects[2],Department=Departments[2], CourseNo = "2015-MV-1477"},
        };

        //public static ArrayList GetCourses()
        //{
        //    var list = new ArrayList(Courses);
        //    list.Add("Hello");
        //    return list;
        //}
    }
}
