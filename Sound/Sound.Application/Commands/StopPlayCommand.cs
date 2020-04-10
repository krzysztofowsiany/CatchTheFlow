using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StopPlayCommand : ICommand
    {
        public DateTime Timestamp { get; set; }

        public DateTime StopTime { get; set; }
    }
}