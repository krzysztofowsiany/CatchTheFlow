using System;
using System.Linq;
using EventBus;
using EventBus.View;
using ShortBreakView.Application.Events;

namespace ShortBreakView.Application.Views
{
    public class StartShortBreakTimeView :BaseView
    {
        public ushort BreakTime { get; private set; }
        public DateTime StartTime { get; private set; }


        public StartShortBreakTimeView(ushort breakTime, DateTime startTime) :base(null)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public StartShortBreakTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakStarted>()
                .FirstOrDefault();

            if (@event == null)
                return;
            
            BreakTime = @event.BreakTime;
            StartTime = @event.StartTime;
        }
    }
}