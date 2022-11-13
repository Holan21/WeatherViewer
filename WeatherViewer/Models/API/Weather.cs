namespace WetherViewer.Models.API
{
    public class Weather
    {
        public int Temperature { get; set; } = int.MaxValue;
        public int Pressure { get; set; } = int.MaxValue;
        public int WindSpeed { get; set; } = int.MaxValue;
        public string WeatherStatus { get; set; } = string.Empty; //rain , snowly
        public string WindDirection { get; set; } = string.Empty; //North, east
    }
}