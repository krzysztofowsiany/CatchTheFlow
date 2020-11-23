using CQRSLib;
using EventBus;
using PomodoroShortBreak.Application.Commands;
using PomodoroShortBreak.Application.Events;

namespace PomodoroShortBreak.Application.CommandHandlers
{
    public class StopShortBreakCommandHandler: ICommandHandler<StopShortBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public StopShortBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StopShortBreakCommand command)
        {
          _eventBus.PushEvent(new ShortBreakStopped(
              command.BreakTime, 
              command.StopTime));
        }
    }
}