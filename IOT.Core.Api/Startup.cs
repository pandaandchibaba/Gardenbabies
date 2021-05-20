using IOT.Core.IRepository.Activity;
using IOT.Core.IRepository.Commodity;
using IOT.Core.IRepository.OrderInfo;
using IOT.Core.IRepository.Colonel;
using IOT.Core.Repository.Activity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Warehouse;
using IOT.Core.Repository.Warehouse;
using IOT.Core.IRepository.Delivery;
using IOT.Core.Repository.Delivery;
using IOT.Core.IRepository.PutLibrary;
using IOT.Core.Repository.PutLibrary;
using IOT.Core.Repository.OrderInfo;
using IOT.Core.Repository.Commodity;
using IOT.Core.IRepository;
using IOT.Core.IRepository.ColonelManagement;
using IOT.Core.Repository.ColonelManagement;
using IOT.Core.IRepository.ColonelGrade;
using IOT.Core.Repository.ColonelGrade;
using IOT.Core.IRepository.GroupPurchase;
using IOT.Core.Repository.GroupPurchase;
using IOT.Core.IRepository.Path;
using IOT.Core.Repository.path;
using IOT.Core.IRepository.Brokerage;
using IOT.Core.Repository.Brokerage;
using IOT.Core.Repository.Colonel;

namespace IOT.Core.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IOT.Core.Api", Version = "v1" });
            });
            //注入
            services.AddSingleton<IActivityRepository, ActivityRepository>();
            services.AddSingleton<IColonelRepository, ColonelRepositoty>();
            services.AddSingleton<ICommodityRepository, CommodityRepository>();
            services.AddSingleton<IRepository.Delivery.IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IPutLibraryRepository, PutLibraryRepository>();
            services.AddSingleton<IOrderInfoRepository, OrderInfoRepository>();
            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
            services.AddSingleton<IColonelManagementRepository, ColonelManagementRepository>();
            services.AddSingleton<IColonelGradeRepository, ColonelGradeRepository>();
            services.AddSingleton<IGroupPurchaseRepository, GroupPurchaseRepository>();
            services.AddSingleton<IPathRepository, pathRepository>();
            services.AddSingleton<IBrokerageRepository,BrokerageRepository>();
            services.AddCors(options => 
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IOT.Core.Api v1"));
            }
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
