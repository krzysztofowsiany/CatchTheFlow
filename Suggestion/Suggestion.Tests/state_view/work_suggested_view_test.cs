using System;
using GWTTestBase;
using Suggestion.Application.Events;
using Suggestion.Application.Views;
using Suggestion.Infrastructure;
using Xunit;

namespace Suggestion.Tests.state_view
{
    public class work_suggested_view_test : ViewTest<SuggestionModule>
    {

        [Fact]
        public void suggest_work__when__short_break_stopped()
        { 
            Give( new WorkTimeUpdated(25));
            
            Give( new ShortBreakStopped(
                5, 
                DateTime.Parse("2019-01-01 23:10"))
            );

            Then(new ShortBreakStoppedInformation(
                25, 
                DateTime.Parse("2019-01-01 23:10")
                )
            );
        }
        
        
        [Fact]
        public void suggest_work__when__long_break_stopped()
        { 
            Give( new WorkTimeUpdated(25));
            
            Give( new LongBreakStopped(
                15, 
                DateTime.Parse("2019-01-01 23:10"))
            );

            Then(new LongBreakStoppedInformation(
                    25, 
                    DateTime.Parse("2019-01-01 23:10")
                )
            );
        }
    }
}