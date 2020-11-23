using System;
using System.Linq;
using EventBus;
using EventBus.View;
using PomodoroShortBreak.Application.Events;

namespace PomodoroShortBreak.Application.Views
{
    public class ShortBreakStartedInformationView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public ushort BreakTime { get; private set; }

        public ShortBreakStartedInformationView(ushort breakTime, DateTime startTime) :base(null)
        {
            StartTime = startTime;
            BreakTime = breakTime;
        }
        
        public ShortBreakStartedInformationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakStarted>()
                .FirstOrDefault();

            BreakTime = @event.BreakTime;
            StartTime = @event.StartTime;
        }
    }
}