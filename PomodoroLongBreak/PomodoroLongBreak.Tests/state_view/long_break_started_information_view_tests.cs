using System;
using GWTTestBase;
using PomodoroLongBreak.Application.Events;
using PomodoroLongBreak.Application.Views;
using PomodoroLongBreak.Infrastructure;
using Xunit;

namespace PomodoroLongBreak.Tests.state_view
{
    public class long_break_started_information_view_tests : ViewTest<PomodoroLongBreakModule>
    {
        [Fact]
        public void short_break_started_information_view_restored__when__short_break_started()
        {
            Give(new LongBreakStarted(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new LongBreakStartedInformationView(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}