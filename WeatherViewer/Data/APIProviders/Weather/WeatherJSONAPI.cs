using System.Text.Json;

using WetherViewer.Service.LocationData;

/* Unmerged change from project 'WeatherViewer (net6.0-android)'
Before:
using WetherViewer.Service.WeatherData;
After:
using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.WeatherData;
*/

/* Unmerged change from project 'WeatherViewer (net6.0-ios)'
Before:
using WetherViewer.Service.WeatherData;
After:
using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.ServiceManager.ServiceManager;
using WetherViewer.Service.ServiceManager.ServiceManager.ServiceManager;
using WetherViewer.Service.WeatherData;
*/

/* Unmerged change from project 'WeatherViewer (net6.0-maccatalyst)'
Before:
using WetherViewer.Service.WeatherData;
After:
using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.ServiceManager.ServiceManager;
using WetherViewer.Service.WeatherData;
*/

using WetherViewer.Service.ServiceManager;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherData
    {
        private const string _apikey = "751bc61019f1d402468490157e578fa2";
        private const string _url = @"https://api.openweathermap.org/data/2.5/weather";

        private readonly ILocationData _locationService;

        public WeatherJSONAPI()
        {
            _locationService = ServiceManager.GetService<ILocationData>();
        }

        public async Task<Models.API.Weather.Weather> GetWeather(string country, string city)
        {
            Models.API.Weather.Weather weather = new();
            Models.API.Location.City.LocationCity location = await _locationService.GetLocation(country, city, _apikey);

            var urlFull = _url + $"?lat={location.Lat}&lon={location.Lot}&units={"metric"}&appid={_apikey}";
            HttpClient client = new();
            var respone = await client.GetAsync(urlFull);
            var json = await respone.Content.ReadAsStringAsync();
            json = json.Replace("[", "").Replace("]", "");

            weather = JsonSerializer.Deserialize<Models.API.Weather.Weather>(json);
            return weather;
        }
    }
}