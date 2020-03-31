using System.Collections.Generic;

namespace EventBus
{
    public class EventRepository : IEventRepository
    {
        private readonly IList<Event> _event;
        public IList<Event> Events => _event;

        public EventRepository()
        {
            _event = new List<Event>();
        }
        public void Add(Event @event)
        {
            _event.Add(@event);
        }

    }
}