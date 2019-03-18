using System;

namespace WebAPI.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var todayDays = (today.Year * 100 + today.Month) * 100 + today.Day;
            var birthDays = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (todayDays - birthDays) / 10000;
        }
    }
}
