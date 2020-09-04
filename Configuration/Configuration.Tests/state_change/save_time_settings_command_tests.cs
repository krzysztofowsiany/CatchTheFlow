using GWTTestBase;
using Configuration.Application.Commands;
using Configuration.Application.Events;
using Xunit;

namespace Configuration.Tests.state_change
{
    public class save_time_settings_command_tests : CommandTest<settings_module, SaveTimeSettingsCommand>
    {
        [Fact]
        public void when_save_time_settings_command__then__work_time_should_be_updated()
        {
            When(new SaveTimeSettingsCommand(
                25, 
                5,
                15)
            );
            
            Then(new WorkTimeUpdated(25));
        }
        
        [Fact]
        public void when_save_time_settings_command__then__short_breake_time_should_be_updated()
        {
            When(new SaveTimeSettingsCommand(
                25, 
                5,
                15)
            );
            
            Then(new ShortBreakeTimeUpdated(5));
        }

        [Fact]
        public void when_save_time_settings_command__then__long_break_time_should_be_updated()
        {
            When(new SaveTimeSettingsCommand(
                25, 
                5,
                15)
            );
            
            Then(new LongBreakeTimeUpdated(15));
        }
    }
}