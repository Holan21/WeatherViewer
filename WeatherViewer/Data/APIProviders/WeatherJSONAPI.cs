using WetherViewer.Models.API;
using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders
{
    public class WeatherJSONAPI : IWeatherData
    {

        public Task<Weather> GetWeather()
        {
            throw new NotImplementedException();
        }
    }
}