using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarRentalServicesWebApp.Contexts;
using CarRentalServicesWebApp.Repositories.CityRepository;
using CarRentalServicesWebApp.Repositories.ShopRepository;
using CarRentalServicesWebApp.Repositories.CarRepository;
using CarRentalServicesWebApp.Repositories.RentalRepository;
using CarRentalServicesWebApp.Repositories.ClientRepository;
using CarRentalServicesWebApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalServicesWebApp
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();
        }

    }
}