using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Application.Models.InputModels
{
    public class RegisterPetInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CareTip { get; set; }
        public decimal Weight { get; set; }
        public int BreedId { get; set; }
        public bool Pedigree { get;  set; }
    }
}
