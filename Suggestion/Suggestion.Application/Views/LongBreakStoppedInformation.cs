using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class LongBreakStoppedInformation :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }

        public LongBreakStoppedInformation(ushort workTime, DateTime stopTime) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
        
        public LongBreakStoppedInformation(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakStopped = GetEvents<LongBreakStopped>()
                .FirstOrDefault();

            var workTimeUpdated = GetEvents<WorkTimeUpdated>()
                .FirstOrDefault();
            
            if (longBreakStopped != null)
            {
                StopTime = longBreakStopped.StopTime;
            }
            
            if (longBreakStopped != null)
            {
                WorkTime = workTimeUpdated.WorkTime;
            }
        }
    }
}