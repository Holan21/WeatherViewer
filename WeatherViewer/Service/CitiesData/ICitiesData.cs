using WetherViewer.Models.API.Location.City;

namespace WetherViewer.Service.CitiesData
{
    public interface ICitiesData
    {
        Task<List<string>> GetCities(CitiesBody request);
    }
}