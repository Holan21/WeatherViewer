using System.Text.Json.Serialization;

namespace WetherViewer.Models.API.Location.Coutry
{
    public class LocationCountryData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("iso2")]
        public string Iso { get; set; } = string.Empty;

        [JsonPropertyName("lat")]
        public double Lat { get; set; } = double.MaxValue;

        [JsonPropertyName("long")]
        public double Lot { get; set; } = double.MaxValue;
    }
}