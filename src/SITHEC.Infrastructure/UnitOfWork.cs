using SITHEC.Application.Common.Interfaces;
using SITHEC.Infrastructure.Contexts;
using SITHEC.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SITHEC.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SITHECDbContext _context;
        private protected IHumanoRepository _humanoRepository;

        public UnitOfWork(SITHECDbContext context)
            => _context = context;

        public IHumanoRepository HumanoRepository => _humanoRepository = new HumanoRepository(_context);


        public async Task<int> Complete()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }
}
