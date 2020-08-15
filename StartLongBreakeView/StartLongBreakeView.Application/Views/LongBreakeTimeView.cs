using System.Linq;
using EventBus;
using EventBus.View;
using StartLongBreakeView.Application.Events;

namespace StartLongBreakeView.Application.Views
{
    public class LongBreakeTimeView :BaseView
    {
        public ushort BreakeTime { get; private set; } = 15;

        public LongBreakeTimeView(ushort breakeTime) :base(null)
        {
            BreakeTime = breakeTime;
        }
        
        public LongBreakeTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakeTimeUpdated>()
                .FirstOrDefault();

            if (@event != null)
                BreakeTime = @event.Time;
        }
    }
}