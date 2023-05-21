using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Services.Implementation
{
    public static class TimeRangeValidator
    {
        public static List<DateRange> GetOverlappingDateRanges(DateRange rangeToCheck, IList<DateRange> ranges)
        {
            return ranges.Where(x => IsTimestampWithinRange(rangeToCheck, x)).ToList();
        }

        public static bool IsTimestampWithinRange(DateRange range, DateRange rangeToCompare)
        {
            return range.DateFrom.CompareTo(rangeToCompare.DateTo) <= 0 && rangeToCompare.DateFrom.CompareTo(range.DateTo) <= 0;
        }
    }
}
