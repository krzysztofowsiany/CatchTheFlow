using System.Collections.Generic;

namespace EventBus
{
    public interface IEventRepository
    {
        void Add(Event @event);

        IEnumerable<TEvent> GetEvents<TEvent>(string typeName)
            where TEvent : class;

        IEnumerable<string> GetNamesOfEvents();
    }
}