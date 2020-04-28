using System;

namespace CQRSLib.DateTime
{
    public class DateTime : IDateTime
    {
        public TimeSpan DueTime(ushort minutes)
            => TimeSpan.FromMinutes(minutes);
    }
}