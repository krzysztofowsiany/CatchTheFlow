using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class work_stopped_time_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void when_work_stopped_then_sound_stopped()
        {
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new WorkStopTimeView(DateTime.Parse("2019-01-01 23:25")));
        }
    }
}