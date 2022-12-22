using System.Net.Http.Json;
using System.Text.Json;
using WetherViewer.Models.API.Location;
using WetherViewer.Models.API.Location.City;
using WetherViewer.Service.CitiesData;
using WetherViewer.Service.Exceptions;
using WetherViewer.Service.Managers;

namespace WetherViewer.Data.APIProviders.City
{

    internal class CitiesJSONAPI : ICitiesData
    {
        private readonly string _url = ConstManager.UrlCities;

        public async Task<List<string>> GetCities(CitiesBody body)
        {
            HttpClient client = new();

            var jsonBody = JsonContent.Create(body);

            var respone = await client.PostAsync(_url, jsonBody);
            var cities = JsonSerializer.Deserialize<BaseResponse<List<string>>>(await respone.Content.ReadAsStreamAsync());

            if (cities.Msg == "country not found") throw new CountryNotFound("Can't found country");

            return cities.Data;
        }
    }
}