using System;
using CQRSLib.DateTime;

namespace StartShortBreakeView.Tests.state_change
{
    public class fake_date_time : IDateTime
    {
        public TimeSpan DueTime(ushort minutes)
            => TimeSpan.Zero;
    }
}