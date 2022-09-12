using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Infrastructure.Contexts
{
    public class AdoteUmPetDbContext : DbContext
    {
        private readonly string _connectionString;
        public AdoteUmPetDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new ArgumentNullException("ConnectionString to communicate with Database cannot be found. See your ENV variables.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
                .UseSnakeCaseNamingConvention();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
