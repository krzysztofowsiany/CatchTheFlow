using System;
using GWTTestBase;
using Suggestion.Application.Events;
using Suggestion.Application.Views;
using Suggestion.Infrastructure;
using Xunit;

namespace Suggestion.Tests.state_view
{
    public class time_of_end_work_view_tests : ViewTest<SuggestionModule>
    {
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_0__when__any_work_stopped_event_was_given()
        {
            Then(new TimeOfEndWorkView(
                0, 
                DateTime.MinValue, 
                0)
            );
        }
        
        
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_1__when__any_work_stopped_event_was_given_one_times()
        {
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new TimeOfEndWorkView(
                25, 
                DateTime.Parse("2019-01-01 23:25"), 
                1)
            );
        }
        
        
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_2__when__any_work_stopped_event_was_given_two_times()
        {
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new TimeOfEndWorkView(
                25, 
                DateTime.Parse("2019-01-01 23:25"), 
                2)
            );
        }
        
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_3__when__any_work_stopped_event_was_given_three_times()
        { 
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new TimeOfEndWorkView(
                25, 
                DateTime.Parse("2019-01-01 23:25"), 
                3)
            );
        }
        
        
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_4__when__any_work_stopped_event_was_given_four_times()
        { 
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 21:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:00"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new TimeOfEndWorkView(
                25, 
                DateTime.Parse("2019-01-01 23:25"), 
                4)
            );
        }
        
        
        [Fact]
        public void time_of_end_work_view_count_is_equal_to_2__when__any_work_stopped_event_was_given_four_times_and_after_two_times_are_added_long_break_stoppped()
        { 
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 21:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:00"))
            );
            
            Give( new LongBreakeStopped(
                15, 
                DateTime.Parse("2019-01-01 21:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 22:30"))
            );
            
            Give( new WorkStopped(
                25, 
                DateTime.Parse("2019-01-01 23:25"))
            );

            Then(new TimeOfEndWorkView(
                25, 
                DateTime.Parse("2019-01-01 23:25"), 
                2)
            );
        }
    }
}