using System.Linq;
using EventBus;
using EventBus.View;
using Configuration.Application.Events;

namespace Configuration.Application.Views
{
    public class SoundConfigurationView :BaseView
    {
        public string WorkSound { get; private set; } = "work_1.mp3";
        public string LongBreakeSound { get; private set; } = "long_breake_1.mp3";
        public string ShortBreakeSound { get; private set; } = "short_breake_1.mp3";

        public SoundConfigurationView(string workSound, string longBreakeSound, string shortBreakeSound) :base(null)
        {
            WorkSound = workSound;
            LongBreakeSound = longBreakeSound;
            ShortBreakeSound = shortBreakeSound;
        }
        
        public SoundConfigurationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakeSoundUpdate = GetEvents<LongBreakeSoundUpdated>().FirstOrDefault();
            var shortBreakeSoundUpdate = GetEvents<ShortBreakeSoundUpdated>().FirstOrDefault();
            var workSoundUpdate = GetEvents<WorkSoundUpdated>().FirstOrDefault();

            if (longBreakeSoundUpdate != null) LongBreakeSound = longBreakeSoundUpdate.Sound;
            if (shortBreakeSoundUpdate != null) ShortBreakeSound = shortBreakeSoundUpdate.Sound;
            if (workSoundUpdate != null) WorkSound = workSoundUpdate.Sound;
        }
    }
}