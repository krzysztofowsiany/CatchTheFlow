using CQRSLib;
using EventBus;
using PomodoroShortBreake.Application.Commands;
using PomodoroShortBreake.Application.Events;

namespace PomodoroShortBreake.Application.CommandHandlers
{
    public class StopShortBreakeCommandHandler: ICommandHandler<StopShortBreakeCommand>
    {
        private readonly IEventBus _eventBus;

        public StopShortBreakeCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StopShortBreakeCommand command)
        {
          _eventBus.PushEvent(new ShortBreakeStopped(
              command.BreakeTime, 
              command.StopTime));
        }
    }
}