using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundShortBreakInformationView :BaseView 
    {
        public string Sound { get; private set; } = "short_break_1.mp3";

        public SoundShortBreakInformationView(string sound): base(null)
        {
            Sound = sound;
        }
        
        public SoundShortBreakInformationView(IEventRepository eventRepository) : base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<ShortBreakSoundUpdated>()
                .FirstOrDefault();

            if (@event != null)
                Sound = @event.Sound;
        }
    }
}