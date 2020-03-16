using System;
using GWTTestBase;
using Sound.Infrastructure;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests
{
    public class work_stopped_time_view_tests : TestBase
    {
        [Fact]
        public void when_work_stopped_then_sound_stopped()
        {
            Give(@event: new WorkStopped(25, 
                DateTime.Parse("2019-01-01 23:25"), 
                DateTime.Parse("2019-01-01 23:25")));

            //TODO: implement test base for views
            Then(new WorkStopTime(DateTime.Parse("2019-01-01 23:25")));
        }
    }
}