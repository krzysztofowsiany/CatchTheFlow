using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using FluentAssertions;

namespace GWTTestBase
{
    public class CommandTest<TModule>
        where TModule: Module, new()
    {
        private readonly IList<object> _givens;
        private readonly IEventBus _eventBus;
        private object _event;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        protected CommandTest()
        {
            IoT.RegisterContainer<TModule>();
            
            _givens = new List<object>();
            _eventBus = IoT.Container.Resolve<IEventBus>();
            _commandBus = IoT.Container.Resolve<ICommandBus>();
            _eventRepository = IoT.Container.Resolve<IEventRepository>();
            _dateTime = IoT.Container.Resolve<IDateTime>();
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

            Thread.Sleep(200);
            
            _event.Should().NotBeNull();
            _event.Should().BeEquivalentTo(@event, options => 
                options.Using(new IgnoreTimestampPropertyStep()));
            
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
            Activator.CreateInstance(typeof(TEventListener), _eventBus, _dateTime, _commandBus, _eventRepository);
        }

        protected void Give<TEvent>(TEvent @event) where TEvent: class
        {
            _givens.Add(@event);
        }
    }
}