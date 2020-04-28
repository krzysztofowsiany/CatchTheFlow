using Autofac;
using CQRSLib;
using EventBus;
using PomodoroWork;
using Sound;

namespace Sandbox
{
    public static class IoT
    {
        private static IContainer _container;

        private static IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventBus.EventBus>()
                .As<IEventBus>()
                .SingleInstance();
            
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .SingleInstance();
            
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .SingleInstance();
            
            builder.RegisterModule(new SoundModule());
            builder.RegisterModule(new PomodoroWorkModule());

            _container = builder.Build();
            return _container;
        }

        public static IContainer Container 
            => _container ?? RegisterContainer();
    }
}