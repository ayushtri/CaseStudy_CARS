using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Officer
    {
        private int _OfficerId;
        private string _FirstName;
        private string _LastName;
        private string _BadgeNumber;
        private string _Rank;
        private string _ContactInformation;
        private int _AgencyId;

        public Officer() { }

        public Officer(int officerId, string firstName, string lastName, string badgeNumber, string rank, string contactInformation, int agencyId)
        {
            OfficerId = officerId;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badgeNumber;
            Rank = rank;
            ContactInformation = contactInformation;
            AgencyId = agencyId;
        }

        public int OfficerId
        {
            get { return _OfficerId; }
            set { _OfficerId = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string BadgeNumber
        {
            get { return _BadgeNumber; }
            set { _BadgeNumber = value; }
        }

        public string Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }

        public string ContactInformation
        {
            get { return _ContactInformation; }
            set { _ContactInformation = value; }
        }

        public int AgencyId
        {
            get { return _AgencyId; }
            set { _AgencyId = value; }
        }
    }
}
