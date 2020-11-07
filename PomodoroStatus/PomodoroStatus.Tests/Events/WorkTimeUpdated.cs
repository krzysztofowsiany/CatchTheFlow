namespace PomodoroStatus.Tests.Events
{
    public class WorkTimeUpdated
    {
        public ushort WorkTime { get; }

        public WorkTimeUpdated(ushort workTime)
        {
            WorkTime = workTime;
        }
    }
}