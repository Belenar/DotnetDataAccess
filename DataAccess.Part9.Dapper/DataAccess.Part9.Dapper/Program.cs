using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccess.Part9.Dapper
{
    class Program
    {
        static void Main()
        {
            var persons = GetPersonsByInitialDapper("C");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }

            //InsertPerson();

            //var personX = GetFullPersonById(14178);

            //BulkInsert(new List<Person>()
            //{
            //    new Person { FirstName = "Jelle", LastName = "Raeymaeckers", RowId = Guid.NewGuid()},
            //    new Person { FirstName = "Senne", LastName = "Vanvinckenroye", RowId = Guid.NewGuid()},
            //    new Person { FirstName = "Kenny", LastName = "Van Houtven", RowId = Guid.NewGuid()},
            //    new Person { FirstName = "Michel", LastName = "Depuydt", RowId = Guid.NewGuid()}
            //});

            //var persons = GetPersonsListSupport(20778, 14178);

            Console.ReadLine();
        }

        private static List<Person> GetPersonsListSupport(params int[] ids)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                string query =
                    @"SELECT BusinessEntityID as Id, Title, FirstName, MiddleName, LastName, Suffix, rowguid as RowId
                        FROM AdventureWorks2014.Person.Person
                        WHERE BusinessEntityID IN @ids";
                var result = conn.Query<Person>(query, new { ids });

                return result.ToList();
            }
        }

        private static void BulkInsert(List<Person> persons)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                conn.Open();

                string query =
                    @"INSERT INTO Person.BusinessEntity (rowguid, ModifiedDate) VALUES (newid(), current_timestamp);
                      INSERT INTO Person.Person (BusinessEntityID, Title, FirstName, MiddleName, LastName, Suffix, rowguid, PersonType, NameStyle, EmailPromotion, ModifiedDate)
					    VALUES (SCOPE_IDENTITY(), @Title, @FirstName, @MiddleName, @LastName, @Suffix, @RowId, 'EM', 0, 1, current_timestamp)";

                conn.Execute(query, persons);
            }
        }

        private static Person GetFullPersonById(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                var query =
                    @"SELECT [BusinessEntityID] AS Id, [Title], [FirstName], [MiddleName], [LastName], [Suffix], [rowguid] AS RowID
                FROM [Person].[Person]
                WHERE[BusinessEntityID] = @id;

                SELECT[AddressLine1], [AddressLine2], [City]
                FROM[Person].[Address] ad INNER JOIN Person.BusinessEntityAddress ba ON ba.AddressID = ad.AddressID
                WHERE ba.BusinessEntityID = @id;";

                using (var multipleResults = conn.QueryMultiple(query, new { id }))
                {
                    var person = multipleResults.Read<Person>().SingleOrDefault();

                    if (person != null)
                    {
                        person.Addresses = multipleResults.Read<Address>().ToList();
                    }
                    return person;
                }
            }
        }

        private static void InsertPerson()
        {
            var person = new Person()
            {
                FirstName = "Hannes",
                LastName = "Lowette",
                MiddleName = "Lodewijk Maria",
                Title = "Pebkac",
                Suffix = "the Great",
                RowId = Guid.NewGuid()
            };

            InsertPersonDAL(person);
        }

        private static void InsertPersonDAL(Person person)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                string query =
                    @"INSERT INTO Person.BusinessEntity (rowguid, ModifiedDate) VALUES (newid(), current_timestamp);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);
                      INSERT INTO Person.Person (BusinessEntityID, Title, FirstName, MiddleName, LastName, Suffix, rowguid, PersonType, NameStyle, EmailPromotion, ModifiedDate)
					    VALUES (SCOPE_IDENTITY(), @Title, @FirstName, @MiddleName, @LastName, @Suffix, @RowId, 'EM', 0, 1, current_timestamp)";

                person.Id = conn.Query<int>(query, person).Single();
            }
        }


        private static List<Person> GetPersonsByInitialDapper(string firstnameInitial)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                string query =
                    @"SELECT BusinessEntityID as Id, Title, FirstName, MiddleName, LastName, Suffix, rowguid as RowId
                        FROM AdventureWorks2014.Person.Person
                        WHERE FirstName LIKE @initial + '%'";
                var result = conn.Query<Person>(query, new { Initial = firstnameInitial });

                return result.ToList();
            }
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
