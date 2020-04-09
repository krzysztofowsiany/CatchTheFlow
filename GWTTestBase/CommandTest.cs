using System;
using System.Collections.Generic;
using Autofac;
using CQRSLib;
using EventBus;
using EventBus.Extensions;
using EventBus.View;
using FluentAssertions;

namespace GWTTestBase
{
    public class CommandTest
    {
        private readonly IList<object> _givens;
        private readonly IEventBus _eventBus;
        private object _event;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        protected CommandTest()
        {
            _givens = new List<object>();
            _eventBus = IoT.Container.Resolve<IEventBus>();
            _commandBus = IoT.Container.Resolve<ICommandBus>();
            _eventRepository = IoT.Container.Resolve<IEventRepository>();
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
            Activator.CreateInstance(typeof(TEventListener), _eventBus, _commandBus, _eventRepository);
        }

        protected void Give<TEvent>(TEvent @event) where TEvent: class
        {
            _givens.Add(@event);
        }
    }
}