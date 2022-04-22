using System.Threading.Tasks;

namespace SITHEC.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IHumanoRepository HumanoRepository { get; }
        Task<int> Complete();
    }
}
