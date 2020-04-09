using System;
using GWTTestBase;
using Sound.Infrastructure;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests
{
    public class work_started_command_tests : CommandTest
    {
        [Fact]
        public void when_work_started_then_sound_should_started()
        {
            Give(@event: new WorkSoundUpdated(
                "work_1.mp3",
                DateTime.Parse("2019-01-01 23:25")));
            
            Give(@event: new WorkStarted(25, 
                DateTime.Parse("2019-01-01 23:25"), 
                DateTime.Parse("2019-01-01 23:25")));

            When<EventListener>();

            Then(new SoundStarted(
                "work_1.mp3",
                DateTime.Parse("2019-01-01 23:25")));
        }
    }
}