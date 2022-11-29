using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherViewer.Models.Respones.ResponeWeather
{
    internal class ResponeWeatherJSON
    {
        public object coord { get; set; } = new object();
        public object weather { get; set; } = new object();
        public object @base { get; set; } = new object();
        public object main { get; set; } = new object();
        public object visibility { get; set; } = new object();
        public object wind { get; set; } = new object();
        public object clouds { get; set; } = new object();
        public object rain { get; set; } = new object();
        public object snow { get; set; } = new object();
        public object dt { get; set; } = new object();
        public object sys { get; set; } = new object();
        public object timezone { get; set; } = new object();
        public object id { get; set; } = new object();
        public object name { get; set; } = new object();
        public object cod { get; set; } = new object();
    }
}
