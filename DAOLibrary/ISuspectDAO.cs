using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    internal interface ISuspectDAO
    {
        public bool AddSuspect(Suspect suspect);
        public Suspect GetSuspectById(int suspectId);
        public List<Suspect> GetAllSuspects();
    }
}
