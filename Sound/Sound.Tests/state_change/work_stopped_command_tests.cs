using System;
using GWTTestBase;
using Sound.Infrastructure;
using Sound.Application.Events;
using Xunit;

namespace Sound.Tests.state_change
{
    public class work_stopped_command_tests : CommandTest<sound_module>
    {
        [Fact]
        public void when_work_stopped_then_sound_stopped()
        {
            Give(@event: new WorkStopped(25, 
                DateTime.Parse("2019-01-01 23:25"), 
                DateTime.Parse("2019-01-01 23:25")));

            When<SoundEventListener>();

            Then(new SoundStopped(DateTime.Parse("2019-01-01 23:25")));
        }
    }
}