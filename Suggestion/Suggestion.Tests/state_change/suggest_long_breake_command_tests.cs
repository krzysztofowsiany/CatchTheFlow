using System;
using GWTTestBase;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;
using Xunit;

namespace Suggestion.Tests.state_change
{
    public class suggest_long_breake_command_tests : CommandTest<suggestion_module, SuggestLongBreakeCommand>
    {
        [Fact]
        public void when_suggest_long_breake_command_then_suggested_long_break()
        {
            When(new SuggestLongBreakeCommand(
                15, 
                DateTime.Parse("2019-01-01 23:25")));
            
            
            Then(new SuggestedLongBreake(
                15,
                DateTime.Parse("2019-01-01 23:25"))
            );
        }
    }
}