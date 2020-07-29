using System;

namespace Suggestion.Application.Events
{
    public class SuggestedLongBreake
    {
        public ushort BreakeTime { get; }
        public DateTime StopTime { get; }

        public SuggestedLongBreake(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }
    }
}