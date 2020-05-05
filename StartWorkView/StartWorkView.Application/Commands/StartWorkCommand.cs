using System;
using CQRSLib;

namespace StartWorkView.Application.Commands
{
    public class StartWorkCommand: ICommand
    {
        public DateTime Timestamp { get; set; }
        public DateTime StopTime { get; set; }

        public ushort WorkTime { get; set; }
    }
}