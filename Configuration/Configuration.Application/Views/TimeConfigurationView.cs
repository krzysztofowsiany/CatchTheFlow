using System.Linq;
using EventBus;
using EventBus.View;
using Configuration.Application.Events;

namespace Configuration.Application.Views
{
    public class TimeConfigurationView :BaseView
    {
        public ushort WorkTime { get; private set; } = 25;
        public ushort LongBreakeTime { get; private set; } = 15;
        public ushort ShortBreakeTime { get; private set; } = 5;

        public TimeConfigurationView(ushort workTime, ushort longBreakeTime, ushort shortBreakeTime) :base(null)
        {
            WorkTime = workTime;
            LongBreakeTime = longBreakeTime;
            ShortBreakeTime = shortBreakeTime;
        }
        
        public TimeConfigurationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakeTimeUpdate = GetEvents<LongBreakeTimeUpdated>().FirstOrDefault();
            var shortBreakeTimeUpdate = GetEvents<ShortBreakeTimeUpdated>().FirstOrDefault();
            var workTimeUpdate = GetEvents<WorkTimeUpdated>().FirstOrDefault();

            if (shortBreakeTimeUpdate != null) ShortBreakeTime = shortBreakeTimeUpdate.Time;
            if (longBreakeTimeUpdate != null) LongBreakeTime = longBreakeTimeUpdate.Time;
            if (workTimeUpdate != null) WorkTime = workTimeUpdate.WorkTime;
        }
    }
}