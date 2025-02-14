using LINQTut04.Shared;
using System.Xml.Linq;

namespace LINQ_P4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Emps = Repository.LoadEmployees();


            #region Generation operator [generate out sequance from nothing]
            // Only one way to call them : is as a static member method From Enumrable class 

            // Range() : generate sequance from 1 and count 10 steps 
            var res1 = Enumerable.Range(1, 10);


            // Empty<Tresult> : Generate an empty IEnumrable 
            var res2 = Enumerable.Empty<int>();


            // Repeat() : repeat an object for N times 
            var R3 = Enumerable.Repeat(5, 10); // repeaat 5 for 10 times 

            // Repeat the Id of the employee with 1030 for 10 times  
            var R4 = Enumerable.Repeat(Emps.Where(e => e.Id == 1030).Select(e => e.Id).First(), 10);



            // SelectMany() : transform each element in input sequance to sub sequance 
            string[] sentences =
              {
                    "i love asp.net core",
                    "i like sql server also",
                    "in general i like programming"
               };
            // split():  بتفصل الاسترينج بناء علي حرف بتريترن اراي اوف سترينج
            var R5 = sentences.SelectMany(x => x.Split(' '));
            // here will return array of words that in all the 3 sentences 
            // R5.ToList()[0]

            var R6 = from FN in sentences // itr on the sentences 
                     from SN in FN.Split(" ") // iterator on each sentence and split each space
                     select SN;


            foreach (var item in R5)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region [Zip operator]
            // Zip method : combines elements from two or more sequences or collections into a single sequence by pairing corresponding elements together
            //Parameters:
            //    IEnumerable<TFirst> first: The first sequence to merge.
            //    IEnumerable<TSecond> second: The second sequence to merge.
            //    Func<TFirst, TSecond, TResult> resultSelector: A function that specifies how to merge the elements from the two sequences.


            // NOTE :  Zip method merges each element of the first sequence with an element in the second sequence with the same index position

            int[] numbersSequence = { 10, 20, 30, 40, 50 };
            string[] wordsSequence = { "Ten", "Twenty", "Thirty", "Fourty" };

            var res20 = numbersSequence.Zip(wordsSequence);// (10,Ten) , (20,Twenty) , (30,Thirty) , (40 , Fourty)


            // If we want to specify any format to combine 
            var res200 = numbersSequence.Zip(wordsSequence,(numseq,wordseq)=> $"Number : {numseq} Word : {wordseq}");
            //Number: 10 Word: Ten
            //Number : 20 Word: Twenty
            //Number : 30 Word: Thirty
            //Number : 40 Word: Fourty


            foreach (var item in res200)
            {
                Console.WriteLine(item);
            }


            #endregion


            #region [Let , Into] [Query Syntax]
            #region [Let]
            // See the following query 
            // select all the employees that its first names start with c in lowercase 
            var EmpsinLower = from emp in Emps
                              where emp.FirstName.ToLower().StartsWith("c")
                              select emp.FirstName.ToLower();

            // here we use ToLower() multiple times so we need to dont repeat ourself , here Let Key word rule in comming 
            // Using LET keyword
            var EmpsInLowerWithLetKeyWord = from emp in Emps
                                            let EmpNameInlower = emp.FirstName.ToLower()
                                            where EmpNameInlower.StartsWith("c")
                                            select EmpNameInlower;
            // So "EmpNameInlower" will be then used in every where , so Let make the code more readable 
            //foreach (var emp in EmpsinLower)
            //{
            //    Console.WriteLine(emp);
            //}
            #endregion


            #region [Into]
            // we know that the query syntax start with from and end with Select or group by 
            // used to continue the execution of Query Sytax after "Select" 

            // Suppose we want to make this busniss 
            // select all the employees that there salary > 75000.00m and < 90000.00m
            // and put them in one group and then selet the employees start with char B

            var filterdEmps = from emp in Emps
                              where emp.Salary > 75000.00m && emp.Salary < 90000.00m
                              select emp
                              into EmpsShouldTakeBouns
                              where EmpsShouldTakeBouns.FirstName.ToLower().StartsWith("b")
                              select EmpsShouldTakeBouns;

            var filterdEmpsInExtension = Emps.Where(e=>e.Salary > 75000.00m && e.Salary < 90000.00m).Where(e=>e.FirstName.ToLower().StartsWith("b")).Select(e=>e);
            
                              

            #endregion



            #endregion


            #region [Joins] 

            #endregion

        }
    }
}   