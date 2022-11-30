using System.Text.Json.Serialization;

namespace WetherViewer.Models.API
{
    public class Location
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; } = string.Empty;
        [JsonPropertyName("error")]
        public bool IsError { get; set; } = false;
        [JsonPropertyName("data")]
        public Data data{ get; set; } = new Data();
    }

    public class Data
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
