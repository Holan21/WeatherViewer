using WetherViewer.Data.APIProviders.City;

namespace WetherViewer.Service.CitiesData
{
    internal class CitiesData : ICitiesData
    {
        public async Task<List<object>> getCitys(string country)
        {
            List<object> _citys = new List<object>();
            CityJSONAPI cityReqest = new CityJSONAPI();
            var json = await cityReqest.sendReqestGetJSON(country);
            var array = json.getData();
            for (int i = 0; i < array.Length; i++)
            {
                _citys.Add(array[i]);
            }
            return _citys;
        }
    }
}