using SITHEC.Infrastructure.Contexts;

namespace SITHEC.Infrastructure.Repositories
{
    internal class BaseRepository<T>
    {
        protected readonly SITHECDbContext _context;

        public BaseRepository(SITHECDbContext context)
        {
            _context = context;
        }
    }
}
