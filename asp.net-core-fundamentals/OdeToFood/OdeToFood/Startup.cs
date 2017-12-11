using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming ...");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else 
            //        {
            //            await next(context);
            //            logger.LogInformation("Response not handled - outgoing ...");
            //        }
            //    };   
            //});

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //});

            //app.UseDeveloperExceptionPage();

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            //app.UseFileServer();

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.getMessageOfTheDay();
                //await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName} : {env.ApplicationName} : {env.ContentRootPath} : {env.WebRootPath}");
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            //routeBuilder.MapRoute("Default", "{controller}/{action}");

            // /Home/Index/4 (ID is optional)
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            // admin/Home/Index
            //routeBuilder.MapRoute("Default", "admin/{controller}/{action}");
        }
    }
}
