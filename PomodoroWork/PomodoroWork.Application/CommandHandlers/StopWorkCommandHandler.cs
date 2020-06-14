using CQRSLib;
using EventBus;
using PomodoroWork.Application.Commands;
using PomodoroWork.Application.Events;

namespace PomodoroWork.Application.CommandHandlers
{
    public class StopWorkCommandHandler: ICommandHandler<StopWorkCommand>
    {
        private readonly IEventBus _eventBus;

        public StopWorkCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StopWorkCommand command)
        {
          _eventBus.PushEvent(new WorkStopped(
              command.WorkTime, 
              command.StopTime));
        }
    }
}