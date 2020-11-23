using System;
using GWTTestBase;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Events;
using Xunit;

namespace StartLongBreakView.Tests.state_change
{
    public class start_long_break_command_tests : CommandTest<start_long_break_view_module, StartLongBreakCommand>
    {
        [Fact]
        public void when_start_long_break_command__then__work_long_break_started()
        {
            When(new StartLongBreakCommand(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
            
            Then(new LongBreakStarted(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}