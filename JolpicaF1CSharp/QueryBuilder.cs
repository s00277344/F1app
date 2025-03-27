using System.Reflection;
using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public class QueryBuilder<T>
    {
        private readonly Type type;
        private readonly List<string> filters;
        private string baseQuery;

        public QueryBuilder(string baseQuery)
        {
            type = typeof(T);
            filters = new List<string>();
            this.baseQuery = baseQuery;
        }

        public void Reset(string baseQuery)
        {
            filters.Clear();
            this.baseQuery = baseQuery;
        }

        public QueryBuilder<T> Filter<TValue>(string propertyName, TValue value)
        {
            var jsonPropertyName = GetPropertyName(propertyName);
            var filter = GetFilterString(jsonPropertyName, value);
            filters.Add(filter);
            return this;
        }

        public string Build()
        {
            var query = baseQuery;
            if (filters.Any())
                query += "/" + string.Join("/", filters);

            return query;
        }

        public string GetPropertyName(string propertyName)
        {
            var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (property is null)
                throw new ArgumentException($"Property '{propertyName}' not found on type '{type.FullName}'");

            var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            return attribute?.PropertyName ?? propertyName;
        }

        private string GetFilterString<TValue>(string propertyName, TValue value)
        {
            string stringValue = value.ToString();

            if (value is DateTime dateTime)
                stringValue = FormatDateTime(dateTime);

            return $"{propertyName}={stringValue}";
        }

        public static string FormatDateTime<TValue>(TValue value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (value is DateTime dateTime)
                return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            return value?.ToString() ?? string.Empty;
        }
    }
}
