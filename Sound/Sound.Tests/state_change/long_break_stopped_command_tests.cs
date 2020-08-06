using System;
using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class long_break_stopped_command_tests : CommandTest<sound_module, StopPlayCommand>
    {
        [Fact]
        public void when_long_breake_stopped_then_sound_stopped()
        {
            When(new StopPlayCommand(
                DateTime.Parse("2019-01-01 23:45"))
            );

            Then(new SoundStopped());
        }
    }
}