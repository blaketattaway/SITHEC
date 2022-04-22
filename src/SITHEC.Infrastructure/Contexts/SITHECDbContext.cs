using Microsoft.EntityFrameworkCore;
using SITHEC.Application.Entities;
using System.Reflection;

namespace SITHEC.Infrastructure.Contexts
{
    public class SITHECDbContext : DbContext
    {
        public SITHECDbContext(DbContextOptions<SITHECDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<EntHumano>().HasData(
                new EntHumano { Id = 1, Nombre = "Diego", Sexo = false, Edad = 29, Altura = 168, Peso = 95 },
                new EntHumano { Id = 2, Nombre = "Ronaldo", Sexo = false, Edad = 25, Altura = 175, Peso = 98.5 },
                new EntHumano { Id = 3, Nombre = "Danai", Sexo = true, Edad = 33, Altura = 165, Peso = 60 }
                );
        }

        public DbSet<EntHumano> Humanos { get; set; }
    }
}
