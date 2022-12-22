using System.Net.Http.Json;
using System.Text.Json;
using WetherViewer.Models.API.Location;
using WetherViewer.Models.API.Location.City;
using WetherViewer.Models.API.Location.Country;
using WetherViewer.Models.API.Location.Coutry;
using WetherViewer.Service.Exceptions;
using WetherViewer.Service.LocationData;
using WetherViewer.Service.Managers;

namespace WetherViewer.Data.APIProviders.Location
{
    internal class LocationJSONAPI : ILocationData
    {

        private const string _urlIso = ConstManager.UrlIso;
        private const string _urlDirect = ConstManager.UrlDirect;
        private const string _appKey = ConstManager.AppKeyLocation;

        public async Task<LocationCity> GetLocation(CountryBody body, string city)
        {
            HttpClient client = new();

            var jsonBody = JsonContent.Create(body);
            var respone = await client.PostAsync(_urlIso, jsonBody);
            var locationDataCountry = JsonSerializer.Deserialize<BaseResponse<LocationCountryData>>(await respone.Content.ReadAsStreamAsync());

            if (locationDataCountry.Data == null) throw new CountryNotFound();

            var fullUrl = $@"{_urlDirect}?q={city},{locationDataCountry.Data.Iso}&limit={1}&appid={_appKey}";

            respone = await client.GetAsync(fullUrl);
            var json = await respone.Content.ReadAsStringAsync();
            json = json.Replace('[', ' ');
            json = json.Replace(']', ' ');
            var locationDataCity = JsonSerializer.Deserialize<LocationCity>(json);

            return locationDataCity;
        }
    }
}