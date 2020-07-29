using CQRSLib;
using EventBus;
using StartLongBreakeView.Application.Commands;
using StartLongBreakeView.Application.Events;

namespace StartLongBreakeView.Application.CommandHandlers
{
    public class StartLongBreakeCommandHandler: ICommandHandler<StartLongBreakeCommand>
    {
        private readonly IEventBus _eventBus;

        public StartLongBreakeCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StartLongBreakeCommand command)
        {
          _eventBus.PushEvent(new LongBreakeStarted(
              command.BreakeTime,
              command.StartTime)
              );
        }
    }
}