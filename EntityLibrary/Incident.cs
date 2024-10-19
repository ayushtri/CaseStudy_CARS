namespace EntityLibrary
{
    public class Incident
    {
        private int _IncidentId;
        private string _IncidentType;
        private DateTime _IncidentDate;
        private string _Location;
        private string _Description;
        private string _Status;
        private int _VictimId;
        private int _SuspectId;

        public Incident() { }

        public Incident(int incidentId, string incidentType, DateTime incidentDate, string location, string description, string status, int victimId, int suspectId)
        {
            IncidentId = incidentId;
            IncidentType = incidentType;
            IncidentDate = incidentDate;
            Location = location;
            Description = description;
            Status = status;
            VictimId = victimId;
            SuspectId = suspectId;
        }

        public int IncidentId
        {
            get { return _IncidentId; }
            set { _IncidentId = value; }
        }

        public string IncidentType
        {
            get { return _IncidentType; }
            set { _IncidentType = value; }
        }

        public DateTime IncidentDate
        {
            get { return _IncidentDate; }
            set { _IncidentDate = value; }
        }

        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int VictimId
        {
            get { return _VictimId; }
            set { _VictimId = value; }
        }

        public int SuspectId
        {
            get { return _SuspectId; }
            set { _SuspectId = value; }
        }
    }
}
