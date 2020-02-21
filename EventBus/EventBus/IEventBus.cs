using System;

namespace EventBus
{
    public interface IEventBus
    {
        void PushEvent<TEvent>(TEvent @event) where TEvent : class;

        IDisposable Subscribe<TEvent>(Action<TEvent> onNext) where TEvent : class;
    }
}