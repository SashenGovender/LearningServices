using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningServices.Service.MouseMover.Observability
{
  internal static class MouseMoverLoggingEvents
  {
    public static EventId HostedService_Stop { get; internal set; }

    internal static EventId HostedService_Start => new EventId(1, nameof(HostedService_Start));
  }
}
