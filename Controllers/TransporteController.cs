using AplcacionLogistica.Models;
using AplcacionLogistica.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AplcacionLogistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        private readonly IServicioTransporte _transporte;
        private readonly string TokenPrueba = "transporteprueba";

        public TransporteController(IServicioTransporte serviciotransporte)
        {
            _transporte = serviciotransporte;
        }

        [HttpPost("Createflota")]
        public async Task<ActionResult<int>> Createflota(flota flotaaux, [FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                if (ValidarNumeroFlota(flotaaux.numeroflota))
                {
                    try
                    {
                        var intGuardar = (await _transporte.setFlota(flotaaux));
                        return intGuardar;

                    }
                    catch
                    {
                        return 422;
                    }
                }
                else
                {
                    return BadRequest("el numeroflota debe tener 3 letras y 4 numeros");
                }
            }
            else
            {
                return BadRequest(401);
            }
        }

        [HttpPost("Createvehiculo")]
        public async Task<ActionResult<int>> Createvehiculo(vehiculo vehiculoaux, [FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                if (ValidarPlacaVehiculo(vehiculoaux.placa))
                {
                    try
                    {
                        var intGuardar = (await _transporte.setvehiculo(vehiculoaux));
                        return intGuardar;

                    }
                    catch
                    {
                        return 422;
                    }
                }
                else
                {
                    return BadRequest("la placa debe tener 3 letras y 3 numeros");
                }
            }
            else
            {
                return BadRequest(401);
            }
        }
        [HttpPost("CreateEntrega")]
        public async Task<ActionResult<int>> CreateEntrega(LogisticaEntrega Entregaaux, [FromHeader] string token)
        {
            if (token == TokenPrueba)
            {
                if (ValidarNumeroGuia(Entregaaux.numeroguia))
                {
                    try
                    {
                        var intGuardar = (await _transporte.setlogisticaEntrega(Entregaaux));
                        return intGuardar;

                    }
                    catch
                    {
                        return 422;
                    }
                }
                else
                {
                    return BadRequest("el numero de guia debe ser alfa numerico y de 10 digitos");
                }
            }
            else
            {
                return BadRequest(401);
            }
        }

        static bool ValidarPlacaVehiculo(string cadena)
        {
            // Patrón de expresión regular para verificar 3 letras seguidas por 3 números
            string patron = @"^[A-Za-z]{3}\d{3}$";

            return Regex.IsMatch(cadena, patron);
        }
        static bool ValidarNumeroFlota(string cadena)
        {

            string patron = @"^[A-Za-z]{3}\d{3}$";

            return Regex.IsMatch(cadena, patron);
        }
        static bool ValidarNumeroGuia(string cadena)
        {

            string patron = @"^[a-zA-Z0-9]{10}$";

            return Regex.IsMatch(cadena, patron);
        }

        [HttpGet("listarEntregas")]
        public async Task<ActionResult<IEnumerable<LogisticaEntrega>>> listarEntregas()
        {
            var listEntregas = (await _transporte.getlogisticaEntrega());      
            return listEntregas.ToList();
        }
        [HttpGet("listarEntregasConDescuento")]
        public async Task<ActionResult<IEnumerable<LogisticaEntrega>>> listarEntregasConDescuento()
        {
            var listEntregas = (await _transporte.getlogisticaEntrega());
            foreach (var entrega in listEntregas)
            {
                if (entrega.flota_id > 0)
                {
                    double porcentaje = entrega.precioenvio * 0.05;
                    entrega.precioenvio -= (int)porcentaje;
                }
                if (entrega.vehiculo_id > 0)
                {
                    double porcentaje = entrega.precioenvio * 0.03;
                    entrega.precioenvio -= (int)porcentaje;
                }
            }
            return listEntregas.ToList();
        }
    }
}
