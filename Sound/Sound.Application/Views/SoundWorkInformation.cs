using System;
using System.Collections.Generic;
using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.Extensions;


namespace Sound.Application.Views
{
    public class SoundWorkInformation
    {
        public DateTime Timestamp { get;  }

        public string Sound { get; private set; }

        public SoundWorkInformation(WorkStarted @event, IList<Event> events)
        {
            GetSoundFromEvents(events);
            
            Timestamp = @event.Timestamp;
        }

        private void GetSoundFromEvents(IList<Event> events)
        {
            var typeName = typeof(WorkSoundUpdated).Name;
            var @event = events
                .Where(e => e.Type == typeName)
                .Select(e => e.Data.Deserialize<WorkSoundUpdated>())
                .OrderByDescending(e => e.Timestamp)
                .FirstOrDefault();

            Sound = @event?.Sound;
        }
    }
}