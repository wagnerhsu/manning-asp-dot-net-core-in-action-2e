using System;
using System.Threading.Tasks;
using AbpReadConfiguration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

namespace AbpReadConfiguration
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("jobsettings.json", false, true)
                .Build();
            var jobSetting = Configuration.GetSection("JobSettings")
                .Get<JobSetting>();
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .WriteTo.Async(c => c.Console())
                .CreateLogger();
            Log.Debug(JsonConvert.SerializeObject(jobSetting));
            try
            {
                Log.Information("Starting console host.");
                await CreateHostBuilder(args)
                    .RunConsoleAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAutofac()
                .UseSerilog()
                .ConfigureAppConfiguration((context, config) =>
                {
                    //setup your additional configuration sources
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddApplication<AbpReadConfigurationModule>();
                });
    }
}