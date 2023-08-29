using AplcacionLogistica.Models;

namespace AplcacionLogistica.Services
{
    public interface IServicioPuertoBodega
    {
        Task<int> setPuertoBodega(PuertoBodega puertobodega);
    }
}
