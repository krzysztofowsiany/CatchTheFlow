using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class ShortBreakeStoppedInformation :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }

        public ShortBreakeStoppedInformation(ushort workTime, DateTime stopTime) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
        
        public ShortBreakeStoppedInformation(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var shortBreakeStopped = GetEvents<ShortBreakeStopped>()
                .FirstOrDefault();

            var workTimeUpdated = GetEvents<WorkTimeUpdated>()
                .FirstOrDefault();
            
            if (shortBreakeStopped != null)
            {
                StopTime = shortBreakeStopped.StopTime;
            }
            
            if (shortBreakeStopped != null)
            {
                WorkTime = workTimeUpdated.WorkTime;
            }
        }
    }
}