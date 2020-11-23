using System;
using GWTTestBase;
using PomodoroLongBreak.Application.Commands;
using PomodoroLongBreak.Application.Events;
using Xunit;

namespace PomodoroLongBreak.Tests.state_change
{
    public class stop_long_break_command_tests : CommandTest<pomodoro_long_break_module, StopLongBreakCommand>
    {
        [Fact]
        public void when_short_break_stop_command_then_short_brake_should_stopped()
        {
            When(new StopLongBreakCommand(
                15, 
                DateTime.Parse("2019-01-01 23:10"))
            );
            
            Then(new LongBreakStopped(
                15,
                DateTime.Parse("2019-01-01 23:10")));
        }
    }
}