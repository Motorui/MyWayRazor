using System;

namespace MyWayRazor.Converters
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        string GetDateString(int year, int month, int day);
        DateTime TryParse(string sqlDateString);
    }

    public class SqlDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;

        public string GetDateString(int year, int month, int day)
        {
            return new DateTime(day, month, year).ToString("dd-MM-yyyy");
        }

        public DateTime TryParse(string sqlDateString)
        {
            var result = new DateTime();
            DateTime.TryParse(sqlDateString, out result);
            return result;
        }
    }
}
