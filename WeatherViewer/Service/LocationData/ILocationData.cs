using WetherViewer.Models.API.Location.City;
namespace WetherViewer.Service.LocationData
 
{
    public interface ILocationData
    {
        public Task<LocationCity> GetLocation(string country,string city, string appID);
    }
}