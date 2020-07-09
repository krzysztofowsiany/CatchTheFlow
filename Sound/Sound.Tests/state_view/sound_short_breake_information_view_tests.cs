using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class sound_short_breake_information_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void sound_short_breake__information_view_restored__when__short_breake_sound_updated_and_short_breake_started()
        {
           Give( new ShortBreakeSoundUpdated(
                "short_breake_1.mp3")
            );
            
            Give( new ShortBreakeStarted(
                5, 
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new SoundShortBreakeInformationView("short_breake_1.mp3"));
        }
    }
}