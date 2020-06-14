using System;

namespace PomodoroWork.Application.Events
{
    public class WorkStarted
    {
        public ushort WorkTime { get; }
        public DateTime StartTime { get; }

        public WorkStarted(ushort workTime, DateTime startTime)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }
    }
}