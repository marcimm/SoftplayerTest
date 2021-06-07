using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace MMM.Teste.CalculoJuros.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
           .UseSerilog()
           .ConfigureAppConfiguration(config =>
           {
               IConfigurationRoot cfg = config.Build();
               Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(cfg, "Serilog").CreateLogger();
           })
           .UseStartup<Startup>()
           .Build()
           .Run();
        }
    }
}
