using CQRSLib;
using EventBus;
using Configuration.Application.Commands;
using Configuration.Application.Events;

namespace Configuration.Application.CommandHandlers
{
    public class SaveSettingsCommandHandler: ICommandHandler<SaveSettingsCommand>
    {
        private readonly IEventBus _eventBus;

        public SaveSettingsCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SaveSettingsCommand command)
        {
          _eventBus.PushEvent(new WorkTimeUpdated(
              command.WorkTime)
              );
          
          _eventBus.PushEvent(new ShortBreakeTimeUpdated(
              command.ShortBreakeTime)
          );
          
          _eventBus.PushEvent(new LongBreakeTimeUpdated(
              command.LongBreakeTime)
          );
        }
    }
}