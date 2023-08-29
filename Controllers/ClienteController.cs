using AplcacionLogistica.Models;
using AplcacionLogistica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplcacionLogistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IServicioCliente _Cliente;
        private readonly string TokenPrueba = "clienteprueba";
        
        public ClienteController(IServicioCliente serviciocliente)
        {
            _Cliente = serviciocliente;
        }


        [HttpPost("CreateCliente")]
        public async Task<ActionResult<int>> CreateCliente(Cliente cliente,[FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                try
                {
                    var intGuardar = (await _Cliente.setCliente(cliente));
                    return intGuardar;

                }
                catch
                {
                    return 422;
                }
            }
            else
            {
                return BadRequest(401);
            }
        }
    }
}
