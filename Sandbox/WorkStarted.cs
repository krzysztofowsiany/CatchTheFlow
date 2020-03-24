using System;

namespace Sandbox
{
    public class WorkStarted
    {
        public short WorkTime { get; }
        public DateTime StartTime { get; }
        public DateTime Timestamp { get; }

        public WorkStarted(short workTime, DateTime startTime, DateTime timestamp)
        {
            WorkTime = workTime;
            StartTime = startTime;
            Timestamp = timestamp;
        }
    }
}