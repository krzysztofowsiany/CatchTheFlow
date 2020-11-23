using System;
using CQRSLib;

namespace PomodoroLongBreak.Application.Commands
{
    public class StopLongBreakCommand: ICommand
    {
        public StopLongBreakCommand(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }

        public DateTime StopTime { get;  }

        public ushort BreakTime { get;  }
    }
}