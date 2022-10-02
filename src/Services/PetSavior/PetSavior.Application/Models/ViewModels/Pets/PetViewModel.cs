using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSavior.Application.Models.ViewModels.Pets
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CareTip { get; set; }
        public decimal Weight { get; set; }
        public PetBreedViewModel Breed { get; set; }
        public int UserId { get; set; }
        public bool Pedigree { get; set; }
        public string Sex { get; set; }
        public IEnumerable<PetVaccineViewModel> Vaccines { get; set; }
        public IEnumerable<PetTemperamentViewModel> Temperaments { get; set; }
    }
}
