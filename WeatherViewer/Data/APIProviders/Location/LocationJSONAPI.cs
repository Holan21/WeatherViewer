using System.Text.Json;
using WetherViewer.Models.Respones.ResponesLocation;

namespace WetherViewer.Data.APIProviders.Location
{
    internal class LocationJSONAPI : ILocationAPI
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/positions";

        public async Task<Models.API.Location> GetLocation( string Country)
        {
            Models.API.Location Location = new Models.API.Location();
            Dictionary<string, string> ValuesBody = new Dictionary<string, string>
            {
                { "country" , Country }
            };
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var body = new FormUrlEncodedContent(ValuesBody);
                var respone = await client.PostAsync(_url, body);
                var stringJson = await respone.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<ResponeLocationJSON>(await respone.Content.ReadAsStreamAsync());
                Location = json.getData();
                
            });
            return Location;
        }
    }
}
