using EntityLibrary;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public class SuspectDAO : ISuspectDAO
    {
        private string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
        public bool AddSuspect(Suspect suspect)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation) " +
                    "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation); SELECT SCOPE_IDENTITY();", sqlConnection))
                {
                    command.Parameters.AddWithValue("@FirstName", suspect.FirstName);
                    command.Parameters.AddWithValue("@LastName", suspect.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", suspect.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", suspect.Gender);
                    command.Parameters.AddWithValue("@ContactInformation", suspect.ContactInformation);

                    int newSuspectId = Convert.ToInt32(command.ExecuteScalar());
                    suspect.SuspectId = newSuspectId; 

                    return newSuspectId > 0;
                }
            }
        }

        public Suspect GetSuspectById(int suspectId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Suspects WHERE SuspectId = @SuspectId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@SuspectId", suspectId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Suspect suspect = new Suspect
                        {
                            SuspectId = reader.GetInt32("SuspectId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth"),
                            Gender = reader.GetString("Gender"),
                            ContactInformation = reader.GetString("ContactInformation")
                        };
                        reader.Close();
                        return suspect;
                    }
                    else
                    {
                        reader.Close();
                        return null; 
                    }
                }
            }
        }

        public List<Suspect> GetAllSuspects()
        {
            List<Suspect> suspects = new List<Suspect>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Suspects", sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Suspect suspect = new Suspect
                        {
                            SuspectId = reader.GetInt32("SuspectId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth"),
                            Gender = reader.GetString("Gender"),
                            ContactInformation = reader.GetString("ContactInformation")
                        };
                        suspects.Add(suspect);
                    }
                    reader.Close();
                }
            }
            return suspects;
        }
    }
}
