using AdoteUmPet.Domain.Pets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdoteUmPet.Infrastructure.Contexts.Mappings
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pet");

            builder.HasMany(p => p.Ads)
                .WithOne(p => p.Pet)
                .HasForeignKey(p => p.PetId);

            builder.HasOne(p => p.Breed)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.BreedId);

            builder.HasMany(p => p.Vaccines)
                .WithOne(p => p.Pet)
                .HasForeignKey(p => p.PetId);

            builder.HasMany(p => p.Temperaments)
                .WithOne(p => p.Pet)
                .HasForeignKey(p => p.PetId);

            builder.HasIndex(p => p.BreedId);

            builder.HasIndex(p => p.UserId);

            builder.HasIndex(p => p.Pedigree);

            builder.HasIndex(p => p.Weight);
        }
    }
}
