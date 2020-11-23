using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class work_to_start_status_after_suggestions_tests : ViewTest<PomodoroStatusModule>
    {
        [Fact]
        public void status_is_work_to_start__when__was_long_break_suggested()
        {
            Give( new SuggestedLongBreak());
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_short_break_suggested()
        {
            Give( new SuggestedShortBreak());
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_work_suggested()
        {
            Give( new SuggestedWork());
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
    }
}