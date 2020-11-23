namespace StartLongBreakView.Application.Events
{
    public class LongBreakTimeUpdated
    {
        public ushort Time { get; }

        public LongBreakTimeUpdated(ushort time)
        {
            Time = time;
        }
    }
}