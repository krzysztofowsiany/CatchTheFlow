using System;
using CQRSLib;

namespace LongBreakView.Application.Commands
{
    public class InterruptLongBreakCommand: ICommand
    {
        public InterruptLongBreakCommand(ushort workTime, DateTime stopTime)
        {
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}