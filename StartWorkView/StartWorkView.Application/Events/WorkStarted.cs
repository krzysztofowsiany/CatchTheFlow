using System;

namespace StartWorkView.Application.Events
{
    public class WorkStarted
    {
        public ushort WorkTime { get; }
        public DateTime StartTime { get; }
        public DateTime Timestamp { get; }

        public WorkStarted(ushort workTime, DateTime startTime, DateTime timestamp)
        {
            WorkTime = workTime;
            StartTime = startTime;
            Timestamp = timestamp;
        }
    }
}