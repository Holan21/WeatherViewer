using System.Text.Json.Serialization;

namespace WetherViewer.Models.API.Weather
{

    public class Weather
    {
        [JsonPropertyName("coord")]
        public Cordinate Cord { get; set; } = new();
        [JsonPropertyName("weather")]
        public AboutWeather AboutWeather { get; set; } = new();
        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;
        [JsonPropertyName("main")]
        public Main Main { get; set; } = new();
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; } = int.MaxValue;
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = new();
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; } = new();
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; } = new();
        [JsonPropertyName("dt")]
        public int DateTime { get; set; } = int.MaxValue;
        [JsonPropertyName("sys")]
        public System System { get; set; } = new();
        [JsonPropertyName("timezone")]
        public int TimeZone { get; set; } = int.MaxValue;
        [JsonPropertyName("id")]
        public int Id { get; set; } = int.MaxValue;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("200")]
        public int Code { get; set; } = int.MaxValue;
    }

    public class Cordinate
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; } = double.MaxValue;
        [JsonPropertyName("lat")]
        public double Lat { get; set; } = double.MaxValue;
    }

    public class AboutWeather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = int.MaxValue;
        [JsonPropertyName("main")]
        public string Main { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; } = double.MaxValue;
        [JsonPropertyName("feels_like")]
        public double TypeTemperature { get; set; } = double.MaxValue;
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; } = int.MaxValue;
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; } = int.MaxValue;
        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; } = int.MaxValue;
        [JsonPropertyName("grnd_level")]
        public int GroundLevel { get; set; } = int.MaxValue;
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; } = double.MaxValue;
        [JsonPropertyName("deg")]
        public int Direction { get; set; } = int.MaxValue;
        [JsonPropertyName("gust")]
        public double Gust { get; set; } = double.MaxValue;
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; } = int.MaxValue;
    }

    public class Rain
    {
        [JsonPropertyName("1h")]
        public double Rain1Hour { get; set; } = double.MaxValue;
        [JsonPropertyName("3h")]
        public double Rain3Hour { get; set; } = double.MaxValue;
    }

    public class System
    {
        [JsonPropertyName("type")]
        public int Type { get; set; } = int.MaxValue;
        [JsonPropertyName("id")]
        public int Id { get; set; } = int.MaxValue;
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; } = int.MaxValue;
        [JsonPropertyName("sunset")]
        public int Sunset { get; set; } = int.MaxValue;
    }
}