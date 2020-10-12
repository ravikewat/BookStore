using Dnc.BookStore.Data;
using Dnc.BookStore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            //to use entity framework core and configure DB
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(@"Data Source=LAPTOP-8AM6UCA4\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;"));

            services.AddControllersWithViews();
#if DEBUG
            //to allow  at runtime compilation for development only and also diable client side validtion
            services.AddRazorPages().AddRazorRuntimeCompilation();//.AddViewOptions(o=> o.HtmlHelperOptions.ClientValidationEnabled = false);

#endif
            //inbuild DI support
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
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
                //Below endpoint we added to demo the scenario where problem occurs after our application hosted inside a folder structure so all anchor tag stopped woring as path changed
                //os in this case we can use anchor tag helpers that will handle routing changes 
                //endpoints.MapControllerRoute("default", "bookapp/{controller=Home}/{action=Index}/{id?}");
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
