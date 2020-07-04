
using Autofac;
using CQRSLib;
using EventBus;
using PomodoroShortBreake.Infrastructure;
using PomodoroWork;
using Sound;
using StartShortBreakeView.UI;
using StartWorkView.UI;

namespace CatchTheFlow
{
    public static class IoT
    {
        private static IContainer _container;

        private static IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<QueryBus>()
                .As<IQueryBus>()
                .SingleInstance();
                
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
            builder.RegisterModule(new StartWorkViewModule());
            builder.RegisterModule(new StartShortBreakeViewModule());
            builder.RegisterModule(new PomodoroShortBreakeModule());

            _container = builder.Build();
            return _container;
        }

        public static IContainer Container 
            => _container ?? RegisterContainer();
    }
}