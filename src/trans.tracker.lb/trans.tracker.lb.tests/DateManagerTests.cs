using trans.tracker.lb.CustomEnums;
using trans.tracker.lb.Services;

namespace trans.tracker.lb.tests
{
    public class DateManagerTests
    {
        private readonly DateManager _manager = new();

        [Fact]
        public void GetWorkingDays_OnlyWorkingDays_ReturnsWeekdays()
        {
            var start = new DateTime(2024, 6, 3); // Monday
            var end = new DateTime(2024, 6, 9);   // Sunday

            var result = _manager.GetWorkingDays(start, end, WorkingDates.OnlyWorkingDays).ToList();

            Assert.Equal(5, result.Count);
            Assert.All(result, d => Assert.InRange((int)d.DayOfWeek, 1, 5)); // Monday to Friday
        }

        [Fact]
        public void GetWorkingDays_WithSaturday_IncludesSaturday()
        {
            var start = new DateTime(2024, 6, 3); // Monday
            var end = new DateTime(2024, 6, 9);   // Sunday

            var result = _manager.GetWorkingDays(start, end, WorkingDates.WithSaturday).ToList();

            Assert.Equal(6, result.Count);
            Assert.Contains(result, d => d.DayOfWeek == DayOfWeek.Saturday);
            Assert.DoesNotContain(result, d => d.DayOfWeek == DayOfWeek.Sunday);
        }

        [Fact]
        public void GetWorkingDays_WithSunday_IncludesSunday()
        {
            var start = new DateTime(2024, 6, 3); // Monday
            var end = new DateTime(2024, 6, 9);   // Sunday

            var result = _manager.GetWorkingDays(start, end, WorkingDates.WithSunday).ToList();

            Assert.Equal(6, result.Count);
            Assert.Contains(result, d => d.DayOfWeek == DayOfWeek.Sunday);
            Assert.DoesNotContain(result, d => d.DayOfWeek == DayOfWeek.Saturday);
        }

        [Fact]
        public void GetWorkingDays_AllDays_ReturnsFullRange()
        {
            var start = new DateTime(2024, 6, 3); // Monday
            var end = new DateTime(2024, 6, 9);   // Sunday

            var result = _manager.GetWorkingDays(start, end, WorkingDates.AllDays).ToList();

            Assert.Equal(7, result.Count);
        }

        [Fact]
        public void AddDateToRange_AddsNewDate()
        {
            var dates = new List<DateTime> { new DateTime(2024, 6, 3) };
            var newDate = new DateTime(2024, 6, 4);

            var result = _manager.AddDateToRange(dates, newDate).ToList();

            Assert.Equal(2, result.Count);
            Assert.Contains(newDate, result);
        }

        [Fact]
        public void RemoveDateFromRange_RemovesSpecifiedDate()
        {
            var dateToRemove = new DateTime(2024, 6, 4);
            var dates = new List<DateTime>
                {
                    new DateTime(2024, 6, 3),
                    dateToRemove,
                    new DateTime(2024, 6, 5)
                };

            var result = _manager.RemoveDateFromRange(dates, dateToRemove).ToList();

            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(dateToRemove, result);
        }
    }
}
