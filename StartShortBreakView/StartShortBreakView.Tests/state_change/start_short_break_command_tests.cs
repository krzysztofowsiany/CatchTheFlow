using System;
using GWTTestBase;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Events;
using Xunit;

namespace StartLongBreakView.Tests.state_change
{
    public class start_short_break_command_tests : CommandTest<start_short_break_view_module, StartShortBreakCommand>
    {
        [Fact]
        public void when_start_short_break_command__then__work_short_break_started()
        {
            When(new StartShortBreakCommand(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
            
            Then(new ShortBreakStarted(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}