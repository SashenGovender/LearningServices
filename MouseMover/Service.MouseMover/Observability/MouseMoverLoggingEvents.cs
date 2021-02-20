using Microsoft.Extensions.Logging;

namespace LearningServices.Service.MouseMover.Observability
{
  internal static class MouseMoverLoggingEvents
  {
    internal static EventId HostedService_Start => new EventId(100, nameof(HostedService_Start));
    public static EventId HostedService_Stop => new EventId(102, nameof(HostedService_Stop));
    public static EventId BeforeMove => new EventId(103, nameof(BeforeMove));
    public static EventId AfterMove => new EventId(104, nameof(AfterMove));
    public static EventId MouseMover_TimerCreated => new EventId(105, nameof(MouseMover_TimerCreated));

  }
}
