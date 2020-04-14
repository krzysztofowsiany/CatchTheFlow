using System;
using System.Collections.Generic;
using System.Linq;
using EventBus;
using EventBus.Extensions;
using EventBus.View;
using PomodoroWork.Application.Events;

namespace PomodoroWork.Application.Views
{
    public class StartWorkTimeView :BaseView
    {
        public DateTime StartTime { get; private set; }
        public short WorkTime { get; private set; }

        public StartWorkTimeView(short workTime, DateTime startTime) :base(null)
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
            GetStartTimeFromEvents(_eventRepository.Events);
        }

        private void GetStartTimeFromEvents(IList<Event> events)
        {
            var @event = GetEvents<WorkStarted>()
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();

            StartTime = @event.StartTime;
            WorkTime = @event.WorkTime;
        }
    }
}