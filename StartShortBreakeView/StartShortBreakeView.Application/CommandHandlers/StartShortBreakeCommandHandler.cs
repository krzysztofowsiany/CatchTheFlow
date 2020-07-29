using CQRSLib;
using EventBus;
using StartLongBreakeView.Application.Commands;
using StartLongBreakeView.Application.Events;

namespace StartLongBreakeView.Application.CommandHandlers
{
    public class StartShortBreakeCommandHandler: ICommandHandler<StartShortBreakeCommand>
    {
        private readonly IEventBus _eventBus;

        public StartShortBreakeCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StartShortBreakeCommand command)
        {
          _eventBus.PushEvent(new ShortBreakeStarted(
              command.BreakeTime,
              command.StartTime)
              );
        }
    }
}