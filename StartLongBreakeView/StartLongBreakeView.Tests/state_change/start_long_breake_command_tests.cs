using System;
using GWTTestBase;
using StartLongBreakeView.Application.Commands;
using StartLongBreakeView.Application.Events;
using Xunit;

namespace StartLongBreakeView.Tests.state_change
{
    public class start_long_breake_command_tests : CommandTest<start_long_breake_view_module, StartLongBreakeCommand>
    {
        [Fact]
        public void when_start_long_breake_command__then__work_long_breake_started()
        {
            When(new StartLongBreakeCommand(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
            
            Then(new LongBreakeStarted(
                15,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}