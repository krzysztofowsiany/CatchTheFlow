using GWTTestBase;
using StartShortBreakeView.Application.Events;
using StartShortBreakeView.Application.Views;
using StartShortBreakeView.UI;
using Xunit;

namespace StartShortBreakeView.Tests.state_view
{
    public class suggest_short_breake_view_tests : ViewTest<StartShortBreakeViewModule>
    {
        [Fact]
        public void short_breake_time_restored__when__short_breake_time_updated_and_suggested_short_breake()
        {
            Give( new ShortBreakeTimeUpdated(5));
            
            Give( new SuggestedShortBreake());

            Then(new ShortBreakeTimeView(5));
        }
    }
}