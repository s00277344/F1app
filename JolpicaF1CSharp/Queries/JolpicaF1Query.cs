namespace JolpicaF1CSharp
{
    public interface IJolpicaF1Query
    {
        public static string JOLPICAF1_ADDRESS = "https://api.jolpi.ca/ergast/f1";
        public string GenerateQuery();
        public void Reset();
    }
}
