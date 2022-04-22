using Microsoft.AspNetCore.Mvc;
using SITHEC.Application.Common.Exceptions;
using SITHEC.Application.Entities;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SITHEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        /// <summary>
        /// Obtiene el resultado de la operación vía post
        /// Ejemplo para obtenerse en postman
        /// Método POST
        /// url https://localhost:44335/api/Operaciones/
        /// Ejemplo de body
        /// {
        ///    "primero": 1,
        ///    "segundo": 2,
        ///    "signo": "/"
        /// }
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(EntOperacion operacion)
        {
            return Ok(Operar(operacion));
        }

        /// <summary>
        /// Obtiene el resultado de la operación vía get, el signo debe ser codificado para mandarlo vía uri, ejemplo para probarse en postman
        /// Método GET
        /// Url https://localhost:44335/api/Operaciones?primero=1&segundo=2&signo=%2B
        /// </summary>
        /// <param name="primero"></param>
        /// <param name="segundo"></param>
        /// <param name="signo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(double primero, double segundo, string signo)
        {
            var operacion = new EntOperacion { Primero = primero, Segundo = segundo, Signo = signo };
            return Ok(Operar(operacion));
        }

        private double Operar(EntOperacion operacion)
        {
            switch (operacion.Signo)
            {
                case "+":
                    return operacion.Primero + operacion.Segundo;
                case "-":
                    return operacion.Primero - operacion.Segundo;
                case "*":
                    return operacion.Primero * operacion.Segundo;
                case "/":
                    if (operacion.Segundo == 0)
                        throw new SITHECStatusException("La operación se indefine", HttpStatusCode.BadRequest);
                    return operacion.Primero / operacion.Segundo;
                default:
                    throw new SITHECStatusException("Operación no aceptada", HttpStatusCode.BadRequest);
            }
        }

    }
}
