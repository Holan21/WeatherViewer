using WetherViewer.Models.API;

namespace WetherViewer.Service.WeatherData
{
    public class WeatherData : IWeatherData
    {

        private readonly string _city;

        public WeatherData(string City)
        {
            _city = City;
        }

        public async Task<Weather> GetWeather()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                return new Weather(new Random().Next(-50, 50));
            });
        }
    }
}