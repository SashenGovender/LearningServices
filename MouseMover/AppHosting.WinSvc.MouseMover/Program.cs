using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Configuration;
using NLog.Web;
using Microsoft.Extensions.DependencyInjection;
using LearningServices.Service.MouseMover.Extensions;

namespace LearningServices.AppHosting.WinSvc.MouseMover
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3
      var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
      try
      {
        CreateHostBuilder(args).Build().RunAsync();
      }
      catch (Exception exception)
      {
        logger.Error(exception, "Stopped program because of exception");
        throw;
      }
      finally
      {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        NLog.LogManager.Shutdown();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder()
          .ConfigureServices((hostContext, services) =>
          {
            services.AddMouseMoverHostedService(hostContext.Configuration);
          })
          .UseWindowsService()
          .ConfigureLogging((hostBuilderContext, logging) =>
          {
            logging.ClearProviders(); //remove all logging provider first because by default the framework will add Console,Debug, TraceSource and EventSource providers
            logging.SetMinimumLevel(LogLevel.Debug);
            logging.AddEventLog(hostBuilderContext.Configuration.GetSection("Logging:EventLog").Get<EventLogSettings>());
          }).UseNLog();  // NLog: Setup NLog for Dependency injection;
  }
}
