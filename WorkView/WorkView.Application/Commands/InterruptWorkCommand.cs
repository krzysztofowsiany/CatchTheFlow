using System;
using CQRSLib;

namespace WorkView.Application.Commands
{
    public class InterruptWorkCommand: ICommand
    {
        public InterruptWorkCommand(ushort workTime, DateTime stopTime)
        {
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}