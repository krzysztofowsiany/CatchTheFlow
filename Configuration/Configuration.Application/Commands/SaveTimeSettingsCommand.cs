using CQRSLib;

namespace Configuration.Application.Commands
{
    public class SaveTimeSettingsCommand: ICommand
    {
        public SaveTimeSettingsCommand(ushort workTime, ushort shortBreakeTime, ushort longBreakeTime)
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