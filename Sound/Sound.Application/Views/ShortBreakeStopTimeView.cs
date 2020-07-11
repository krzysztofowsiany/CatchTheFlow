using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class ShortBreakeStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public ShortBreakeStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public ShortBreakeStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakeStopped>()
                    .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}