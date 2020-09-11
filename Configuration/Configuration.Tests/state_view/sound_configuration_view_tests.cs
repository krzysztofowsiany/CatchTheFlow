using GWTTestBase;
using Configuration.Application.Events;
using Configuration.Application.Views;
using Configuration.UI;
using Xunit;

namespace Configuration.Tests.state_view
{
    public class sound_configuration_view_tests : ViewTest<SettingsModule>
    {
        [Fact]
        public void sound_configuration_restored__when__all_update_block_sound_are_updated()
        { 
            Give(new LongBreakeSoundUpdated("long_breake_1.mp3"));
            Give(new ShortBreakeSoundUpdated("short_breake_2.mp3"));
            Give(new WorkSoundUpdated("work_1.mp3"));

            Then(new SoundConfigurationView("work_1.mp3","long_breake_1.mp3","short_breake_2.mp3"));
        }
        
        [Fact]
        public void sound_configuration_restored__with_default_values__when__update_event_not_happen()
        { 
            Then(new SoundConfigurationView("work_1.mp3","long_breake_1.mp3","short_breake_1.mp3"));
        }
        
        [Fact]
        public void sound_configuration_restored__when__all_update_block_sound_are_updated_many_sounds()
        {
            for (var i = 5; i < 10; i++)
            {
                Give(new LongBreakeSoundUpdated($"long_breake_{i}.mp3"));
                Give(new ShortBreakeSoundUpdated($"short_breake_{i}.mp3"));
                Give(new WorkSoundUpdated($"work_{i}.mp3"));
            }

            Give(new LongBreakeSoundUpdated("long_breake_1.mp3"));
            Give(new ShortBreakeSoundUpdated("short_breake_2.mp3"));
            Give(new WorkSoundUpdated("work_1.mp3"));

            Then(new SoundConfigurationView("work_1.mp3","long_breake_1.mp3","short_breake_2.mp3"));
        }
    }
}