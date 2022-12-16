using WetherViewer.Models.API.Weather;
namespace WetherViewer.Service.WeatherData
{
    public interface IWeatherData
    {
        public Task<Weather> GetWeather(string country, string city);
    }
}