using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class short_break_stopped_time_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void when_short_break_stopped_then_sound_stopped()
        {
            Give( new ShortBreakStopped(
                5, 
                DateTime.Parse("2019-01-01 23:10"))
            );

            Then(new ShortBreakStopTimeView(DateTime.Parse("2019-01-01 23:10")));
        }
    }
}