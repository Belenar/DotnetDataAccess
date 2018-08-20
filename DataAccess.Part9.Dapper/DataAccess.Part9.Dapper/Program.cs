using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Part9.Dapper
{
    class Program
    {
        static void Main()
        {
            var personList = GetPersonsByInitial("C");

            foreach (var person in personList)
            {
                Console.WriteLine(person.ToString());
            }
            Console.ReadLine();
        }

        private static List<Person> GetPersonsByInitial(string firstnameInitial)
        {
            var result = new List<Person>();
            // A connection
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                conn.Open();
                // A command
                using (var cmd = conn.CreateCommand())
                {
                    string query =
                        @"SELECT BusinessEntityID, Title, FirstName, MiddleName, LastName, Suffix, rowguid
                        FROM AdventureWorks2014.Person.Person
                        WHERE FirstName LIKE @initial + '%'";

                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@initial", firstnameInitial));
                    // A reader
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var person = new Person
                            {
                                Id = (int)reader["BusinessEntityID"],
                                Title = (string)reader["Title"].ConvertNullValue(),
                                FirstName = (string)reader["FirstName"].ConvertNullValue(),
                                MiddleName = (string)reader["MiddleName"].ConvertNullValue(),
                                LastName = (string)reader["LastName"].ConvertNullValue(),
                                Suffix = (string)reader["Suffix"].ConvertNullValue(),
                                RowId = (Guid)reader["rowguid"]
                            };
                            result.Add(person);
                        }
                    }
                }
            }
            return result;
        }
    }
}
