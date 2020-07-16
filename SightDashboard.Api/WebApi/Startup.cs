using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories.Context;
using Repositories.Interface;
using Repositories.Repository;
using Repositories.UnitOfWork;
using Services.Facade;
using Services.Interface;
using Services.Service;

namespace WebApi
{
    public class Startup
    {
        private static string _connection = string.Empty;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connection = StringExtensions.Base64Decode(Environment.GetEnvironmentVariable(Configuration.GetConnectionString("ConnectionString")));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BaseContext>(options => options.UseSqlServer(_connection), ServiceLifetime.Scoped);
            services.AddSingleton(Configuration);
            services.AddTransient<IFacade, Facade>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<ICustomerService, CustomerService>();         
            services.AddScoped<DataSeed>();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var nOrders = 1000;
            var nCustomers = 20;
            seeder.SeedData(nCustomers, nOrders);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
