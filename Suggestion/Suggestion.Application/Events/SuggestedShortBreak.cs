using System;

namespace Suggestion.Application.Events
{
    public class SuggestedShortBreak
    {
        public ushort BreakTime { get; }
        public DateTime StopTime { get; }

        public SuggestedShortBreak(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}