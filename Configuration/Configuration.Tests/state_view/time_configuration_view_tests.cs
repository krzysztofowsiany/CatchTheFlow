using GWTTestBase;
using Configuration.Application.Events;
using Configuration.Application.Views;
using Configuration.UI;
using Xunit;

namespace Configuration.Tests.state_view
{
    public class time_configuration_view_tests : ViewTest<SettingsModule>
    {
        [Fact]
        public void time_configuration_restored__when__all_update_block_time_are_updated()
        { 
            Give(new LongBreakTimeUpdated(10));
            Give(new ShortBreakTimeUpdated(10));
            Give(new WorkTimeUpdated(30));

            Then(new TimeConfigurationView(30,10,10));
        }
        
        [Fact]
        public void time_configuration_restored__with_default_values__when__update_event_not_happen()
        { 
            Then(new TimeConfigurationView(25,15,5));
        }
        
        [Fact]
        public void time_configuration_restored__when__all_update_block_time_are_updated_many_times()
        {
            for (var i = 1; i < 6; i++)
            {
                Give(new LongBreakTimeUpdated((ushort) (10+i)));
                Give(new ShortBreakTimeUpdated((ushort) (5+i)));
                Give(new WorkTimeUpdated((ushort) (30+i)));
            }

            Give(new LongBreakTimeUpdated(10));
            Give(new ShortBreakTimeUpdated(5));
            Give(new WorkTimeUpdated(30));

            Then(new TimeConfigurationView(30,10,5));
        }
    }
}