using System;
using GWTTestBase;
using PomodoroLongBreake.Application.Events;
using PomodoroLongBreake.Application.Views;
using PomodoroLongBreake.Infrastructure;
using Xunit;

namespace PomodoroLongBreake.Tests.state_view
{
    public class long_breake_started_information_view_tests : ViewTest<PomodoroLongBreakeModule>
    {
        [Fact]
        public void
            short_breake_started_information_view_restored__when__short_breake_started()
        {
            Give(new LongBreakeStarted(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new LongBreakeStartedInformationView(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}