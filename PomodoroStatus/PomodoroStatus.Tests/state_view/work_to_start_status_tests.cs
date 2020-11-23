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
            
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new ShortBreakStopped(
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
            
            Give( new LongBreakStarted(
                15, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new LongBreakStopped(
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
            Give(new ShortBreakStarted(
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
            Give(new LongBreakStarted(
                10,
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new LongBreakInterrupted(
                10,
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        
        [Fact]
        public void status_is_work_to_start__when__was_work_stopped_after_work_interrupted()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkInterrupted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );


            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        
        [Fact]
        public void status_is_work_to_start__when__was_work_stopped()
        {
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );


            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
    }
}