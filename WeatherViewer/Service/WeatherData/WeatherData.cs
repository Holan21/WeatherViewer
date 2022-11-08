using WetherViewer.Models.API;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Service.WeatherData
{
    public class WeatherData : IWeatherData
    {
        public Task<Weather> GetWeather(Models.API.Location location)
        {
            throw new NotImplementedException();
        }
    }
}