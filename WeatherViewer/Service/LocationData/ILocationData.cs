using WetherViewer.Models.API.Location.City;
using WetherViewer.Models.API.Location.Country;

namespace WetherViewer.Service.LocationData
 
{
    public interface ILocationData
    {
        public Task<LocationCity> GetLocation(CountryBody body ,string city);
    }
}