using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StartPlayCommand: ICommand
    {
        public StartPlayCommand(string sound, DateTime timestamp)
        {
            Sound = sound;
            Timestamp = timestamp;
        }

        public DateTime Timestamp { get;  }
        public string Sound { get;  }
    }
}