using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Victim
    {
        private int _VictimId;
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _Gender;
        private string _ContactInformation;

        public Victim() { }
        
        public Victim(int victimId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactInformation)
        {
            VictimId = victimId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public int VictimId
        {
            get { return _VictimId; }
            set { _VictimId = value; }
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

        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string ContactInformation
        {
            get { return _ContactInformation; }
            set { _ContactInformation = value; }
        }
    }
}
