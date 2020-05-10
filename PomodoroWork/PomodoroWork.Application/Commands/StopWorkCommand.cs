using System;
using CQRSLib;

namespace PomodoroWork.Application.Commands
{
    public class StopWorkCommand: ICommand
    {
        public StopWorkCommand(ushort workTime, DateTime stopTime, DateTime timestamp)
        {
            WorkTime = workTime;
            StopTime = stopTime;
            Timestamp = timestamp;
        }

        public DateTime Timestamp { get;  }
        public DateTime StopTime { get;  }

        public ushort WorkTime { get;  }
    }
}