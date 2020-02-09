using System.Reactive.Subjects;

namespace EventBus
{
    public interface IEventBus : ISubject<Event>
    {
        void PushEvent(Event @event);
    }
}