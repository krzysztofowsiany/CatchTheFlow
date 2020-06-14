using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class WorkStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public WorkStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public WorkStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<WorkStopped>()
                    .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}