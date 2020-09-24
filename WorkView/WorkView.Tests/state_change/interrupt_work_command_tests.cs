using System;
using GWTTestBase;
using WorkView.Application.Commands;
using WorkView.Application.Events;
using Xunit;

namespace WorkView.Tests.state_change
{
    public class interrupt_work_command_tests : CommandTest<work_view_module, InterruptWorkCommand>
    {
        [Fact]
        public void when_interrupt_work_command_then_work_should_interrupted()
        {
            When(new InterruptWorkCommand(
                25,
                DateTime.Parse("2019-01-01 23:23"))
            );
            
            Then(new WorkInterrupted(
                25,
                DateTime.Parse("2019-01-01 23:23"))
            );
        }
    }
}