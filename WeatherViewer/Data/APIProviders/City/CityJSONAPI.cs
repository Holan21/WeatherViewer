using System.Text.Json;
using WetherViewer.Models.Respones.RepsoneCities;
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
                var body = new FormUrlEncodedContent(values);
                var respone = await client.PostAsync(_url, body);
                var json = JsonSerializer.Deserialize<ResponeCitiesJSON>(await respone.Content.ReadAsStreamAsync());
                if (json.getMsg() == "country not found")  throw new CountryNotFound("Can't found country"); 
                var cities = json.getData();
                for (int i = 0; i < cities.Length; i++) listCities.Add(cities[i]);
            });
            return listCities; 
        }
    }
}
