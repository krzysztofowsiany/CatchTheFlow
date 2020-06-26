using System;

namespace StartShortBreakeView.Application.Events
{
    public class ShortBreakeStarted
    {
        public ShortBreakeStarted(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakeTime { get;  }
    }
}