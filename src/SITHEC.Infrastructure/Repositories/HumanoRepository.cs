using Microsoft.EntityFrameworkCore;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Application.Entities;
using SITHEC.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SITHEC.Infrastructure.Repositories
{
    internal class HumanoRepository : BaseRepository<EntHumano>, IHumanoRepository
    {
        public HumanoRepository(SITHECDbContext context) : base(context) { }

        public async Task<int> CreateHumano(EntHumano humano)
        {
            await _context.Humanos.AddAsync(humano);
            return 1;
        }

        public async Task<EntHumano> GetHumanoById(int id)
            => await _context.Humanos.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<EntHumano>> RetrieveAllHumanos()
            => await _context.Humanos.ToListAsync();

        public async Task<int> UpdateHumano(EntHumano humano)
        {
            EntHumano original = await _context.Humanos.FirstOrDefaultAsync(x => x.Id == humano.Id);
            original.Nombre = humano.Nombre;
            original.Altura = humano.Altura;
            original.Edad = humano.Edad;
            original.Peso = humano.Peso;
            original.Sexo = humano.Sexo;
            return 1;
        }
    }
}
