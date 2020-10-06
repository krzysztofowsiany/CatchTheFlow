using System;
using GWTTestBase;
using LongBreakView.Application.Commands;
using LongBreakView.Application.Events;
using Xunit;

namespace LongBreakView.Tests.state_change
{
    public class interrupt_long_break_command_tests : CommandTest<long_break_view_module, InterruptLongBreakCommand>
    {
        [Fact]
        public void when_interrupt_long_break_command_then_long_break_should_interrupted()
        {
            When(new InterruptLongBreakCommand(
                15,
                DateTime.Parse("2019-01-01 23:30"))
            );
            
            Then(new LongBreakInterrupted(
                15,
                DateTime.Parse("2019-01-01 23:30"))
            );
        }
    }
}