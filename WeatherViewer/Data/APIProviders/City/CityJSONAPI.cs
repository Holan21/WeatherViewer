using System.Text.Json;

using WetherViewer.Models.API;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.Errors;

namespace WetherViewer.Data.APIProviders.City
{
    internal class CitiesJSONAPI : ICitiesData
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/cities";

        public async Task<List<string>> GetCities(string coutnry)
        {
            HttpClient client = new();

            var body = new FormUrlEncodedContent(
                new Dictionary<string, string>
                {
                    {"country" ,coutnry},
                }
            );

            var respone = await client.PostAsync(_url, body);
            var cities = JsonSerializer.Deserialize<BaseResponse<List<string>>>(await respone.Content.ReadAsStreamAsync());

            if (cities.Msg == "country not found") throw new CountryNotFound("Can't found country");

            return cities.Data;
        }
    }
}