using System;
using GWTTestBase;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;
using Xunit;

namespace Suggestion.Tests.state_change
{
    public class suggest_long_break_command_tests : CommandTest<suggestion_module, SuggestLongBreakCommand>
    {
        [Fact]
        public void when_suggest_long_break_command_then_suggested_long_break()
        {
            When(new SuggestLongBreakCommand(
                15, 
                DateTime.Parse("2019-01-01 23:25")));
            
            
            Then(new SuggestedLongBreak(
                15,
                DateTime.Parse("2019-01-01 23:25"))
            );
        }
    }
}