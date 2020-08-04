using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundLongBreakeInformationView :BaseView 
    {
        public string Sound { get; private set; }

        public SoundLongBreakeInformationView(string sound): base(null)
        {
            Sound = sound;
        }
        
        public SoundLongBreakeInformationView(IEventRepository eventRepository) : base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakeSoundUpdated>()
                .FirstOrDefault();

            Sound = @event?.Sound;
        }
    }
}