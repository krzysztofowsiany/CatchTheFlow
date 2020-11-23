using CQRSLib;

namespace Configuration.Application.Commands
{
    public class SaveSoundSettingsCommand: ICommand
    {
        public SaveSoundSettingsCommand(string workSound, string shortBreakSound, string longBreakSound)
        {
            WorkSound = workSound;
            ShortBreakSound = shortBreakSound;
            LongBreakSound = longBreakSound;
        }

        public string WorkSound { get;  }
        public string ShortBreakSound { get;  }
        public string LongBreakSound { get;  }
    }
}