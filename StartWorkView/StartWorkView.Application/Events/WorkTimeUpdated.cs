using System;

namespace StartWorkView.Application.Events
{
    public class WorkTimeUpdated
    {
        public ushort WorkTime { get; }
        public DateTime Timestamp { get; }

        public WorkTimeUpdated(ushort workTime, DateTime timestamp)
        {
            WorkTime = workTime;
            Timestamp = timestamp;
        }
    }
}