using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Database.Context;
using WebApi.Infrastructure.Interfaces;
using WebApi.Infrastructure.Models;
using WebApi.Infrastructure.Repositories;


namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                       {
                           options.JsonSerializerOptions.PropertyNamingPolicy = null;
                           options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                       });
            ConfigureScoped(services);
            services.AddCors();
            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = Configuration.GetValue<string>("Url:identityServer");
                options.RequireHttpsMetadata = false;
                options.ApiName = "coreapi";
                //options.JwtValidationClockSkew = TimeSpan.FromSeconds(60);
                // // Ensure the token hasn't expired: AddJwtBearer
                // RequireExpirationTime = true,
                // ValidateLifetime = true,
            });

            services.AddDbContext<PaymentDetailContext>(optionns =>
                            optionns.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("UserIdentity")));

            services.AddIdentityCore<ApplicationUser>(options => { });
            new IdentityBuilder(typeof(ApplicationUser), services)
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order API", Version = "v1" });

                /* #region  old authorize swagger ui */
                // c.AddSecurityDefinition("oauth2", new ApiKeyScheme
                // {
                //     Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                //     In = "header",
                //     Name = "Authorization",
                //     Type = "apiKey"
                // });

                // c.OperationFilter<SecurityRequirementsOperationFilter>();
                /* #endregion */
                
                /* #region  new authorize swagger ui */
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                /* #endregion */

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                    c.RoutePrefix = string.Empty;

                });
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            options.WithOrigins(Configuration.GetValue<string>("Url:client"))
            .AllowAnyMethod()
            .AllowAnyHeader());

            //authorize here
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void ConfigureScoped(IServiceCollection services)
        {
            services.AddScoped<IPaymentDetailRepository, PaymentDetailRepository>();
        }
    }
}
