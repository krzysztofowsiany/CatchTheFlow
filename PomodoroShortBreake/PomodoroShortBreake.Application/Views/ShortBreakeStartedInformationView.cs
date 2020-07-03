using System;
using System.Linq;
using EventBus;
using EventBus.View;
using PomodoroShortBreake.Application.Events;

namespace PomodoroShortBreake.Application.Views
{
    public class ShortBreakeStartedInformationView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public ushort BreakeTime { get; private set; }

        public ShortBreakeStartedInformationView(ushort breakeTime, DateTime startTime) :base(null)
        {
            StartTime = startTime;
            BreakeTime = breakeTime;
        }
        
        public ShortBreakeStartedInformationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakeStarted>()
                .FirstOrDefault();

            BreakeTime = @event.BreakeTime;
            StartTime = @event.StartTime;
        }
    }
}