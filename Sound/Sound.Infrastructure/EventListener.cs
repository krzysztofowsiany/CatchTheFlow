using System;
using System.Reactive.Linq;
using EventBus;
using EventBus.Extensions;
using Sound.Application.Events;

namespace Sound.Infrastructure
{
    public class EventListener
    {
        private IEventBus _eventBus;

        public EventListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
            var events = _eventBus.Subscribe<WorkStopped>(onNext =>
            {
                Console.WriteLine($"Event in sound {onNext.Value}");
            });
                
        }
    }
}