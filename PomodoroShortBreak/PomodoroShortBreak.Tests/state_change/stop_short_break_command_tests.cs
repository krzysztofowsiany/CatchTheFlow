using System;
using GWTTestBase;
using PomodoroShortBreak.Application.Commands;
using PomodoroShortBreak.Application.Events;
using Xunit;

namespace PomodoroShortBreak.Tests.state_change
{
    public class stop_short_break_command_tests : CommandTest<pomodoro_short_break_module, StopShortBreakCommand>
    {
        [Fact]
        public void when_short_breake_stop_command_then_short_brake_should_stopped()
        {
            When(new StopShortBreakCommand(
                5, 
                DateTime.Parse("2019-01-01 23:10"))
            );
            
            Then(new ShortBreakStopped(
                5,
                DateTime.Parse("2019-01-01 23:10")));
        }
    }
}