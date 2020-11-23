using System;

namespace Sound.Application.Events
{
    public class LongBreakStarted
    {
        public short BreakTime { get; }
        public DateTime StartTime { get; }
        public LongBreakStarted(short breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }
    }
}