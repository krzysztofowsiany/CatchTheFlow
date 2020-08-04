using System;

namespace Sound.Application.Events
{
    public class LongBreakeStopped
    {
        public short BreakeTime { get; }
        public DateTime StopTime { get; }
        public LongBreakeStopped(short breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}