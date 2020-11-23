using System;

namespace PomodoroShortBreak.Application.Events
{
    public class ShortBreakStarted
    {
        public ushort BreakTime { get; }
        public DateTime StartTime { get; }

        public ShortBreakStarted(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }
    }
}