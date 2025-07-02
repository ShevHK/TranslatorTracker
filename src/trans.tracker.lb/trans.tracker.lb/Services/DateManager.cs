using trans.tracker.lb.CustomEnums;

namespace trans.tracker.lb.Services
{
    public class DateManager
    {
        public IEnumerable<DateTime> GetWorkingDays(DateTime start, DateTime end, WorkingDates param)
        {
            for (DateTime date = start.Date; date <= end.Date; date = date.AddDays(1))
            {
                var day = date.DayOfWeek;

                switch (param)
                {
                    case WorkingDates.OnlyWorkingDays:
                        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Friday)
                            yield return date;
                        break;

                    case WorkingDates.WithSaturday:
                        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Saturday)
                            yield return date;
                        break;

                    case WorkingDates.WithSunday:
                        if ((day >= DayOfWeek.Monday && day <= DayOfWeek.Friday) || day == DayOfWeek.Sunday)
                            yield return date;
                        break;

                    case WorkingDates.AllDays:
                        yield return date;
                        break;
                }
            }
        }

        public IEnumerable<DateTime> AddDateToRange(IEnumerable<DateTime> dates, DateTime date) => dates.Append(date);

        public IEnumerable<DateTime> RemoveDateFromRange(IEnumerable<DateTime> dates, DateTime date) => dates.Where(d => !d.Equals(date));

    }
}
