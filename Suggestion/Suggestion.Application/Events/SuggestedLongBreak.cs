using System;

namespace Suggestion.Application.Events
{
    public class SuggestedLongBreak
    {
        public ushort BreakTime { get; }
        public DateTime StopTime { get; }

        public SuggestedLongBreak(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}