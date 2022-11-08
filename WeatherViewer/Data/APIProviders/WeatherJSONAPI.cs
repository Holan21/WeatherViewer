using WetherViewer.Models.API;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders
{
    public class WeatherJSONAPI : IWeatherData
    {
        public Task<Weather> GetWeather(Models.API.Location location)
        {
            throw new NotImplementedException();
        }
    }
}