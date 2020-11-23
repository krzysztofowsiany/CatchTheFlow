using CQRSLib;

namespace Configuration.Application.Commands
{
    public class SaveTimeSettingsCommand: ICommand
    {
        public SaveTimeSettingsCommand(ushort workTime, ushort shortBreakTime, ushort longBreakTime)
        {
            WorkTime = workTime;
            ShortBreakTime = shortBreakTime;
            LongBreakTime = longBreakTime;
        }

        public ushort WorkTime { get;  }
        public ushort ShortBreakTime { get;  }
        public ushort LongBreakTime { get;  }
    }
}