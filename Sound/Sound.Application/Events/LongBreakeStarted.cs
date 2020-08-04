using System;

namespace Sound.Application.Events
{
    public class LongBreakeStarted
    {
        public short BreakeTime { get; }
        public DateTime StartTime { get; }
        public LongBreakeStarted(short breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }
    }
}