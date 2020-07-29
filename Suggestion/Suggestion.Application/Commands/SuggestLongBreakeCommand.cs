using System;
using CQRSLib;

namespace Suggestion.Application.Commands
{
    public class SuggestLongBreakeCommand: ICommand
    {
        public SuggestLongBreakeCommand(ushort breakeTime, DateTime stopTime)
        {
            StopTime = stopTime;
            BreakeTime = breakeTime;
        }

        public DateTime StopTime { get;  }
        public ushort BreakeTime { get;  }
    }
}