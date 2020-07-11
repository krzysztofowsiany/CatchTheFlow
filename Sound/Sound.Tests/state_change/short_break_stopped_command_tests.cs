using System;
using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class short_breake_stopped_command_tests : CommandTest<sound_module, StopPlayCommand>
    {
        [Fact]
        public void when_short_breake_stopped_then_sound_stopped()
        {
            When(new StopPlayCommand(
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new SoundStopped());
        }
    }
}