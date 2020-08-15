using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundShortBreakeInformationView :BaseView 
    {
        public string Sound { get; private set; } = "short_breake_1.mp3";

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

            if (@event != null)
                Sound = @event.Sound;
        }
    }
}