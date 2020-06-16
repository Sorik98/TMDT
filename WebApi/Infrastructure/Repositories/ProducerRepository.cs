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
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext _context;

        public ProducerRepository(AppDbContext context)
        {
            _context = context;
        }
        // public async void getAllProducer(int id){
        //     // var producer = await _context.ImageUrls.FindAsync(id);
        //     // var urls = producer.Producer.;
        // await _context.Producers.AddAsync(new Producer());

        // }
       
        /* #region  base method */
         public async Task<IEnumerable<Producer>> GetAllProducts(int id)
        {
             var products = await _context.Producers.Where(p => p.ProducerId == id).Include(p => p.Products).ToListAsync();

            return products;
        }
        public async Task<IEnumerable<Producer>> GetAll()
        {
            var producers = await _context.Producers.ToListAsync();

            return producers;
        }
        public async Task<Producer> GetBy(int id)
        {
            return await _context.Producers.Where(p => p.ProducerId == id).FirstOrDefaultAsync();
        }
        public async Task<int> Create(Producer producer)
        {
            var result = await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
            return producer.ProducerId;
        }
        public async Task Update(Producer producer)
        {
            _context.Producers.Update(producer);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var producer = await GetBy(id);
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
        }
        /* #endregion */
    }
}