using System;
using System.Linq;
using EventBus;
using EventBus.View;
using PomodoroLongBreake.Application.Events;

namespace PomodoroLongBreake.Application.Views
{
    public class LongBreakeStartedInformationView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public ushort BreakeTime { get; private set; }

        public LongBreakeStartedInformationView(ushort breakeTime, DateTime startTime) :base(null)
        {
            StartTime = startTime;
            BreakeTime = breakeTime;
        }
        
        public LongBreakeStartedInformationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakeStarted>()
                .FirstOrDefault();

            BreakeTime = @event.BreakeTime;
            StartTime = @event.StartTime;
        }
    }
}