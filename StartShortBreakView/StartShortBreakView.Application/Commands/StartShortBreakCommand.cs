using System;
using CQRSLib;

namespace StartLongBreakView.Application.Commands
{
    public class StartShortBreakCommand: ICommand
    {
        public StartShortBreakCommand(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakTime { get;  }
    }
}