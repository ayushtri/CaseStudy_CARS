using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Evidence
    {
        private int _EvidenceId;
        private string _Description;
        private string _LocationFound;
        private int _IncidentId;

        public Evidence() { }
        
        public Evidence(int evidenceId, string description, string locationFound, int incidentId)
        {
            EvidenceId = evidenceId;
            Description = description;
            LocationFound = locationFound;
            IncidentId = incidentId;
        }

        public int EvidenceId
        {
            get { return _EvidenceId; }
            set { _EvidenceId = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string LocationFound
        {
            get { return _LocationFound; }
            set { _LocationFound = value; }
        }

        public int IncidentId
        {
            get { return _IncidentId; }
            set { _IncidentId = value; }
        }
    }
}
