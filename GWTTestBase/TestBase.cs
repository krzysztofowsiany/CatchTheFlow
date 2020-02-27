using System;
using System.Collections.Generic;
using EventBus;
using FluentAssertions;

namespace GWTTestBase
{
    public class TestBase
    {
        private IList<object> _givens;
        private IEventBus _eventBus;
        private object _event;

        public TestBase()
        {
            _givens = new List<object>();
            _eventBus = new EventBus.EventBus();
        }

        protected void Then<TEvent>(TEvent @event) where TEvent: class
        {
            _eventBus.Subscribe<TEvent>(incomeEvent =>
            {
                if (@event.GetType().Name.Equals(incomeEvent.GetType().Name))
                {
                    _event = incomeEvent;
                }
            });
            
            PushEvents();

            _event.Should().NotBeNull();
            _event.Should().BeEquivalentTo(@event);
            
            void PushEvents()
            {
                foreach (var given in _givens)
                {
                    _eventBus.PushEvent(given);
                }
            }
        }
        
        protected void When<TEventListener>()
        {
            Activator.CreateInstance(typeof(TEventListener), _eventBus);
        }

        protected void Give<TEvent>(TEvent @event) where TEvent: class
        {
            _givens.Add(@event);
        }
    }
}