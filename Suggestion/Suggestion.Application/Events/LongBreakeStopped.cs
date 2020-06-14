using System;

namespace Suggestion.Application.Events
{
    public class LongBreakeStopped
    {
        public ushort BreakeTime { get; }
        public DateTime StopTime { get; }

        public LongBreakeStopped(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}