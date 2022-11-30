
using System.Text.Json.Serialization;

namespace WetherViewer.Models.Respones.RepsoneCities
{
    public class ResponeCitiesJSON
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; } = true;
        [JsonPropertyName("msg")]
        public string Msg { get; set; } = string.Empty;
        [JsonPropertyName("data")]
        public List<string> Data { get; set; } = new List<string>(); 

    }
}
