using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Conn.GetRowNumbers();
            Console.WriteLine();
            Conn.GetPublisherDetails();
            Console.WriteLine();
            Conn.NumberOfBooksForEachPublisher();
            Console.WriteLine();
            Conn.TotalPriceForBooksForAPublisher();


            Console.ReadKey();

        }
    }
}
