using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    public class TreatmentRepo
    {
        private List<Treatment> treatments = new List<Treatment>();
        public string ConnectToDB = "Server=10.56.8.32; database=A_DB41_2019; user id=A_STUDENT41; password=A_OPENDB41;";

        /*
         * SELECT TOP (1000) [TreatId]
          ,[TreatService]
          ,[TreatDate]
          ,[TreatCharge]
          ,[PetId]
          FROM [A_DB41_2019].[dbo].[TREATMENT]
         */

        public TreatmentRepo()
        {
            // Load all treatment data from database via SQL statements and populate treatment repository
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectToDB;
                    conn.Open();

                    // using the code here...
                    SqlCommand sql = new SqlCommand("SELECT * FROM [A_DB41_2019].[dbo].[TREATMENT]", conn);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            //create owner and assign info
                            var treatment = new Treatment();

                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t |", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));

                            treatment.TreatId = (int)reader["TreatId"];
                            treatment.Service = (string)reader["TreatService"];
                            treatment.Date = (DateTime)reader["TreatDate"];
                            treatment.Charge = (double)reader["TreatCharge"];

                            treatments.Add(treatment);
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

        public int Add(Treatment treatment)
        {
            // Add new treatment to database and to repository
            // Return the database id of the treatment

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }
        public List<Treatment> GetAll()
        {
            // Retrieve all treatments from database

            List<Treatment> result = new List<Treatment>();

            // IMPLEMENT THIS!

            return result;
        }
        public Treatment GetById(int id)
        {
            // Get treatment by id from database

            Treatment result = null;

            // IMPLEMENT THIS!

            return result;
        }
        public void Update(Treatment treatment)
        {
            // Update existing treatment on database

            // IMPLEMENT THIS!
        }
        public void Remove(Treatment treatment)
        {
            // Delete existing treatment in database

            // IMPLEMENT THIS!
        }
    }
}
