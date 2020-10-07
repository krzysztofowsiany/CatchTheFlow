using System;

namespace LongBreakView.Application.Events
{
    public class LongBreakeStarted
    {
        public ushort BreakeTime { get; }
        public DateTime StartTime { get; }

        public LongBreakeStarted(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }
    }
}