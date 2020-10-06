using System;
using GWTTestBase;
using LongBreakView.Application.Events;
using LongBreakView.Application.Views;
using LongBreakView.UI;
using Xunit;

namespace LongBreakView.Tests.state_view
{
    public class start_long_break_time_view_tests : ViewTest<LongBreakViewModule>
    {
        [Fact]
        public void start_long_break_time_view_restored__when__long_break_started()
        {
            Give( new LongBreakeStarted(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );
            
            Then(new StartLongBreakTimeView(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );
        }
    }
}