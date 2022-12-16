using System.Text.Json.Serialization;

namespace WetherViewer.Models.API.Location.City
{
    public class LocationCity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("local_names")]
        public object LocalNames { get; set; } = new();
        [JsonPropertyName("lat")]
        public double Lat { get; set; } = double.MaxValue;
        [JsonPropertyName("lon")]
        public double Lot { get; set; } = double.MaxValue;
        [JsonPropertyName("country")]
        public string Coutry { get; set; } = string.Empty;
    }
}
