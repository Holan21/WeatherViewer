using WetherViewer.Data.APIProviders.City;

namespace WetherViewer.Service.CitiesData
{
    internal class CitiesData : ICitiesData
    {
        public async Task<List<object>> getCitys(string country)
        {
            CityJSONAPI cityReqest = new CityJSONAPI();
            return await cityReqest.sendReqest(country);
        }
    }
}