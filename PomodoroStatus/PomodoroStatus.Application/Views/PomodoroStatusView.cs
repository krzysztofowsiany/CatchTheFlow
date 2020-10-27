using System.Linq;
using EventBus;
using EventBus.View;

namespace PomodoroStatus.Application.Views
{
    public class PomodoroStatusView :BaseView
    {
        public PomodoroStatus PomodorStatus { get; set; } = PomodoroStatus.WorkToStart;
        
        public PomodoroStatusView(PomodoroStatus pomodorStatus) :base(null)
        {
            PomodorStatus = pomodorStatus;
        }

        public PomodoroStatusView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var eventNameList = _eventRepository
                .GetNamesOfEvents()
                .FirstOrDefault();
           
           if (eventNameList.Contains("WorkStarted"))
                PomodorStatus = PomodoroStatus.Work;
           else if (eventNameList.Contains("ShortBreakeStarted"))
                PomodorStatus = PomodoroStatus.ShortBreak;
           else if (eventNameList.Contains("LongBreakeStarted"))
                PomodorStatus = PomodoroStatus.LongBreak;
           else if (eventNameList.Contains("ShortBreakeStopped")
                || eventNameList.Contains("LongBreakeStopped")
                || eventNameList.Contains("WorkInterrupted")
                || eventNameList.Contains("ShortBreakInterrupted")
                || eventNameList.Contains("LongBreakInterrupted")
                )
               PomodorStatus = PomodoroStatus.WorkToStart;
           else PomodorStatus = PomodoroStatus.Nothing;
        }
    }
}