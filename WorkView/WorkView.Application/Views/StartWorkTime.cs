using System;
using System.Linq;
using EventBus;
using EventBus.View;
using WorkView.Application.Events;

namespace WorkView.Application.Views
{
    public class StartWorkTime :BaseView
    {
        public ushort WorkTime { get; private set; }
        public DateTime StartTime { get; private set; }


        public StartWorkTime(ushort workTime, DateTime startTime) :base(null)
        {
            WorkTime = workTime;
            StartTime = startTime;
        }

        public StartWorkTime(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<WorkStarted>()
                .FirstOrDefault();

            if (@event == null)
                return;
            
            WorkTime = @event.WorkTime;
            StartTime = @event.StartTime;
        }
    }
}