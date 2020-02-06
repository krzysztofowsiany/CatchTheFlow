using System.Reactive.Subjects;

namespace EventBus
{
    public interface IEventBus : ISubject<IEvent>
    {
        void PushEvent(IEvent @event);
    }
}