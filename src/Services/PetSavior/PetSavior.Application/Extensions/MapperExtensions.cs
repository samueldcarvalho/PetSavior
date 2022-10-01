using AdoteUmPet.Domain.Pets;
using PetSavior.Application.Models.ViewModels.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Extensions
{
    public static class MapperExtensions
    {
        public static PetViewModel ToViewModel(this Pet pet) =>
            new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Description = pet.Description,
                CareTip = pet.CareTip,
                Pedigree = pet.Pedigree,
                UserId = pet.UserId,
                Weight = pet.Weight,
                Sex = Enum.GetName(pet.Sex),
                Breed = pet.Breed.ToViewModel(),
                Temperaments = pet.Temperaments.Select(t => t.ToViewModel()),
                Vaccines = pet.Vaccines.Select(v => v.ToViewModel())
            };
        

        public static PetBreedViewModel ToViewModel(this PetBreed breed) =>
            new PetBreedViewModel
            {
                Id = breed.Id,
                ArticleURL = breed.ArticleURL,
                Description = breed.Description,
                Group = breed.Description,
                Name = breed.Name
            };

        public static PetTemperamentViewModel ToViewModel(this PetTemperament temperament) =>
            new PetTemperamentViewModel
            {
                Id = temperament.Id,
                PetId = temperament.PetId,
                TemperamentLevel = temperament.TemperamentLevel,
                TemperamentName = temperament.TemperamentName
            };

        public static PetVaccineViewModel ToViewModel(this PetVaccine vaccine) =>
            new PetVaccineViewModel
            {
                Id = vaccine.Id,
                PetId = vaccine.PetId,
                Description = vaccine.Description,
                Completed = vaccine.Completed,
                DosesRemaining = vaccine.DosesRemaining,
            };
    }
}
