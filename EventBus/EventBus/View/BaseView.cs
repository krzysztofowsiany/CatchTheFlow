using System.Collections.Generic;

namespace EventBus.View
{
    public abstract class BaseView
    {
        protected readonly IEventRepository _eventRepository;

        protected BaseView(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public abstract void RestoreState();

        protected IEnumerable<TEvent> GetEvents<TEvent>()
            where TEvent : class
        {
            var typeName = typeof(TEvent).Name;
            return _eventRepository.GetEvents<TEvent>(typeName);
        }
    }
}