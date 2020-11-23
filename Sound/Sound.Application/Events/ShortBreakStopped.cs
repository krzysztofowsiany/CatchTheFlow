using System;

namespace Sound.Application.Events
{
    public class ShortBreakStopped
    {
        public short BreakTime { get; }
        public DateTime StopTime { get; }
        public ShortBreakStopped(short breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }
    }
}