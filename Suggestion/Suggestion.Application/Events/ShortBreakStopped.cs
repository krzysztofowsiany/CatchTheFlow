using System;

namespace Suggestion.Application.Events
{
    public class LongBreakStopped
    {
        public ushort BreakTime { get; }
        public DateTime StopTime { get; }

        public LongBreakStopped(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}