using System;

namespace StartLongBreakView.Application.Events
{
    public class LongBreakStarted
    {
        public LongBreakStarted(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakTime { get;  }
    }
}