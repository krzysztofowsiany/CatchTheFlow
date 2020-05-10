using Autofac;
using CQRSLib;
using EventBus;

namespace GWTTestBase
{
    public static class IoT
    {
        public static IContainer Container;

        public static void RegisterContainer<TModule>()
            where TModule: Module, new()
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

            builder.RegisterModule<TModule>();
            
            Container = builder.Build();
        }
    }
}