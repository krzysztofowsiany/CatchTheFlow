using System;
using GWTTestBase;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;
using Xunit;

namespace Suggestion.Tests.state_change
{
    public class suggest_short_breake_command_tests : CommandTest<suggestion_module, SuggestShortBreakCommand>
    {
        [Fact]
        public void when_suggest_short_breake_command_then_suggested_short_break()
        {
            When(new SuggestShortBreakCommand(
                5,
                DateTime.Parse("2019-01-01 23:25"))
            );
            
            Then(new SuggestedShortBreake(
                5,
                DateTime.Parse("2019-01-01 23:25"))
            );
        }
    }
}