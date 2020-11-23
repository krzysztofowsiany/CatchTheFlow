using System;

namespace PomodoroStatus.Tests.Events
{
    public class ShortBreakStarted
    {
        public ShortBreakStarted(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakTime { get;  }
    }
}