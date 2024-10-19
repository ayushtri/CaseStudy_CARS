using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Suspect
    {
        private int _SuspectId;
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private string _Gender;
        private string _ContactInformation;

        public Suspect() { }
        
        public Suspect(int suspectId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactInformation)
        {
            SuspectId = suspectId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactInformation = contactInformation;
        }

        public int SuspectId
        {
            get { return _SuspectId; }
            set { _SuspectId = value; }
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
