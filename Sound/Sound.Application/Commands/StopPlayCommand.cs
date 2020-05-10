using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StopPlayCommand : ICommand
    {
        public StopPlayCommand(DateTime stopTime, DateTime timestamp)
        {
            StopTime = stopTime;
            Timestamp = timestamp;
        }

        public DateTime Timestamp { get;  }

        public DateTime StopTime { get;  }
    }
}