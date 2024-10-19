using DAOLibrary;
using EntityLibrary;

namespace NUnitTest
{
    public class IncidentCreation
    {
        [Test]
        public void TestCreateIncident_ValidData()
        {
            CrimeAnalysisServiceImpl crimeAnalysisService = new CrimeAnalysisServiceImpl();

            
            Incident incident = new Incident
            {
                IncidentType = "Theft",
                IncidentDate = DateTime.Parse("2024-10-21"),
                Location = "Central Park",
                Description = "A purse was stolen from a bench again.",
                Status = "Active",
                VictimId = 2,
                SuspectId = 2
            };

            int createdIncidentID = crimeAnalysisService.CreateIncident(incident);

            Assert.IsTrue(createdIncidentID > 0);

            
            Incident createdIncident = crimeAnalysisService.GetIncidentById(createdIncidentID);

        
            Assert.AreEqual(incident.IncidentType, createdIncident.IncidentType);
            Assert.AreEqual(incident.IncidentDate, createdIncident.IncidentDate);
            Assert.AreEqual(incident.Location, createdIncident.Location);
            Assert.AreEqual(incident.Description, createdIncident.Description);
            Assert.AreEqual(incident.Status, createdIncident.Status);
            Assert.AreEqual(incident.VictimId, createdIncident.VictimId);
            Assert.AreEqual(incident.SuspectId, createdIncident.SuspectId);
        }
    }
}