using Autofac;

namespace CQRSLib
{
    public class CommandBus : ICommandBus
    {
        private ILifetimeScope _container;

        public CommandBus(ILifetimeScope container)
        {
            _container = container;
        }
        
        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _container.ResolveOptional<ICommandHandler<TCommand>>();

            commandHandler?.Handle(command);
        }
    }
}