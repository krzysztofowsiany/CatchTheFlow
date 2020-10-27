using System;

namespace PomodoroStatus.Tests.Events
{
    public class LongBreakInterrupted
    {
        public ushort WorkTime { get; }
        public DateTime StartTime { get; }

        public LongBreakInterrupted(ushort workTime, DateTime startTime)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }
    }
}