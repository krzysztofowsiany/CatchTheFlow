using System;
using GWTTestBase;
using ShortBreakView.Application.Commands;
using ShortBreakView.Application.Events;
using Xunit;

namespace ShortBreakView.Tests.state_change
{
    public class interrupt_short_break_command_tests : CommandTest<short_break_view_module, InterruptShortBreakCommand>
    {
        [Fact]
        public void when_interrupt_short_break_command_then_short_break_should_interrupted()
        {
            When(new InterruptShortBreakCommand(
                5,
                DateTime.Parse("2019-01-01 23:08:02"))
            );
            
            Then(new ShortBreakInterrupted(
                5,
                DateTime.Parse("2019-01-01 23:08:02"))
            );
        }
    }
}