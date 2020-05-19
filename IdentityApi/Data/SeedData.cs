// // Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// // Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


// using System;
// using System.Linq;
// using System.Security.Claims;
// using IdentityModel;
// using IdentityApi.Data;
// using IdentityApi.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Serilog;

// namespace IdentityApi
// {
//     public class SeedData
//     {
//         public static void EnsureSeedData(string connectionString)
//         {
//             var services = new ServiceCollection();
//             services.AddLogging();
//             services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(connectionString));

//             services.AddIdentity<ApplicationUser, IdentityRole>()
//                 .AddEntityFrameworkStores<ApplicationDbContext>()
//                 .AddDefaultTokenProviders();

//             using (var serviceProvider = services.BuildServiceProvider())
//             {
//                 using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
//                 {
//                     var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
//                     context.Database.Migrate();

//                     var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//                     var alice = userMgr.FindByNameAsync("alice").Result;
//                     if (alice == null)
//                     {
//                         alice = new ApplicationUser
//                         {
//                             UserName = "alice@gmail.com",
//                             Name = "Alice",
//                             Address = "Duong 3 thang 2",
//                             Role = "Admin",
//                             Status = "Ok",
//                             PhoneNumber = "0930345872",
//                             Email = "alice@gmail.com",

//                         };
//                         var result = userMgr.CreateAsync(alice, "Pass123$").Result;
//                         if (!result.Succeeded)
//                         {
//                             throw new Exception(result.Errors.First().Description);
//                         }
                        
//                         result = userMgr.AddClaimsAsync(alice, new Claim[]{
//                         new Claim(JwtClaimTypes.Name, alice.UserName),
//                         new Claim(JwtClaimTypes.Email, alice.Email),
//                         new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
//                         new Claim(JwtClaimTypes.Role, alice.Role),
//                         new Claim(JwtClaimTypes.Address, alice.Address),
//                         new Claim(JwtClaimTypes.PhoneNumber, alice.PhoneNumber)}).Result;
//                         if (!result.Succeeded)
//                         {
//                             throw new Exception(result.Errors.First().Description);
//                         }
//                         Log.Debug("alice created");
//                     }
//                     else
//                     {
//                         Log.Debug("alice already exists");
//                     }
//                 }
//             }
//         }
//     }
// }
