using System;
using System.Reflection;
using Autofac;
using EventBus;
using Sound;

namespace Sandbox
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = RegisterContainer();

            var eventBus = container.Resolve<IEventBus>();
            
            var workStopped = new WorkStopped("test");
            eventBus.PushEvent(workStopped);     
            
            Console.ReadKey();
        }

        private static IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventBus.EventBus>()
                .As<IEventBus>()
                .SingleInstance();
            
            builder.RegisterModule(new SoundModule(Assembly.GetExecutingAssembly()));
            var container = builder.Build();
            return container;
        }
    }
}