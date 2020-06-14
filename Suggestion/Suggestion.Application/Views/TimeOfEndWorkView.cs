using System;
using System.Linq;
using EventBus;
using EventBus.View;
using Suggestion.Application.Events;

namespace Suggestion.Application.Views
{
    public class TimeOfEndWorkView :BaseView
    {
        private const int PomodoroMaxWorkCycle = 4;
        public ushort WorkTime { get; private set; }
        public DateTime StopTime { get; private set; }
        public ushort Count { get; private set; }

        public TimeOfEndWorkView(ushort workTime, DateTime stopTime, ushort count) :base(null)
        {
            WorkTime = workTime;
            StopTime = stopTime;
            Count = count;
        }
        
        public TimeOfEndWorkView(IEventRepository eventRepository) :base(eventRepository)
        {
            RestoreState();
        }

        public override void RestoreState()
        {
            var workStopped = GetEvents<WorkStopped>()
                .FirstOrDefault();

            var eventNames = GetNamesOfEvents();
            
            if (workStopped != null)
            {
                StopTime = workStopped.StopTime;
                WorkTime = workStopped.WorkTime;
            }
            
            Count = 0;

            foreach (var eventName in eventNames)
            {
                if (eventName.Equals("WorkStopped"))
                {
                    Count++;
                }
                
                if (eventName.Equals("LongBreakeStopped"))
                {
                    break;
                }
                
                if (Count >= PomodoroMaxWorkCycle)
                {
                    break;
                }
            }
            
        }
    }
}