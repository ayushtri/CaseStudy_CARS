using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Case
    {
        private int _CaseId;
        private string _CaseDescription;
        private List<Incident> _AssociatedIncidents;

        public Case() { }

        public Case(int caseId, string caseDescription, List<Incident> associatedIncidents)
        {
            _CaseId = caseId;
            _CaseDescription = caseDescription;
            _AssociatedIncidents = associatedIncidents;
        }

        public int CaseId
        {
            get { return _CaseId; }
            set { _CaseId = value; }
        }

        public string CaseDescription
        {
            get { return _CaseDescription; }
            set { _CaseDescription = value; }
        }

        public List<Incident> AssociatedIncidents
        {
            get { return _AssociatedIncidents; }
            set { _AssociatedIncidents = value; }
        }
    }
}
