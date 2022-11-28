namespace WetherViewer.Service.CitiesData
{
    internal interface ICitiesData
    {
        Task<List<object>> getCitys(string coutnry);
    }
}