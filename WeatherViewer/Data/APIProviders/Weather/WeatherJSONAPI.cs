using System.Text.Json;
using WetherViewer.Models.API.Location.Country;
using WetherViewer.Service.LocationData;
using WetherViewer.Service.Managers;
using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherData
    {
        private const string _apikey = ConstManager.ApiKeyWeather;
        private const string _url = ConstManager.UrlWeather;

        private readonly ILocationData _locationService;

        public WeatherJSONAPI()
        {
            _locationService = ServiceManager.GetService<ILocationData>();
        }

        public async Task<Models.API.Weather.Weather> GetWeather(string country, string city)
        {
            var body = new CountryBody(country);
            var location = await _locationService.GetLocation(body, city);

            var urlFull = _url + $"?lat={location.Lat}&lon={location.Lot}&units={"metric"}&appid={_apikey}";

            HttpClient client = new();

            var respone = await client.GetAsync(urlFull);
            var json = await respone.Content.ReadAsStringAsync();
            json = json.Replace("[", "").Replace("]", "");

            var weather = JsonSerializer.Deserialize<Models.API.Weather.Weather>(json);
            return weather;
        }
    }
}