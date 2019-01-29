using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to print all the books from 2010?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.Books2010();

            Console.WriteLine("Do you want to print all the books by max year?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.BooksMaxYear();

            Console.WriteLine("Do you want to print top 10 books?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.Top10Books();



            Console.ReadKey();
            
        }
    }
}
