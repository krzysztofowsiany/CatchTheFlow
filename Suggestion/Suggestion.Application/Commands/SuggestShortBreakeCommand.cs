using System;
using CQRSLib;

namespace Suggestion.Application.Commands
{
    public class SuggestShortBreakCommand: ICommand
    {
        public SuggestShortBreakCommand(ushort workTime, DateTime stopTime, DateTime timestamp)
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