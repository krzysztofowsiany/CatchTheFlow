using System;
using CQRSLib;

namespace StartWorkView.Application.Commands
{
    public class StartWorkCommand: ICommand
    {
        public StartWorkCommand(ushort workTime, DateTime stopTime, DateTime timestamp)
        {
            Timestamp = timestamp;
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime Timestamp { get;  }
        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}