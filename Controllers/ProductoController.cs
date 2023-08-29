using AplcacionLogistica.Models;
using AplcacionLogistica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplcacionLogistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IServicioProducto _Producto;
        private readonly string TokenPrueba = "productoprueba";

        public ProductoController(IServicioProducto servicioproducto)
        {
            _Producto = servicioproducto;
        }


        [HttpPost("CreateProducto")]
        public async Task<ActionResult<int>> CreateProducto(Producto producto, [FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                try
                {
                    var intGuardar = (await _Producto.setProducto(producto));
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
