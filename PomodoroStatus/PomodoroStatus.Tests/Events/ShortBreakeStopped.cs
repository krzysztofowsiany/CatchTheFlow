using System;

namespace PomodoroStatus.Tests.Events
{
    public class ShortBreakeStopped
    {
        public ushort BreakeTime { get; }
        public DateTime StopTime { get; }

        public ShortBreakeStopped(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}