using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab1
{

    class Program
    {
        static void Main()
        {
            string connectionString = "Data Source=(local);Initial Catalog=AtelierDB;Integrated Security=true";

            string queryString =
                "SELECT dbo.UniversityTeachers.id, first_name, last_name, patronymic_name, dbo.Workplaces.name,first_subj.name as first_subject,second_subj.name as second_subject, position_hourly_rate,count_read_hours,home_address,characteristics" +
                    " FROM dbo.UniversityTeachers INNER JOIN dbo.Subjects AS first_subj ON first_subj.id = first_subject_name " +
                    "INNER JOIN dbo.Subjects AS second_subj ON second_subj.id = ISNULL(second_subject_name, CAST(NULL AS INT))" +
                    "INNER JOIN dbo.Workplaces ON work_place = dbo.Workplaces.id";

            //int paramValue = 5;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);//

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10]);
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
