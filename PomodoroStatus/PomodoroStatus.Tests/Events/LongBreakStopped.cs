using System;

namespace PomodoroStatus.Tests.Events
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