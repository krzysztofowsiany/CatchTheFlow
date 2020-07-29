using System;

namespace StartLongBreakeView.Application.Events
{
    public class LongBreakeStarted
    {
        public LongBreakeStarted(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakeTime { get;  }
    }
}