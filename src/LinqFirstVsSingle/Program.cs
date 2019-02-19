using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFirstVsSingle
{
    class Program
    {
        static void Main(string[] args)
        {
            //sample data
            string[] names = { "Bob", "Gary", "Dave", "Barry", "Geena", "Harry" };

            //LINQ first examples

            var first = names.First();
            //value will be Bob
            Console.WriteLine(first);

            first = names.Where(m => m.StartsWith("B")).First();
            //value will still be bob
            Console.WriteLine(first);

            try
            {
                //throw an exception since count will be 0
                first = names.Where(m => m.StartsWith("A")).First();
                Console.WriteLine(first);
            }
            catch (InvalidOperationException ex)
            {
                //InvalidOperationException 
                Console.WriteLine("No result.");
            }

            first = names.Where(m => m.StartsWith("A")).FirstOrDefault();
            //value will be null
            Console.WriteLine(first!=null?first:"No result.");

            //LINQ single examples
            string single;

            try
            { 
                single = names.Single();
                //throw an exception since there is more than one
                Console.WriteLine(single);
            }
            catch(InvalidOperationException ex )
            {
                //InvalidOperationException 
                Console.WriteLine("No result.");
            }

            single = names.Where(m => m.StartsWith("D")).Single();
            //success since one a single result is returned.
            Console.WriteLine(single);

            try
            {
                single = names.Where(m => m.StartsWith("A")).Single();
                //throw an exception since count will be 0
                Console.WriteLine(single);
            }
            catch (InvalidOperationException ex)
            {
                //InvalidOperationException 
                Console.WriteLine("No result.");
            }


            single = names.Where(m => m.StartsWith("A")).SingleOrDefault();
            //value will be null
            Console.WriteLine(single != null ? single : "No result.");


            Console.ReadKey();
        }
    }
}
