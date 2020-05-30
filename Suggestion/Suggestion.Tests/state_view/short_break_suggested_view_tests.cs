using System;
using GWTTestBase;
using Suggestion.Application.Events;
using Suggestion.Application.Views;
using Suggestion.Infrastructure;
using Xunit;

namespace Suggestion.Tests.state_view
{
    public class short_break_suggested_view_tests : ViewTest<SuggestionModule>
    {
        [Fact]
        public void start_work_time_view_restored__when__work_started()
        {
            Give( new WorkStarted(25, 
                DateTime.Parse("2019-01-01 23:00"), 
                DateTime.Parse("2019-01-01 23:00")));
            
            Give( new WorkStopped(25, 
                DateTime.Parse("2019-01-01 23:25"), 
                DateTime.Parse("2019-01-01 23:25")));

            Then(new TimeOfEndWorkView(25, DateTime.Parse("2019-01-01 23:25"), 0));
        }
    }
}