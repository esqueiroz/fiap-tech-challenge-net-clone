using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        //public ApplicationDbContext()
        //{
        //}

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }
       

        public DbSet<Regional> Regional { get; set; }
        public DbSet<Contato> Contato { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ConnectionString"));            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
