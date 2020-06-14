using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Events;
using Sound.Core;

namespace Sound.Application.CommandHandlers
{
    public class StartPlayCommandHandler: ICommandHandler<StartPlayCommand>
    {
        private readonly SoundPlayerService _soundPlayerService;
        private readonly IEventBus _eventBus;

        public StartPlayCommandHandler(
            IEventBus eventBus, 
            SoundPlayerService soundPlayerService)
        {
            _soundPlayerService = soundPlayerService;
            _eventBus = eventBus;
        }
        
        public void Handle(StartPlayCommand command)
        {
            _soundPlayerService.StartPlay(command.Sound); 
            _eventBus.PushEvent(new SoundStarted(command.Sound));
        }
    }
}