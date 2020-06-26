using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using eShop.Service;
using eShop.Service.Repository;
using eShop.Service.Interfaces;

namespace eShop.API
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
            var customerRepo = new CustomerRepository();
            var orderRepo = new OrderRepository();
            var itemRepo = new ItemRepository();
            var itemServ = new ItemService(itemRepo);

            services.AddSingleton<ICustomerRepository, CustomerRepository>(x => customerRepo);
            services.AddSingleton<IOrderRepository, OrderRepository>(x => orderRepo);
            services.AddSingleton<IItemRepository, ItemRepository>(x => itemRepo);
            services.AddSingleton<ICustomerService, CustomerService>(x => new CustomerService(customerRepo));
            services.AddSingleton<IItemService, ItemService>(x => itemServ);
            services.AddSingleton<IOrderService, OrderService>(x => new OrderService(orderRepo, itemServ));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
