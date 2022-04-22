using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Infrastructure.Contexts;
using SITHEC.Infrastructure.Seeder;

namespace SITHEC.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {   //Comentar si se usa inmemory db
            //services.AddDbContext<SITHECDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SITHECDb")));
            //Comentar si se usa sql server
            services.AddDbContext<SITHECDbContext>(options => options.UseInMemoryDatabase("SITHECDb"));
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
