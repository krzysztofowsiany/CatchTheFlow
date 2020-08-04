using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class LongBreakeStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public LongBreakeStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public LongBreakeStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakeStopped>()
                    .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}