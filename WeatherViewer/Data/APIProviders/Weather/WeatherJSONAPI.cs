using System.Text.Json;
using WetherViewer.Service;
using WetherViewer.Service.LocationData;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherData
    {
        private readonly string _url = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly string _apikey = "751bc61019f1d402468490157e578fa2";

        public async Task<Models.API.Weather.Weather> GetWeather(string country, string city)
        {
            Models.API.Weather.Weather weather = new();
            Models.API.Location.City.LocationCity location = await (ServiceManager.GetSerive<ILocationData>()).GetLocation(country, city, _apikey);
            var urlFull = _url + $"?lat={location.Lat}&lon={location.Lot}&units={"metric"}&appid={_apikey}";
            HttpClient client = new();
            var respone = await client.GetAsync(urlFull);
            var json = await respone.Content.ReadAsStringAsync();
            json = json.Replace("[", "");
            json = json.Replace("]", "");
            weather = JsonSerializer.Deserialize<Models.API.Weather.Weather>(json);
            return weather;
        }
    }
}