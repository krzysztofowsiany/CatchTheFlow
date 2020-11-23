using System;

namespace PomodoroLongBreak.Application.Events
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