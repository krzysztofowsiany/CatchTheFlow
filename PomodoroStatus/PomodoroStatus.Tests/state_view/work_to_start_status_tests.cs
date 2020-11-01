using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class work_to_start_status_tests : ViewTest<PomodoroStatusModule>
    {
        [Fact]
        public void status_is_work_to_start__when__was_work_and_short_break()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new ShortBreakeStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new ShortBreakeStopped(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__dont_have_any_events()
        {
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_work_and_long_break()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new LongBreakeStarted(
                15, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new LongBreakeStopped(
                15, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        
        [Fact]
        public void status_is_work_to_start__when__was_work_interrupted()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkInterrupted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_short_break_interrupted()
        {
            Give(new ShortBreakeStarted(
                5,
                DateTime.Parse("2019-01-01 23:00"))
                );
            
            Give( new ShortBreakInterrupted(
                5,
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_long_break_interrupted()
        {
            Give(new LongBreakeStarted(
                10,
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new LongBreakInterrupted(
                10,
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
    }
}