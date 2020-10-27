using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class work_status_tests : ViewTest<PomodoroStatusModule>
    {
        [Fact]
        public void status_is_work__when__work_started()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.Work));
        }
    }
}