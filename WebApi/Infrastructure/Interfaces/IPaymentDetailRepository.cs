using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Interfaces
{
    public interface IPaymentDetailRepository : IRepository<PaymentDetail>
    {
        // Task<IEnumerable<string>> GetGenres();
        // Task<IEnumerable<PaymentDetailDTO>> GetMovies(string genre = null, string searchString = null);
        // bool MovieExists(int id);
    }
}