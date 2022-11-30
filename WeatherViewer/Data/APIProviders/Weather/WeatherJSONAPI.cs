using System.Text.Json;
using WetherViewer.Models.API;
using WetherViewer.Models.Respones.ResponeWeather;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherAPI
    {
        private readonly string _url = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly string _apikey = "751bc61019f1d402468490157e578fa2";
        public async Task<Models.API.Weather> SendReqest(Models.API.Location location)
        {
            Models.API.Weather weather = new Models.API.Weather();
            /*await Task.Run(async () =>
            {
                var urlFull = _url + $"?lat={location.GetLat()}&lon={location.GetLong()}&units={"metric"}&appid={_apikey}";
                HttpClient client = new HttpClient();
                var respone = await client.GetAsync(urlFull);
                var weatherData = JsonSerializer.Deserialize<ResponeWeatherJSON>(await respone.Content.ReadAsStreamAsync());
            });*/
            return weather; 
        }
    }
}