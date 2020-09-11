using CQRSLib;
using EventBus;
using Configuration.Application.Commands;
using Configuration.Application.Events;

namespace Configuration.Application.CommandHandlers
{
    public class SaveSoundSettingsCommandHandler: ICommandHandler<SaveSoundSettingsCommand>
    {
        private readonly IEventBus _eventBus;

        public SaveSoundSettingsCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SaveSoundSettingsCommand command)
        {
          _eventBus.PushEvent(new WorkSoundUpdated(
              command.WorkSound)
              );
          
          _eventBus.PushEvent(new ShortBreakeSoundUpdated(
              command.ShortBreakeSound)
          );
          
          _eventBus.PushEvent(new LongBreakeSoundUpdated(
              command.LongBreakeSound)
          );
        }
    }
}