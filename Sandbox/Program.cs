using System;
using System.Threading;
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

            var workStarted = new WorkStarted(23, DateTime.Now, DateTime.Now);
            eventBus.PushEvent(workStarted);  
            
            Thread.Sleep(5000);
            
            eventBus.PushEvent(workStarted); 
            Thread.Sleep(5000);
            
            var workStopped = new WorkStopped(23, DateTime.Now, DateTime.Now);
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