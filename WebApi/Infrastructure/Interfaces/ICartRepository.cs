using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Interfaces
{
    public interface ICartRepository : IRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetAll(string userId);
        Task<IEnumerable<CartItem>> GetAll(int productId);

        Task Delete(int[] ids);
    }
}