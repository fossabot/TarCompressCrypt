﻿using System;

namespace TCC.Lib.Helpers
{
    public static class StringExtensions
    {
        public static string Escape(this string str)
        {
            return '"' + str.Trim('"') + '"';
        }

        public static string HumanizedBandwidth(this double bandwidth, int decimals = 2)
        {
            var ordinals = new[] { "", "K", "M", "G", "T", "P", "E" };
            var rate = (decimal)bandwidth;
            var ordinal = 0;
            while (rate > 1024)
            {
                rate /= 1024;
                ordinal++;
            }
            return String.Format("{0:n" + decimals + "} {1}b/s", Math.Round(rate, decimals, MidpointRounding.AwayFromZero), ordinals[ordinal]);
        }

        public static string HumanizedTimeSpan(this TimeSpan t, int parts = 2)
        {
            string result = string.Empty;
            if (t.TotalDays >= 1 && parts > 0)
            {
                result += $"{t.Days}d ";
                parts--;
            }
            if (t.TotalHours >= 1 && parts > 0)
            {
                result += $"{t.Hours}h ";
                parts--;
            }
            if (t.TotalMinutes >= 1 && parts > 0)
            {
                result += $"{t.Minutes}m ";
                parts--;
            }
            if (t.Seconds >= 1 && parts > 0)
            {
                result += $"{t.Seconds}s ";
                parts--;
            }
            if (t.Milliseconds >= 1 && parts > 0)
            {
                result += $"{t.Milliseconds}ms";
            }
            return result.TrimEnd();
        }

        public static string Pad(this string source, int length)
        {
            if (source == null)
            {
                return new string(' ', length);
            }
            return source.Length > length ? source.Substring(0, length) : source.PadLeft(length, ' ');
        }
    }
}