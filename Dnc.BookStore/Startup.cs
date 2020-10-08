using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dnc.BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //to allow  at runtime
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            //app.Use(async (context, next)=>
            //{
            //    await context.Response.WriteAsync("Response From Custom Middleware 1 Pre");
            //    await next();
            //    await context.Response.WriteAsync("Response From Custom Middleware 1 Post");
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/ravi", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Ravi!");
            //    });
            //});
        }
    }
}
