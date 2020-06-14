using Autofac;
using CQRSLib;
using EventBus;
using FluentAssertions;

namespace GWTTestBase
{
    public class CommandTest<TModule, TCommand>
        where TModule: Module, new()
        where TCommand: ICommand
    {
        private readonly IEventBus _eventBus;
        private object _event;
        private readonly ICommandBus _commandBus;
        private TCommand _command;
        private readonly IoT _iot;

        protected CommandTest()
        {
            _iot = new IoT();
            _iot.RegisterContainer<TModule>();
            
            _eventBus = _iot.Container.Resolve<IEventBus>();
            _commandBus = _iot.Container.Resolve<ICommandBus>();
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
            
            _commandBus.Send(_command);

            _event.Should().NotBeNull();
            _event.Should().BeEquivalentTo(@event, options => 
                options.Using(new IgnoreEmptyObjectStep()));
        }
        
        protected void When(TCommand command) =>
            _command = command;
    }
}