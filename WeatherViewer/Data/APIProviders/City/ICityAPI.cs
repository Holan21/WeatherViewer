namespace WetherViewer.Data.APIProviders.City
{
    internal interface ICityAPI
    {
        public Task<List<object>> sendReqest(string coutnry);
    }
}
