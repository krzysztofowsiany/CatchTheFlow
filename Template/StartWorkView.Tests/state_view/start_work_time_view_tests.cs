using System;
using GWTTestBase;
using StartWorkView.Infrastructure;
using Xunit;

namespace StartWorkView.Tests.state_view
{
    public class start_work_time_view_tests : ViewTest<StartWorkViewModule>
    {
        [Fact]
        public void start_work_time_view_restored__when__work_started()
        {
           /* Give( new WorkStarted(25, 
                DateTime.Parse("2019-01-01 23:00"), 
                DateTime.Parse("2019-01-01 23:00")));

            Then(new StartWorkTimeView(25, DateTime.Parse("2019-01-01 23:00")));*/
        }
    }
}