using MediatR;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Application.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SITHEC.Application.Humano.Queries
{
    public class RetrieveAllHumanosQuery : IRequest<List<EntHumano>>
    {
    }

    public class RetrieveAllHumanosQueryHandler : IRequestHandler<RetrieveAllHumanosQuery, List<EntHumano>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetrieveAllHumanosQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<List<EntHumano>> Handle(RetrieveAllHumanosQuery request, CancellationToken cancellationToken)
            => await _unitOfWork.HumanoRepository.RetrieveAllHumanos();
    }
}
