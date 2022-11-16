namespace WetherViewer.Models.API
{
    public class Weather
    {
        public Weather(int Temperature = int.MaxValue, int Pressure = int.MaxValue , int WindSpeed = int.MaxValue , string WeatherStatus = "", string WindDirection = "")
        {
            this.Temperature = Temperature;
            this.Pressure = Pressure;
            this.WindSpeed = WindSpeed;
            this.WeatherStatus = WeatherStatus;
            this.WindDirection = WindDirection;
        }
        public int Temperature { get; set; } = int.MaxValue;
        public int Pressure { get; set; } = int.MaxValue;
        public int WindSpeed { get; set; } = int.MaxValue;
        public string WeatherStatus { get; set; } = string.Empty; //rain , snowly
        public string WindDirection { get; set; } = string.Empty; //North, east
    }
}