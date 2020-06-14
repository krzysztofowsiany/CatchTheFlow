using System;

namespace Sound.Application.Events
{
    public class WorkStopped
    {
        public ushort WorkTime { get; }
        public DateTime StopTime { get; }
        
        public WorkStopped(ushort workTime, DateTime stopTime)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
    }
}