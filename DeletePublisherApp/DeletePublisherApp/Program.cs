using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletePublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to delete a publisher?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.DeletePublisher();

            Console.WriteLine("Do you want to delete a publisher with the stored procedure?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.DeletePublisherStoredProcedure();

            Console.WriteLine("Do you want to delete a publisher and his books?: yes/no");
            if (Console.ReadLine() == "yes")
                Conn.DeletePublisherAndBooks();


            Console.ReadKey();
        }
    }
}
