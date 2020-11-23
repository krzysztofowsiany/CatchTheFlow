using System;

namespace Sound.Application.Events
{
    public class ShortBreakStarted
    {
        public short BreakTime { get; }
        public DateTime StartTime { get; }
        public ShortBreakStarted(short breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }
    }
}