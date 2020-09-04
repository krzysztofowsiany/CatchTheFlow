using CQRSLib;
using EventBus;
using Configuration.Application.Commands;
using Configuration.Application.Events;

namespace Configuration.Application.CommandHandlers
{
    public class SaveTimeSettingsCommandHandler: ICommandHandler<SaveTimeSettingsCommand>
    {
        private readonly IEventBus _eventBus;

        public SaveTimeSettingsCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SaveTimeSettingsCommand command)
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