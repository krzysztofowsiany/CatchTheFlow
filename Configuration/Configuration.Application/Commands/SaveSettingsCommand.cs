using CQRSLib;

namespace Configuration.Application.Commands
{
    public class SaveSettingsCommand: ICommand
    {
        public SaveSettingsCommand(ushort workTime, ushort shortBreakeTime, ushort longBreakeTime)
        {
            WorkTime = workTime;
            ShortBreakeTime = shortBreakeTime;
            LongBreakeTime = longBreakeTime;
        }

        public ushort WorkTime { get;  }
        public ushort ShortBreakeTime { get;  }
        public ushort LongBreakeTime { get;  }
    }
}