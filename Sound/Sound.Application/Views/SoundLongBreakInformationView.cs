using System.Linq;
using EventBus;
using Sound.Application.Events;
using EventBus.View;


namespace Sound.Application.Views
{
    public class SoundLongBreakInformationView :BaseView
    {
        public string Sound { get; private set; } = "long_break_1.mp3";
        
        public SoundLongBreakInformationView(string sound): base(null)
        {
            Sound = sound;
        }
        
        public SoundLongBreakInformationView(IEventRepository eventRepository) : base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var @event = GetEvents<LongBreakSoundUpdated>()
                .FirstOrDefault();

            if (@event != null)
                Sound = @event.Sound;
        }
    }
}