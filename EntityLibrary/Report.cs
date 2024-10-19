using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Report
    {
        private int _ReportId;
        private int _IncidentId;
        private int _ReportingOfficer;
        private DateTime _ReportDate;
        private string _ReportDetails;
        private string _Status;

        public Report() { }
        

        public Report(int reportId, int incidentId, int reportingOfficer, DateTime reportDate, string reportDetails, string status)
        {
            ReportId = reportId;
            IncidentId = incidentId;
            ReportingOfficer = reportingOfficer;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }

        public int ReportId
        {
            get { return _ReportId; }
            set { _ReportId = value; }
        }

        public int IncidentId
        {
            get { return _IncidentId; }
            set { _IncidentId = value; }
        }

        public int ReportingOfficer
        {
            get { return _ReportingOfficer; }
            set { _ReportingOfficer = value; }
        }

        public DateTime ReportDate
        {
            get { return _ReportDate; }
            set { _ReportDate = value; }
        }

        public string ReportDetails
        {
            get { return _ReportDetails; }
            set { _ReportDetails = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
