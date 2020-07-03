using System;
using GWTTestBase;
using PomodoroShortBreake.Application.Events;
using PomodoroShortBreake.Application.Views;
using PomodoroShortBreake.Infrastructure;
using Xunit;

namespace PomodoroShortBreake.Tests.state_view
{
    public class short_breake_started_information_view_tests : ViewTest<PomodoroShortBreakeModule>
    {
        [Fact]
        public void
            short_breake_started_information_view_restored__when__short_breake_started()
        {
            Give(new ShortBreakeStarted(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new ShortBreakeStartedInformationView(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}