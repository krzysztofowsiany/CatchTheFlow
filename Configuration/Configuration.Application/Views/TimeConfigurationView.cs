using System.Linq;
using EventBus;
using EventBus.View;
using Configuration.Application.Events;

namespace Configuration.Application.Views
{
    public class TimeConfigurationView :BaseView
    {
        public ushort WorkTime { get; private set; } = 25;
        public ushort LongBreakTime { get; private set; } = 15;
        public ushort ShortBreakTime { get; private set; } = 5;

        public TimeConfigurationView(ushort workTime, ushort longBreakTime, ushort shortBreakTime) :base(null)
        {
            WorkTime = workTime;
            LongBreakTime = longBreakTime;
            ShortBreakTime = shortBreakTime;
        }
        
        public TimeConfigurationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakTimeUpdate = GetEvents<LongBreakTimeUpdated>().FirstOrDefault();
            var shortBreakTimeUpdate = GetEvents<ShortBreakTimeUpdated>().FirstOrDefault();
            var workTimeUpdate = GetEvents<WorkTimeUpdated>().FirstOrDefault();

            if (shortBreakTimeUpdate != null) ShortBreakTime = shortBreakTimeUpdate.Time;
            if (longBreakTimeUpdate != null) LongBreakTime = longBreakTimeUpdate.Time;
            if (workTimeUpdate != null) WorkTime = workTimeUpdate.WorkTime;
        }
    }
}