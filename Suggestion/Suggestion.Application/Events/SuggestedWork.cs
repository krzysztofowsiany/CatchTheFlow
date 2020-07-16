using System;

namespace Suggestion.Application.Events
{
    public class SuggestedWork
    {
        public ushort WorkTime { get; }
        public DateTime StopTime { get; }

        public SuggestedWork(ushort workTime, DateTime stopTime)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
    }
}