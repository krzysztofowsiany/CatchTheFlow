using System;
using System.Threading;
using Autofac;
using EventBus;

namespace Sandbox
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var eventBus = IoT.Container.Resolve<IEventBus>();

            eventBus.PushEvent(new WorkSoundUpdated("work_1.mp3", DateTime.Now));  
            var workStarted = new WorkStarted(23, DateTime.Now, DateTime.Now);
            eventBus.PushEvent(workStarted);  
            
            Thread.Sleep(5000);
            
            eventBus.PushEvent(new WorkSoundUpdated("work_2.mp3", DateTime.Now));  
            eventBus.PushEvent(workStarted); 
            Thread.Sleep(5000);
            
            var workStopped = new WorkStopped(23, DateTime.Now, DateTime.Now);
            eventBus.PushEvent(workStopped);
            
            Console.ReadKey();
        }
    }
}