using System.Linq;
using EventBus;
using EventBus.View;
using StartLongBreakView.Application.Events;

namespace StartLongBreakView.Application.Views
{
    public class LongBreakTimeView :BaseView
    {
        public ushort BreakTime { get; private set; } = 15;

        public LongBreakTimeView(ushort breakTime) :base(null)
        {
            BreakTime = breakTime;
        }
        
        public LongBreakTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakTimeUpdated>()
                .FirstOrDefault();

            if (@event != null)
                BreakTime = @event.Time;
        }
    }
}