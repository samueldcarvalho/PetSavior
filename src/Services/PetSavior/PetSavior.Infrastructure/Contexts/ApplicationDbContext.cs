using AdoteUmPet.Core.Domain;
using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Ads;
using AdoteUmPet.Domain.Favorites;
using AdoteUmPet.Domain.Pets;
using AdoteUmPet.Domain.Users;
using AdoteUmPet.Infrastructure.Contexts.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>, IUnitOfWork
    {
        private readonly string _connectionString;

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetBreed> PetBreeds { get; set; }
        public DbSet<PetVaccine> PetVaccines { get; set; }
        public DbSet<PetTemperament> PetTemperaments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new ArgumentNullException("ConnectionString cannot be found. See your ENV variables.");

            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PetBreed>().ApplyPetBreedSeeds();

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString), options =>  options
                .MigrationsAssembly("PetSavior.Infrastructure"))
                .UseSnakeCaseNamingConvention();

            base.OnConfiguring(optionsBuilder);
        }

        private void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.Entry.Entity is Entity)
            {
                switch (e.NewState)
                {
                    case EntityState.Added:
                        ((Entity)e.Entry.Entity).CreatedAt = DateTime.Now;
                        ((Entity)e.Entry.Entity).AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((Entity)e.Entry.Entity).AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        ((Entity)e.Entry.Entity).AlteredAt = DateTime.Now;
                        ((Entity)e.Entry.Entity).Removed = true;
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Detached:
                        break;
                }
            }
        }

        public async Task Commit()
        {
            if (!ChangeTracker.HasChanges())
                return;

            await SaveChangesAsync();
        }
    }
}
