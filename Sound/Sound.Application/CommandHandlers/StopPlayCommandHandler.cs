using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Events;
using Sound.Core;

namespace Sound.Application.CommandHandlers
{
    public class StopPlayCommandHandler: ICommandHandler<StopPlayCommand>
    {
        private readonly SoundPlayerService _soundPlayerService;
        private readonly IEventBus _eventBus;

        public StopPlayCommandHandler(
            IEventBus eventBus, 
            SoundPlayerService soundPlayerService)
        {
            _soundPlayerService = soundPlayerService;
            _eventBus = eventBus;
        }
        
        public void Handle(StopPlayCommand command)
        {
           // _soundPlayerService.StopPlay(); 
            _eventBus.PushEvent(new SoundStopped());
        }
    }
}