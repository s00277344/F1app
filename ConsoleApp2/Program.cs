using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using OpenF1CSharp;

namespace main
{
    internal class Program
    {
        static void Main()
        {
            OpenF1Reader openF1Reader = new OpenF1Reader();
            test(openF1Reader).Wait();
        }
        public static async Task test(OpenF1Reader openF1Reader)
        {
            var rawData = await openF1Reader.Query(new CarQuery()
                .Filter(nameof(CarData.DriverNumber), 16)
                .Filter(nameof(CarData.SessionKey), 9159)
                .Filter(nameof(CarData.Speed), 315, ComparisonOperator.GreaterThanOrEqual)
                .Filter(nameof(CarData.Date), new DateTime(2023, 9, 15, 13, 35, 41), ComparisonOperator.GreaterThanOrEqual)
                .GenerateQuery());
            if (rawData == null)
            {
                Console.WriteLine("returned null");
                return;
            }
            List<CarData> carData = JsonConvert.DeserializeObject<List<CarData>>(rawData);

            foreach (CarData data in carData)
            {
                Type type = typeof(CarData);
                foreach (System.Reflection.PropertyInfo field in type.GetProperties())
                {
                    Console.WriteLine($"{field.Name}: {field.GetValue(data)}");
                }
                Console.WriteLine();
            }
        }
    }
}
