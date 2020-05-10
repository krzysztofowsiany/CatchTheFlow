using System;
using GWTTestBase;
using StartWorkView.Application.Commands;
using StartWorkView.Application.Events;
using Xunit;

namespace StartWorkView.Tests.state_change
{
    public class start_work_command_tests : CommandTest<start_work_view_module, StartWorkCommand>
    {
        [Fact]
        public void when_work_stop_command_then_work_should_stopped()
        {
            When(new StartWorkCommand(
                25,
                DateTime.Parse("2019-01-01 23:00"),
                DateTime.Parse("2019-01-01 23:00")
            ));
            
            Then(new WorkStarted(
                25,
                DateTime.Parse("2019-01-01 23:00"),
                DateTime.Parse("2019-01-01 23:00")));
        }
    }
}