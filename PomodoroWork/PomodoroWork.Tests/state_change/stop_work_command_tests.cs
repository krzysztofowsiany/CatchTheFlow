using System;
using GWTTestBase;
using PomodoroWork.Application.Commands;
using PomodoroWork.Application.Events;
using Xunit;

namespace PomodoroWork.Tests.state_change
{
    public class stop_work_command_tests : CommandTest<pomodoro_work_module, StopWorkCommand>
    {
        [Fact]
        public void when_work_stop_command_then_work_should_stopped()
        {
            When(new StopWorkCommand(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );
            
            Then(new WorkStopped(
                25,
                DateTime.Parse("2019-01-01 23:25")));
        }
    }
}