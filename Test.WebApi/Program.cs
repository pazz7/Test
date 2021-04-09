using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Test.Common;

namespace Test.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            Log.Logger = GlobalConfigs.CreateLogger(configuration["LogPath"].ToString());

            try
            {
                Log.Information("Imagegram service is starting up...");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Imagegram service started.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Imagegram service start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static IConfigurationRoot GetConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{environment}.json")
                .Build();
        }
    }
}
