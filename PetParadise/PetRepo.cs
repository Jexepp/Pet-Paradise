using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace PetParadise
{
    public class PetRepo
    {
        private List<Pet> pets = new List<Pet>();
        public string ConnectToDB = "Server=10.56.8.32; database=A_DB41_2019; user id=A_STUDENT41; password=A_OPENDB41;";

        public PetRepo()
        {
            // Load all pet data from database via SQL statements and populate pet repository
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand sql = new SqlCommand("SELECT * FROM [A_DB41_2019].[dbo].[PET]", conn);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            //create owner and assign info
                            var pet = new Pet();

                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t |", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));

                            //SELECT TOP (1000) [PetId]
                            //,[PetName]
                            //,[PetType]
                            //,[PetBreed]
                            //,[PetDOB]
                            //,[PetWeight]
                            //,[OwnerId]
                            //  FROM[A_DB41_2019].[dbo].[PET]

                            pet.PetId = (int)reader["PetId"];
                            pet.Name = (string)reader["PetName"];
                            pet.PetType = (PetTypes)reader["PetType"];
                            pet.Breed = (string)reader["PetBreed"];
                            pet.DOB = (DateTime)reader["PetDOB"];
                            pet.Weight = (double)reader["PetWeight"];

                            pets.Add(pet);
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

        public int Add(Pet pet)
        {
            // Add new pet to database and to repository
            // Return the database id of the pet

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }
        public List<Pet> GetAll()
        {
            // Retrieve all pets from database

            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand sql = new SqlCommand("SELECT * FROM [A_DB41_2019].[dbo].[PET]", conn);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = sql.ExecuteReader())
                        // while there is another record present
                        while (reader.Read())
                        {
                            //create owner and assign info
                            var pet = new Pet();

                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t |", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));

                            //SELECT TOP (1000) [PetId]
                            //,[PetName]
                            //,[PetType]
                            //,[PetBreed]
                            //,[PetDOB]
                            //,[PetWeight]
                            //,[OwnerId]
                            //  FROM[A_DB41_2019].[dbo].[PET]

                            pet.PetId = (int)reader["PetId"];
                            pet.Name = (string)reader["PetName"];
                            pet.PetType = (PetTypes)reader["PetType"];
                            pet.Breed = (string)reader["PetBreed"];
                            pet.DOB = (DateTime)reader["PetDOB"];
                            pet.Weight = (double)reader["PetWeight"];

                            result.Add(pet);
                        }
                    }
                    //Closes automatically with the "using" keyword
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return result;
        }


        public Pet GetById(int id)
        {
            // Get pet by id from database
            Pet result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    SqlCommand sql = new SqlCommand("SELECT * FROM Pet WHERE PetID = @0", conn);

                    sql.Parameters.Add(new SqlParameter("0", id));

                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        result.PetId = (int)reader["PetId"];
                        result.Name = (string)reader["PetName"];
                        result.PetType = (PetTypes)reader["PetType"];
                        result.Breed = (string)reader["PetBreed"];
                        result.DOB = (DateTime)reader["PetDOB"];
                        result.Weight = (double)reader["PetWeight"];

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

        public void Update(Pet pet)
        {
            // Update existing pet on database

            // IMPLEMENT THIS!
        }
        public void Remove(Pet pet)
        {
            // Delete existing pet in database

            // IMPLEMENT THIS!
        }
    }
}
