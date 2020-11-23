using System;
using System.Linq;
using EventBus;
using EventBus.View;
using LongBreakView.Application.Events;

namespace LongBreakView.Application.Views
{
    public class StartLongBreakTimeView :BaseView
    {
        public ushort BreakTime { get; private set; }
        public DateTime StartTime { get; private set; }


        public StartLongBreakTimeView(ushort breakTime, DateTime startTime) :base(null)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public StartLongBreakTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakStarted>()
                .FirstOrDefault();

            if (@event == null)
                return;
            
            BreakTime = @event.BreakTime;
            StartTime = @event.StartTime;
        }
    }
}