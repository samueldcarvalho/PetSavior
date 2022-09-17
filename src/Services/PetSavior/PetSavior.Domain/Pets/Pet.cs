using AdoteUmPet.Core.Domain;
using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Ads;
using AdoteUmPet.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdoteUmPet.Domain.Pets
{
    public class Pet : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CareTip { get; private set; }
        public decimal Weight { get; private set; }
        public int BreedId { get; private set; }
        public PetBreed Breed { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public bool Pedigree { get; private set; }
        public ICollection<PetVaccine> Vaccines { get; private set; } = new List<PetVaccine>();
        public ICollection<PetTemperament> Temperaments { get; private set; } = new List<PetTemperament>();
        public ICollection<Ad> Ads { get; private set; } = new List<Ad>();

        protected Pet() { }
        public Pet(string name, string description, string careTip, decimal weight, int breedId, bool pedigree, User user)
        {
            Name = name;
            Description = description;
            CareTip = careTip;
            Weight = weight;
            BreedId = breedId;
            Pedigree = pedigree;
            User = user;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Cannot change the pet's name by another empty or null");

            Name = name;
        }

        public void AddVaccines(IEnumerable<PetVaccine> vaccines)
        {
            if (!vaccines.Any())
                return;

            Vaccines.ToList().AddRange(vaccines);
        }

        public void AddTemperaments(IEnumerable<PetTemperament> temperaments)
        {
            if (!temperaments.Any())
                return;

            Temperaments.ToList().AddRange(temperaments);
        }
    }
}
