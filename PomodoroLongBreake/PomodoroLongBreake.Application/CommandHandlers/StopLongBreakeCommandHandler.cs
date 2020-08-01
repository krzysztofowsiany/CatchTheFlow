using CQRSLib;
using EventBus;
using PomodoroLongBreake.Application.Commands;
using PomodoroLongBreake.Application.Events;

namespace PomodoroLongBreake.Application.CommandHandlers
{
    public class StopLongBreakeCommandHandler: ICommandHandler<StopLongBreakeCommand>
    {
        private readonly IEventBus _eventBus;

        public StopLongBreakeCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StopLongBreakeCommand command)
        {
          _eventBus.PushEvent(new LongBreakeStopped(
              command.BreakeTime, 
              command.StopTime));
        }
    }
}