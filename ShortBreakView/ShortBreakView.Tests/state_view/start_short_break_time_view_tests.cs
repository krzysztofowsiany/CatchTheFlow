using System;
using GWTTestBase;
using ShortBreakView.Application.Events;
using ShortBreakView.Application.Views;
using ShortBreakView.UI;
using Xunit;

namespace ShortBreakView.Tests.state_view
{
    public class start_short_break_time_view_tests : ViewTest<ShortBreakViewModule>
    {
        [Fact]
        public void start_short_break_time_view_restored__when__short_break_started()
        {
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:05"))
            );
            
            Then(new StartShortBreakTimeView(
                5, 
                DateTime.Parse("2019-01-01 23:05"))
            );
        }
    }
}