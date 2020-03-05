using System;

namespace Sound.Infrastructure.Events
{
    public class WorkStopped
    {
        public ushort WorkTime { get; }
        public DateTime StopTime { get; }
        
        public DateTime Timestamp { get; }
        public WorkStopped(ushort workTime, DateTime stopTime, DateTime timestamp)
        {
            WorkTime = workTime;
            StopTime = stopTime;
            Timestamp = timestamp;
        }
    }
}