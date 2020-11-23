using GWTTestBase;
using Configuration.Application.Commands;
using Configuration.Application.Events;
using Xunit;

namespace Configuration.Tests.state_change
{
    public class save_sound_settings_command_tests : CommandTest<settings_module, SaveSoundSettingsCommand>
    {
        [Fact]
        public void when_save_sound_settings_command__then__work_sound_should_be_updated()
        {
            When(new SaveSoundSettingsCommand(
                "work_1.mp3", 
                "short_break_2.mp3",
                "long_break_1.mp3")
            );
            
            Then(new WorkSoundUpdated("work_1.mp3"));
        }
        
        [Fact]
        public void when_save_sound_settings_command__then__short_break_sound_should_be_updated()
        {
            When(new SaveSoundSettingsCommand(
                "work_1.mp3", 
                "short_break_2.mp3",
                "long_break_1.mp3")
            );
            
            Then(new ShortBreakSoundUpdated("short_break_2.mp3"));
        }

        [Fact]
        public void when_save_sound_settings_command__then__long_break_sound_should_be_updated()
        {
            When(new SaveSoundSettingsCommand(
                "work_1.mp3", 
                "short_break_2.mp3",
                "long_break_1.mp3")
            );
            
            Then(new LongBreakSoundUpdated("long_break_1.mp3"));
        }
    }
}