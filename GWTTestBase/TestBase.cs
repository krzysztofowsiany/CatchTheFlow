using System.Collections.Generic;
using EventBus;
using FluentAssertions;

namespace GWTTestBase
{
    public class TestBase
    {
        private IList<object> _givens;
        protected IEventBus _eventBus;
        private object _event;

        public TestBase()
        {
            _givens = new List<object>();
            _eventBus = new EventBus.EventBus();
        }

        protected void Then<TEvent>(TEvent @event) where TEvent: class
        {
            _eventBus.Subscribe<TEvent>(onNext =>
            {
                _event = onNext;
            });
            
            PushEvents();
            
            _event.Should().BeEquivalentTo(@event);
            
            void PushEvents()
            {
                foreach (var given in _givens)
                {
                    _eventBus.PushEvent(given);
                }
            }
        }

        protected void Give<TEvent>(TEvent @event) where TEvent: class
        {
            _givens.Add(@event);
        }
    }
}