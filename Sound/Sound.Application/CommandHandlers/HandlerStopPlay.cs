using System;
using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Events;
using Sound.Core;

namespace Sound.Application.CommandHandlers
{
    public class HandlerStopPlay: ICommandHandler<StopPlay>
    {
        private readonly SoundPlayerFacade _soundPlayerFacade;
        private readonly IEventBus _eventBus;

        public HandlerStopPlay(
            IEventBus eventBus, 
            SoundPlayerFacade soundPlayerFacade)
        {
            _soundPlayerFacade = soundPlayerFacade;
            _eventBus = eventBus;
        }
        
        public void Handle(StopPlay command)
        {
            _soundPlayerFacade.StopPlay(); 
            _eventBus.PushEvent(new SoundStopped(command.Timestamp));
        }
    }
}