using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Empresa.Sistema.Mensageiro.API
{
    public class Program
    {
        #region .NetCore 2.2
        //public static void Main(string[] args)
        //{
        //    CreateWebHostBuilder(args).Build().Run();
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .UseIISIntegration();
        #endregion

        #region .NetCore 2.2 hospedado no IIS
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //                 .UseKestrel()
        //                 .UseContentRoot(Directory.GetCurrentDirectory())
        //                 .UseIISIntegration()
        //                 .UseStartup<Startup>()
        //                 .Build();
        //    host.Run();
        //}
        #endregion

        #region .NetCore 3.1 hospedado no IIS

        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            //webBuilder.UseKestrel();
        //            webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        //            webBuilder.UseIISIntegration();
        //            webBuilder.UseStartup<Startup>();
        //        });

        #endregion

        #region .NetCore 3.1

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();

                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(configuration);
                });

        #endregion
    }
}
