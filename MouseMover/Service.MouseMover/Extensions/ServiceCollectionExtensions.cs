using LearningServices.Service.MouseMover.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningServices.Service.MouseMover.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddMouseMoverHostedService(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IMouseMoverService, MouseMoverService>();

      services.AddHostedService<MouseMoverHostedService>();
      return services;
    }
  }
}
