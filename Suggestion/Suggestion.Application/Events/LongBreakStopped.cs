using System;

namespace Suggestion.Application.Events
{
    public class ShortBreakStopped
    {
        public ushort BreakTime { get; }
        public DateTime StopTime { get; }

        public ShortBreakStopped(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}