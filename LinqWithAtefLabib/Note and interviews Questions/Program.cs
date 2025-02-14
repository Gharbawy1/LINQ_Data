namespace Note_and_interviews_Questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // What is the LINQ architecture? 
            /*
                 LINQ has a three-layered architecture. The language extensions are located in the top layer,
                and the data sources are located in the bottom layer.
                The objects used as the data sources often implement the general IEnumerable or IQueryable interfaces.

                Other than the fundamental LINQ query and data sources, an additional element is presently called the LINQ provider. 
                The purpose of a LINQ provider is to translate a LINQ query into a format that the available data sources can understand.
              */



            // Types of LINQ Queries ?
            /*
              1- Linq to Objects : objectCollection
              2- Linq to DataSets : ADO.NET DataSet 
              3- Linq to XML : XML document (XLINQ)
              4-  Linq to Entity : Entity FrameWork 
              5- Linq to SQL : SQL dataBase (DLINQ)
              6-  Implenting IQueryable : Other DataSources

            In addition to the types of LINQ mentioned above, there is also one called PLINQ, which is Microsoft's parallel LINQ.
            */

            // What is PLINQ ?
            /*
             Due to its tight ties to the task parallel library, it supports parallel programming. 
            With some queries, it makes it easier to use many processors automatically.
            PLINQ can speed up LINQ to Objects queries by effectively utilizing all of the host computer's cores

            */


           // What are the primary LINQ components, please? In the case of LINQ to SQL, what is the file extension ?
           // 1 -  we have 3 compnents : Linq provider , Language extension , standard query operators 
           // when using LINQ to SQL the file extension is .dbml

        }
    }
}