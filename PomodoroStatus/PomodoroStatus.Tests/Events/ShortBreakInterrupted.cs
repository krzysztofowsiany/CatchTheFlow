using System;

namespace PomodoroStatus.Tests.Events
{
    public class ShortBreakInterrupted
    {
        public ushort WorkTime { get; }
        public DateTime StartTime { get; }

        public ShortBreakInterrupted(ushort workTime, DateTime startTime)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }
    }
}