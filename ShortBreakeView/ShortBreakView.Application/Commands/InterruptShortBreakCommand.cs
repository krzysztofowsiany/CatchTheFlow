using System;
using CQRSLib;

namespace ShortBreakView.Application.Commands
{
    public class InterruptShortBreakCommand: ICommand
    {
        public InterruptShortBreakCommand(ushort workTime, DateTime stopTime)
        {
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}