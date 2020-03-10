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
        public EventListener(
            IEventBus eventBus, 
            ICommandBus commandBus)
        {
            var events = eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTime(@event.StopTime);

                commandBus.Send(new StopPlay());
                
                //_eventBus.PushEvent(new SoundStopped(@event.Timestamp));
                Console.WriteLine($"Event in sound {@event.WorkTime}");
              
            });
                
        }
    }
}