using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class LongBreakeStoppedInformation :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }

        public LongBreakeStoppedInformation(ushort workTime, DateTime stopTime) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
        
        public LongBreakeStoppedInformation(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakeStopped = GetEvents<LongBreakeStopped>()
                .FirstOrDefault();

            var workTimeUpdated = GetEvents<WorkTimeUpdated>()
                .FirstOrDefault();
            
            if (longBreakeStopped != null)
            {
                StopTime = longBreakeStopped.StopTime;
            }
            
            if (longBreakeStopped != null)
            {
                WorkTime = workTimeUpdated.WorkTime;
            }
        }
    }
}