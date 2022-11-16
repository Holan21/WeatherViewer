using System.Diagnostics.Metrics;

namespace WetherViewer.Service.CitiesData
{
    internal class CitiesData : ICitiesData
    {
        public List<string> getCitys(string country)
        {
            List<string> _citys = new List<string>();
            switch (country.Trim().ToLower())
            {
                case "ukraine": _citys.Add("Kyiv"); _citys.Add("Mykolaev"); _citys.Add("Herson"); break;
                case "usa": _citys.Add("Washington"); _citys.Add("New-York"); break;
                case "hallownest": _citys.Add("City Tear"); break;
            }
            return _citys;
        }
    }
}