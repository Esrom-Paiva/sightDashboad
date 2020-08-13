using System;
using AutoMapper;
using Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories.Context;
using Services.AutoMapper;
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
            services.AddSingleton(AutoMapperConfiguration.GetMapper());
            services.AddTransient<IFacade, Facade>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<ICustomerService, CustomerService>();         
            services.AddScoped<DataSeed>();

            services.AddSwaggerGen(sw => 
            {
                sw.SwaggerDoc("v1",new OpenApiInfo
                { 
                    Title = "swagger",
                    Version ="v1"
                });
            });
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

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("v1/swagger.json", "v1");
            });
        }
    }
}
