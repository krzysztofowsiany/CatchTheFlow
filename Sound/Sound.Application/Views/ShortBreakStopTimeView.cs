using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class ShortBreakStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public ShortBreakStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public ShortBreakStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakStopped>()
                    .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}