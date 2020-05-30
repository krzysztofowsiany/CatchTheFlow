using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class TimeOfEndWorkView :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }
        public ushort Count { get; private set; }

        public TimeOfEndWorkView(ushort workTime, DateTime stopTime, ushort count) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
            Count = count;
        }
        
        public TimeOfEndWorkView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var workStarted = GetEvents<WorkStarted>()
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();
            
            var workStopped = GetEvents<WorkStopped>()
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();

            var eventNames = GetNamesOfEvents();

            WorkTime = workStarted.WorkTime;
            StopTime = workStopped.StopTime;
            Count = 0;
        }
    }
}