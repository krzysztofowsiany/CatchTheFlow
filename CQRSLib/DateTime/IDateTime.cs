using System;

namespace CQRSLib.DateTime
{
    public interface IDateTime
    {
        TimeSpan DueTime(ushort minutes);
    }
}