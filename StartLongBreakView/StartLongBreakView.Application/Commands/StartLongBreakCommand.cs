using System;
using CQRSLib;

namespace StartLongBreakView.Application.Commands
{
    public class StartLongBreakCommand: ICommand
    {
        public StartLongBreakCommand(ushort breakTime, DateTime startTime)
        {
            BreakTime = breakTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakTime { get;  }
    }
}