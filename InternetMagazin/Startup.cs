using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PresentationLayer.Servieces.Implementation;
using PresentationLayer.Servieces.Interfaces;

namespace InternetMagazin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DataLayer")));
            services.AddIdentity<ApplicationUsers,ApplicationRole>().AddEntityFrameworkStores<EFDBContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });
            services.AddCors();
            //jwt
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSetting:JWT_Secret"].ToString());
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddTransient<IDatabaseInit, DatabaseInit>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped<UnitOfWork>();

            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<ICustomerServieces, CustomerServieces>();
            services.AddTransient<IOrderItemServieces, OrderItemServieces>();
            services.AddTransient<IOrderServieces, OrderServieces>();
            services.AddTransient<IItemServieces, ItemServieces>();
           
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseHsts();
            }
           
            app.UseCors(builer =>
            
                builer.WithOrigins(Configuration["ApplicationSetting:Client_URL"].ToString())
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "/");
            });
        }
    }
}
