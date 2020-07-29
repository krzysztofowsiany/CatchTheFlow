using GWTTestBase;
using StartLongBreakeView.Application.Events;
using StartLongBreakeView.Application.Views;
using StartLongBreakeView.UI;
using Xunit;

namespace StartLongBreakeView.Tests.state_view
{
    public class long_breake_time_view_tests : ViewTest<StartLongBreakeViewModule>
    {
        [Fact]
        public void long_breake_time_restored__when__long_breake_time_update()
        {
            Give( new LongBreakeTimeUpdated(15));

            Then(new LongBreakeTimeView(15));
        }
    }
}