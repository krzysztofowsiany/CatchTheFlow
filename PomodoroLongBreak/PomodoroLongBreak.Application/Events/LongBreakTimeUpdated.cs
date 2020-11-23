
namespace PomodoroLongBreak.Application.Events
{
    public class ShortBreakTimeUpdated
    {
        public ushort Time { get; }
        
        public ShortBreakTimeUpdated(ushort time)
        {
            Time = time;
        }
    }
}