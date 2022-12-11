using WetherViewer.Models.API;

namespace WetherViewer.Service.WeatherData
{
    public interface IWeatherData
    {
        public Task<Weather> GetWeather();
    }
}