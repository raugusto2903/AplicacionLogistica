using AplcacionLogistica.Models;

namespace AplcacionLogistica.Services
{
    public interface IServicioProducto
    {
        Task<int>setProducto(Producto producto);
    }
}
