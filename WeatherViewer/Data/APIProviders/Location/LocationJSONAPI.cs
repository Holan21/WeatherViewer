using System.Text.Json;
using WetherViewer.Service.LocationData;

namespace WetherViewer.Data.APIProviders.Location
{
    internal class LocationJSONAPI : ILocationData
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/positions";

        public async Task<Models.API.Location> GetLocation( string Country)
        {
            Models.API.Location lolcationData = new Models.API.Location();
            Dictionary<string, string> bodyDictionary = new Dictionary<string, string>
            {
                { "country", Country},
            };
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var body = new FormUrlEncodedContent(bodyDictionary);
                var respone = await client.PostAsync(_url , body);
                string jsonString = await respone.Content.ReadAsStringAsync();
                lolcationData = JsonSerializer.Deserialize<Models.API.Location>(await respone.Content.ReadAsStreamAsync());
            });
            return lolcationData;
        }
    }
}
