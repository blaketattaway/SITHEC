using FluentValidation;
using MediatR;
using SITHEC.Application.Common.Exceptions;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Application.Entities;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SITHEC.Application.Humano.Commands
{
    public class UpdateHumanoCommand : IRequest<string>
    {
        public UpdateHumanoCommand(EntHumano humano)
            => Humano = humano;
        public EntHumano Humano { get; set; }
    }

    public class UpdateHumanoCommandHandler : IRequestHandler<UpdateHumanoCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateHumanoCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<string> Handle(UpdateHumanoCommand request, CancellationToken cancellationToken)
        {
            EntHumano humano = await _unitOfWork.HumanoRepository.GetHumanoById(Convert.ToInt32(request.Humano.Id));
            if (humano == null)
                throw new SITHECStatusException("No se encontró el humano a actualizar", HttpStatusCode.NotFound);
            _ = await _unitOfWork.HumanoRepository.UpdateHumano(request.Humano);
            _ = await _unitOfWork.Complete();
            return "Humano actualizado correctamente";
        }
    }

    public class UpdateHumanoCommandValidator : AbstractValidator<UpdateHumanoCommand>
    {
        public UpdateHumanoCommandValidator()
        {
            RuleFor(x => new { x.Humano.Nombre, x.Humano.Altura, x.Humano.Edad, x.Humano.Peso, x.Humano.Sexo })
                .Must(x => !string.IsNullOrEmpty(x.Nombre))
                .WithMessage("Revise la información enviada");

            RuleFor(x => new { x.Humano.Altura, x.Humano.Edad, x.Humano.Peso })
                .Must(x => x.Edad >= 0 && x.Peso > 0 && x.Altura > 0)
                .WithMessage("Revise los datos enviados para la edad, peso y/o altura");
        }
    }
}
