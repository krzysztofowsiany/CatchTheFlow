using System;
using System.Collections.Generic;
using Autofac;
using CQRSLib;
using EventBus;
using FluentAssertions;
using Sound;

namespace GWTTestBase
{
    public class TestBase
    {
        private readonly IList<object> _givens;
        private readonly IEventBus _eventBus;
        private object _event;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        protected TestBase()
        {
            _givens = new List<object>();
            var container = RegisterContainer();
            _eventBus = container.Resolve<IEventBus>();
            _commandBus = container.Resolve<ICommandBus>();
            _eventRepository = container.Resolve<IEventRepository>();
        }
        
        private static IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventBus.EventBus>()
                .As<IEventBus>()
                .SingleInstance();
            
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .SingleInstance();
            
            builder.RegisterModule(new SoundModule());
            var container = builder.Build();
            return container;
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