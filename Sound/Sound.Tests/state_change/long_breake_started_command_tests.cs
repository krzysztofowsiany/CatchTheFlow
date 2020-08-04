﻿using GWTTestBase;
using Sound.Application.Commands;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class long_breake_started_command_tests : CommandTest<sound_module, StartPlayCommand>
    {
        [Fact]
        public void when_long_breake_started_then_long_breake_sound_should_started()
        {
            When(new StartPlayCommand( 
                "long_breake_2.mp3") 
            );

            Then(new SoundStarted(
                "long_breake_2.mp3")
            );
        }
    }
}