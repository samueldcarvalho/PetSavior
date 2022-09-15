using AdoteUmPet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Pets
{
    public class PetTemperament : Entity
    {
        public string TemperamentName { get; private set; }
        public int TemperamentLevel { get; private set; }

        protected PetTemperament() { }
        public PetTemperament(string temperamentName, int temperamentLevel)
        {
            TemperamentName = temperamentName;
            TemperamentLevel = temperamentLevel;
        }

        public void ChangeTemperamentLevel(int level)
        {
            TemperamentLevel = level;
        }
    }
}
