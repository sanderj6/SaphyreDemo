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
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return Regex.Replace(
                Regex.Replace(value, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"),
                @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        public static async Task<List<T>> SearchModelForValue<T>(List<T> records, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return records;
            }

            List<T> filteredRecords = new();
            searchTerm = searchTerm.ToUpper().Trim();
            var properties = typeof(T).GetProperties();

            foreach (var record in records)
            {
                foreach (var property in properties)
                {
                    var propValue = property.GetValue(record);
                    if (propValue == null) continue;

                    var value = propValue.ToString();

                    if (value.ToUpper().Contains(searchTerm))
                    {
                        filteredRecords.Add(record);
                        break;
                    }
                }
            }

            return filteredRecords;
        }

    }
}
