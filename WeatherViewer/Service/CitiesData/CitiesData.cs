using WetherViewer.Data.APIProviders.City;
using WetherViewer.Service.CitiesData.Errros;
namespace WetherViewer.Service.CitiesData
{
    internal class CitiesData : ICitiesData
    {
        public async Task<List<object>> getCitys(string country)
        {
            List<object> listCities = new List<object>();
            CityJSONAPI cityReqest = new CityJSONAPI();
            var json = await cityReqest.sendReqestGetJSON(country);
            if (json.getMsg() == "country not found") { throw new CountryNotFound("Can't found country"); }
            var cities = json.getData();
            for (int i = 0; i < cities.Length; i++) listCities.Add(cities[i]);
            return listCities;
        }
    }
}