namespace WetherViewer.Service.LocationData
{
    internal interface ILocationData
    {
        public Task<Models.API.Location> GetLocation( string Country);
    }
}
