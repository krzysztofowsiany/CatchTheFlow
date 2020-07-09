using System;

namespace Sound.Application.Events
{
    public class ShortBreakeStarted
    {
        public short BreakeTime { get; }
        public DateTime StartTime { get; }
        public ShortBreakeStarted(short breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }
    }
}