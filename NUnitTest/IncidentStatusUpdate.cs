using DAOLibrary;
using EntityLibrary;

namespace NUnitTest
{
    internal class IncidentStatusUpdate
    {
        [Test]
        public void TestUpdateIncidentStatus_Valid()
        {
            CrimeAnalysisServiceImpl crimeAnalysisService = new CrimeAnalysisServiceImpl();
            Incident incident = new Incident
            {
                IncidentType = "Theft",
                IncidentDate = DateTime.Parse("2024-10-22"),
                Location = "Central Park",
                Description = "A purse was stolen from a bench again 2",
                Status = "Active",
                VictimId = 2,
                SuspectId = 2
            };

            int createdIncidentID = crimeAnalysisService.CreateIncident(incident);

            bool result = crimeAnalysisService.UpdateIncidentStatus("Closed", createdIncidentID);

            
            Assert.IsTrue(result);

            Incident updatedIncident = crimeAnalysisService.GetIncidentById(createdIncidentID);

            
            Assert.AreEqual("Closed", updatedIncident.Status);
        }
    }
}
