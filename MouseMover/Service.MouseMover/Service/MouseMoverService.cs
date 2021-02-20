using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using LearningServices.Service.MouseMover.Models;
using Microsoft.Extensions.Options;
using LearningServices.Service.MouseMover.Observability;

namespace LearningServices.Service.MouseMover.Service
{
  public class MouseMoverService : IMouseMoverService
  {
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    private readonly ILogger<MouseMoverService> _logger;
    private readonly MouseSettingsOptions _mouseSettings;

    private Timer? _timer;

    public MouseMoverService(ILogger<MouseMoverService> logger, IOptions<MouseSettingsOptions> mouseSettingsOptions)
    {
      _logger = logger;
      _mouseSettings = mouseSettingsOptions.Value;
    }

    public Task Start()
    {
      _logger.LogInformation(MouseMoverLoggingEvents.MouseMover_TimerCreated, "Creating long running mouse mover task");

      _timer = new Timer(BeginMouseMoving!, null, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(_mouseSettings.IntervalInMinutes));

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _timer?.Dispose();

      return Task.CompletedTask;
    }

    private void BeginMouseMoving(object state)
    {
      _logger.LogInformation(MouseMoverLoggingEvents.BeforeMove, "About to move mouse cursor");

      _mouseSettings.DistanceInPxels = _mouseSettings.DistanceInPxels * -1;
      var xPosition = _mouseSettings.StartPointX + _mouseSettings.DistanceInPxels;
      var yPosition = _mouseSettings.StartPointY + _mouseSettings.DistanceInPxels;

      SetCursorPos(xPosition, yPosition);

      _logger.LogInformation(MouseMoverLoggingEvents.AfterMove, $"Mouse cursor moved to X:{xPosition}, Y:{yPosition}");

    }
  }
}
