using System.Threading;
using System.Threading.Tasks;

namespace LearningServices.Service.MouseMover.Service
{
  public interface IMouseMoverService
  {
    Task Start();
    Task StopAsync(CancellationToken cancellationToken);
  }
}
