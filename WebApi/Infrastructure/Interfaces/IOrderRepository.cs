using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAll(string userId);
        Task UpdateStatus(int id, string status = null);
    }
}