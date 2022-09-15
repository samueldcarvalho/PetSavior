using AdoteUmPet.Core.Domain;
using AdoteUmPet.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;

namespace AdoteUmPet.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly string _connectionString;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new ArgumentNullException("ConnectionString cannot be found. See your ENV variables.");

            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString), options =>  options
                .MigrationsAssembly("AdoteUmPet.Infrastructure"))
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
    }
}
