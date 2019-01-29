using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InsertPublisherApp
{
    internal class Conn
    {
        public static void InsertPublisher(string PublisherName) {

            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source =.; Initial Catalog = Library; Integrated Security = True" };

                    connection.Open();

            // INSERT INTO Publisher
            SqlParameter PublisherNameParameter = new SqlParameter("PublisherNameParameter",PublisherName);

            SqlCommand InsertPublisher = new SqlCommand(@"INSERT INTO Publisher(Name) VALUES (@PublisherNameParameter);",connection);
            InsertPublisher.Parameters.Add("PublisherNameParameter", SqlDbType.VarChar).Value = PublisherName;

            InsertPublisher.ExecuteNonQuery();
 
            // GetID
            SqlCommand GetID = new SqlCommand(@"SELECT TOP 1 PublisherId FROM Publisher ORDER BY PublisherId DESC;", connection);
            int CurrentID = (int)GetID.ExecuteScalar();
            Console.WriteLine($"\n PublisherID: {CurrentID}");

                    connection.Close();

        }
    }
}
