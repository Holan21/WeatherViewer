using WetherViewer.Service.WeatherData;

namespace WetherViewer.Data.APIProviders.Weather
{
    public class WeatherJSONAPI : IWeatherData
    {
        public async Task<Models.API.Weather> GetWeather()
        {
            await Task.Run(() =>
            {
                
            });
            throw new Exception();
        }
    }
}