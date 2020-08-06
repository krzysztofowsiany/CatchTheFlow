using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class long_breake_stopped_time_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void when_long_breake_stopped_then_sound_stopped()
        {
            Give( new LongBreakeStopped(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );

            Then(new LongBreakeStopTimeView(DateTime.Parse("2019-01-01 23:30")));
        }
    }
}