using System;

namespace PomodoroStatus.Tests.Events
{
    public class ShortBreakeTimeUpdated
    {
        public ushort Time { get; }

        public ShortBreakeTimeUpdated(ushort time)
        {
            Time = time;
        }
    }
}