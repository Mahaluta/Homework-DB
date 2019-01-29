using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DeletePublisherApp
{
    public class Conn
    {
        public static void DeletePublisher()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

            connection.Open();

            Console.Write("Read the publisher's ID: ");
            int PublisherID = Convert.ToInt32(Console.ReadLine());

            SqlParameter PID = new SqlParameter("PublisherID", PublisherID);
            SqlCommand DelPublisher = new SqlCommand(@"ALTER TABLE Book DROP CONSTRAINT FK_Book_PublisherId ; DELETE FROM Publisher WHERE PublisherId=@PublisherID; ALTER TABLE Book WITH NOCHECK ADD CONSTRAINT FK_Book_PublisherId FOREIGN KEY (PublisherId) REFERENCES Publisher(PublisherId);", connection);

            DelPublisher.CommandType = CommandType.StoredProcedure;

            DelPublisher.Parameters.Add("PublisherID", SqlDbType.Int).Value = PublisherID;

            DelPublisher.ExecuteNonQuery();

            Console.WriteLine("The publisher has been deleted.");
        }

        public static void DeletePublisherStoredProcedure()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

            connection.Open();

            Console.Write("Read the publisher's ID: ");
            int PublisherID = Convert.ToInt32(Console.ReadLine());

            SqlParameter PID = new SqlParameter("PublisherID", PublisherID);
            SqlCommand DelPublisher = new SqlCommand("DelPub", connection);

            DelPublisher.CommandType = CommandType.StoredProcedure;

            DelPublisher.Parameters.Add("PublisherID", SqlDbType.Int).Value = PublisherID;

            DelPublisher.ExecuteNonQuery();

            Console.WriteLine("The publisher has been deleted.");

            /* CREATE PROCEDURE DelPub
            @PublisherID int
            AS
            ALTER TABLE Book DROP CONSTRAINT FK_Book_PublisherId;
            DELETE FROM Publisher WHERE PublisherId = @PublisherID;
            ALTER TABLE Book WITH NOCHECK ADD CONSTRAINT FK_Book_PublisherId FOREIGN KEY(PublisherId) REFERENCES Publisher(PublisherId);
            */
        }

        public static void DeletePublisherAndBooks()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

            connection.Open();

            Console.Write("Read the publisher's ID: ");
            int PublisherID = Convert.ToInt32(Console.ReadLine());

            SqlParameter PID = new SqlParameter("PublisherID", PublisherID);
            SqlCommand DelPublisher = new SqlCommand("DelPubAndBooks", connection);

            DelPublisher.CommandType = CommandType.StoredProcedure;

            DelPublisher.Parameters.Add("PublisherID", SqlDbType.Int).Value = PublisherID;

            DelPublisher.ExecuteNonQuery();

            Console.WriteLine("The publisher and his books were deleted.");

            /*
             CREATE PROCEDURE DelPubAndBooks
            @PublisherID int
            AS
            ALTER TABLE Book DROP CONSTRAINT FK_Book_PublisherId ; 
            DELETE FROM Publisher WHERE PublisherId=@PublisherID; 
            DELETE FROM Book WHERE PublisherId=@PublisherID;
            ALTER TABLE Book WITH NOCHECK ADD CONSTRAINT FK_Book_PublisherId FOREIGN KEY (PublisherId) REFERENCES Publisher(PublisherId);
            */
        }
    }

}
