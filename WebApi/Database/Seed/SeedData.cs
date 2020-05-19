// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using MovieApi.Models;

// namespace MovieApi.Data
// {
//     public class SeedData
//     {
//         public static async Task InitializeAync(MovieContext context)
//         {
//             context.Database.EnsureCreated();

//             if (!context.Movies.Any())
//             {
//                 await context.Movies.AddRangeAsync(
//                     new Movie
//                     {
//                         Title = "When Harry Met Sally",
//                         ReleaseDate = DateTime.Parse("1989-2-12"),
//                         Genre = "Romantic Comedy",
//                         Rating = "R",
//                         Price = 7.99M,
//                         PictureUri = "http://externalcatalogbaseurltobereplaced/images/products/1.png"
//                     },

//                     new Movie
//                     {
//                         Title = "Ghostbusters ",
//                         ReleaseDate = DateTime.Parse("1984-3-13"),
//                         Genre = "Comedy",
//                         Rating = "G",
//                         Price = 8.99M,
//                         PictureUri = "http://externalcatalogbaseurltobereplaced/images/products/2.png"
//                     },

//                     new Movie
//                     {
//                         Title = "Ghostbusters 2",
//                         ReleaseDate = DateTime.Parse("1986-2-23"),
//                         Genre = "Comedy",
//                         Rating = "R",
//                         Price = 9.99M,
//                         PictureUri = "http://externalcatalogbaseurltobereplaced/images/products/3.png"
//                     },

//                     new Movie
//                     {
//                         Title = "Rio Bravo",
//                         ReleaseDate = DateTime.Parse("1959-4-15"),
//                         Genre = "Western",
//                         Rating = "G",
//                         Price = 3.99M,
//                         PictureUri = "http://externalcatalogbaseurltobereplaced/images/products/4.png"
//                     }
//                 );

//                 await context.SaveChangesAsync();
//             }
//         }

//     }
// }