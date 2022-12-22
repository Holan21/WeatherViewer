using System.Text.Json;

using WetherViewer.Models.API.Location;
using WetherViewer.Models.API.Location.City;
using WetherViewer.Models.API.Location.Coutry;
using WetherViewer.Service.Exceptions;
using WetherViewer.Service.LocationData;

namespace WetherViewer.Data.APIProviders.Location
{
    internal class LocationJSONAPI : ILocationData
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/positions";

        //TODO: Replace dictionary by model

        public async Task<LocationCity> GetLocation(string coutry, string city, string appID)
        {
            Dictionary<string, string> bodyDictionary = new()
            {
                { "country", coutry },
            };

            HttpClient client = new();

            var body = new FormUrlEncodedContent(bodyDictionary);
            var respone = await client.PostAsync(_url, body);
            var locationDataCountry = JsonSerializer.Deserialize<BaseResponse<LocationCountryData>>(await respone.Content.ReadAsStreamAsync());

            if (locationDataCountry.Data == null) throw new CountryNotFound();

            var fullUrl = $@"http://api.openweathermap.org/geo/1.0/direct?q={city},{locationDataCountry.Data.Iso}&limit={1}&appid={appID}";

            respone = await client.GetAsync(fullUrl);
            var json = await respone.Content.ReadAsStringAsync();
            json = json.Replace('[', ' ');
            json = json.Replace(']', ' ');
            var locationDataCity = JsonSerializer.Deserialize<LocationCity>(json);

            return locationDataCity;
        }
    }
}