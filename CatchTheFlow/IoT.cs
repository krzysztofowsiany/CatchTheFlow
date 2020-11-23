
using Autofac;
using Configuration.UI;
using CQRSLib;
using EventBus;
using LongBreakView.UI;
using PomodoroShortBreak.Infrastructure;
using PomodoroLongBreak.Infrastructure;
using PomodoroStatus.Infrastructure;
using PomodoroWork;
using ShortBreakView.UI;
using Sound;
using StartLongBreakView.UI;
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
            builder.RegisterModule(new StartShortBreakViewModule());
            builder.RegisterModule(new PomodoroShortBreakModule());
            builder.RegisterModule(new PomodoroLongBreakModule());
            builder.RegisterModule(new SuggestionModule());
            builder.RegisterModule(new StartLongBreakViewModule());
            builder.RegisterModule(new SettingsModule());
            builder.RegisterModule(new WorkViewModule());
            builder.RegisterModule(new ShortBreakViewModule());
            builder.RegisterModule(new LongBreakViewModule());
            builder.RegisterModule(new PomodoroStatusModule());

            builder.RegisterType<CatchTheFlowEventListener>()
                .AutoActivate();
            
            _container = builder.Build();
            return _container;
        }

        public static IContainer Container 
            => _container ?? RegisterContainer();
    }
}