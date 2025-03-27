using System.Reflection;
using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public interface IBaseQuery { }
    public abstract class BaseQuery<T>
    {
        protected readonly QueryBuilder<T> QueryBuilder;
        private readonly string DefaultQuery;
        private readonly string EndQuery;

        private readonly Type type;
        private readonly Dictionary<string, string> filters;
        private string baseQuery;

        protected BaseQuery(string baseQuery, string endQuery)
        {
            type = typeof(T);
            filters = new Dictionary<string, string>();

            EndQuery = endQuery;
            DefaultQuery = baseQuery;
            this.baseQuery = baseQuery;
            QueryBuilder = new QueryBuilder<T>(DefaultQuery);
        }

        public void Reset()
        {
            filters.Clear();
            this.baseQuery = DefaultQuery;
        }

        public string GenerateQuery()
        {
            var query = baseQuery;
            if (filters.Any())
            {
                query += "/" + string.Join("/", filters.Values);
            }

            return query + EndQuery;
        }

        public BaseQuery<T> Filter<TValue>(string propertyName, TValue value)
        {
            var jsonPropertyName = GetPropertyName(propertyName);
            var filter = GetFilterString(jsonPropertyName, value);
            
            if (filters.TryGetValue(jsonPropertyName, out var filterValue))
                filters[jsonPropertyName] = filter;
            else
                filters.Add(jsonPropertyName, filter);

                return this;
        }

        private string GetPropertyName(string propertyName)
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
                stringValue = FormateDateTime(dateTime);

            return propertyName switch
            {
                "drivers" => $"{propertyName}/{stringValue}",
                _ => $"{stringValue}"
            };
        }

        public static string FormateDateTime<TValue>(TValue value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (value is DateTime dateTime)
                return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            return value?.ToString() ?? string.Empty;
        }
    }
}
