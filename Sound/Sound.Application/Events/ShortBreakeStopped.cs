using System;

namespace Sound.Application.Events
{
    public class ShortBreakeStopped
    {
        public short BreakeTime { get; }
        public DateTime StopTime { get; }
        public ShortBreakeStopped(short breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}