using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using WetherViewer.Models.API.JSON;
using WetherViewer.Service.CitiesData;

namespace WetherViewer.Data.APIProviders.City
{
    internal class CityJSONAPI : ICityAPI
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/cities";
        public async Task<ResponeJSON> sendReqestGetJSON(string coutnry)
        {
            ResponeJSON json = null;
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    {"country" ,coutnry},
                };
                var content = new FormUrlEncodedContent(values);
                var respone = await client.PostAsync(_url, content);
                json = JsonSerializer.Deserialize<ResponeJSON>(respone.Content.ReadAsStream());
            });
            return json; 
        }
    }
}
