using System;
using Sound.Infrastructure;

namespace Sandbox
{
    static class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus.EventBus();
            var sound = new EventListener(eventBus);
            var workStopped = new WorkStopped("test");
            eventBus.PushEvent(workStopped);     
            
            Console.ReadKey();
        }
    }
}