using System;
using System.Reflection;
using Autofac;
using CQRSLib;
using EventBus;
using Sound;

namespace Sandbox
{
    internal class Program
    {
        public static void Main(string[] args)
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
            
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .SingleInstance();
            
            builder.RegisterModule(new SoundModule());
            var container = builder.Build();
            return container;
        }
    }
}