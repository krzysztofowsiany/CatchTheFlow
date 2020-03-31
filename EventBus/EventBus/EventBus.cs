using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using EventBus.Extensions;

namespace EventBus
{
    public class EventBus : IEventBus
    {
        private readonly Subject<Event> _subject = new Subject<Event>();
        private readonly IEventRepository _eventRepository;

        public EventBus(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IDisposable Subscribe<TEvent>(Action<TEvent> onNext) where TEvent: class
        {
            var observer = new AnonymousObserver<TEvent>(onNext);
            var typeName = typeof(TEvent).Name;

            return _subject
                .Where(e=> e.Type.Equals(typeName))
                .Select(e=>e.Data.Deserialize<TEvent>())
                .Subscribe(observer);
        }

        public void PushEvent<TEvent>(TEvent @event) where TEvent: class
        {
            var e = new Event(@event.Serialize(), @event.GetType().Name);
            _eventRepository.Add(e);
            _subject.OnNext(e);
        }
    }
}