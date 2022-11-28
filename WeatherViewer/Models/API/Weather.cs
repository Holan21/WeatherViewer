namespace WetherViewer.Models.API
{
    public class Weather
    {
        public Weather(int Temperature = int.MaxValue, int Pressure = int.MaxValue , int WindSpeed = int.MaxValue , string WeatherStatus = "", string WindDirection = "")
        {
            this._temperature = Temperature;
            this._pressure = Pressure;
            this._windSpeed = WindSpeed;
            this._weatherStatus = WeatherStatus;
            this._windDirection = WindDirection;
        }
        private int _temperature { get;} = int.MaxValue;
        private int _pressure { get;} = int.MaxValue;
        private int _windSpeed { get;} = int.MaxValue;
        private string _weatherStatus { get;} = string.Empty; //rain , snowly
        private string _windDirection { get;} = string.Empty; //North, east


        public int getTemperature()
        {
            return _temperature; 
        }
    }
}