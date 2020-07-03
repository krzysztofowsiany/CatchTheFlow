using System;
using GWTTestBase;
using PomodoroShortBreake.Application.Commands;
using PomodoroShortBreake.Application.Events;
using Xunit;

namespace PomodoroShortBreake.Tests.state_change
{
    public class stop_short_breake_command_tests : CommandTest<pomodoro_short_breake_module, StopShortBreakeCommand>
    {
        [Fact]
        public void when_short_breake_stop_command_then_short_brake_should_stopped()
        {
            When(new StopShortBreakeCommand(
                5, 
                DateTime.Parse("2019-01-01 23:10"))
            );
            
            Then(new ShortBreakeStopped(
                5,
                DateTime.Parse("2019-01-01 23:10")));
        }
    }
}