using FluentValidation;
using MediatR;
using SITHEC.Application.Common.Interfaces;
using SITHEC.Application.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SITHEC.Application.Humano.Commands
{
    public class CreateHumanoCommand : IRequest<string>
    {
        public CreateHumanoCommand(EntHumano humano)
            => Humano = humano;
        public EntHumano Humano { get; set; }
    }

    public class CreateHumanoCommandHandler : IRequestHandler<CreateHumanoCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateHumanoCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<string> Handle(CreateHumanoCommand request, CancellationToken cancellationToken)
        {
            _ = await _unitOfWork.HumanoRepository.CreateHumano(request.Humano);
            _ = await _unitOfWork.Complete();
            return "Humano guardadod correctamente";
        }

    }

    public class CreateHumanoCommandValidator : AbstractValidator<CreateHumanoCommand>
    {
        public CreateHumanoCommandValidator()
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
