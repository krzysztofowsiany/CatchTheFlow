using System;
using GWTTestBase;
using StartWorkView.Application.Events;
using StartWorkView.Application.Views;
using StartWorkView.Infrastructure;
using Xunit;

namespace StartWorkView.Tests.state_view
{
    public class user_work_time_view_tests : ViewTest<StartWorkViewModule>
    {
        [Fact]
        public void user_work_time_view_restored__when__work_time_update()
        {
            Give( new WorkTimeUpdated(20, 
                DateTime.Parse("2019-01-01 22:45")));
            
            Give( new WorkTimeUpdated(25, 
                DateTime.Parse("2019-01-01 22:45:10")));

            Then(new UserWorkTime(25));
        }
    }
}