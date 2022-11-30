﻿using System.Text.Json.Serialization;

namespace WetherViewer.Models.API
{
    public class Location
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; } = string.Empty;

        [JsonPropertyName("error")]
        public bool IsError { get; set; } = false;

        [JsonPropertyName("data")]
        public LocationData Data { get; set; } = new();
    }
}