using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetBy(int id);
        Task<int> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}