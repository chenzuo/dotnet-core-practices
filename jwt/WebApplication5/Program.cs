using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                     .ConfigureAppConfiguration((hostingContext, config) =>
                     {
                         var env = hostingContext.HostingEnvironment;
                         config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false);
                         config.AddEnvironmentVariables();
                         config.AddCommandLine(args);
                     })
                .ConfigureLogging((hostingContext, logging) =>
                    {
                        // Requires `using Microsoft.Extensions.Logging;`
                        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                    })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
