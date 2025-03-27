namespace JolpicaF1CSharp
{
    public class JolpicaF1Reader : IDisposable
    {
        private readonly HttpClient client;

        public JolpicaF1Reader()
        {
            client = new HttpClient();
        }

        public async Task<string> Query(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
