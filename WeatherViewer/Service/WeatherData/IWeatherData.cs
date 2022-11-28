using WetherViewer.Models.API;

namespace WetherViewer.Service.WeatherData
{
    public interface IWeatherData
    {
        Task<Models.API.Weather> GetWeather();
    }
}