using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dnc.BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This method return IHostBuilder object than we build and run to achive web app.
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
