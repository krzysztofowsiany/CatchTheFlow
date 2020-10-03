
using Autofac;
using Configuration.UI;
using CQRSLib;
using EventBus;
using PomodoroShortBreake.Infrastructure;
using PomodoroLongBreake.Infrastructure;
using PomodoroWork;
using ShortBreakView.UI;
using Sound;
using StartLongBreakeView.UI;
using StartWorkView.UI;
using Suggestion.Infrastructure;
using WorkView.UI;

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
            
            builder.RegisterType<LiteDBEventRepository>()
                .As<IEventRepository>()
                .SingleInstance();
            
            builder.RegisterModule(new SoundModule());
            builder.RegisterModule(new PomodoroWorkModule());
            builder.RegisterModule(new StartWorkViewModule());
            builder.RegisterModule(new StartShortBreakeViewModule());
            builder.RegisterModule(new PomodoroShortBreakeModule());
            builder.RegisterModule(new PomodoroLongBreakeModule());
            builder.RegisterModule(new SuggestionModule());
            builder.RegisterModule(new StartLongBreakeViewModule());
            builder.RegisterModule(new SettingsModule());
            builder.RegisterModule(new WorkViewModule());
            builder.RegisterModule(new ShortBreakViewModule());

            builder.RegisterType<CatchTheFlowEventListener>()
                .AutoActivate();
            
            _container = builder.Build();
            return _container;
        }

        public static IContainer Container 
            => _container ?? RegisterContainer();
    }
}