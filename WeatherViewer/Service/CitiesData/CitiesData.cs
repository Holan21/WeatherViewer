using WetherViewer.Data.APIProviders.City;

namespace WetherViewer.Service.CitiesData
{
    internal class CitiesData : ICities
    {
        public async Task<List<string>> GetCities(string country)
        {
            CityJSONAPI cityReqest = new CityJSONAPI();
            return await cityReqest.GetCities(country);
        }
    }
}