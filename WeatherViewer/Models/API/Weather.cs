namespace WetherViewer.Models.API
{
    // TODO: Круто, но переделай!

    public class Weather
    {
        public int Temperature { get; } = int.MaxValue;

        public Weather(int Temperature = int.MaxValue, int Pressure = int.MaxValue, int WindSpeed = int.MaxValue, string WeatherStatus = "", string WindDirection = "")
        {
            _temperature = Temperature;
            _pressure = Pressure;
            _windSpeed = WindSpeed;
            _weatherStatus = WeatherStatus;
            _windDirection = WindDirection;
        }

        private int _temperature { get; } = int.MaxValue;
        private int _pressure { get; } = int.MaxValue;
        private int _windSpeed { get; } = int.MaxValue;
        private string _weatherStatus { get; } = string.Empty; //rain , snowly
        private string _windDirection { get; } = string.Empty; //North, east

        public int GetTemperature()
        {
            return _temperature;
        }
    }
}