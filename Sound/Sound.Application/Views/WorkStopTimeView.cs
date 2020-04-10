using System;
using System.Collections.Generic;
using System.Linq;
using EventBus;
using EventBus.Extensions;
using EventBus.View;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class WorkStopTimeView :BaseView
    {
        public DateTime StopTime { get; private set; }

        public WorkStopTimeView(DateTime stopTime) :base(null)
        {
            StopTime = stopTime;
        }
        
        public WorkStopTimeView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            GetSoundFromEvents(_eventRepository.Events);
        }

        private void GetSoundFromEvents(IList<Event> events)
        {
            var typeName = typeof(WorkStopped).Name;
            var @event = events
                .Where(e => e.Type == typeName)
                .Select(e => e.Data.Deserialize<WorkStopped>())
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();

            StopTime = @event.StopTime;
        }
    }
}