using System;

namespace PomodoroStatus.Tests.Events
{
    public class WorkInterrupted
    {
        public ushort WorkTime { get; }
        public DateTime StartTime { get; }

        public WorkInterrupted(ushort workTime, DateTime startTime)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }
    }
}