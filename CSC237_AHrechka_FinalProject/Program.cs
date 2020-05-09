//CSC237
//Aliaksandra Hrechka
//05/08/2020

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CSC237_AHrechka_FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
