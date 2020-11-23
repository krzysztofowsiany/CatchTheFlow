using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class short_break_started_command_tests : CommandTest<sound_module, StartPlayCommand>
    {
        [Fact]
        public void when_short_break_started_then_short_break_sound_should_started()
        {
            When(new StartPlayCommand( 
                "short_break_1.mp3") 
            );

            Then(new SoundStarted(
                "short_break_1.mp3")
            );
        }
    }
}