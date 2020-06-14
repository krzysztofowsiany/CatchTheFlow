using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class work_started_command_tests : CommandTest<sound_module, StartPlayCommand>
    {
        [Fact]
        public void when_work_started_then_sound_should_started()
        {
            When(new StartPlayCommand( 
                "work_2.mp3") 
            );

            Then(new SoundStarted(
                "work_2.mp3")
            );
        }
    }
}