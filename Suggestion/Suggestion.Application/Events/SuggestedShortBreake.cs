using System;

namespace Suggestion.Application.Events
{
    public class SuggestedShortBreake
    {
        public ushort BreakeTime { get; }
        public DateTime StopTime { get; }

        public SuggestedShortBreake(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}