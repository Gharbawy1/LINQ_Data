namespace LINQ_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Any collection implment IEnumrable<T> is called as a Sequance 
            // 2 Types of sequances 
            // Local sequance : LinqToObject , Linq2ADO , Linq2XML built in memory
            // Remote sequance : L2sql,L2E [LINQ to Entity]

            // We can call the extension method as it static function with the class name 
            // but we must pass the input list of the list i need to perform the filtertion on it 
            List<int> list = new List<int>() { 1,2,3,4,5,6};
            Enumerable.Where(list, i => i % 2 == 0); 

            // call it as an extension method 
            var filterdnums = list.Where(i=>i%2==0);

            #region Operators types
            //[deffered types and eager types but we dont this types]

            // ==== 3 Types ==== 
            //1- operator take the input sequance or list and return another out sequance and the out sequance <= input sequance
            //2- operator take input and return single value [elment operators , aggregrate opertator]
            //3- operator take no input and produce an out sequance that is called generation sequance [range ,.. ,..] so we cant call them as a static functions






            #endregion


            /// Query Syntax is more easier than to write it rather than writing Extension method 
            /// and this cases shown at (Join , Group , Let , Into)
            // Lets write a Query Syntax and know what it represent 
            var result = from i in list 
                         where i%2 == 0
                         select i;
            // we will explain the steps we write the query synatx and explain this query
            // Start with from clause , introduce the range variable (i) : represent each and every elment in Input Sequance 
            // and within this 2 clauses we write the all logic 
            // End with select or Group by .




        }
    }
}