using System;

namespace Sound.Application.Events
{
    public class LongBreakStopped
    {
        public short BreakTime { get; }
        public DateTime StopTime { get; }
        public LongBreakStopped(short breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}