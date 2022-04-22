using Microsoft.Extensions.DependencyInjection;
using SITHEC.Application.Entities;
using SITHEC.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace SITHEC.Infrastructure.Seeder
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SITHECDbContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SITHECDbContext>())
                {

                    if (!context.Humanos.Any())
                    {
                        var humanos = new List<EntHumano>
                        {
                            new EntHumano { Id = 1, Nombre = "Diego", Sexo = false, Edad = 29, Altura = 168, Peso = 95 },
                            new EntHumano { Id = 2, Nombre = "Ronaldo", Sexo = false, Edad = 25, Altura = 175, Peso = 98.5 },
                            new EntHumano { Id = 3, Nombre = "Danai", Sexo = true, Edad = 33, Altura = 165, Peso = 60 }
                        };
                        context.AddRange(humanos);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
