using System;
using Autofac;
using EventBus;
using EventBus.Extensions;
using EventBus.View;
using FluentAssertions;

namespace GWTTestBase
{
    public class ViewTest
    {
        private readonly IEventRepository _eventRepository;

        protected ViewTest()
        {
            _eventRepository = IoT.Container.Resolve<IEventRepository>();
        }
        
        protected void Then<TView>(TView view) where TView: BaseView
        {
            var expectedView =
                (TView)Activator.CreateInstance(typeof(TView), _eventRepository);

            expectedView.RestoreState();
            
            expectedView.Should().BeEquivalentTo(view);
        }
       

        protected void Give<TEvent>(TEvent given) where TEvent: class
        {
            var @event = new Event(given.Serialize(), given.GetType().Name);
            _eventRepository.Add(@event);
        }
    }
}