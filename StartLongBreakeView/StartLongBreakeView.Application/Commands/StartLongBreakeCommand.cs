using System;
using CQRSLib;

namespace StartLongBreakeView.Application.Commands
{
    public class StartLongBreakeCommand: ICommand
    {
        public StartLongBreakeCommand(ushort breakeTime, DateTime startTime)
        {
            BreakeTime = breakeTime;
            StartTime = startTime;
        }

        public DateTime StartTime { get;  }
        public ushort BreakeTime { get;  }
    }
}