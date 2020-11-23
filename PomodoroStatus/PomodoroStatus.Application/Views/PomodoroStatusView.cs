using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventBus;
using EventBus.View;

namespace PomodoroStatus.Application.Views
{
    public class PomodoroStatusView :BaseView
    {
        private IDictionary<string, PomodoroStatus> _pomodorStatuses;
        private IEnumerable<string> _exceptEvents;

        public PomodoroStatus PomodoroStatus { get; set; } = PomodoroStatus.WorkToStart;
        
        public PomodoroStatusView(PomodoroStatus pomodoroStatus) :base(null)
        {
            InitializePomodoroStatuses();
            PomodoroStatus = pomodoroStatus;
        }

        public PomodoroStatusView(IEventRepository eventRepository) :base(eventRepository)
        {
            InitializePomodoroStatuses();
            RestoreState();
        }

        public override void RestoreState()
        {
            var eventNameList = _eventRepository
                .GetNamesOfEvents()
                .Except(_exceptEvents)
                .FirstOrDefault();
           
            if (eventNameList == null)
            {
                return;
            }
            
            if (_pomodorStatuses.ContainsKey(eventNameList))
            {
                PomodoroStatus = _pomodorStatuses[eventNameList];
            }
            else
            {
                PomodoroStatus = PomodoroStatus.Nothing;
            }
        }
        
        private void InitializePomodoroStatuses()
        {
            _pomodorStatuses = new Dictionary<string, PomodoroStatus>
            {
                {"WorkStarted", PomodoroStatus.Work},
                {"ShortBreakStarted", PomodoroStatus.ShortBreak},
                {"LongBreakStarted", PomodoroStatus.LongBreak},
                {"ShortBreakStopped", PomodoroStatus.WorkToStart},
                {"LongBreakStopped", PomodoroStatus.WorkToStart},
                {"WorkInterrupted", PomodoroStatus.WorkToStart},
                {"WorkStopped", PomodoroStatus.WorkToStart},
                {"ShortBreakInterrupted", PomodoroStatus.WorkToStart},
                {"LongBreakInterrupted", PomodoroStatus.WorkToStart},
            };

            _exceptEvents = new[]
            {
                "SoundStarted", "SoundStopped",
                "LongBreakSoundUpdated", "LongBreakTimeUpdated",
                "ShortBreakSoundUpdated", "ShortBreakTimeUpdated",
                "WorkSoundUpdated", "WorkTimeUpdated",
                "SuggestedLongBreak", "SuggestedShortBreak", "SuggestedWork"
            };
        }
    }
}