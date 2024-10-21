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
    public class VictimDAO : IVictimDAO
    {
        private string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");

        public int AddVictim(Victim victim)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation) " +
                    "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactInformation); SELECT SCOPE_IDENTITY();", sqlConnection))
                {
                    command.Parameters.AddWithValue("@FirstName", victim.FirstName);
                    command.Parameters.AddWithValue("@LastName", victim.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", victim.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", victim.Gender);
                    command.Parameters.AddWithValue("@ContactInformation", victim.ContactInformation);

                    object result = command.ExecuteScalar();

                    if (result == null || !int.TryParse(result.ToString(), out int newVictimId) || newVictimId <= 0)
                    {
                        throw new Exception("Failed to add victim.");
                    }

                    return newVictimId;
                }
            }
        }

        public Victim GetVictimById(int victimId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Victims WHERE VictimId = @VictimId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@VictimId", victimId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Victim victim = new Victim
                        {
                            VictimId = reader.GetInt32("VictimId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth"),
                            Gender = reader.GetString("Gender"),
                            ContactInformation = reader.GetString("ContactInformation")
                        };
                        reader.Close();
                        return victim;
                    }
                    else
                    {
                        reader.Close();
                        return null; 
                    }
                }
            }
        }

        public List<Victim> GetAllVictims()
        {
            List<Victim> victims = new List<Victim>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Victims", sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Victim victim = new Victim
                        {
                            VictimId = reader.GetInt32("VictimId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth"),
                            Gender = reader.GetString("Gender"),
                            ContactInformation = reader.GetString("ContactInformation")
                        };
                        victims.Add(victim);
                    }
                    reader.Close();
                }
            }
            return victims;
        }

    }
}
