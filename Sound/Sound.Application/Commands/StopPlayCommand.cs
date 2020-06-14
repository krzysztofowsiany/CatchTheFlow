using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StopPlayCommand : ICommand
    {
        public DateTime StopTime { get;  }
        
        public StopPlayCommand(DateTime stopTime)
        {
            StopTime = stopTime;
        }
    }
}