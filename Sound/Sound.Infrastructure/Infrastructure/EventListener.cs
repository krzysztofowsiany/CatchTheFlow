using System;
using CQRSLib;
using EventBus;
using Sound.Application.CommandHandlers;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Infrastructure.Events;

namespace Sound.Infrastructure
{
    public class EventListener
    {
        private IEventBus _eventBus;

        public EventListener(IEventBus eventBus, ICommandHandler<StopPlay> stopPlayCommandHandler)
        {
            _eventBus = eventBus;
            var events = _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTime(@event.StopTime);
                
                stopPlayCommandHandler.Handle(new StopPlay());
                
                //_eventBus.PushEvent(new SoundStopped(@event.Timestamp));
                Console.WriteLine($"Event in sound {@event.WorkTime}");
              
            });
                
        }
    }
}