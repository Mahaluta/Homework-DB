using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SummaryBookApp
{
    public class Conn
    {
        public static void Books2010()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            SqlCommand BooksYear2010 = new SqlCommand(@"SELECT BookId,Title,Year,Price,PublisherId FROM Book WHERE Year=2010", connection);

            SqlDataReader reader = BooksYear2010.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]} - Title: {reader["Title"]} - Year: {reader["Year"]} - Price: {reader["Price"]} - PublisherID: {reader["PublisherId"]}");
            }

            reader.Close();

                    connection.Close();

        }

        public static void BooksMaxYear()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            SqlCommand MaxYear = new SqlCommand(@"SELECT MAX(Year) FROM Book", connection);
            int maxyear = (int)MaxYear.ExecuteScalar();

            SqlParameter max = new SqlParameter("BookMaxYear", maxyear);
            SqlCommand BooksPrintByMaxYear = new SqlCommand(@"SELECT BookId,Title,Year,Price,PublisherId FROM Book WHERE Year = @BookMaxYear;", connection);
            BooksPrintByMaxYear.Parameters.Add("BookMaxYear", SqlDbType.Int).Value = maxyear;

            SqlDataReader reader = BooksPrintByMaxYear.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]} - Title: {reader["Title"]} - Year: {reader["Year"]} - Price: {reader["Price"]} - PublisherID: {reader["PublisherId"]}");
            }

            reader.Close();

                    connection.Close();

        }

        public static void Top10Books()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            SqlCommand TopTenBooks = new SqlCommand(@"SELECT TOP 10 BookId,Title,Year,Price,PublisherId FROM Book;", connection);

            SqlDataReader reader = TopTenBooks.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]} - Title: {reader["Title"]} - Year: {reader["Year"]} - Price: {reader["Price"]} - PublisherID: {reader["PublisherId"]}");
            }

            reader.Close();

                    connection.Close();
        }
    }
}
