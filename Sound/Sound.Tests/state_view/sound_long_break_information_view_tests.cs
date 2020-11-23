using System;
using GWTTestBase;
using Sound.Application.Events;
using Sound.Application.Views;
using Xunit;

namespace Sound.Tests.state_view
{
    public class sound_long_break_information_view_tests : ViewTest<SoundModule>
    {
        [Fact]
        public void sound_long_break__information_view_restored__when__long_break_sound_updated_and_long_break_started()
        {
           Give( new LongBreakSoundUpdated(
                "long_break_2.mp3")
            );
            
            Give( new LongBreakStarted(
                15, 
                DateTime.Parse("2019-01-01 23:30"))
            );

            Then(new SoundLongBreakInformationView("long_break_2.mp3"));
        }
    }
}