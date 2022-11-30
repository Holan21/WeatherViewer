using System.Text.Json;
using WetherViewer.Models.Respones.RepsoneCities;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.CitiesData.Errros;

namespace WetherViewer.Data.APIProviders.City
{
    internal class CityJSONAPI : ICities
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/cities";
        public async Task<List<string>> GetCities(string coutnry)
        {
            List<string> listCities = new List<string>();
            await Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var bodyDictionary = new Dictionary<string, string>
                {
                    {"country" ,coutnry},
                };
                var body = new FormUrlEncodedContent(bodyDictionary);
                var respone = await client.PostAsync(_url, body);
                var cities = JsonSerializer.Deserialize<ResponeCitiesJSON>(await respone.Content.ReadAsStreamAsync());
                if (cities.Msg == "country not found")  throw new CountryNotFound("Can't found country");
                listCities = cities.Data;
            });
            return listCities;
        }
    }
}
