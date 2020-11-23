using System;
using GWTTestBase;
using PomodoroShortBreak.Application.Events;
using PomodoroShortBreak.Application.Views;
using PomodoroShortBreak.Infrastructure;
using Xunit;

namespace PomodoroShortBreak.Tests.state_view
{
    public class short_break_started_information_view_tests : ViewTest<PomodoroShortBreakModule>
    {
        [Fact]
        public void short_break_started_information_view_restored__when__short_break_started()
        {
            Give(new ShortBreakStarted(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new ShortBreakStartedInformationView(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}