using System.Text.Json;
using WetherViewer.Models.API.JSON;
using WetherViewer.Service.CitiesData.Errros;

namespace WetherViewer.Data.APIProviders.City
{
    internal class CityJSONAPI : ICityAPI
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/cities";
        public async Task<List<object>> sendReqest(string coutnry)
        {
            List<object> listCities = new List<object>();
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    {"country" ,coutnry},
                };
                var content = new FormUrlEncodedContent(values);
                var respone = await client.PostAsync(_url, content);
                var json = JsonSerializer.Deserialize<ResponeJSON>(respone.Content.ReadAsStream());
                if (json.getMsg() == "country not found") { throw new CountryNotFound("Can't found country"); }
                var cities = json.getData();
                for (int i = 0; i < cities.Length; i++) listCities.Add(cities[i]);
            });
            return listCities; 
        }
    }
}
