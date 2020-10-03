using System;

namespace ShortBreakView.Application.Events
{
    public class ShortBreakeStarted
    {
        public ushort BreakeTime { get; }
        public DateTime StartTime { get; }

        public ShortBreakeStarted(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }
    }
}