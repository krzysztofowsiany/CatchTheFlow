using CQRSLib;
using EventBus;
using StartShortBreakeView.Application.Commands;
using StartShortBreakeView.Application.Events;

namespace StartShortBreakeView.Application.CommandHandlers
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