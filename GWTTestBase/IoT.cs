using Autofac;
using CQRSLib;
using EventBus;

namespace GWTTestBase
{
    public class IoT
    {
        public IContainer Container;

        public void RegisterContainer<TModule>()
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