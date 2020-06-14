using System;
using System.Threading;
using Autofac;
using EventBus;
using EventBus.Extensions;
using EventBus.View;
using FluentAssertions;

namespace GWTTestBase
{
    public class ViewTest<TModule>
        where TModule: Module, new()
    {
        private readonly IEventRepository _eventRepository;
        private readonly IoT _iot;

        protected ViewTest()
        {
            _iot = new IoT();
            _iot.RegisterContainer<TModule>();
            _eventRepository =  _iot.Container.Resolve<IEventRepository>();
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
            var @event = new Event(
                given.Serialize(), 
                given.GetType().Name,
                DateTime.UtcNow);
            _eventRepository.Add(@event);
            Thread.Sleep(1);
        }
    }
}