namespace WetherViewer.Models.API.Location.Country
{
    public class CountryBody
    {
        public string Country { get; set; }

        public CountryBody(string country)
        {
            Country = country;
        }
    }
}
