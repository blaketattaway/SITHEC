using MediatR;
using SITHEC.Application.Common.Exceptions;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Application.Entities;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SITHEC.Application.Humano.Queries
{
    public class GetHumanoByIdQuery : IRequest<EntHumano>
    {
        public GetHumanoByIdQuery(int id)
            => Id = id;
        public int Id { get; set; }
    }

    public class GetHumanoByIdQueryHandler : IRequestHandler<GetHumanoByIdQuery, EntHumano>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetHumanoByIdQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<EntHumano> Handle(GetHumanoByIdQuery request, CancellationToken token)
        {
            var humano = await _unitOfWork.HumanoRepository.GetHumanoById(request.Id);
            if (humano == null)
                throw new SITHECStatusException("No se encontró el humano", HttpStatusCode.NotFound);
            return humano;
        }
    }
}
