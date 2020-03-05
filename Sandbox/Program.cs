using System;
using System.Reflection;
using Autofac;
using Sound;
using Sound.Infrastructure;

namespace Sandbox
{
    static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SoundModule(Assembly.GetExecutingAssembly()));
            
            var eventBus = new EventBus.EventBus();
            var sound = new EventListener(eventBus);
            var workStopped = new WorkStopped("test");
            eventBus.PushEvent(workStopped);     
            
            Console.ReadKey();
        }
    }
}