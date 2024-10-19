using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public interface ICrimeAnalysisService
    {
        public int CreateIncident(Incident incident);
        public bool UpdateIncidentStatus(string status, int incidentId);
        public List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        public List<Incident> SearchIncidents(Incident incidentType);
        public Report GenerateIncidentReport(Incident incident);
        public Case CreateCase(string caseDescription, List<int> incidentIds);
        public Case GetCaseDetails(int caseId);
        public bool UpdateCaseDetails(Case caseDetails);
        public List<Case> GetAllCases();
    }
}
