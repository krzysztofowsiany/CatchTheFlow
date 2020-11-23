using System;
using System.Linq;
using EventBus;
using EventBus.View;
using PomodoroLongBreak.Application.Events;

namespace PomodoroLongBreak.Application.Views
{
    public class LongBreakStartedInformationView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public ushort BreakTime { get; private set; }

        public LongBreakStartedInformationView(ushort breakTime, DateTime startTime) :base(null)
        {
            StartTime = startTime;
            BreakTime = breakTime;
        }
        
        public LongBreakStartedInformationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakStarted>()
                .FirstOrDefault();

            BreakTime = @event.BreakTime;
            StartTime = @event.StartTime;
        }
    }
}