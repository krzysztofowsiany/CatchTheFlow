using GWTTestBase;
using StartLongBreakView.Application.Events;
using StartLongBreakView.Application.Views;
using StartLongBreakView.UI;
using Xunit;

namespace StartLongBreakView.Tests.state_view
{
    public class suggest_short_break_view_tests : ViewTest<StartShortBreakViewModule>
    {
        [Fact]
        public void short_break_time_restored__when__short_break_time_updated_and_suggested_short_break()
        {
            Give( new ShortBreakTimeUpdated(5));
            
            Give( new SuggestedShortBreak());

            Then(new ShortBreakTimeView(5));
        }
    }
}