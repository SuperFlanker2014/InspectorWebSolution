using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            //.ConfigureLogging(logging =>
            //{
            //    logging.ClearProviders();
            //    logging.AddProvider();
            //})
            .UseUrls("http://*:8080;https://*:4443")
            //.UseKestrel(options =>
            //{
            //    options.Listen(IPAddress.Any, 80);         // http:*:80
            //    options.Listen(IPAddress.Any, 443, listenOptions =>
            //    {
            //        listenOptions.UseHttps("certificate.pfx", "password");
            //    });
            //})
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>();
    }
}