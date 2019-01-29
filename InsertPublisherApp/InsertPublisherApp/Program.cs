using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InsertPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Insert a new Publisher: \n");
            Console.Write("Read the publisher's name: ");
            Conn.InsertPublisher(Console.ReadLine());



            Console.ReadKey();

        }
    }
}
