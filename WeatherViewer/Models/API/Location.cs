namespace WetherViewer.Models.API
{
    public class Location
    {
        public Location(string Country, string City)
        {
            this.Country = Country;
            this.City = City;
        }

        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}