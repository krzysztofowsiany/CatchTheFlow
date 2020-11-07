namespace PomodoroStatus.Tests.Events
{
    public class LongBreakeTimeUpdated
    {
        public ushort Time { get; }

        public LongBreakeTimeUpdated(ushort time)
        {
            Time = time;
        }
    }
}