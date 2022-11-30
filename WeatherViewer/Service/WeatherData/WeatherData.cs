using WetherViewer.Data.APIProviders.Weather;
using WetherViewer.Models.API;

namespace WetherViewer.Service.WeatherData
{
    public class WeatherData : IWeatherData
    {
        public async Task<Weather> GetWeather(Models.API.Location location)
        {
            return await new WeatherJSONAPI().SendReqest(location);
        }
    }
}