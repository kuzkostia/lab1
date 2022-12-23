using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab1
{

    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=DESKTOP-G5U6MU1\MYSQLSERVER;Initial Catalog=atelierDB;Integrated Security=true";

            string queryString =
               "SELECT Number, Price, DateOfAdmission, DateOfIssue, LastName, FirstName, MiddleName" +
               "FROM Orders INNER JOIN Users on Orders.UserID = Users.ID";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("{0,12} {1,7} {2,20} {3,20} {4,17} {5,17} {6,17}\n", "Number", "Price", "Date of addmission", "Date of issue", "LastName", "FirstName", "MiddleName");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
