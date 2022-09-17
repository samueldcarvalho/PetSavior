using AdoteUmPet.Domain.Ads;
using AdoteUmPet.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Contexts.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(p => p.Ads)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Pets)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Favorites)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
