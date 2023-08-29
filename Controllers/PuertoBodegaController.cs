using AplcacionLogistica.Models;
using AplcacionLogistica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplcacionLogistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuertoBodegaController : ControllerBase
    {
        private readonly IServicioPuertoBodega _PuertoBodega;
        private readonly string TokenPrueba = "puertobodegaprueba";

        public PuertoBodegaController(IServicioPuertoBodega serviciopuertobodega)
        {
            _PuertoBodega = serviciopuertobodega;
        }

        [HttpPost("CreatePuertoBodega")]
        public async Task<ActionResult<int>> CreateProducto(PuertoBodega puertobodega, [FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                try
                {
                    var intGuardar = (await _PuertoBodega.setPuertoBodega(puertobodega));
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
