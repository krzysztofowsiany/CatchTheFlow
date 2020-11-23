using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class sound_short_break_information_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void sound_short_break__information_view_restored__when__short_break_sound_updated_and_short_break_started()
        {
           Give( new ShortBreakSoundUpdated(
                "short_break_1.mp3")
            );
            
            Give( new ShortBreakStarted(
                5, 
                DateTime.Parse("2019-01-01 23:05"))
            );

            Then(new SoundShortBreakInformationView("short_break_1.mp3"));
        }
    }
}