using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApi.Database.Context;
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Interfaces;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        // public async void getAllProduct(int id){
        //     // var product = await _context.ImageUrls.FindAsync(id);
        //     // var urls = product.Product.;
        // await _context.Products.AddAsync(new Product());

        // }
       
        /* #region  base method */
         public async Task<IEnumerable<Product>> GetAll(string type)
        {
             var products = await _context.Products.Where(p => p.Type == type).Include(p => p.Producer).Include(p => p.ImageUrls).ToListAsync();

            return products;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.Include(p => p.ImageUrls).ToListAsync();

            return products;
        }
        public async Task<Product> GetBy(int id)
        {
            return await _context.Products.Where(p => p.Id == id).Include(p => p.ImageUrls).FirstOrDefaultAsync();
        }
        public async Task<int> Create(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await GetBy(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        /* #endregion */
    }
}