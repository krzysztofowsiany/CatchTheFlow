using System.Collections.Generic;
using System.Linq;
using EventBus.Extensions;

namespace EventBus.View
{
    public abstract class BaseView
    {
        protected IEventRepository _eventRepository;

        protected BaseView(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public abstract void RestoreState();

        protected IEnumerable<TEvent> GetEvents<TEvent>()
            where TEvent : class
        {
            var typeName = typeof(TEvent).Name;
            var events = _eventRepository.Events
                .Where(e => e.Type == typeName)
                .OrderByDescending(e=> e.Timestamp)
                .Select(e => e.Data.Deserialize<TEvent>());

            return events;
        }

        protected IEnumerable<string> GetNamesOfEvents()
            => _eventRepository.Events
                .OrderByDescending(e=> e.Timestamp)
                .Select(e => e.Type);
    }
}