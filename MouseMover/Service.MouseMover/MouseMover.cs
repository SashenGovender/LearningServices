using LearningServices.Service.MouseMover.Observability;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearningServices.Service.MouseMover
{
  public class MouseMover : IHostedService
  {
    private readonly ILogger<MouseMover> _logger;

    public MouseMover(ILogger<MouseMover> logger)
    {
      _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation(MouseMoverLoggingEvents.HostedService_Start, "Starting Mouse Mover hosted Service");

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation(MouseMoverLoggingEvents.HostedService_Stop, "Stopping Mouse Mover hosted Service");

      return Task.CompletedTask;
    }
  }

}
