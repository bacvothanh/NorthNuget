using System;
using System.Globalization;

namespace NN.Standard.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToLocalTime(this DateTimeOffset? value)
        {
            if (value.HasValue)
                return value.Value.LocalDateTime;
            return default(DateTime);
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        public static DateTimeOffset LastDayOfWeek(this DateTimeOffset dateTimeOffset)
        {
            var date = dateTimeOffset.DateTime.GetFirstDayOfWeek().AddDays(6);
            return date;
        }

        public static DateTime EndOfDay(this DateTimeOffset date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
    }
}
