using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CrudBookApp
{
    public class Conn
    {
        public static void InsertBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            Console.Write("Read the title of the book: ");
            string BN = Console.ReadLine();
            Console.Write("Read the ID of the Publisher: ");
            int PID = Convert.ToInt32(Console.ReadLine());

            // INSERT INTO Book
            SqlParameter BookNameParameter = new SqlParameter("BookNameParameter", BN);
            SqlParameter PublisherIDParameter = new SqlParameter("PublisherIDParameter", PID);

            SqlCommand InsertBook = new SqlCommand(@"INSERT INTO Book(Title,PublisherId) VALUES (@BookNameParameter,@PublisherIDParameter);", connection);
            InsertBook.Parameters.Add("BookNameParameter", SqlDbType.VarChar).Value = BN;
            InsertBook.Parameters.Add("PublisherIDParameter", SqlDbType.Int).Value = PID;

            InsertBook.ExecuteNonQuery();

            // Get Current ID
            SqlCommand GetID = new SqlCommand(@"SELECT TOP 1 BookId FROM Book ORDER BY BookId DESC;", connection);
            int CurrentID = (int)GetID.ExecuteScalar();
            Console.WriteLine($"\n BookID: {CurrentID}");

                    connection.Close();

            Console.WriteLine("Book has been inserted");

        }

        public static void UpdateBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            Console.Write("Read the ID of the book: ");
            int BookID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Read the new Name for the book: ");
            string NewBookName = Console.ReadLine();

            SqlParameter BookIDParmater = new SqlParameter("BookIDParameter", BookID);
            SqlParameter NewBookNameParameter = new SqlParameter("NewBookNameParameter", NewBookName);

            SqlCommand UpdateBook = new SqlCommand(@"UPDATE book SET Title=@NewBookNameParameter WHERE BookID=@BookIDParameter", connection);
            UpdateBook.Parameters.Add("BookIDParameter", SqlDbType.Int).Value = BookID;
            UpdateBook.Parameters.Add("NewBookNameParameter", SqlDbType.VarChar).Value = NewBookName;

            UpdateBook.ExecuteNonQuery();

                    connection.Close();

            Console.WriteLine("Book has been updated");
        }

        public static void DeleteBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            Console.Write("Read the ID of the book: ");
            int BookID = Convert.ToInt32(Console.ReadLine());

            SqlParameter BookIDParmater = new SqlParameter("BookIDParameter", BookID);

            SqlCommand DeleteBook = new SqlCommand(@"DELETE FROM Book WHERE BookId=@BookIDParameter",connection);
            DeleteBook.Parameters.Add("BookIDParameter", SqlDbType.Int).Value = BookID;

            DeleteBook.ExecuteNonQuery();

                    connection.Close();

            Console.WriteLine("Book has been deleted");
        }

        public static void PrintBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            Console.Write("Read the ID of the book: ");
            int BookID = Convert.ToInt32(Console.ReadLine());

            SqlParameter BookIDParmater = new SqlParameter("BookIDParameter", BookID);

            SqlCommand PrintBook = new SqlCommand(@"SELECT BookId,Title,PublisherId,Year,Price FROM Book WHERE BookId=@BookIDParameter", connection);
            PrintBook.Parameters.Add("BookIDParameter", SqlDbType.Int).Value = BookID;

            SqlDataReader reader = PrintBook.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]} - Title: {reader["Title"]} - Year: {reader["Year"]} - Price: {reader["Price"]} - PublisherID: {reader["PublisherId"]}");
            }
            reader.Close();

            connection.Close();

        }
    }
}
