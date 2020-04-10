using System.Collections.Generic;
using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.Extensions;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundWorkInformationView :BaseView 
    {
        public string Sound { get; private set; }

        public SoundWorkInformationView(string sound): base(null)
        {
            Sound = sound;
        }
        
        public SoundWorkInformationView(IEventRepository eventRepository) : base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            GetSoundFromEvents(_eventRepository.Events);
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