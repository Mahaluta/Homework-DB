using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to insert a new book?: yes/no.");
            if (Console.ReadLine() == "yes")
                Conn.InsertBook();
            Console.WriteLine("Do you want to update a book?: yes/no.");
            if (Console.ReadLine() == "yes")
                Conn.UpdateBook();
            Console.WriteLine("Do you want to delete a book?: yes/no.");
            if (Console.ReadLine() == "yes")
                Conn.DeleteBook();
            Console.WriteLine("Do you want to print the data of a book?: yes/no.");
            if (Console.ReadLine() == "yes")
                Conn.PrintBook();

            Console.ReadLine();
        }
    }
}
