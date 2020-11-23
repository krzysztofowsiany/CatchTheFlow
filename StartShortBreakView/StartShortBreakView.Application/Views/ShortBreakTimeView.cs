using System.Linq;
using EventBus;
using EventBus.View;
using StartLongBreakView.Application.Events;

namespace StartLongBreakView.Application.Views
{
    public class ShortBreakTimeView :BaseView
    {
        public ushort BreakTime { get; private set; } = 5;

        public ShortBreakTimeView(ushort breakTime) :base(null)
        {
            BreakTime = breakTime;
        }
        
        public ShortBreakTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakTimeUpdated>()
                .FirstOrDefault();

            if (@event != null)
                BreakTime = @event.Time;
        }
    }
}