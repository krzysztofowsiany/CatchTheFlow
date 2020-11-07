using System;
using GWTTestBase;
using PomodoroStatus.Tests.Events;
using PomodoroStatus.Application.Views;
using PomodoroStatus.Infrastructure;
using Xunit;

namespace PomodoroStatus.Tests.state_view
{
    public class work_to_start_status_befor_update_configurations_tests : ViewTest<PomodoroStatusModule>
    {
        [Fact]
        public void status_is_work_to_start__when__was_long_brek_sound_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new LongBreakeSoundUpdated(""));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_short_brek_sound_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new ShortBreakeSoundUpdated(""));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_short_brek_time_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new ShortBreakeTimeUpdated(0));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_long_brek_time_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new LongBreakeTimeUpdated(0));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_work_sound_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new WorkSoundUpdated(""));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
        
        [Fact]
        public void status_is_work_to_start__when__was_work_time_updated()
        {
            Give( new WorkStopped(25, DateTime.Parse("2019-01-01 23:00")));
            Give( new WorkTimeUpdated(0));
            
            Then(new PomodoroStatusView(Application.Views.PomodoroStatus.WorkToStart));
        }
    }
}