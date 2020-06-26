using System;
using GWTTestBase;
using StartShortBreakeView.Application.Commands;
using StartShortBreakeView.Application.Events;
using Xunit;

namespace StartShortBreakeView.Tests.state_change
{
    public class start_short_breake_command_tests : CommandTest<start_short_breake_view_module, StartShortBreakeCommand>
    {
        [Fact]
        public void when_start_short_breake_command__then__work_short_breake_started()
        {
            When(new StartShortBreakeCommand(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
            
            Then(new ShortBreakeStarted(
                5,
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}