using CQRSLib;

namespace Configuration.Application.Commands
{
    public class SaveSoundSettingsCommand: ICommand
    {
        public SaveSoundSettingsCommand(string workSound, string shortBreakeSound, string longBreakeSound)
        {
            WorkSound = workSound;
            ShortBreakeSound = shortBreakeSound;
            LongBreakeSound = longBreakeSound;
        }

        public string WorkSound { get;  }
        public string ShortBreakeSound { get;  }
        public string LongBreakeSound { get;  }
    }
}