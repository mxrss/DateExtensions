using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateExtensionMethods
{
    public static  class StringDateExtensions
    {
        
        public static DateTime ToDate(this string dateFormated)
        {
            return DateTime.Parse(dateFormated);
        }
    }

    public static class DateExtensions
    {
        public static int LastDayInMonth(this DateTime date)
        {
            string rootMonthString = string.Format("{0}/1/{1}", date.Month, date.Year);
            return rootMonthString.ToDate().AddMonths(1).AddDays(-1).Day;
        }
        
        public static bool IsLastDayInMonth(this DateTime date)
        {
            return date.Day == date.LastDayInMonth();

        }

        public static DateTime NextMonth(this DateTime startDate)
        {
            return GetResultingDate(startDate, 1);
        }

        public static DateTime LastMonth(this DateTime startDate)
        {
            return GetResultingDate(startDate, -1);
        }

        private static DateTime GetResultingDate(DateTime startDate, int monthLocation)
        {
            DateTime nextMonth = startDate.AddMonths(monthLocation);
            DateTime resultingDate;

            if (startDate.Day > nextMonth.LastDayInMonth())
                resultingDate = string.Format("{0}/{1}/{2}", nextMonth.Month, nextMonth.LastDayInMonth(), nextMonth.Year).ToDate();
            else
                resultingDate = string.Format("{0}/{1}/{2}", nextMonth.Month, startDate.Day, nextMonth.Year).ToDate();
            return resultingDate;
        }
    }
}
