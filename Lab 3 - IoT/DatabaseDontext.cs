using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cdv.people
{
     public class DatabaseContext
    {
        private readonly string connectionString;
        private const string Query = "Select * from people";

        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        PersonId = Convert.ToInt32(reader["PersonId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phonenumber = reader["PhoneNumber"].ToString()

                    });
                }
                reader.Close();
            }

            return people;
        }


    }
}