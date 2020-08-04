using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class sound_long_breake_information_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void sound_long_breake__information_view_restored__when__long_breake_sound_updated_and_long_breake_started()
        {
           Give( new LongBreakeSoundUpdated(
                "long_breake_2.mp3")
            );
            
            Give( new LongBreakeStarted(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );

            Then(new SoundLongBreakeInformationView("long_breake_2.mp3"));
        }
    }
}