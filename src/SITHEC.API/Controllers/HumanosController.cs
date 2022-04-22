using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SITHEC.Application.Entities;
using SITHEC.Application.Humano.Commands;
using SITHEC.Application.Humano.Queries;
using System.Threading.Tasks;

namespace SITHEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    ///  url para postman https://localhost:44335/api/Humanos/
    ///  Cambiar métodos post/get/put
    ///  Para la obtención por id usar https://localhost:44335/api/Humanos/id
    /// </summary>
    /// <returns></returns>
    public class HumanosController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Mediator.Send(new RetrieveAllHumanosQuery()));
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await Mediator.Send(new GetHumanoByIdQuery(id)));
        [HttpPost]
        public async Task<IActionResult> Post(EntHumano humano)
            => Ok(await Mediator.Send(new CreateHumanoCommand(humano)));
        [HttpPut]
        public async Task<IActionResult> Put(EntHumano humano)
            => Ok(await Mediator.Send(new UpdateHumanoCommand(humano)));
    }
}
