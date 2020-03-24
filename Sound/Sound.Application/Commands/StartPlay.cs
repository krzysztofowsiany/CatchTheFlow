using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StartPlay: ICommand
    {
        public DateTime Timestamp { get; set; }
        public string Sound { get; set; }
        
    }
}