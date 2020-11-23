using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class long_break_stopped_time_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void when_long_break_stopped_then_sound_stopped()
        {
            Give( new LongBreakStopped(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );

            Then(new LongBreakStopTimeView(DateTime.Parse("2019-01-01 23:30")));
        }
    }
}