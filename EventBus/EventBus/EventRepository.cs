using System.Collections.Generic;
using System.Linq;
using EventBus.Extensions;

namespace EventBus
{
    public class EventRepository : IEventRepository
    {
        private readonly IList<Event> _events;

        public EventRepository()
        {
            _events = new List<Event>();
        }

        public void Add(Event @event)
        {
            _events.Add(@event);
        }

        public IEnumerable<TEvent> GetEvents<TEvent>(string typeName)
            where TEvent : class
        {
            return _events
                .Where(e => e.Type == typeName)
                .OrderByDescending(e => e.Timestamp)
                .Select(e => e.Data.Deserialize<TEvent>());
        }

        public IEnumerable<string> GetNamesOfEvents()
        {
            return _events
                .OrderByDescending(e => e.Timestamp)
                .Select(e => e.Type);
        }
    }
}