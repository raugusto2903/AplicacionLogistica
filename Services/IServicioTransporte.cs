using AplcacionLogistica.Models;

namespace AplcacionLogistica.Services
{
    public interface IServicioTransporte
    {
        Task<int> setFlota(flota flotaAux);
        Task<int> setvehiculo(vehiculo vehiculoaux);
        Task<int> setlogisticaEntrega(LogisticaEntrega Entregaaux);
        Task<IEnumerable<LogisticaEntrega>> getlogisticaEntrega();
    }
}
