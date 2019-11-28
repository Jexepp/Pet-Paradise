using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace PetParadise
{
    public class OwnerRepo
    {
        private List<Owner> owners = new List<Owner>();

        //Server=10.56.8.32; database=<databasenavn>; user id=<user>; password=<password>;
        public string ConnectToDB = "Server=10.56.8.32; database=A_DB41_2019; user id=A_STUDENT41; password=A_OPENDB41;";

        public OwnerRepo()
        {
            // Load all owner data from database via SQL statements and populate owner repository
            //SELECT * FROM Owner
            //-DB: A_DB41_2019 -USER: A_STUDENT41 -PASS: A_OPENDB41
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand sql = new SqlCommand("SELECT [OwnerId],[OwnerFirstName],[OwnerLastName],[OwnerPhone],[OwnerEmail] FROM [A_DB41_2019].[dbo].[OWNER]", conn);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            //create owner and assign info
                            var owner = new Owner();

                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t |", reader[0], reader[1], reader[2], reader[3], reader[4]));
                            /*
                            SELECT TOP(1000) [OwnerId]
                              ,[OwnerFirstName]
                              ,[OwnerLastName]
                              ,[OwnerPhone]
                              ,[OwnerEmail]
                                FROM[A_DB41_2019].[dbo].[OWNER]
                                */
                            /*   
                            *   Protection against null values:
                            */
                            owner.OwnerId = (int)reader["OwnerId"];

                            if (reader["OwnerFirstName"] != DBNull.Value)
                                owner.FirstName = (string)reader["OwnerFirstName"];
                            else
                                owner.FirstName = null;

                            if (reader["OwnerLastName"] != DBNull.Value)
                                owner.LastName = (string)reader["OwnerLastName"];
                            else
                                owner.LastName = null;

                            owner.Phone = (int)reader["OwnerPhone"];

                            owner.Email = (string)reader["OwnerEmail"];
                            if (reader["OwnerEmail"] != DBNull.Value)
                                owner.Email = (string)reader["OwnerEmail"];
                            else
                                owner.Email = null;

                            owners.Add(owner);
                        }
                    }
                    //Closes automatically with the "using" keyword
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public int Add(Owner owner)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO TableName (OwnerFirstName, OwnerSecondName, OwnerPhone, OwnerEmail) VALUES (@0, @1, @2, @3)", conn);

                    insertCommand.Parameters.Add(new SqlParameter("0", owner.FirstName));
                    insertCommand.Parameters.Add(new SqlParameter("1", owner.LastName));
                    insertCommand.Parameters.Add(new SqlParameter("2", owner.Phone));
                    insertCommand.Parameters.Add(new SqlParameter("3", owner.Email));

                    return (int)insertCommand.ExecuteScalar();

                    //OVERFLØDIGT!?
                    //SqlCommand returnIdCommand = new SqlCommand("SELECT OwnerId FROM Owner WHERE OwnerPhone = @0 AND OwnerEmail = @1", conn);

                    //returnIdCommand.Parameters.Add(new SqlParameter("0", owner.Phone));
                    //returnIdCommand.Parameters.Add(new SqlParameter("1", owner.Email));

                    //using (SqlDataReader reader = returnIdCommand.ExecuteReader())
                    //{
                    //    // while there is another record present
                    //    while (reader.Read())
                    //    {
                    //        owner.OwnerId = (int)reader["OwnerId"];
                    //    }
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return -1;
            }
        }


        public List<Owner> GetAll()
        {
            // Retrieve all owners from database

            List<Owner> result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand sql = new SqlCommand("SELECT * FROM Owner", conn);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            //create owner and assign info
                            var owner = new Owner();

                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} | {4} \t |", reader[0], reader[1], reader[2], reader[3], reader[4]));

                            //OWNER(OwnerId, OwnerFirstName, OwnerLastName, OwnerPhone, OwnerEmail)
                            owner.OwnerId = (int)reader["OwnerId"];

                            if (reader["OwnerFirstName"] != DBNull.Value)
                                owner.FirstName = (string)reader["OwnerFirstName"];
                            else
                                owner.FirstName = null;

                            if (reader["OwnerLastName"] != DBNull.Value)
                                owner.LastName = (string)reader["OwnerLastName"];
                            else
                                owner.LastName = null;

                            owner.Phone = (int)reader["OwnerPhone"];

                            if (reader["OwnerEmail"] != DBNull.Value)
                                owner.Email = (string)reader["OwnerEmail"];
                            else
                                owner.Email = null;

                            result.Add(owner);
                        }
                    }
                    //Closes automatically with the "using" keyword
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return result;
        }

        public Owner GetById(int id)
        {
            // Get owner by id from database

            Owner result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    SqlCommand sql = new SqlCommand("SELECT * FROM Owner WHERE OwnerID = @0", conn);

                    sql.Parameters.Add(new SqlParameter("0", id));

                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        result.OwnerId = (int)reader["OwnerId"];
                        result.FirstName = (string)reader["OwnerFirstName"];
                        result.LastName = (string)reader["OwnerLastName"];
                        result.Phone = (int)reader["OwnerPhone"];
                        result.Email = (string)reader["OwnerEmail"];

                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return result;
        }

        public void Update(Owner owner)
        {
            // Update existing owner on database

            // IMPLEMENT THIS!
        }
        public void Remove(Owner owner)
        {
            // Delete existing owner in database

            // IMPLEMENT THIS!
        }

    }
}
