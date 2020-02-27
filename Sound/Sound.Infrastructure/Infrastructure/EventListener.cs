using System;
using EventBus;
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
                _eventBus.PushEvent(new SoundStopped(onNext.Value));
                Console.WriteLine($"Event in sound {onNext.Value}");
            });
                
        }
    }
}