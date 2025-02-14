using LINQTut04.Shared;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity; // i install entity framework paket from nuget packet

namespace Projection
{
    class Program
    {

        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var netdevs = employees.Select(e => e.Id);//"select * from employees where skills = ".net"
            foreach (var id in netdevs)
            {
                Console.WriteLine(id);
            }
        }


        #region          [Select]
        // use of select method 
        public static void Example01()
        {
            List<string> list = new List<string> { "Apple", "Banana", "Orange" };

            var listUppre = list.Select(x => x.ToUpper()); // here data not in result untill i iterate on it [defeerd exectui]
            foreach (var item in listUppre)
            {
                Console.WriteLine(item);
            }

            // var listUppre = list.Select(x => {
            // return new EmployeeDTO {
            //Name = $"{x.fname}  {x.lname}"
            // See Essam video
            //}

            // }); 


        }
        #endregion

        #region [SelectMany]
        // select method return element element not return element in elemnt 
        // يعني السيليكت بترجع عنصر عنصر انا هنا مش عاوز ارجع الجمله لا انا عاوز ارجع الكلمات الي جوا العنصر
        // يعني سيلكيكت جواها سيليكت
        static void Example02()
        {
               string[] sentences =
               {
                    "i love asp.net core",
                    "i like sql server also",
                    "in general i like programming"
               };
                // split بتفصل الاسترينج بناء علي حرف بتريترن اراي اوف سترينج
                var result = sentences.SelectMany(x => x.Split(' '));
                // here will return array of words that in all the 3 sentences 
                foreach (var sent in result)
                {
                    Console.WriteLine(sent);
                }



        }
        

        static void Example03()
        {
            var employees = Repository.LoadEmployees();
            // each employee has id , firstname,lastname,email, number of skills 
            // i want to take all the employees skills and display it 
            var res = employees.SelectMany(x => x.Skills).Distinct();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            // with query syntax 
            var res2 = (from emp in employees
                      from skill in emp.Skills
                      select skill).Distinct();

        }

        #endregion

        #region         [Zip]
        // if i have 2 arrays and want to make it as pairs !
        static void Example04()
        {
            string[] arr1 = { "Ahmed", "Shaban", "Ramadan" };
            string[] arr2 = { "coustmer", "manager", "service" };

            var res = arr1.Zip(arr2, (name, job) =>$"name: {name} , job :{job}"); // how to display it to user
            foreach(var item in res)
            {
                Console.WriteLine(item);
            }

            // also know 
        }



        #endregion
    }


}