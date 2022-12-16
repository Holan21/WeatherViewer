using System.Text.Json.Serialization;

namespace WetherViewer.Models.API.Location
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; } = string.Empty;

        [JsonPropertyName("error")]
        public bool IsError { get; set; } = false;

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}