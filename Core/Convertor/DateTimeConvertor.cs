using System;
using System.Globalization;

namespace Core
{
    public static class DateTimeConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar p = new PersianCalendar();
            return p.GetYear(value) + "/" + p.GetMonth(value).ToString("00") + "/" + p.GetDayOfMonth(value).ToString("00");
        }
    }
}