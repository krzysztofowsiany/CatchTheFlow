using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StartPlayCommand: ICommand
    {
        public DateTime Timestamp { get; set; }
        public string Sound { get; set; }
    }
}