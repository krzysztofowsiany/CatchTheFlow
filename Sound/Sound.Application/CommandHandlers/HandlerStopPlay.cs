using System;
using CQRSLib;
using Sound.Application.Commands;
using Sound.Core;

namespace Sound.Application.CommandHandlers
{
    public class HandlerStopPlay: ICommandHandler<StopPlay>
    {
        private SoundPlayerFacade _soundPlayerFacade;

        public HandlerStopPlay(SoundPlayerFacade soundPlayerFacade)
        {
            _soundPlayerFacade = soundPlayerFacade;
        }
        
        public void Handle(StopPlay command)
        {
            _soundPlayerFacade.StopPlay(); 
        }
    }
}