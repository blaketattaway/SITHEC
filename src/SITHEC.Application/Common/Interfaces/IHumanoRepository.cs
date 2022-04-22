using SITHEC.Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SITHEC.Application.Common.Interfaces
{
    public interface IHumanoRepository
    {
        Task<EntHumano> GetHumanoById(int id);
        Task<List<EntHumano>> RetrieveAllHumanos();
        Task<int> CreateHumano(EntHumano entity);
        Task<int> UpdateHumano(EntHumano entHumano);
    }
}
