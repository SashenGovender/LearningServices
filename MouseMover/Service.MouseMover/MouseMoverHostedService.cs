using LearningServices.Service.MouseMover.Observability;
using LearningServices.Service.MouseMover.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearningServices.Service.MouseMover
{
  public class MouseMoverHostedService : IHostedService
  {
    private readonly ILogger<MouseMoverHostedService> _logger;
    private readonly IMouseMoverService _mouseMover;

    public MouseMoverHostedService(ILogger<MouseMoverHostedService> logger, IMouseMoverService mouseMover)
    {
      _logger = logger;
      _mouseMover = mouseMover;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation(MouseMoverLoggingEvents.HostedService_Start, "Starting Mouse Mover hosted Service");
      _mouseMover.Start();

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation(MouseMoverLoggingEvents.HostedService_Stop, "Stopping Mouse Mover hosted Service");
      _mouseMover.StopAsync(cancellationToken);

      return Task.CompletedTask;
    }
  }

}
