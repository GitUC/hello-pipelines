using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.AppConfiguration.AspNetCore;
using Microsoft.AspNetCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

       public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder webHostBuilder1 = WebHost.CreateDefaultBuilder(args)
                                .ConfigureAppConfiguration((hostingContext, config) =>
                                {
                                    var settings = config.Build();
                                    config.AddAzureAppConfiguration(settings["ConnectionStrings:AppConfig"]);
                                })
                                .ConfigureLogging(logging =>
                                {
                                    logging.ClearProviders();
                                    logging.AddConsole();
                                });
            IWebHostBuilder webHostBuilder = webHostBuilder1;
            return webHostBuilder
                    .UseStartup<Startup>();
        }

    }
}
