using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NorthwindAPI.Auth;
using NorthwindAPI.Middleware;
using NorthwindAPI.Swagger;
using NorthwindData;
using NorthwindData.Models;
using NortwindBusinessLogic;

namespace NorthwindAPI
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwagger();
            services.AddTokenAuthentication(Configuration);

            //wbudowane
            //services.AddScoped<IOrdersRepository, OrdersEfRepository>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //autofac
            //builder.RegisterModule();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthTokenSettings>().As<AuthTokenSettings>().InstancePerLifetimeScope();
            builder.RegisterType<NorthwindContext>().As<NorthwindContext>().InstancePerLifetimeScope();
            builder.RegisterType<OrdersEfRepository>().As<IOrdersRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductsEfRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<RequestMiddlewareExtensions>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
