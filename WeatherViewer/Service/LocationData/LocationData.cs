using System.Text.Json;
using WetherViewer.Data.APIProviders.Location;
using WetherViewer.Models.API;
using Location = WetherViewer.Models.API.Location;

namespace WetherViewer.Service.LocationData
{
    internal class LocationData : ILocationData
    {        
        public async Task<Location> GetLocation(string Country )
        {
            return await (new LocationJSONAPI()).GetLocation( Country );
        }
    }
}
