namespace WetherViewer.Models.API.Location.City
{
    public class CitiesBody
    {
        public string Country { get; set; }

        public CitiesBody(string country)
        {
            Country = country;
        }
    }
}
