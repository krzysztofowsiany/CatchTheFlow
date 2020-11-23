using System;
using CQRSLib;

namespace PomodoroShortBreak.Application.Commands
{
    public class StopShortBreakCommand: ICommand
    {
        public StopShortBreakCommand(ushort breakTime, DateTime stopTime)
        {
            BreakTime = breakTime;
            StopTime = stopTime;
        }

        public DateTime StopTime { get;  }

        public ushort BreakTime { get;  }
    }
}