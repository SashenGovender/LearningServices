using LearningServices.Service.MouseMover.Models;
using LearningServices.Service.MouseMover.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningServices.Service.MouseMover.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddMouseMoverHostedService(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<MouseSettingsOptions>(options => configuration.GetSection("MouseSettings").Bind(options));

      services.AddTransient<IMouseMoverService, MouseMoverService>();

      services.AddHostedService<MouseMoverHostedService>();

      return services;
    }
  }
}
