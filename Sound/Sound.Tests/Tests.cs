using GWTTestBase;
using Sound.Application.Events;
using Sound.Infrastructure;
using Xunit;

namespace Sound.Tests
{
    public class Tests : TestBase
    {
        [Fact]
        public void test()
        {
            Give(new WorkStopped("test"));

            When<EventListener>();

            Then(new SoundStopped("test"));
        }

       
    }
}