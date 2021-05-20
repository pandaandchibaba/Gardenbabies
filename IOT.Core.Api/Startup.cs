using IOT.Core.IRepository.Activity;
using IOT.Core.IRepository.Bargain;
using IOT.Core.IRepository.Commodity;
using IOT.Core.IRepository.GroupBooking;
using IOT.Core.IRepository.Live;
using IOT.Core.IRepository.SeckillCom;
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
using IOT.Core.Repository.Colonel;
using IOT.Core.Repository.Commodity;
using IOT.Core.IRepository;
using IOT.Core.IRepository.OrderComment;
using IOT.Core.Repository.MiniProgram;
using IOT.Core.IRepository.Users;
using IOT.Core.IRepository.OutLibrary;
using IOT.Core.Repository.OutLibrary;
using IOT.Core.Repository.SeckillCom;
using IOT.Core.Repository.Live;
using IOT.Core.Repository.Bargain;
using IOT.Core.Repository.GroupBooking;
using IOT.Core.IRepository.CheckRep;
using IOT.Core.Repository.CheckRep;
using IOT.Core.IRepository.NowRep;
using IOT.Core.Repository.NowRep;
using IOT.Core.IRepository.Group_Comm;
using IOT.Core.Repository.Group_Comm;
using IOT.Core.IRepository.CommType;
using IOT.Core.Repository.CommType;
using IOT.Core.IRepository.Specification;
using IOT.Core.Repository.Specification;

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
            services.AddSingleton<IColonelRepository, ColonelRepository>();
            services.AddSingleton<ICommodityRepository, CommodityRepository>();
            services.AddSingleton<IRepository.Delivery.IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IPutLibraryRepository, PutLibraryRepository>();
            services.AddSingleton<IOrderInfoRepository, OrderInfoRepository>();
            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();

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
