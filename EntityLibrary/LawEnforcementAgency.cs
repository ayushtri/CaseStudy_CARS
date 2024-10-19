using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class LawEnforcementAgency
    {
        private int _AgencyId;
        private string _AgencyName;
        private string _Jurisdiction;
        private string _ContactInformation;

        public LawEnforcementAgency() { }

        public LawEnforcementAgency(int agencyId, string agencyName, string jurisdiction, string contactInformation)
        {
            AgencyId = agencyId;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInformation = contactInformation;
        }
        public int AgencyId
        {
            get { return _AgencyId; }
            set { _AgencyId = value; }
        }

        public string AgencyName
        {
            get { return _AgencyName; }
            set { _AgencyName = value; }
        }

        public string Jurisdiction
        {
            get { return _Jurisdiction; }
            set { _Jurisdiction = value; }
        }

        public string ContactInformation
        {
            get { return _ContactInformation; }
            set { _ContactInformation = value; }
        }
    }
}
