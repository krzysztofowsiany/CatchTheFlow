using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class short_break_status_tests : ViewTest<PomodoroStatusModule>
    {
 
        [Fact]
        public void status_is_not_short_break__when__short_break_started_not_a_last_event()
        {
            
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new ShortBreakStopped(5, 
                DateTime.Parse("2019-01-01 23:00")));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_short_break__when__short_break_started()
        {
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.ShortBreak));
        }
        
        [Fact]
        public void status_is_short_break__when__short_break_started_as_last_event()
        {
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.ShortBreak));
        }
        
        
    }
}