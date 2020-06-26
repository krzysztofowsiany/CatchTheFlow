using System.Linq;
using EventBus;
using EventBus.View;
using StartShortBreakeView.Application.Events;

namespace StartShortBreakeView.Application.Views
{
    public class ShortBreakeTimeView :BaseView
    {
        public ushort BreakeTime { get; private set; }

        public ShortBreakeTimeView(ushort breakeTime) :base(null)
        {
            BreakeTime = breakeTime;
        }
        
        public ShortBreakeTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakeTimeUpdated>()
                .FirstOrDefault();

            BreakeTime = @event.Time;
        }
    }
}