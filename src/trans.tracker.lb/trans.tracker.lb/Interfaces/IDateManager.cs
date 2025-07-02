using trans.tracker.lb.CustomEnums;

namespace trans.tracker.lb.Interfaces
{
    public interface IDateManager
    {
        IEnumerable<DateTime> GetWorkingDays(DateTime start, DateTime end, WorkingDates param);
        IEnumerable<DateTime> AddDateToRange(IEnumerable<DateTime> dates, DateTime date);
        IEnumerable<DateTime> RemoveDateFromRange(IEnumerable<DateTime> dates, DateTime date);
    }
}
