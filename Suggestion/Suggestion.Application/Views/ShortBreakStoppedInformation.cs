using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class ShortBreakStoppedInformation :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }

        public ShortBreakStoppedInformation(ushort workTime, DateTime stopTime) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }
        
        public ShortBreakStoppedInformation(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var shortBreakStopped = GetEvents<ShortBreakStopped>()
                .FirstOrDefault();

            var workTimeUpdated = GetEvents<WorkTimeUpdated>()
                .FirstOrDefault();
            
            if (shortBreakStopped != null)
            {
                StopTime = shortBreakStopped.StopTime;
            }
            
            if (shortBreakStopped != null)
            {
                WorkTime = workTimeUpdated.WorkTime;
            }
        }
    }
}