using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class short_breake_stopped_time_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void when_short_breake_stopped_then_sound_stopped()
        {
            Give( new ShortBreakeStopped(
                5, 
                DateTime.Parse("2019-01-01 23:10"))
            );

            Then(new ShortBreakeStopTimeView(DateTime.Parse("2019-01-01 23:10")));
        }
    }
}