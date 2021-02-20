using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.MouseMover
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
      throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }

}
