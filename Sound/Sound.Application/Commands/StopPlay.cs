using System;
using CQRSLib;

namespace Sound.Application.Commands
{
    public class StopPlay : ICommand
    {
        public DateTime Timestamp { get; set; }
    }
}