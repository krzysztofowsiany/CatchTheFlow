using System;
using CQRSLib;

namespace PomodoroWork.Application.Commands
{
    public class StopWorkCommand: ICommand
    {
        public DateTime Timestamp { get; set; }
        public DateTime StopTime { get; set; }

        public ushort WorkTime { get; set; }
    }
}