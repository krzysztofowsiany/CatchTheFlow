using System;
using CQRSLib;

namespace Suggestion.Application.Commands
{
    public class SuggestWorkCommand: ICommand
    {
        public SuggestWorkCommand(ushort workTime, DateTime stopTime)
        {
            StopTime = stopTime;
            WorkTime = workTime;
        }

        public DateTime StopTime { get;  }
        public ushort WorkTime { get;  }
    }
}