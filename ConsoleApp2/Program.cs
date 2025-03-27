using JolpicaF1CSharp;
using Newtonsoft.Json;
using OpenF1CSharp;
using System.Reflection;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace main
{
    internal class Program
    {
        static void Main()
        {
            OpenF1Reader openF1Reader = new OpenF1Reader();
            //test(openF1Reader).Wait();

            JolpicaF1Reader jolpicaF1Reader = new JolpicaF1Reader();
            test2(jolpicaF1Reader).Wait();
        }
        public static async Task test(OpenF1Reader openF1Reader)
        {
            var rawData = await openF1Reader.Query(new CarQuery()
                .Filter(nameof(CarData.DriverNumber), 16)
                .Filter(nameof(CarData.SessionKey), 9159)
                .Filter(nameof(CarData.Speed), 315, ComparisonOperator.GreaterThanOrEqual)
                .Filter(nameof(CarData.Date), new DateTime(2023, 9, 15, 13, 35, 41), ComparisonOperator.GreaterThanOrEqual)
                .GenerateQuery());

            //var query = await openF1Reader.Query("https://api.openf1.org/v1/sessions?meeting_key=latest");
            var query = await openF1Reader.Query(new SessionQuery()
                .Filter(nameof(SessionData.MeetingKey), "latest")
                .GenerateQuery());

            if (rawData is null)
            {
                Console.WriteLine("returned null");
                return;
            }
            List<CarData>? carData = JsonConvert.DeserializeObject<List<CarData>>(rawData);
            List<SessionData>? queryData = JsonConvert.DeserializeObject<List<SessionData>>(query);

            /*
            if (carData != null)
                foreach (CarData data in carData)
                {
                    Type type = typeof(CarData);
                    foreach (System.Reflection.PropertyInfo field in type.GetProperties())
                    {
                        Console.WriteLine($"{field.Name}: {field.GetValue(data)}");
                    }
                    Console.WriteLine();
                }

            Console.WriteLine("drivers : \n");
            */
            if (queryData != null)
                foreach (SessionData data in queryData)
                {
                    Type type = typeof(SessionData);
                    foreach (System.Reflection.PropertyInfo field in type.GetProperties())
                    {
                        Console.WriteLine($"{field.Name}: {field.GetValue(data)}");
                    }
                    Console.WriteLine();
                }
        }
    
        public static async Task test2(JolpicaF1Reader jolpicaF1Reader)
        {
            var temp = new DriverStandingsQuery()
                .Filter(nameof(DriverStandingData.year), 2024)
                .GenerateQuery();
            var query = await jolpicaF1Reader.Query(temp);

            if (query is null)
            {
                Console.WriteLine("query is null");
                return;
            }

            var apiResponse = JsonConvert.DeserializeObject<Root>(query);

            List<DriverStandingData> driverStandingDatas = apiResponse.MRData?.StandingsTable?.StandingsLists?[0].DriverStandings ?? new List<DriverStandingData>();

            foreach (DriverStandingData data in driverStandingDatas)
                Console.WriteLine($"{data.position}. {data.Driver.givenName} {data.Driver.familyName} - {data.points} points");
        }
    }
}
