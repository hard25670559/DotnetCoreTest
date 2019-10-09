using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCore_30_Middleware_Test.MiddlewareExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotnetCore_30_Middleware_Test
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseTest();

            app.Use(async (context, next) =>
            {
                //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("First in\n"));
                Debug.WriteLine("Fist in\n");
                await next();
                Debug.WriteLine("Fist out\n");
            });

            app.Use(async (context, next) =>
            {
                //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Second in\n"));
                Debug.WriteLine("Second in\n");
                await next();
                Debug.WriteLine("Second out\n");
            });

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
