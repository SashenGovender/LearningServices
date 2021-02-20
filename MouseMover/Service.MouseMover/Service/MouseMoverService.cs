using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LearningServices.Service.MouseMover.Service
{
  public class MouseMoverService : IMouseMoverService
  {
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    private readonly ILogger<MouseMoverService> logger;

    public MouseMoverService(ILogger<MouseMoverService> logger)
    {
      this.logger = logger;
    }

    public void Start()
    {
      SetCursorPos(500, 500);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}
