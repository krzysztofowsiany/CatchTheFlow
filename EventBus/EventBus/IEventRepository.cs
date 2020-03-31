using System.Collections.Generic;

namespace EventBus
{
    public interface IEventRepository
    {
        void Add(Event @event);
        IList<Event> Events { get; }
    }
}