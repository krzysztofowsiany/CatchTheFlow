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
        public void status_is_short_break__when__short_break_started()
        {
            Give( new ShortBreakeStarted(
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
            
            Give( new ShortBreakeStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.ShortBreak));
        }
        
        [Fact]
        public void status_is_not_short_break__when__short_break_started_not_a_last_event()
        {
            
            Give( new ShortBreakeStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new SuggestedShortBreake());
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.Nothing));
        }
    }
}