using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InspectorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
                //.UseKestrel()
                //.UseIISIntegration()
            .UseStartup<Startup>();
        //.UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
        //.UseStartup<Startup>()
        //.UseDefaultServiceProvider(i => i.ValidateScopes = false)
        //.ConfigureAppConfiguration((context, config) =>
        //{
        //    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //})
        //.ConfigureLogging(l =>
        //{
        //    l.ClearProviders();
        //    l.SetMinimumLevel(LogLevel.Trace);
        //})
        //.UseNLog();
    }
}
