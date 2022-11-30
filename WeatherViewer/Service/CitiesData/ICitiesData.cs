namespace WetherViewer.Service.CitiesData
{
    public interface ICitiesData
    {
        Task<List<string>> GetCities(string country);
    }
}