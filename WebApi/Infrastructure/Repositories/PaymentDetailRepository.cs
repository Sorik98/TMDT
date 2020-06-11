// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using WebApi.Database.Context;
// using WebApi.Infrastructure.DTOs;
// using WebApi.Infrastructure.Interfaces;
// using WebApi.Infrastructure.Models;

// namespace WebApi.Infrastructure.Repositories
// {
//     public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
//     {
//         private readonly AppDbContext _context;

//         public PaymentDetailRepository(AppDbContext context) : base(context)
//         {
//             _context = context;
//         }
    
//         // public async Task<IEnumerable<string>> GetGenres()
//         // {
//         //     return await _context.Movies
//         //         .OrderBy(m => m.Genre)
//         //         .Select(m => m.Genre)
//         //         .Distinct().ToListAsync();
//         // }

//         // public async Task<IEnumerable<PaymentDetailDTO>> GetMovies(string genre = null, string searchString = null)
//         // {
//         //     var movies = from m in _context.Movies
//         //                  select m;

//         //     if (!string.IsNullOrEmpty(genre))
//         //     {
//         //         movies = movies.Where(m => m.Genre.Contains(genre));
//         //     }
//         //     if (!string.IsNullOrEmpty(searchString))
//         //     {
//         //         movies = movies.Where(m => m.Title.Contains(searchString));
//         //     }

//         //     return await movies
//         //         .Select(m => m.ToDTO()).ToListAsync();
//         // }

//         // public bool MovieExists(int id)
//         // {
//         //     return _context.Movies.Any(m => m.Id == id);
//         // }
//     }
// }