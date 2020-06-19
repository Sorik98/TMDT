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
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }
        // public async void getAllCartItem(int id){
        //     // var cartItem = await _context.ImageUrls.FindAsync(id);
        //     // var urls = cartItem.CartItem.;
        // await _context.CartItems.AddAsync(new CartItem());

        // }
       
        /* #region  base method */
         
        public async Task<IEnumerable<CartItem>> GetAll()
        {
            var cartItems = await _context.CartItems
            .Include(p => p.Product).ThenInclude(p => p.ImageUrls)
            .Include(p => p.Product).ThenInclude(p => p.Producer)
            .ToListAsync();

            return cartItems;
        }
        public async Task<IEnumerable<CartItem>> GetAll(string userId)
        {
            var cartItems = await _context.CartItems.Where(i => i.UserId == userId)
            .Include(p => p.Product.ImageUrls)
            .Include(p => p.Product.Producer)
            .ToListAsync();

            return cartItems;
        }
        public async Task<IEnumerable<CartItem>> GetAll(int productId)
        {
            var cartItems = await _context.CartItems.Where(i => i.ProductId == productId)
            .Include(p => p.Product).ThenInclude(p => p.ImageUrls)
            .Include(p => p.Product).ThenInclude(p => p.Producer)
            .ToListAsync();

            return cartItems;
        }
        public async Task<CartItem> GetBy(int id)
        {
            return await _context.CartItems.Where(p => p.Id == id)
            .Include(p => p.Product).ThenInclude(p => p.ImageUrls)
            .Include(p => p.Product).ThenInclude(p => p.Producer)
            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<CartItem>> GetByRange(int[] ids)
        {
            return await _context.CartItems.Where(p => ids.Contains(p.Id))
            .Include(p => p.Product).ThenInclude(p => p.ImageUrls)
            .Include(p => p.Product).ThenInclude(p => p.Producer)
            .ToListAsync();
        }
        public async Task<int> Create(CartItem cartItem)
        {
            var result = await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem.Id;
        }
        public async Task Update(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var cartItem = await GetBy(id);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int[] ids){
            var cartItem = await GetByRange(ids);
            _context.CartItems.RemoveRange(cartItem);
            await _context.SaveChangesAsync();
        }
        /* #endregion */
    }
}