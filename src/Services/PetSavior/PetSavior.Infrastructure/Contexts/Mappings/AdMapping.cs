using AdoteUmPet.Domain.Ads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Contexts.Mappings
{
    public class AdMapping : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("ad");

            builder.HasOne(p => p.Pet)
                .WithMany(p => p.Ads)
                .HasForeignKey(p => p.PetId);

            builder.HasIndex(p => p.UserId);

            builder.HasIndex(p => p.PetId);

            builder.HasIndex(p => p.AdoptionStatus);
        }
    }
}
