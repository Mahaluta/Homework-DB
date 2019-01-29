using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SummaryPublisherApp
{
    public class Conn
    {
            public static void GetRowNumbers() {
                SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                        connection.Open();

                // GetRowNumbers
                SqlCommand NumberOfRows = new SqlCommand(@"SELECT Count(*) FROM Publisher;", connection);
                int number = (int)NumberOfRows.ExecuteScalar();
                Console.WriteLine($"Number of rows: {number}");

                        connection.Close();


            }

            public static void GetPublisherDetails() {
                SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                       connection.Open();

                // Get Publisher Details
                SqlCommand PublisherDetails = new SqlCommand(@"SELECT TOP 10 PublisherId,Name FROM Publisher;", connection);
                SqlDataReader reader = PublisherDetails.ExecuteReader();

                while (reader.Read())
                {
                    string Publisher = $"{reader["PublisherId"]}. {reader["Name"]}";
                    Console.WriteLine(Publisher);
                }

                reader.Close();
                        connection.Close();
            }

            public static void NumberOfBooksForEachPublisher() {
                SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                         connection.Open();

                // Number Of Books for each Publisher
                SqlCommand NumberOfBooksForAPublisher = new SqlCommand("SELECT COUNT(b.BookId), p.Name FROM Book b INNER JOIN Publisher p ON b.PublisherID = p.PublisherID GROUP BY p.Name;", connection);
                SqlDataReader reader = NumberOfBooksForAPublisher.ExecuteReader();
                while (reader.Read())
                {
                    string Printer = $"{reader[1]}. {reader[0]} book/s";
                    Console.WriteLine(Printer);
                }
                reader.Close();

                        connection.Close();

            }

            public static void TotalPriceForBooksForAPublisher()
            {
                SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                        connection.Open();

                // Total Price for Books for a Publisher
                SqlCommand SumPriceOfBooksForAPublisher = new SqlCommand("SELECT  p.Name, SUM(b.Price) as 'Price' FROM Book b INNER JOIN Publisher p ON b.PublisherId = p.PublisherId GROUP BY p.Name;", connection);
                SqlDataReader reader = SumPriceOfBooksForAPublisher.ExecuteReader();
                while (reader.Read())
                 {
                        Console.WriteLine($"{reader[0]} are suma: {reader[0]}.");
                 }
                reader.Close();

                        connection.Close();

            }

    }

}

