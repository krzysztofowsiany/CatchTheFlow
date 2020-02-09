using System;
using System.Reactive.Linq;
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
            var events = _eventBus
                .OfType<Event>();

            events.Where(e => e.Type.Equals(nameof(WorkStopped)))
                .Select(e => e.Data.Deserialize())
                .Subscribe(oNext =>
                {
                    
                });
        }
    }
}