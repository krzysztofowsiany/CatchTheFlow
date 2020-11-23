using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class LongBreakStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public LongBreakStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public LongBreakStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakStopped>()
                    .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}