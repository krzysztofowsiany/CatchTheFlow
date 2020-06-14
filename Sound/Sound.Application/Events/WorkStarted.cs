using System;

namespace Sound.Application.Events
{
    public class WorkStarted
    {
        public short WorkTime { get; }
        public DateTime StartTime { get; }
        public WorkStarted(short workTime, DateTime startTime)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }
    }
}