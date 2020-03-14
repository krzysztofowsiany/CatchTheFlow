using System;
using System.Collections.Generic;
using CQRSLib;
using EventBus;
using FluentAssertions;

namespace GWTTestBase
{
    public class TestBase
    {
        private IList<object> _givens;
        private IEventBus _eventBus;
        private object _event;
        private CommandBus _commandBus;

        protected TestBase()
        {
            _givens = new List<object>();
            _eventBus = new EventBus.EventBus();
            _commandBus = new CommandBus(null);
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
            Activator.CreateInstance(typeof(TEventListener), _eventBus, _commandBus);
        }

        protected void Give<TEvent>(TEvent @event) where TEvent: class
        {
            _givens.Add(@event);
        }
    }
}