namespace WetherViewer.Data.APIProviders.Location
{
    internal interface ILocationAPI
    {
        public Task<Models.API.Location> GetLocation(string Country);
    }
}
