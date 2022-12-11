using WetherViewer.Service.LocationData;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherData
    {
        private readonly string _url = @"https://api.openweathermap.org/data/2.5/weather";
        private readonly string _apikey = "751bc61019f1d402468490157e578fa2";
        private readonly ILocationData _locationData;

        public WeatherJSONAPI(ILocationData locationData)
        {
            _locationData = locationData;
        }

        public Task<Models.API.Weather> GetWeather()
        {
            throw Exception;
        }

        //public async Task<Models.API.Weather> SendReqest()
        //{
        //    Models.API.Weather weather = new();
        //    await Task.Run(async () =>
        //    {
        //        var urlFull = _url + $"?lat={location.Lat}&lon={location.GetLong()}&units={"metric"}&appid={_apikey}";
        //        HttpClient client = new HttpClient();
        //        var respone = await client.GetAsync(urlFull);
        //        var weatherData = JsonSerializer.Deserialize<ResponeWeatherJSON>(await respone.Content.ReadAsStreamAsync());
        //    });
        //    return weather;
        //}
    }
}