using AdoteUmPet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Pets
{
    public class PetVaccine : Entity
    {
        public string Description { get; private set; }
        public int DosesRemaining { get; private set; }
        public bool Completed { get; private set; }
        public int PetId { get; private set; }
        public Pet Pet { get; private set; }

        protected PetVaccine() { }
        public PetVaccine(string description, int dosesRemaining, bool completed, Pet pet)
        {
            Description = description;
            DosesRemaining = dosesRemaining;
            Completed = completed;
            Pet = pet;
        }
    }
}
