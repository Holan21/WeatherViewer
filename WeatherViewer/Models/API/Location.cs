namespace WetherViewer.Models.API
{
    public class Location
    {
        public int @long { get; set; } = int.MaxValue;
        public int lat { get; set; } = int.MaxValue;
        public string iso2 { get; set; } = string.Empty;

        public int getLong(){return @long;}
        public int getLat() { return lat; }
        public string getIso() { return iso2; }
    }
}
