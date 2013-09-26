using System;

namespace Epiphany.Web.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Return a relative date string
        /// </summary>
        /// <param name="date"></param>
        /// <returns>A relative date (i.e. 7 minutes ago)</returns>
        /// <remarks>
        /// This code has been adapted from the answers at http://stackoverflow.com/questions/11/how-do-i-calculate-relative-time
        /// </remarks>
        public static string ToRelativeDateString(this DateTime date)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 60)
            {
                return ts.Seconds == 1
                           ? "one second ago"
                           : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                var months = Convert.ToInt32(Math.Floor((double) ts.Days/30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            var years = Convert.ToInt32(Math.Floor((double) ts.Days/365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}