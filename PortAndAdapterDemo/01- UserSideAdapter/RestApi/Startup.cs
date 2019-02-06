using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookingSqlAdapter;
using BookingStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using UseCases;

namespace RestApi
{
    public class Startup
    {
      
        public const string connectionString = "Server=tcp:test-gurra.database.windows.net,1433;Initial Catalog=PortsDemo;Persist Security Info=False;User ID=XXX;Password=XXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private const string ApiName = "PortsDemo API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRouting();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = ApiName, Version = "v1" });
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterType<BookingManageApplication>();
            containerBuilder.RegisterType<ManageBookingController>();
            containerBuilder.RegisterInstance(new BookingRepository(connectionString)).As<IBookingRepository>();

            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PortsDemo API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
            


        }
    }
}
