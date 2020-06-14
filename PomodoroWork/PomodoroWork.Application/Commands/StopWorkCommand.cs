using System;
using CQRSLib;

namespace PomodoroWork.Application.Commands
{
    public class StopWorkCommand: ICommand
    {
        public StopWorkCommand(ushort workTime, DateTime stopTime)
        {
            WorkTime = workTime;
            StopTime = stopTime;
        }

        public DateTime StopTime { get;  }

        public ushort WorkTime { get;  }
    }
}