using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    internal interface IVictimDAO
    {
        public int AddVictim(Victim victim);
        public Victim GetVictimById(int victimId);
        public List<Victim> GetAllVictims();
    }
}
