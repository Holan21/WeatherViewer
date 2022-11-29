using WetherViewer.Data.APIProviders.City;
using WetherViewer.Service.CitiesData.Errros;
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