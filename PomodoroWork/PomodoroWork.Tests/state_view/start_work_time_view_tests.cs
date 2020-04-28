using System;
using GWTTestBase;
using PomodoroWork.Application.Events;
using PomodoroWork.Application.Views;
using Xunit;

namespace PomodoroWork.Tests.state_view
{
    public class start_work_time_view_tests : ViewTest<PomodoroWorkModule>
    {
        [Fact]
        public void start_work_time_view_restored__when__work_started()
        {
            Give( new WorkStarted(25, 
                DateTime.Parse("2019-01-01 23:00"), 
                DateTime.Parse("2019-01-01 23:00")));

            Then(new StartWorkTimeView(25, DateTime.Parse("2019-01-01 23:00")));
        }
    }
}