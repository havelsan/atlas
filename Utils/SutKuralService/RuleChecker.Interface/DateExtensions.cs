using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace RuleChecker.Interface
{
    public enum DateInterval
    {
        Year,
        Quarter,
        Month,
        DayOfYear,
        Day,
        WeekOfYear,
        Weekday,
        Hour,
        Minute,
        Second
    }

    public enum FirstDayOfWeek
    {
        System,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum FirstWeekOfYear
    {
        System,
        Jan1,
        FirstFourDays,
        FirstFullWeek
    }

    public static class DateExtensions
    {
        private static readonly CultureInfo _ci = CultureInfo.CreateSpecificCulture("tr-TR");

        public static readonly DayOfWeek[] Weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };

        public static string GetDateString(this DateTime? source)
        {
            if (!source.HasValue)
                return string.Empty;

            return source.Value.ToString("dd.MM.yyyy", _ci);
        }

        public static string GetDateString(this DateTime source)
        {
            return source.ToString("dd.MM.yyyy", _ci);
        }

        public static string GetToDateStringWithTime(this DateTime source)
        {
            return source.ToString("dd.MM.yyyy HH:mm:ss", _ci);
        }

        private static Calendar CurrentCalendar
        {
            get
            {
                return CultureInfo.CurrentCulture.Calendar;
            }
        }

        private static DateTimeFormatInfo GetDateTimeFormatInfo()
        {
            return CultureInfo.CurrentCulture.DateTimeFormat;
        }

        private static int GetDayOfWeek(DateTime dt, FirstDayOfWeek weekdayFirst)
        {
            if ((weekdayFirst < FirstDayOfWeek.System) || (weekdayFirst > FirstDayOfWeek.Saturday))
            {
                throw new ArgumentOutOfRangeException(nameof(weekdayFirst));
            }
            if (weekdayFirst == FirstDayOfWeek.System)
            {
                weekdayFirst = (FirstDayOfWeek)(GetDateTimeFormatInfo().FirstDayOfWeek + 1);
            }
            return (((int)(((dt.DayOfWeek - ((DayOfWeek)((int)weekdayFirst))) + 8) % (int)(DayOfWeek.Saturday | DayOfWeek.Monday))) + 1);
        }

        public static long DateDiff(DateInterval Interval, DateTime Date1, DateTime Date2)
        {
            return DateDiff(Interval, Date1, Date2, FirstDayOfWeek.System, FirstWeekOfYear.System);
        }

        public static long DateDiff(DateInterval Interval, DateTime Date1, DateTime Date2, FirstDayOfWeek DayOfWeek, FirstWeekOfYear WeekOfYear)
        {
            Calendar currentCalendar;
            TimeSpan span = Date1.Subtract(Date2);
            switch (Interval)
            {
                case DateInterval.Year:
                    currentCalendar = CurrentCalendar;
                    return (long)(currentCalendar.GetYear(Date1) - currentCalendar.GetYear(Date2));

                case DateInterval.Quarter:
                    currentCalendar = CurrentCalendar;
                    return (long)((((currentCalendar.GetYear(Date1) - currentCalendar.GetYear(Date2)) * 4) + ((currentCalendar.GetMonth(Date1) - 1) / 3)) - ((currentCalendar.GetMonth(Date2) - 1) / 3));

                case DateInterval.Month:
                    currentCalendar = CurrentCalendar;
                    return (long)((((currentCalendar.GetYear(Date1) - currentCalendar.GetYear(Date2)) * 12) + currentCalendar.GetMonth(Date1)) - currentCalendar.GetMonth(Date2));

                case DateInterval.DayOfYear:
                case DateInterval.Day:
                    return (long)Math.Round(Fix(span.TotalDays));

                case DateInterval.WeekOfYear:
                    Date2 = Date2.AddDays((double)(0 - GetDayOfWeek(Date2, DayOfWeek)));
                    Date1 = Date1.AddDays((double)(0 - GetDayOfWeek(Date1, DayOfWeek)));
                    return (((long)Math.Round(Fix(Date1.Subtract(Date2).TotalDays))) / 7L);

                case DateInterval.Weekday:
                    return (((long)Math.Round(Fix(span.TotalDays))) / 7L);

                case DateInterval.Hour:
                    return (long)Math.Round(Fix(span.TotalHours));

                case DateInterval.Minute:
                    return (long)Math.Round(Fix(span.TotalMinutes));

                case DateInterval.Second:
                    return (long)Math.Round(Fix(span.TotalSeconds));
            }

            throw new ArgumentOutOfRangeException(nameof(Interval));
        }


        public static double Fix(double Number)
        {
            if (Number >= 0.0)
            {
                return Math.Floor(Number);
            }
            return -Math.Floor(-Number);
        }

        public static string ToDateTerm(this DateTime src)
        {
            const string DateFormat = "dd.MM.yyyy";

            return string.Format("TO_DATE('{0}','{1}')", src.ToString(DateFormat, _ci), DateFormat);
        }

        public static IEnumerable<int> BusinessDaysInMonth(this DateTime src)
        {
            int daysInMonth = DateTime.DaysInMonth(src.Year, src.Month);

            var businessDaysInMonth = Enumerable.Range(1, daysInMonth)
                .Where(d => !Weekends.Contains(new DateTime(src.Year, src.Month, d).DayOfWeek));

            return businessDaysInMonth;
        }

        public static bool IsBusinessDay(this DateTime src)
        {
            if (!Weekends.Contains(src.DayOfWeek))
                return true;

            return false;
        }

        public static DateTime? Get1900Date(this DateTime? src)
        {
            if (!src.HasValue)
                return src;

            var dstDateTime = new DateTime(1900, 1, 1, src.Value.Hour, src.Value.Minute, src.Value.Second);

            return dstDateTime;
        }

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }
    }
}
