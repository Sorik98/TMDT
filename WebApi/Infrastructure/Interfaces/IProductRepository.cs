using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
       Task<IEnumerable<Product>> GetAll(string type);
    }
}