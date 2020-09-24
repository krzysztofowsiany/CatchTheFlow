using System;
using System.Threading;
using GWTTestBase;
using WorkView.Application.Events;
using WorkView.Application.Views;
using WorkView.UI;
using Xunit;

namespace WorkView.Tests.state_view
{
    public class start_work_time_view_tests : ViewTest<WorkViewModule>
    {
        [Fact]
        public void start_work_time_view_restored__when__work_started()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:30"))
            );
            
            Then(new StartWorkTime(
                25, 
                DateTime.Parse("2019-01-01 23:30"))
            );
        }
    }
}