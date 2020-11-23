using CQRSLib;
using EventBus;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Events;

namespace StartLongBreakView.Application.CommandHandlers
{
    public class StartLongBreakCommandHandler: ICommandHandler<StartLongBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public StartLongBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StartLongBreakCommand command)
        {
          _eventBus.PushEvent(new LongBreakStarted(
              command.BreakTime,
              command.StartTime)
              );
        }
    }
}