using AdoteUmPet.Domain.Pets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Contexts.Seeds
{
    public static class SeedsManager
    {
        public static void ApplyPetBreedSeeds(this EntityTypeBuilder<PetBreed> builder)
        {
            var breed1 = new PetBreed("Vira-lata", "Bonzinho demais da conta sô", "Canidae");
            breed1.Id = 1;

            builder.HasData(breed1);
        }

        public static void ApplyPetTemperamentsSeeds(this EntityTypeBuilder<PetTemperament> builder)
        {
            
        }
    }
}
