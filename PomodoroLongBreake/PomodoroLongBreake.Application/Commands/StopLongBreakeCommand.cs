using System;
using CQRSLib;

namespace PomodoroLongBreake.Application.Commands
{
    public class StopLongBreakeCommand: ICommand
    {
        public StopLongBreakeCommand(ushort breakeTime, DateTime stopTime)
        {
            BreakeTime = breakeTime;
            StopTime = stopTime;
        }

        public DateTime StopTime { get;  }

        public ushort BreakeTime { get;  }
    }
}