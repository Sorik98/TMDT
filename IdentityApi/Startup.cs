// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using IdentityApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace IdentityApi
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment environment,IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();
            // services.ConfigureNonBreakingSameSiteCookies();
            services.AddCors();

            // services.Configure<CookieAuthenticationOptions>(IdentityServerConstants.DefaultCookieAuthenticationScheme, options =>
            // {
            //     options.Cookie.SameSite = SameSiteMode.None;
            //     options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //     options.Cookie.IsEssential = true;
            // });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            // var builder = services.AddIdentityServer(options =>{
            //     options.Authentication.CookieLifetime = TimeSpan.FromSeconds(60);
            //     options.Authentication.CookieSlidingExpiration = false;
            //  })
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.Ids)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>();
                
            // services.AddAuthentication("MyCookie")
            //     .AddCookie("MyCookie", options =>
            //     {
            //         options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //     });

            // builder.Services.ConfigureExternalCookie(options => {
            //         options.Cookie.IsEssential = true;
            //         options.Cookie.SameSite = SameSiteMode.Unspecified;  //SameSiteMode.Unspecified in .NET Core 3.1
            //     });
            
            // builder.Services.ConfigureApplicationCookie(options => {
            //          options.Cookie.IsEssential = true;
            //          options.Cookie.SameSite = SameSiteMode.Unspecified; //SameSiteMode.Unspecified in .NET Core 3.1
            // });
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

           
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseHttpsRedirection();
            // uncomment if you want to add MVC
            app.UseStaticFiles();
            // app.UseCookiePolicy();
            app.UseRouting();
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200","http://localhost:5000")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseIdentityServer();
            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
