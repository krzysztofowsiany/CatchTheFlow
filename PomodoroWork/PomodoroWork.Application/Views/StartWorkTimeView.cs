using System;
using System.Linq;
using EventBus;
using EventBus.View;
using PomodoroWork.Application.Events;

namespace PomodoroWork.Application.Views
{
    public class StartWorkTimeView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public ushort WorkTime { get; private set; }

        public StartWorkTimeView(ushort workTime, DateTime startTime) :base(null)
        {
            StartTime = startTime;
            WorkTime = workTime;
        }
        
        public StartWorkTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<WorkStarted>()
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();

            StartTime = @event.StartTime;
            WorkTime = @event.WorkTime;
        }
    }
}