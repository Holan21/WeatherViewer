using WetherViewer.Models.API;
using Location = WetherViewer.Models.API.Location;

namespace WetherViewer.Service.WeatherData
{
    public class WeatherData : IWeatherData
    {

        private Location _location;

        public WeatherData(Location Location)
        {
            _location = Location;
        }

        public async Task<Weather> GetWeather()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Weather weather = new Weather();
                weather.Temperature = new Random().Next(-50 , 50);
                return weather;
            });
        }
    }
}