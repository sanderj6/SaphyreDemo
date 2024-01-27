using System.Text.RegularExpressions;

namespace SaphyreDemo.Helpers.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Splits a CamelCased object name into space delimited words.
        /// </summary>
        /// <returns>The string split into words</returns>
        public static string FromCamelCase(this string value)
        {
            return Regex.Replace(
                Regex.Replace(value, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"),
                @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

    }
}
