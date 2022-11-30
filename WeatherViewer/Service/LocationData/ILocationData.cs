namespace WetherViewer.Service.LocationData
{
    public interface ILocationData
    {
        public Task<Models.API.LocationData> GetLocation(string country);
    }
}