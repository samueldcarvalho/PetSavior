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
        public int PetId { get; private set; }
        public Pet Pet { get; private set; }

        protected PetTemperament() { }
        public PetTemperament(string temperamentName, int temperamentLevel, Pet pet)
        {
            TemperamentName = temperamentName;
            TemperamentLevel = temperamentLevel;
            Pet = pet;
        }

        public void ChangeTemperamentLevel(int level)
        {
            TemperamentLevel = level;
        }
    }
}
