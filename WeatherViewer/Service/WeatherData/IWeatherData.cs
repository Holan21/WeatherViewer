using WetherViewer.Models.API;
using Location = WetherViewer.Models.API.Location;

namespace WetherViewer.Service.WeatherData
{
    public interface IWeatherData
    {
        Task<Weather> GetWeather();
    }
}