using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundShortBreakeInformationView :BaseView 
    {
        public string Sound { get; private set; }

        public SoundShortBreakeInformationView(string sound): base(null)
        {
            Sound = sound;
        }
        
        public SoundShortBreakeInformationView(IEventRepository eventRepository) : base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakeSoundUpdated>()
                .FirstOrDefault();

            Sound = @event?.Sound;
        }
    }
}