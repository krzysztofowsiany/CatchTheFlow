using System;
using GWTTestBase;
using PomodoroLongBreake.Application.Commands;
using PomodoroLongBreake.Application.Events;
using Xunit;

namespace PomodoroLongBreake.Tests.state_change
{
    public class stop_long_breake_command_tests : CommandTest<pomodoro_long_breake_module, StopLongBreakeCommand>
    {
        [Fact]
        public void when_short_breake_stop_command_then_short_brake_should_stopped()
        {
            When(new StopLongBreakeCommand(
                15, 
                DateTime.Parse("2019-01-01 23:10"))
            );
            
            Then(new LongBreakeStopped(
                15,
                DateTime.Parse("2019-01-01 23:10")));
        }
    }
}