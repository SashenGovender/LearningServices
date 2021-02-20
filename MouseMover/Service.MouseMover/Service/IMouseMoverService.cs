using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningServices.Service.MouseMover.Service
{
  public interface IMouseMoverService
  {
    void Start();
    Task StopAsync(CancellationToken cancellationToken); 
  }
}
