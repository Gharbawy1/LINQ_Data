using LINQTut04.Shared;

namespace LINQ_part_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Emps = Repository.LoadEmployees();

            #region [Where]
            /// select the employees Id who is first name start with char C 
            //var EmpsStartWithC = Emps.Where(emp=>emp.FirstName.StartsWith('C'))
            //                         .Select(emp=>emp.Id);
            //foreach (var emp in EmpsStartWithC)
            //{
            //    Console.WriteLine(emp);
            //}

            /// select employee Id and his first name who has and ASP.NET skill
            //var EmpsWithDotNetSkill = Emps.Where(emp=>emp.Skills.Contains("ASP.NET"))
            //                              .Select(emp=>new { emp.Id, emp.FirstName });
            //foreach (var emp in EmpsWithDotNetSkill)
            //{
            //    Console.WriteLine(emp);
            //}

            /// Indexed where [valid only in extesion method]
            /// From the first 5 emps do the where condition 
            //var EmpsWithCharCWithin5emps = Emps.Where((emp, i) => (emp.FirstName.StartsWith('C')) && i < 5);
            //foreach (var emp in EmpsWithCharCWithin5emps)
            //{
            //    Console.WriteLine(emp);
            //}



            #endregion


            #region The anynomous type 
            // suppose we have a dropdown list and want to fill it with all employees names and him id only 
            // witout the anynomous types we will create a new class and make this proprties and a big operations 
            // simply use the anynomous type
            //var res = Emps.Select(emp => new { emp.FirstName, emp.Id });
            //foreach (var emp in res)
            //{
            //    Console.WriteLine(emp);
            //}

            //var res2 = from emp in Emps
            //           select new { emp.FirstName, emp.Id };

            #endregion


            #region No Anynmous type
            // If we have to give all employees bouns and select them all so select all with the same
            // select all employees and return it with the same data but edit the salary 
            //var res3 = Emps.Select(emp => new Employee()
            //{
            //    Id = emp.Id,
            //    FirstName = emp.FirstName,
            //    LastName = emp.LastName,
            //    Email = emp.Email,
            //    Skills = emp.Skills,
            //    Salary = emp.Salary/2
            //});
            //foreach (var emp in res3)
            //{
            //    Console.WriteLine(emp);
            //}

            #endregion


            #region Indexed Select
            //var res4 = Emps.Where(emp => emp.Skills.Contains("ASP.NET"))
            //               .Select((e, i) => new {FirstName = e.FirstName, Index=i});
            //foreach (var e in res4)
            //{
            //    Console.WriteLine(e);
            //}
            #endregion

            #region Ordering 
            // order clause as usual 

            // if 2 elements is equal -> we use then by such if 2 employees has the same salary order them by the skills count
            //var orderdemps = Emps.OrderBy(e => e.Salary).ThenBy(e => e.Skills.Count()).Select(e => new{e.Salary , e.Skills.Count });
            //foreach (var order in orderdemps)
            //{
            //    Console.WriteLine(order);
            //}
            #endregion


            #region Hybrid Query [(Query expression).ExtensionMethod
            // return the first employee has this skill 
            //var res = (from e in Emps
            //           where e.Skills.Contains("ASP.NET")
            //           select e).First(); // in praces return i enumrable 



            #endregion


            #region [Element operator - Eager execution]

            //var res = Emps.First();

            //res = Emps.First(e=>e.FirstName.StartsWith('E')); // based on conditions

            //List<int> lst = new List<int>();
            //var ls = lst.First(); //  empty sequance trhow an exception 
            //ls = lst.FirstOrDefault(); // return the deafult of the sequance 





            #endregion


            // Single() operator :
            // throw exception if no element in sequance or there is more than one [0 or more than 1]
            // throw exception if more than one element matched the condition or if no matched elemnets 
            // Case study : we use this operator if we want to sure that no 2 employees has the same id 

            #region Aggregrate and the IComprable
            var rs = Emps.Max();
            // this code will make an error cause we dont know max depend on what ?! 
            #region [We dont pass any argumetns to MAX()]
            // compiler go to the class and see the CompareTo functtion 
            // so Employee class must implment "IComparble"

            // After implment IComparable we get MAX(based on Salary)
            #endregion

            #region [We pass an argumetns to MAX()]
            var rs2 = Emps.Max(e => e.Salary); 
            #endregion




            #endregion

        }
    }
}