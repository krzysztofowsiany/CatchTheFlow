using System.Linq;
using EventBus;
using EventBus.View;
using Configuration.Application.Events;

namespace Configuration.Application.Views
{
    public class SoundConfigurationView :BaseView
    {
        public string WorkSound { get; private set; } = "work_1.mp3";
        public string LongBreakSound { get; private set; } = "long_break_1.mp3";
        public string ShortBreakSound { get; private set; } = "short_break_1.mp3";

        public SoundConfigurationView(string workSound, string longBreakSound, string shortBreakSound) :base(null)
        {
            WorkSound = workSound;
            LongBreakSound = longBreakSound;
            ShortBreakSound = shortBreakSound;
        }
        
        public SoundConfigurationView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var longBreakSoundUpdate = GetEvents<LongBreakSoundUpdated>().FirstOrDefault();
            var shortBreakSoundUpdate = GetEvents<ShortBreakSoundUpdated>().FirstOrDefault();
            var workSoundUpdate = GetEvents<WorkSoundUpdated>().FirstOrDefault();

            if (longBreakSoundUpdate != null) LongBreakSound = longBreakSoundUpdate.Sound;
            if (shortBreakSoundUpdate != null) ShortBreakSound = shortBreakSoundUpdate.Sound;
            if (workSoundUpdate != null) WorkSound = workSoundUpdate.Sound;
        }
    }
}