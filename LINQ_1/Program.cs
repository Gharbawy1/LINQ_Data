using System.Linq;
using System.IO;
using System.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace LINQ_1
{
    // for extension methods 
    internal class Program
    {
        // with out yield returen statment 

        // with yield [explained in notebook]

        static void Main(string[] args)
        {
            // الاحسن عشان تفهم لازم تبص ف الكشكول وتقرا كويس 
            #region Extension methods 
            //List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, -7, -8 };
            //list.Filter((i) => i > 0);


            //string str = "ASsdl;fjASdweoijL";
            //Console.WriteLine(Extensions.RemoveCapitalLetters01(str));


            //string str01 = "sldmopwjLasADKlsfedif";
            //Console.WriteLine(str01.RemoveCapitalLetters02());


            //str01.RemoveCapitalLetters02().print(); 
            #endregion
    
            #region [Yield statment and how it work]

            #region [Eager excution]
            //TryEagerExecution();
            #endregion

            #region [Deferred Excution]
            //TryDefeeredExecution();
            #endregion

            #region [Deferred Execution VS. Eager Execution and how it differ]
            // FIRST EAGER EXECUTION 
            string[] fruits = { "apricot", "avocado", "lemon", "cherry" };

            var filteredFruits = fruits.Where(f => f.StartsWith("a")).ToList(); //filterd frutis now has the result 

            foreach (string f in filteredFruits)
                Console.WriteLine(f); // apricot , avocado

            Console.WriteLine("= = = = == == =");

            fruits[2] = "apple";
            foreach (string f in filteredFruits)
                Console.WriteLine(f);// apricot , avocado

            Console.WriteLine("= = = = == == =");


            // Second eager EXECUTION 

            var filteredFruits2 = fruits.Where(f => f.StartsWith("a")); // the will not executed now 

            foreach (string f in filteredFruits2)
                Console.WriteLine(f); // apricot , avocado , apple
            Console.WriteLine("= = = = == == =");

            fruits[2] = "ahmed";

            foreach (string f in filteredFruits2)
                Console.WriteLine(f);// apricot , avocado , appele 
                                     // why ? cause when we edit the list the result alreay not be in the filterdlist 2 when iterate on the list we get data


            /*
                Before the query is executed, the data source may change    
             */





            #endregion

            #region LINQ operators work as deffered , eager execution 
            // [defeered] 
            // [AsEnumerable ,Cast ,Concat, DefaultIfEmpty, Distinct, Except, GroupBy,GroupJoin,Intersect,Join,OfType,OrderBy,OrderByDescending,Range,Repeat,Reverse,Select,SelectMany,Skip,SkipWhile,Take,TakeWhile,ThenBy,ThenByDescending,Union,Where]

            //[Eager or immediate execution] : return an atomic value, single element or a list
            //[Aggregate, All, Any, Average, Contains,Count,ElementAt,ElementAtOrDefault,Empty,First,FirstOrDefault,Last,LastOrDefault,LongCount,Max,Min,SequenceEqual,Single,SingleOrDefault,Sum,ToArray,ToDictionary,ToList,ToLookup]
            #endregion






            #endregion

        }




        public static IEnumerable<int> Sequance01()
        {
            //list implment Ienumrable 
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            return list;
        }

        public static void TryEagerExecution()
        {
            IEnumerable<int> list = Sequance01(); // here excute the function directly [list store the result already]
            // so now the all data in the list 
            foreach(var i in list)
            {
                Console.WriteLine(i);
            }   
        }

        public static IEnumerable<int> Sequance02()
        {
            // co-routine function explaine in trydefferdexecution
            Console.WriteLine("............... return 1 ");
            yield return 1;
            Console.WriteLine("............... return 2 ");
            yield return 2;
            Console.WriteLine("............... return 3 ");
            yield return 3;
            Console.WriteLine("............... return 4 ");
            yield return 4;
        }

        public static void TryDefeeredExecution()
        {
            IEnumerable<int> list = Sequance02(); // here compiler return an object that implment ienumrable store a commands to execute this fucntion
                                                  // - function dont excuted directly
                                                  // - the list variable now stores a set of commands to execute .
                                                  // - here sequance02 return an ienumrable object but in its movenext implelmentation is calling of the sequance02() function
                                                  // - there is no excution for the function untill iterate on the enumrable 
                                                  // - now list has an compiler generated class has ienumrable that i will use to excute the function and the return statment use it to return in it the return values 
            
            // in "co-routine" function : when i call function and i arrived to the line 5 in this function and make a return statment
            // and call this function again the function resume its work and dont execute from the start such [yield]
            // in sequance02() i write and return and when call this function in looping and call this function again it resume its execution
            
            foreach (int i in list) // tell list to get enumerator and call movenext function then call the function 
            {
                Console.WriteLine(i); 
            }

        }

    }





}

