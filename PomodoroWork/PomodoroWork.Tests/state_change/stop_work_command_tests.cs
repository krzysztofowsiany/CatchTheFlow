using System;
using System.Threading;
using GWTTestBase;
using PomodoroWork.Application.Events;
using PomodoroWork.Infrastructure;
using Xunit;

namespace PomodoroWork.Tests.state_change
{
    public class stop_work_command_tests : CommandTest<pomodoro_work_module>
    {
        [Fact]
        public void when_work_stop_command_then_work_should_stopped()
        {
            Give(@event: new WorkStarted(
                25,
                DateTime.Parse("2019-01-01 23:00"),
                DateTime.Parse("2019-01-01 23:00")
                ));
            
            When<PomodoroWorkEventListener>();
            
            Then(new WorkStopped(
                25,
                DateTime.Parse("2019-01-01 23:25"),
                DateTime.Parse("2019-01-01 23:25")));
        }
    }
}