using EntityLibrary;
using ExceptionLibrary;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAOLibrary
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        public int CreateIncident(Incident incident)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                
                using (SqlCommand command = new SqlCommand("INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimId, SuspectId) VALUES (@IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimId, @SuspectId); SELECT SCOPE_IDENTITY()", sqlConnection))
                {
                    command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    command.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    command.Parameters.AddWithValue("@Location", incident.Location);
                    command.Parameters.AddWithValue("@Description", incident.Description);
                    command.Parameters.AddWithValue("@Status", incident.Status);
                    command.Parameters.AddWithValue("@VictimId", incident.VictimId);
                    command.Parameters.AddWithValue("@SuspectId", incident.SuspectId);

             
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int newIncidentId))
                    {
                        return newIncidentId;
                    }
                    else
                    {
                        throw new Exception("Failed to create incident.");
                    }
                }
            }
        }

        public bool UpdateIncidentStatus(string status, int incidentId)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Incidents SET Status = @Status WHERE IncidentId = @IncidentId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@IncidentId", incidentId);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }

            }
            
        }

        public List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                List<Incident> incidents = new List<Incident>();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate", sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        Incident incident = new Incident();
                        incident.IncidentId = reader.GetInt32("IncidentId");
                        incident.IncidentType = reader.GetString("IncidentType");
                        incident.IncidentDate = reader.GetDateTime("IncidentDate");
                        incident.Location = reader.GetString("Location");
                        incident.Description = reader.GetString("Description");
                        incident.Status = reader.GetString("Status");
                        incident.VictimId = reader.GetInt32("VictimId");
                        incident.SuspectId = reader.GetInt32("SuspectId");
                        incidents.Add(incident);
                    }
                    reader.Close();
                }
                return incidents;

            }
            
        }

        public List<Incident> SearchIncidents(Incident incidentType)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                List<Incident> incidents = new List<Incident>();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentType = @IncidentType", sqlConnection))
                {
                    command.Parameters.AddWithValue("@IncidentType", incidentType.IncidentType);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Incident incident = new Incident();
                        incident.IncidentId = reader.GetInt32("IncidentId");
                        incident.IncidentType = reader.GetString("IncidentType");
                        incident.IncidentDate = reader.GetDateTime("IncidentDate");
                        incident.Location = reader.GetString("Location");
                        incident.Description = reader.GetString("Description");
                        incident.Status = reader.GetString("Status");
                        incident.VictimId = reader.GetInt32("VictimId");
                        incident.SuspectId = reader.GetInt32("SuspectId");
                        incidents.Add(incident);
                    }
                    reader.Close();
                }
                return incidents;
            }
            
        }

        public Report GenerateIncidentReport(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentNullException(nameof(incident), "The incident cannot be null.");
            }

            Report report = new Report
            {
                IncidentId = incident.IncidentId,
                ReportDate = DateTime.Now,
                ReportDetails = GenerateReportDetails(incident),
                Status = "Pending"  
            };

            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Reports (IncidentId, ReportDate, ReportDetails, Status) VALUES (@IncidentId, @ReportDate, @ReportDetails, @Status); SELECT SCOPE_IDENTITY()", sqlConnection))
                {
                    command.Parameters.AddWithValue("@IncidentId", report.IncidentId);
                    command.Parameters.AddWithValue("@ReportDate", report.ReportDate);
                    command.Parameters.AddWithValue("@ReportDetails", report.ReportDetails);
                    command.Parameters.AddWithValue("@Status", report.Status);

                    int reportId = Convert.ToInt32(command.ExecuteScalar());
                    report.ReportId = reportId; 
                }
            }

            return report;
        }

        private string GenerateReportDetails(Incident incident)
        {
            return $"Incident ID: {incident.IncidentId}\n" +
                   $"Incident Type: {incident.IncidentType}\n" +
                   $"Incident Date: {incident.IncidentDate:yyyy-MM-dd}\n" +
                   $"Location: {incident.Location}\n" +
                   $"Description: {incident.Description}\n" +
                   $"Status: {incident.Status}\n" +
                   $"Report Date: {DateTime.Now:yyyy-MM-dd}";
        }

        public Case CreateCase(string caseDescription, List<int> incidentIds)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Cases (CaseDescription) VALUES (@CaseDescription); SELECT SCOPE_IDENTITY()", sqlConnection))
                {
                    command.Parameters.AddWithValue("@CaseDescription", caseDescription);

                    decimal caseIdDecimal = (decimal)command.ExecuteScalar();
                    int caseId = Convert.ToInt32(caseIdDecimal);

                    if (caseId > 0)
                    {
                        foreach (int incidentId in incidentIds)
                        {
                            Incident incident = GetIncidentById(incidentId);
                            AssociateIncidentWithCase(caseId, incident.IncidentId);
                        }

                        return new Case(caseId, caseDescription, incidentIds.Select(GetIncidentById).ToList());
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        private void AssociateIncidentWithCase(int caseId, int incidentId)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO CaseIncidents (CaseId, IncidentId) VALUES (@CaseId, @IncidentId)", sqlConnection))
                {
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@IncidentId", incidentId);

                    command.ExecuteNonQuery();
                }

            }
            
        }

        public Case GetCaseDetails(int caseId)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Cases WHERE CaseId = @CaseId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@CaseId", caseId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Case caseObj = new Case();
                        caseObj.CaseId = reader.GetInt32("CaseId");
                        caseObj.CaseDescription = reader.GetString("CaseDescription");
                        caseObj.AssociatedIncidents = GetAssociatedIncidentsForCase(caseId);
                        reader.Close();
                        return caseObj;
                    }
                    else
                    {
                        throw new IncidentNumberNotFoundException($"Case with ID {caseId} not found.");
                    }
                }

            }
            
        }

        public bool UpdateCaseDetails(Case caseDetails)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Cases SET CaseDescription = @CaseDescription WHERE CaseId = @CaseId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@CaseDescription", caseDetails.CaseDescription);
                    command.Parameters.AddWithValue("@CaseId", caseDetails.CaseId);

                    int rowsAffected = command.ExecuteNonQuery(); ;

                    return rowsAffected > 0;
                }

            }
            
        }

        public List<Case> GetAllCases()
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                List<Case> cases = new List<Case>();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Cases", sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int caseId = reader.GetInt32("CaseId");
                        string caseDescription = reader.GetString("CaseDescription");
                        List<Incident> associatedIncidents = GetAssociatedIncidentsForCase(caseId);
                        Case caseObj = new Case(caseId, caseDescription, associatedIncidents);
                        cases.Add(caseObj);
                    }
                    reader.Close();
                }
                return cases;

            }
            
        }

        private List<Incident> GetAssociatedIncidentsForCase(int caseId)
        {
            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                List<Incident> incidents = new List<Incident>();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentId IN (SELECT IncidentId FROM CaseIncidents WHERE CaseId = @CaseId)", sqlConnection))
                {
                    command.Parameters.AddWithValue("@CaseId", caseId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Incident incident = new Incident();
                        incident.IncidentId = reader.GetInt32("IncidentId");
                        incident.IncidentType = reader.GetString("IncidentType");
                        incident.IncidentDate = reader.GetDateTime("IncidentDate");
                        incident.Location = reader.GetString("Location");
                        incident.Description = reader.GetString("Description");
                        incident.Status = reader.GetString("Status");
                        incident.VictimId = reader.GetInt32("VictimId");
                        incident.SuspectId = reader.GetInt32("SuspectId");
                        incidents.Add(incident);
                    }
                    reader.Close();
                }
                return incidents;
            }
            
        }
        public Incident GetIncidentById(int incidentId)
        {
            if (incidentId <= 0)
            {
                throw new ArgumentException("Incident ID must be greater than zero.", nameof(incidentId));
            }

            string connectionString = UtilLibrary.DBConnection.ReturnCn("dbCn");
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentId = @IncidentId", sqlConnection))
                {
                    command.Parameters.AddWithValue("@IncidentId", incidentId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Incident incident = new Incident
                        {
                            IncidentId = reader.GetInt32("IncidentId"),
                            IncidentType = reader.GetString("IncidentType"),
                            IncidentDate = reader.GetDateTime("IncidentDate"),
                            Location = reader.GetString("Location"),
                            Description = reader.GetString("Description"),
                            Status = reader.GetString("Status"),
                            VictimId = reader.GetInt32("VictimId"),
                            SuspectId = reader.GetInt32("SuspectId")
                        };
                        return incident;
                    }
                    else
                    {
                        throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found.");
                    }
                }
            }
        }


    }


}
