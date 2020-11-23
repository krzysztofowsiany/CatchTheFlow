using CQRSLib;
using EventBus;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Events;

namespace StartLongBreakView.Application.CommandHandlers
{
    public class StartShortBreakCommandHandler: ICommandHandler<StartShortBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public StartShortBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StartShortBreakCommand command)
        {
          _eventBus.PushEvent(new ShortBreakStarted(
              command.BreakTime,
              command.StartTime)
              );
        }
    }
}