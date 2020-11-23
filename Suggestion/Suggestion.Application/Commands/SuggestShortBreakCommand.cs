using System;
using CQRSLib;

namespace Suggestion.Application.Commands
{
    public class SuggestShortBreakCommand: ICommand
    {
        public SuggestShortBreakCommand(ushort breakTime, DateTime stopTime)
        {
            StopTime = stopTime;
            BreakTime = breakTime;
        }

        public DateTime StopTime { get;  }
        public ushort BreakTime { get;  }
    }
}