using System;
using CQRSLib;

namespace PomodoroShortBreake.Application.Commands
{
    public class StopShortBreakeCommand: ICommand
    {
        public StopShortBreakeCommand(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }

        public DateTime StopTime { get;  }

        public ushort BreakeTime { get;  }
    }
}