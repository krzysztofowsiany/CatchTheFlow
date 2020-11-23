using GWTTestBase;
using StartLongBreakView.Application.Events;
using StartLongBreakView.Application.Views;
using StartLongBreakView.UI;
using Xunit;

namespace StartLongBreakView.Tests.state_view
{
    public class long_break_time_view_tests : ViewTest<StartLongBreakViewModule>
    {
        [Fact]
        public void long_break_time_restored__when__long_break_time_update()
        {
            Give( new LongBreakTimeUpdated(15));

            Then(new LongBreakTimeView(15));
        }
    }
}