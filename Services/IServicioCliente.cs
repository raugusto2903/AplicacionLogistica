using AplcacionLogistica.Models;

namespace AplcacionLogistica.Services
{
    public interface IServicioCliente
    {
        Task<int> setCliente(Cliente cliente);
    }
}
