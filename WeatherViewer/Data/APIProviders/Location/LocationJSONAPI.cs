using Android.OS;

using System.Text.Json;

using WetherViewer.Models.API;
using WetherViewer.Service.LocationData;

namespace WetherViewer.Data.APIProviders.Location
{
    internal class LocationJSONAPI : ILocationData
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/positions";

        public async Task<LocationData> GetLocation(string country)
        {
            Dictionary<string, string> bodyDictionary = new()
            {
                { "country", country },
            };

            HttpClient client = new();

            var body = new FormUrlEncodedContent(bodyDictionary);
            var respone = await client.PostAsync(_url, body);

            var locationData = JsonSerializer.Deserialize<BaseResponse<LocationData>>(await respone.Content.ReadAsStreamAsync());
            return locationData.Data;
        }
    }
}