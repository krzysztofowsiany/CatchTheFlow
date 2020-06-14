using System.Linq;
using EventBus;
using Sound.Application.Events;
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
            var @event = GetEvents<WorkSoundUpdated>()
                .FirstOrDefault();

            Sound = @event?.Sound;
        }
    }
}