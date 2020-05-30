using GWTTestBase;
using Suggestion.Application.Commands;
using Xunit;

namespace Suggestion.Tests.state_change
{
    public class suggest_short_breake_command_tests : CommandTest<suggestion_module, SuggestShortBreakCommand>
    {
        [Fact]
        public void when_suggest_short_breake_command_then_suggested_shor_break()
        {
           /* Give(@event: new WorkStarted(
                25,
                DateTime.Parse("2019-01-01 23:00"),
                DateTime.Parse("2019-01-01 23:00")
                ));
            
            When<PomodoroWorkEventListener>();
            
            Then(new WorkStopped(
                25,
                DateTime.Parse("2019-01-01 23:25"),
                DateTime.Parse("2019-01-01 23:25")));*/
        }
    }
}