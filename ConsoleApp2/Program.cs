using JolpicaF1CSharp;
using Newtonsoft.Json;

namespace main
{
    internal class Program
    {
        static void Main()
        {

            JolpicaF1Reader jolpicaF1Reader = new JolpicaF1Reader();
            test2(jolpicaF1Reader).Wait();
        }
    
        public static async Task test2(JolpicaF1Reader jolpicaF1Reader)
        {
            var temp = new SeasonQuery()
                .GenerateQuery("100");
            var query = await jolpicaF1Reader.Query(temp);

            if (query is null)
            {
                Console.WriteLine("query is null");
                return;
            }

            var apiResponse = JsonConvert.DeserializeObject<Root>(query);

            var driverStandingDatas = apiResponse.GetTarget<SeasonData>();
            if (driverStandingDatas is null) return;

            foreach (SeasonData data in driverStandingDatas)
                Console.WriteLine($"{data.season}, {data.url}");
        }
    }
}
