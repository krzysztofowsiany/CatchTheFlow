using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class sound_worker_information_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void sound_work_information_view_restored__when__work_sound_updated_and_work_started()
        {
            Give( new WorkSoundUpdated(
                "work_1.mp3")
            );
            
            Give( new WorkStarted(
                25, 
                DateTime.Parse("2019-01-01 23:00"))
            );

            Then(new SoundWorkInformationView("work_1.mp3"));
        }
    }
}