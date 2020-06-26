using System;
using CQRSLib;

namespace StartShortBreakeView.Application.Commands
{
    public class StartShortBreakeCommand: ICommand
    {
        public StartShortBreakeCommand(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakeTime { get;  }
    }
}