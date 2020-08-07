using System;
using GWTTestBase;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;
using Xunit;

namespace Suggestion.Tests.state_change
{
    public class suggest_work_command_tests : CommandTest<suggestion_module, SuggestWorkCommand>
    {
        [Fact]
        public void when_suggest_work_command_then_suggested_work()
        {
            When(new SuggestWorkCommand(
                25,
                DateTime.Parse("2019-01-01 23:10"))
            );
            
            Then(new SuggestedWork(
                25,
                DateTime.Parse("2019-01-01 23:10"))
            );
        }
    }
}