using System.Reflection;
using Newtonsoft.Json;

namespace JolpicaF1CSharp
{
    public interface IBaseQuery { }
    public abstract class BaseQuery<T>
    {
        private string DefaultQuery;
        private string EndQuery;
        private string baseQuery;

        private readonly Type type;
        private readonly Dictionary<string, string> filters;
        private readonly List<string> filterOrder;
        
        protected BaseQuery(string baseQuery, string endQuery, List<string> filterOrder)
        {
            type = typeof(T);
            filters = new Dictionary<string, string>();
            this.filterOrder = filterOrder;

            EndQuery = endQuery;
            DefaultQuery = baseQuery;
            this.baseQuery = baseQuery;
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
                var filtered = filters.OrderBy(f => filterOrder.IndexOf(f.Key));
                query += "/" + string.Join("/", filtered.Select(f => $"{f.Value}"));
            }

            return query + EndQuery + ".json";
        }

        public string GenerateQuery(string limit)
        {
            var query = baseQuery;
            if (filters.Any())
            {
                var filtered = filters.OrderBy(f => filterOrder.IndexOf(f.Key));
                query += "/" + string.Join("/", filtered.Select(f => $"{f.Value}"));
            }

            return query + EndQuery + $".json?limit={limit}";
        }


        public BaseQuery<T> Filter<TValue>(string propertyName, TValue value)
        {
            var jsonPropertyName = GetPropertyName(propertyName);
            if (jsonPropertyName == "Position" || jsonPropertyName == "LapNumber" || jsonPropertyName == "StopNumber")
            {
                EndQuery += $"/{value}";
                return this;
            }
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
                "Driver" => $"drivers/{stringValue}",
                "Constructor" => $"constructors/{stringValue}",
                "Circuit" => $"circuits/{stringValue}",
                "Fastest" => $"fastest/{stringValue}",
                "Grid" => $"grid/{stringValue}",
                "Result" => $"results/{stringValue}",
                "Status" => $"status/{stringValue}",
                "Laps" => $"laps/{stringValue}",
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
