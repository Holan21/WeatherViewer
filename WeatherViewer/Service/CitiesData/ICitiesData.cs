namespace WetherViewer.Service.CitiesData
{
    internal interface ICities
    {
        Task<List<string>> GetCities(string coutnry);
    }
}