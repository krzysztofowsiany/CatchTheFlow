using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class long_break_started_command_tests : CommandTest<sound_module, StartPlayCommand>
    {
        [Fact]
        public void when_long_break_started_then_long_break_sound_should_started()
        {
            When(new StartPlayCommand( 
                "long_break_2.mp3") 
            );

            Then(new SoundStarted(
                "long_break_2.mp3")
            );
        }
    }
}