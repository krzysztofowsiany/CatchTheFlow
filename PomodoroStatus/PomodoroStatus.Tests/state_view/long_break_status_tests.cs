using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class long_break_status_tests : ViewTest<PomodoroStatusModule>
    {
        [Fact]
        public void status_is_long_break__when__long_break_started()
        {
            Give( new LongBreakeStarted(
                15, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.LongBreak));
        }
    }
}