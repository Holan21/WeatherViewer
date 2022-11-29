using System.Text.Json;
using WetherViewer.Models.API;
using WetherViewer.Models.Respones.ResponeWeather;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherAPI
    {
        private readonly string _url = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly string APIKEY = "751bc61019f1d402468490157e578fa2";
        public async Task<Models.API.Weather> sendReqest(Models.API.Location location)
        {
            Models.API.Weather weather = new Models.API.Weather();
            await Task.Run(async () =>
            {
                var _urlFull = _url + $"?lat={location.getLat()}&lon={location.getLong()}&units={"metric"}&appid={APIKEY}";
                HttpClient client = new HttpClient();
                var respone = await client.GetAsync(_urlFull);
                var json = JsonSerializer.Deserialize<ResponeWeatherJSON>(await respone.Content.ReadAsStreamAsync());
                var data = json;
            });
            return weather; 
        }
    }
}