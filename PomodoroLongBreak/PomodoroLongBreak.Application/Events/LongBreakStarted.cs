using System;

namespace PomodoroLongBreak.Application.Events
{
    public class LongBreakStarted
    {
        public ushort BreakTime { get; }
        public DateTime StartTime { get; }

        public LongBreakStarted(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }
    }
}