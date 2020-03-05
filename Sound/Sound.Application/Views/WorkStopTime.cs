using System;

namespace Sound.Application.Views
{
    public class WorkStopTime
    {
        public DateTime StopTime { get; }
        
        public WorkStopTime(DateTime stopTime)
        {
            StopTime = stopTime;
        }
    }
}