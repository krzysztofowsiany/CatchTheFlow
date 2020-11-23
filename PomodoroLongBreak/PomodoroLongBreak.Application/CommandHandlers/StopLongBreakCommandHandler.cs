using CQRSLib;
using EventBus;
using PomodoroLongBreak.Application.Commands;
using PomodoroLongBreak.Application.Events;

namespace PomodoroLongBreak.Application.CommandHandlers
{
    public class StopLongBreakCommandHandler: ICommandHandler<StopLongBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public StopLongBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StopLongBreakCommand command)
        {
          _eventBus.PushEvent(new LongBreakStopped(
              command.BreakTime, 
              command.StopTime));
        }
    }
}