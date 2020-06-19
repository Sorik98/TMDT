using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Const;
using WebApi.Database.Context;
using WebApi.Infrastructure.Interfaces;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        
       
        /* #region  base method */
         
       
        public async Task<IEnumerable<Order>> GetAll(string userId)
        {
            var orders = await _context.Orders.Where(i => i.UserId == userId)
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product).ThenInclude(p => p.ImageUrls)
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product.Producer)
            .ToListAsync();

            return orders;
        }
        
        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product).ThenInclude(p => p.ImageUrls)
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product.Producer)
            .ToListAsync();

            return orders;
        }

        public async Task<Order> GetBy(int id)
        {
            return await _context.Orders.Where(p => p.Id == id)
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product).ThenInclude(p => p.ImageUrls)
            .Include(i => i.OrderDetails).ThenInclude(i => i.Product.Producer)
            .FirstOrDefaultAsync();
        }
        public async Task<int> Create(Order order)
        {
            var result = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            var order_ = await GetBy(order.Id);
            order_.TotalPrice = order_.OrderDetails.Sum(i => i.Product.Price*i.Quantity);
            await Update(order_);
            return order.Id;
        }
        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatus(int id, string status = null)
        {
            var order = await _context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            if(status == null){
                switch(status)
                {
                    case OrderStatus.Sent:
                    order.Status = OrderStatus.Received;
                    break;
                    case OrderStatus.Received:
                    order.Status = OrderStatus.onShipping;
                    break;
                    case OrderStatus.onShipping:
                    order.Status = OrderStatus.Shipped;
                    order.CompleteDate = DateTime.Now;
                    break;

                }
            }
            else{
                 switch(status)
                {
                    case OrderStatus.Sent:
                    order.Status = OrderStatus.Sent;
                    break;
                    case OrderStatus.Received:
                    order.Status = OrderStatus.Received;
                    break;
                    case OrderStatus.onShipping:
                    order.Status = OrderStatus.onShipping;
                    break;
                    case OrderStatus.Shipped:
                    order.Status = OrderStatus.Shipped;
                    break;
                    case OrderStatus.Cancel:
                    order.Status = OrderStatus.Cancel;
                    break;
                }
            }
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var order = await _context.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        /* #endregion */
    }
}