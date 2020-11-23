using System;

namespace PomodoroStatus.Tests.Events
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