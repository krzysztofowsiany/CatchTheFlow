using System.Linq;
using EventBus;
using EventBus.View;
using StartWorkView.Application.Events;

namespace StartWorkView.Application.Views
{
    public class UserWorkTime :BaseView
    {
        public ushort WorkTime { get; private set; }

        public UserWorkTime(ushort workTime) :base(null)
        {
            WorkTime = workTime;
        }
        
        public UserWorkTime(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<WorkTimeUpdated>()
                .FirstOrDefault();

            WorkTime = @event.WorkTime;
        }
    }
}