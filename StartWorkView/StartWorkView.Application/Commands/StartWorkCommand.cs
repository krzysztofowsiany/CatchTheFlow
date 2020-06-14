using System;
using CQRSLib;

namespace StartWorkView.Application.Commands
{
    public class StartWorkCommand: ICommand
    {
        public StartWorkCommand(ushort workTime, DateTime stopTime)
        {
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}