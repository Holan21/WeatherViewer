using System.Text.Json;
using WetherViewer.Data.APIProviders.Location;
using WetherViewer.Models.API;
using Location = WetherViewer.Models.API.Location;

namespace WetherViewer.Service.LocationData
{
    internal class LocationData : ILocationData
    {
        private readonly string _url = @"https://countriesnow.space/api/v0.1/countries/positions";
        
        public async Task<Location> GetLocation(string Country)
        {
            return await (new LocationJSONAPI()).GetLocation(Country) ;
        }
    }
}
